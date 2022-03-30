using Microsoft.AspNetCore.Identity;

namespace NetFlex.WEB.ViewModels
{
    public class ChangeRoleViewModel
    {
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public List<RoleViewModel> AllRoles { get; set; }
        public IList<string> UserRoles { get; set; }
        public ChangeRoleViewModel()
        {
            AllRoles = new List<RoleViewModel>();
            UserRoles = new List<string>();
        }
    }
}
