using System;
using System.ComponentModel.DataAnnotations;

namespace SocialApp.Models
{
	public class GroupUser
	{
		[Range(0, Int32.MaxValue)]
		public int GroupId { get; set; }
		[Range(0, Int32.MaxValue)]
		public int UserId { get; set; }
		[Range(0, Int32.MaxValue)]
		public int RoleId { get; set; }

		public Group Group { get; set; }
		public User User { get; set; }
		public GroupRole Role { get; set; }
	}
}
