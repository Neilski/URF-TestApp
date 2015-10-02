using Repository.Pattern.Ef6;


namespace UrfTestApp.Models
{
    public class UserDetails : Entity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}