using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace PE2.LIB.Helper
{
    public class ADRef
    {
        public const string LDAPLong = "LDAP://127.0.0.1:389/";
        public const string LDAPShort = "LDAP://";
        public const string ADDomainEmail = "@aitjdd.local";
        public const string ADDomainNameShort = "aitjdd";
        public const string ADDomainNameLong = "aitjdd.local";

        public static bool DoesUserExits(string username)
        {
            PrincipalContext pc = new PrincipalContext(ContextType.Domain);
            UserPrincipal up = UserPrincipal.FindByIdentity(pc, IdentityType.SamAccountName, username);
            if (up == null)
                return false;
            else
                return true;

        }
    }
}
