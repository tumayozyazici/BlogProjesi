using Blog.SERVICE.Services.TopicServices;
using Blog.WEBUI.Models.VMs;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WEBUI.Controllers
{
    public class TopicController : Controller
    {
        private readonly ITopicSERVICE topicService;

        public TopicController(ITopicSERVICE topicService)
        {
            this.topicService = topicService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await topicService.GetAllAsync();
            TopicListVM topicListVM = new TopicListVM();
            topicListVM.Topics = result;
            return View(topicListVM);
        }
    }
}
