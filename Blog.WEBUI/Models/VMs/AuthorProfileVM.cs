using Blog.DATA.Concrete;

namespace Blog.WEBUI.Models.VMs
{
    public class AuthorProfileVM
    {
        public string AuthorId { get; set; }
        public List<Article> Articles { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public DateTime AuthorCreatedDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? AboutMe { get; set; }

    }
}
