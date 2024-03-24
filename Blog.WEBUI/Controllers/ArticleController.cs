﻿using Blog.DATA.Concrete;
using Blog.SERVICE.Services.ArticleServices;
using Blog.SERVICE.Services.TopicServices;
using Blog.WEBUI.Models.VMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blog.WEBUI.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleSERVICE articleSERVICE;
        private readonly ITopicSERVICE topicService;
        private readonly UserManager<Author> userManager;

        public ArticleController(IArticleSERVICE articleSERVICE, ITopicSERVICE topicService, UserManager<Author> userManager)
        {
            this.articleSERVICE = articleSERVICE;
            this.topicService = topicService;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult List()
        {
            var result = articleSERVICE.GetArticleJoinedList();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> CreateArticle()
        {
            List<Topic> topics = await topicService.GetAllAsync();
            ViewBag.Topics = new SelectList(topics, "TopicId", "TopicName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(ArticleCreateVM vm)
        {
            var user = await userManager.GetUserAsync(User);
            Article article = new Article() { Title = vm.Title, Content = vm.Content, ReadingTime = vm.ReadingTime, AuthorId = user.Id, TopicId = vm.TopicId };
            articleSERVICE.Add(article);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> ReadArticle(int id)
        {
            var result = articleSERVICE.GetArticleJoined(id);
            var article = await articleSERVICE.GetByIdAsync(id);
            result.ArticleCount = articleSERVICE.GetArticleCountByAuthorId(article.AuthorId);

            return View(result);
        }

        [HttpGet]
        public IActionResult ListByTopics(int id)
        {
            var result = articleSERVICE.GetArticleJoinedByTopicId(id);

            return View(result);
        }
    }
}
