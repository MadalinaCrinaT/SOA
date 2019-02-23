using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialApp.Models
{
	public class GroupRole
	{
		public int RoleId { get; set; }
		[Required]
		[StringLength(20)]
		public string RoleName { get; set; }

		public List<GroupUser> GroupUsers { get; set; }
	}
}
