using netways_task.DAL;
using netways_task.Models;
using netways_task.Security;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace netways_task.Controllers
{
    public class AuthController : ApiController
    {
        [Route("api/login")]
        [ResponseType(typeof(Account))]
        public IHttpActionResult login(string loginName, string password)
        {
            if (UserSecurity.login(loginName, password))
            {
                using (NetwaysContext db = new NetwaysContext())
                {
                    Account account = db.Accounts.Where(user => user.LoginName.Equals(loginName,
                        StringComparison.OrdinalIgnoreCase) && user.Password == password).FirstOrDefault();

                    return Ok(account);
                }
            }
            else
            {

                return NotFound();

            }
        }
    }

}