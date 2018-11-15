using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using netways_task.DAL;
using netways_task.Models;

namespace netways_task.Controllers
{
    public class UserProfilesController : ApiController
    {
        private IUserProfileRepository userRepository;

        public UserProfilesController()
        {
            this.userRepository = new UserProfileRepository(new NetwaysContext());
        }

        public UserProfilesController(IUserProfileRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        // GET: api/UserProfiles
        public IEnumerable<UserProfile> GetUserProfile()
        {
            return userRepository.GetUsersProfile();
        }

        // GET: api/UserProfiles/5
        [ResponseType(typeof(UserProfile))]
        public IHttpActionResult GetUserProfile(string loginName)
        {
            UserProfile userProfile = userRepository.GetUserProfileByID(loginName);
            if (userProfile == null)
            {
                return NotFound();
            }

            return Ok(userProfile);
        }

        // PUT: api/UserProfiles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserProfile(string LoginName, UserProfile userProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (LoginName != userProfile.LoginName)
            {
                return BadRequest();
            }

            userRepository.UpdateUserProfile(userProfile);
            userRepository.Save();

         

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/UserProfiles
        [ResponseType(typeof(UserProfile))]
        public IHttpActionResult PostUserProfile(UserProfile userProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            userRepository.InsertUserProfile(userProfile);
            userRepository.Save();
           
           
            return CreatedAtRoute("DefaultApi", new { id = userProfile.LoginName }, userProfile);
        }

        // DELETE: api/UserProfiles/5
        [ResponseType(typeof(UserProfile))]
        public IHttpActionResult DeleteUserProfile(string id)
        {
            UserProfile userProfile =userRepository.GetUserProfileByID(id);
            if (userProfile == null)
            {
                return NotFound();
            }

            userRepository.DeleteUserProfile(id);
            userRepository.Save();

            return Ok(userProfile);
        }

        protected override void Dispose(bool disposing)
        {
            userRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}