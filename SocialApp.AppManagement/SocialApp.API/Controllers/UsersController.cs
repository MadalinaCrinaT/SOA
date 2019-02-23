using SocialApp.Core.Services;
using SocialApp.Data;
using SocialApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;


namespace SocialApp.Core.Controllers
{
	[Produces("application/json")]
	[Route("app/users")]
	public class UsersController : Controller
	{
		private readonly IUsersServices _userServices;
		private readonly IGroupsServices _groupServices;

		public UsersController(GoingOutContext context)
		{
			_userServices = new UsersService(context);
			_groupServices = new GroupsService(context);
		}

		[HttpGet("{userId}/groups", Name = "GetGroups")]
		public IActionResult GetGroups(int userId)
		{
				List<Group> groups = _groupServices.GetGroups(userId);

				return Ok(groups);
		}
	}
}
