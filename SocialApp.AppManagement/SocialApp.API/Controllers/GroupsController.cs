using SocialApp.Core.Services;
using SocialApp.Data;
using SocialApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace SocialApp.Core.Controllers
{
    [Produces("application/json")]
    [Route("api/app/groups")]
    public class GroupsController : Controller
    {
        private readonly IGroupsServices _groupServices;
        public GroupsController(GoingOutContext context)
        {
            _groupServices = new GroupsService(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Group> groups = _groupServices.Get();

            return Ok(groups);
        }

        [HttpGet("{id:int}", Name = "GetGroupDetails")]
        public IActionResult GetGroupDetails(int id)
        {
            Group group = _groupServices.GetById(id);

            return Ok(group);
        }

        [HttpGet("{groupId}/members", Name = "GetGroupMembers")]
        public IActionResult GetGroupMembers(int groupId)
        {
            List<User> members = _groupServices.GetGroupMembers(groupId);

            return Ok(members);
        }

        [HttpGet("{groupId}/owner", Name = "GetGroupOwner")]
        public IActionResult GetGroupOwner(int groupId)
        {
            User owner = _groupServices.GetGroupOwner(groupId);

            return Ok(owner);
        }

        [HttpPost(Name = "AddGroup")]
        public IActionResult AddGroup(int userId, [FromBody]Group group)
        {
            if (ModelState.IsValid)
            {
                group = _groupServices.CreateGroup(userId, group);

                return Ok(group);
            }
            return BadRequest("Group is not well introduced");
        }

        [HttpPost("{groupId}/{userId}", Name = "JoinGroup")]
        public IActionResult JoinGroup(int groupId, int userId)
        {
            if (ModelState.IsValid)
            {
                _groupServices.Join(userId, groupId);

                return Ok();
            }
            return BadRequest("Group is not well introduced");
        }

        [HttpDelete(Name = "DeleteGroup")]
        public IActionResult DeleteGroup(int userId, int groupId)
        {
            Group group = _groupServices.DeleteGroup(userId, groupId);

            return Ok(group);
        }

        [HttpPut(Name = "UpdateGroupName")]
        public IActionResult UpdateGroupName(int groupId, [FromBody]Group group)
        {
            group = _groupServices.UpdateGroupName(groupId, group.GroupName);
            return Ok(group);
        }
    }
}
