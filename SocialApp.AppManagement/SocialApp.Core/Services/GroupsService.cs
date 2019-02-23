using SocialApp.Data;
using SocialApp.Data.DAL;
using SocialApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using SocialApp.Models.Exceptions;
using Microsoft.AspNetCore.Http;

namespace SocialApp.Core.Services
{
    public class GroupsService : IGroupsServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public GroupsService(GoingOutContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        public List<Group> Get()
        {
            List<Group> groups = _unitOfWork.GroupRepository
                .Get()
                .ToList();

            return groups;
        }

        public Group GetById(int groupId)
        {
            Group group = _unitOfWork.GroupRepository
                .GetByID(groupId);
            if (group != null) MakeGroupFieldNullToAvoidInfiniteReference(group);

            return group;
        }

        public List<User> GetGroupMembers(int groupId)
        {
            Group group = _unitOfWork.GroupRepository
                .Get(filter: g => g.GroupId == groupId, includeProperties: "GroupUsers")
                .FirstOrDefault();
            if (group == null) throw new HttpStatusCodeException(StatusCodes.Status404NotFound, @"Group not found");
            List<GroupUser> groupMembers = group
                .GroupUsers
                .ToList();
            List<User> members = new List<User>();
            foreach (GroupUser groupMember in groupMembers)
            {
                members.Add(_unitOfWork.GroupUserRepository
                    .Get(filter: gu => gu.UserId == groupMember.UserId && gu.GroupId == groupMember.GroupId, includeProperties: "User")
                    .FirstOrDefault()
                    .User);
            }
            members.ForEach(u => MakeUserFieldNullToAvoidInfiniteReference(u));

            return members;
        }
        public User GetGroupOwner(int groupId)
        {
            Group group = _unitOfWork.GroupRepository
                .Get(filter: g => g.GroupId == groupId, includeProperties: "GroupUsers")
                .FirstOrDefault();
            if (group == null) throw new HttpStatusCodeException(StatusCodes.Status404NotFound, @"Group not found");
            GroupUser groupOwner = group
                .GroupUsers
                .Where(gu => gu.RoleId == 1)
                .FirstOrDefault();
            User owner = _unitOfWork.UserRepository.GetByID(groupOwner.UserId);

            MakeUserFieldNullToAvoidInfiniteReference(owner);

            return owner;
        }

        public Group CreateGroup(int userId, Group group)
        {
            _unitOfWork.GroupRepository.Insert(group);
            _unitOfWork.GroupRepository.Save();
            GroupUser groupUserToBeInserted = new GroupUser { GroupId = group.GroupId, UserId = userId, RoleId = 1 };
            _unitOfWork.GroupUserRepository.Insert(groupUserToBeInserted);
            _unitOfWork.GroupUserRepository.Save();
            MakeGroupFieldNullToAvoidInfiniteReference(group);

            return group;
        }

        public Group DeleteGroup(int userId, int groupId)
        {
            Group group = _unitOfWork.GroupRepository
                .Get(filter: g => g.GroupId == groupId, includeProperties: "Plans").FirstOrDefault();
            GroupUser groupUser = _unitOfWork.GroupUserRepository
                .Get(filter: gu => gu.GroupId == groupId && gu.UserId == userId)
                .FirstOrDefault();
            if (groupUser == null) throw new HttpStatusCodeException(StatusCodes.Status404NotFound, @"Group not found");
            int roleId = groupUser.RoleId;
            _unitOfWork.GroupUserRepository.Delete(groupUser);
            _unitOfWork.GroupUserRepository.Save();
            List<User> members = GetGroupMembers(group.GroupId);
            if (members.Count() == 0)
            {
                _unitOfWork.GroupRepository.Delete(group);
                _unitOfWork.GroupRepository.Save();
            }
            else if(roleId==1)
            {
                List<GroupUser> groupMembers = _unitOfWork.GroupUserRepository
                .Get(filter: gu => gu.GroupId == groupId).ToList();
                GroupUser newOwner = groupMembers[0];
                newOwner.RoleId = 1;
                foreach ( GroupUser gu in groupMembers)
                {
                    _unitOfWork.GroupUserRepository.Update(gu);
                }
                _unitOfWork.GroupUserRepository.Save(); ;
            }
            MakeGroupFieldNullToAvoidInfiniteReference(group);

            return group;
        }

        public Group UpdateGroupName(int groupId, string groupName)
        {
            Group group = _unitOfWork.GroupRepository
                .Get(filter: g => g.GroupId == groupId)
                .FirstOrDefault();
            if (group == null) throw new HttpStatusCodeException(StatusCodes.Status404NotFound, @"Group not found");
            group.GroupName = groupName;
            _unitOfWork.GroupRepository.Update(group);
            _unitOfWork.GroupRepository.Save();

            return group;
        }

        public List<Group> GetGroups(int userId)
        {
            User user = _unitOfWork.UserRepository
                .Get(filter: u => u.UserId == userId, includeProperties: "GroupUsers")
                .FirstOrDefault();
            if (user == null) throw new HttpStatusCodeException(StatusCodes.Status404NotFound, @"User not found");
            else
            {
                List<Group> groups = new List<Group>();
                foreach (GroupUser groupUser in user.GroupUsers)
                {
                    groups.Add(_unitOfWork.GroupUserRepository
                        .Get(filter: gu => gu.UserId == groupUser.UserId && gu.GroupId == groupUser.GroupId, includeProperties: "Group")
                        .FirstOrDefault()
                        .Group);
                }
                groups.ForEach(x => MakeGroupFieldNullToAvoidInfiniteReference(x));

                return groups;
            }
        }

        private void MakeGroupFieldNullToAvoidInfiniteReference(Group x)
        {
            x.GroupUsers = null;
        }

        private void MakeUserFieldNullToAvoidInfiniteReference(User u)
        {
            u.GroupUsers = null;
        }
       
        public void Join(int userId, int groupId)
        {
            _unitOfWork.GroupUserRepository.Insert(new GroupUser { GroupId = groupId, RoleId = 3, UserId = userId });
            _unitOfWork.GroupUserRepository.Save();
        }
    }
}
