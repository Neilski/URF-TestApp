using Repository.Pattern.Ef6;


namespace UrfTestApp.Models
{
    public class User : Entity
    {
        public int UserId { get; set; }
        public string Email { get; set; }

        public virtual UserDetails Details { get; set; }
    }
}