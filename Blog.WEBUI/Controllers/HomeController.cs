using Blog.DATA.Concrete;
using Blog.REPO.DTO;
using Blog.SERVICE.Services.ArticleServices;
using Blog.SERVICE.Services.AuthorTopicServices;
using Blog.WEBUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blog.WEBUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleSERVICE _articleService;
        private readonly IAuthorTopicSERVICE _authorTopicService;
        private readonly UserManager<Author> _userManager;

        public HomeController(ILogger<HomeController> logger, IArticleSERVICE articleService, IAuthorTopicSERVICE authorTopicService, UserManager<Author> userManager)
        {
            _logger = logger;
            _articleService = articleService;
            _authorTopicService = authorTopicService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            List<ArticleListDTO> list = new List<ArticleListDTO>();
            if (user is not null)
            {
                var ids = _authorTopicService.GetByAuthorId(user.Id).Select(x => x.TopicId).ToList();
                list = _articleService.GetArticleJoinedByInterest(ids);
            }

            return View(list);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
