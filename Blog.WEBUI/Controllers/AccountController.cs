using Blog.DATA.Concrete;
using Blog.SERVICE.Services.ArticleServices;
using Blog.SERVICE.Services.AuthorTopicServices;
using Blog.SERVICE.Services.TopicServices;
using Blog.WEBUI.Models.VMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WEBUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<Author> _signInManager;
        private readonly UserManager<Author> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public static AuthorCreateVM _user;
        private readonly IArticleSERVICE _articleService;
        private readonly ITopicSERVICE _topicService;
        private readonly IAuthorTopicSERVICE _authorTopicService;

        public AccountController(SignInManager<Author> signInManager, UserManager<Author> userManager, IWebHostEnvironment webHostEnvironment, IArticleSERVICE articleService, ITopicSERVICE topicService, IAuthorTopicSERVICE authorTopicService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
            _articleService = articleService;
            _topicService = topicService;
            _authorTopicService = authorTopicService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AuthorCreateVM vm)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(vm.Email);
                if (user == null)
                {
                    Random rnd = new Random();
                    int confirmationCode = rnd.Next(10000, 99999);

                    HelperClass.Helper.SendMail(user, vm, confirmationCode);

                    _user = vm;
                    TempData["confirmationCode"] = confirmationCode;
                    return RedirectToAction("Confirmation", "Account");
                }
                else
                {
                    ViewBag.rejection = "Bu E-mail'de bir kullanıcı mevcut.";
                    return View(vm);
                }
            }
            return View(vm);
        }

        [HttpGet]
        public IActionResult Confirmation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Confirmation(ConfirmationCodeVM vm)
        {
            if (vm.ConfirmationCode == TempData["confirmationCode"].ToString())
            {
                var user = new Author() { UserName = _user.UserName, Email = _user.Email };
                var result = await _userManager.CreateAsync(user, _user.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Code + " - " + item.Description);
                }
                return View();
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthorLoginVM vm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(vm.UserName, vm.Password, vm.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Giriş Başarısız");
            }
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Settings()
        {
            var topics = await _topicService.GetAllAsync();
            var result = await _userManager.GetUserAsync(User);
            var selectedTopics = _authorTopicService.GetByAuthorId(result.Id);
            AuthorSettingsVM vm = new AuthorSettingsVM()
            {
                FirstName = result.FirstName,
                LastName = result.LastName,
                Photo = result.Photo,
                Email = result.Email,
                UserName = result.UserName,
                Topics = topics,
                AuthorTopics = (List<AuthorTopic>)selectedTopics
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Settings(AuthorSettingsVM vm, IFormFile file, List<int> selectedIds)
        {
            var result = await _userManager.GetUserAsync(User);

            List<AuthorTopic> authorTopics = new List<AuthorTopic>();
            foreach (var item in selectedIds)
            {
                AuthorTopic authorTopic = new AuthorTopic() { AuthorId = result.Id, TopicId = item };
                authorTopics.Add(authorTopic);
            }

            if (_authorTopicService.GetByAuthorId(result.Id).Count() > 0)
            {
                var gotToDelete = _authorTopicService.GetByAuthorId(result.Id);
                _authorTopicService.Delete(gotToDelete);
            }

            _authorTopicService.Create(authorTopics);

            if (result is not null)
            {
                result.FirstName = vm.FirstName;
                result.LastName = vm.LastName;
                result.Email = vm.Email;
                result.UserName = vm.UserName;
                result.AboutMe = vm.AboutMe;

                if (file is not null)
                {
                    result.Photo = HelperClass.Helper.AddPhoto(file, _webHostEnvironment);
                }
            }

            await _userManager.UpdateAsync(result);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            var articles = (await _articleService.GetWhereAsync(x => x.AuthorId == user.Id)).OrderByDescending(x => x.CreateDate).ToList();
            AuthorProfileVM vm = new AuthorProfileVM()
            {
                AuthorId = user.Id,
                Articles = articles,
                AuthorCreatedDate = user.CreateDate,
                Email = user.Email,
                Photo = user.Photo,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                AboutMe = user.AboutMe,
            };
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> AuthorProfile(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var articles = (await _articleService.GetWhereAsync(x => x.AuthorId == user.Id)).OrderByDescending(x => x.CreateDate).ToList();
            AuthorProfileVM vm = new AuthorProfileVM()
            {
                AuthorId = user.Id,
                Articles = articles,
                AuthorCreatedDate = user.CreateDate,
                Email = user.Email,
                Photo = user.Photo,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                AboutMe = user.AboutMe
            };
            return View(vm);
        }
    }
}
