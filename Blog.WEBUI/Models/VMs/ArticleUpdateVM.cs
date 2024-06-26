using System.ComponentModel.DataAnnotations;

namespace Blog.WEBUI.Models.VMs
{
    public class ArticleUpdateVM
    {
        public int ArticleId { get; set; }

        [Display(Name = "Başlık")]
        public string Title { get; set; }

        [Display(Name = "Makale")]
        [MinLength(200, ErrorMessage = "200 karakterdan kısa makaleler yazamazsınız.")]
        public string Content { get; set; }

        [Display(Name = "Okuma Süresi")]
        public int ReadingTime { get; set; }

        public int TopicId { get; set; }
    }
}
