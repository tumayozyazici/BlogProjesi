namespace Blog.WEBUI.Models.VMs
{
    public class ArticleCreateVM
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public int ReadingTime {  get; set; }

        public int TopicId { get; set; }
    }
}
