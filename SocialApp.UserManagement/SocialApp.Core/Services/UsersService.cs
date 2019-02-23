using SocialApp.Data;
using SocialApp.Data.DAL;
using SocialApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SocialApp.Models.Exceptions;
using Microsoft.AspNetCore.Http;

namespace SocialApp.Core.Services
{
    public class UsersService : IUsersServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsersService(GoingOutContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        public User GetById(int id)
        {
            User user = _unitOfWork.UserRepository.GetByID(id);
            if (user == null) throw new HttpStatusCodeException(StatusCodes.Status404NotFound, @"User not found");

            return user;
        }

        public User Get(string userName)
        {
            User user = _unitOfWork.UserRepository
                .Get(filter: u => u.UserName.Equals(userName, StringComparison.InvariantCulture))
                .FirstOrDefault();
            if (user == null) throw new HttpStatusCodeException(StatusCodes.Status404NotFound, @"User not found");

            return user;
        }

        public User CreateUser(User user)
        {
            List<User> users = _unitOfWork.UserRepository
                .Get(filter: u => u.UserName.Equals(user.UserName))
                .ToList();
            if (users.Count != 0) throw new HttpStatusCodeException(StatusCodes.Status400BadRequest, @"User cannot be duplicated");
            _unitOfWork.UserRepository.Insert(user);
            _unitOfWork.UserRepository.Save();

            return user;
        }

        public User DeleteUser(int userId)
        {
            User user = _unitOfWork.UserRepository
                .Get(filter: u => u.UserId == userId)
                .FirstOrDefault();
            if (user == null) throw new HttpStatusCodeException(StatusCodes.Status404NotFound, @"User not found");
            DeleteUserGroups(user);
            _unitOfWork.UserRepository.Delete(user);
            _unitOfWork.UserRepository.Save();

            return user;
        }

        private void DeleteUserGroups(User user)
        {
            List<GroupUser> userGroups = _unitOfWork.GroupUserRepository
               .Get(filter: gu => gu.UserId == user.UserId)
               .ToList();
            foreach (GroupUser groupUser in userGroups)
            {
                if (groupUser.RoleId == 1)
                {
                    List<GroupUser> groupUsers = _unitOfWork.GroupUserRepository
                        .Get(filter: gu => gu.GroupId == groupUser.GroupId && gu.UserId != user.UserId)
                        .ToList();

                    if (groupUsers.Count != 0)
                    {
                        groupUsers.FirstOrDefault().RoleId = 1;
                    }
                    else
                    {
                        DeleteGroup(groupUser);
                    }
                }
            }
            _unitOfWork.GroupRepository.Save();
        }

        private void DeleteGroup(GroupUser groupUser)
        {
            Group group = _unitOfWork.GroupRepository
                .Get(filter: g => g.GroupId == groupUser.GroupId)
                .FirstOrDefault();
            _unitOfWork.GroupRepository.Delete(group);
        }
    }
}
