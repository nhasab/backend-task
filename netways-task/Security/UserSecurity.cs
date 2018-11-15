using netways_task.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace netways_task.Security
{
    public class UserSecurity
    {
        public static bool login(string loginName, string password)
        {
            using (NetwaysContext db = new NetwaysContext())
            {
                return db.Accounts.Any(user => user.LoginName.Equals(loginName,
                    StringComparison.OrdinalIgnoreCase) && user.Password == password);
            }
        }
    }
}