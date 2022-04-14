namespace MobileWorld.Core.Models
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Roles= new List<string>();
        }
        public string Id { get; set; }

        public string UserName { get; set; }

        public List<string> Roles { get; set; } 
    }
}
