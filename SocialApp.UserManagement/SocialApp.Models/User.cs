using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialApp.Models
{
	public class User
	{
		public int UserId { get; set; }
		[Required]
		[StringLength(30)]
		public string UserName { get; set; }

		public List<GroupUser> GroupUsers { get; set; }
	}
}