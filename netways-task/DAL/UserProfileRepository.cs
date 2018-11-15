using netways_task.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace netways_task.DAL
{
    public class UserProfileRepository: IUserProfileRepository, IDisposable
    {
        private NetwaysContext context;

        public UserProfileRepository(NetwaysContext context)
        {
            this.context = context;
        }

        public IEnumerable<UserProfile> GetUsersProfile()
        {
            return context.UserProfile.Include(c => c.Country).ToList();
        }

        public UserProfile GetUserProfileByID(string userId)
        {
            return context.UserProfile.Find(userId);
        }

        public void InsertUserProfile(UserProfile user)
        {
            context.UserProfile.Add(user);
        }

        public void DeleteUserProfile(string userID)
        {
            UserProfile user = context.UserProfile.Find(userID);
            context.UserProfile.Remove(user);
        }

        public void UpdateUserProfile(UserProfile user)
        {

            context.Entry(user).State = EntityState.Modified;
        }
        public void Save()
        {
            context.SaveChanges();

        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
