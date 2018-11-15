using netways_task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace netways_task.DAL
{
    public interface IUserProfileRepository: IDisposable
    {
        IEnumerable<UserProfile> GetUsersProfile();
        UserProfile GetUserProfileByID(string userId);
        void InsertUserProfile(UserProfile user);
        void DeleteUserProfile(string userID);
        void UpdateUserProfile(UserProfile user);
        void Save();
    }
}