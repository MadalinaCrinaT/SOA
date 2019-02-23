using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialApp.Models
{
	public class Group
	{
		public int GroupId { get; set; }
		[Required]
		[StringLength(25)]
		public string GroupName { get; set; }

		public List<GroupUser> GroupUsers { get; set; }
	}
}
