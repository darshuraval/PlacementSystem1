using System;

namespace PlacementSystem.Models
{
	public class Admin : User
	{
		public string RoleType { get; set; } = "Admin";
	}
}
