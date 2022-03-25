using Microsoft.AspNet.Identity.EntityFramework;

namespace NetFlex.DAL.EF
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }

        public ApplicationRole(string name)
            : base(name)
        { }
    }
}
