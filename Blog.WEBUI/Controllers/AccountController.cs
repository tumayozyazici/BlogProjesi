using Blog.DATA.Concrete;
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

        public AccountController(SignInManager<Author> signInManager, UserManager<Author> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
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
            var result = await _userManager.GetUserAsync(User);
            AuthorSettingsVM vm = new AuthorSettingsVM()
            {
                FirstName = result.FirstName,
                LastName = result.LastName,
                Photo = result.Photo,
                Email = result.Email,
                UserName = result.UserName,
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Settings(AuthorSettingsVM vm, IFormFile file)
        {
            var result = await _userManager.GetUserAsync(User);
            if (result is not null)
            {
                result.FirstName = vm.FirstName;
                result.LastName = vm.LastName;
                result.Photo = HelperClass.Helper.AddPhoto(file, _webHostEnvironment);
                result.Email = vm.Email;
                result.UserName = vm.UserName;
            }
            await _userManager.UpdateAsync(result);
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult Profile() 
        { 

            return View();
        }

        [HttpGet]
        public IActionResult AuthorProfile()
        {
            return View();
        }

    }
}
