using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFlex.DAL.Constants
{
    public class Constants
    {
        public static class Roles
        {
            public const string Administrator = "Administrator";
            public const string Manager = "Manager";
            public const string User = "User";
        }

        public static class Policies
        {
            public const string RequireAdmin = "RequireAdmin";
            public const string RequireManager = "RequireManager";
        }
    }
}
