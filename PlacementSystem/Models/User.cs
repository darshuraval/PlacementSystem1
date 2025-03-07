using System;

namespace PlacementSystem.Models
{
	public class User
	{
		public int Id { get; set; }
		public string FullName { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public bool IsEmailVerified { get; set; } = false;
		public string PhoneNumber { get; set; } = string.Empty;
		public bool IsPhoneNumberVerified { get; set; } = false;
		public string PasswordHash { get; set; } = string.Empty;
		public string Role { get; set; } = "Guest";
		public DateTime? DateOfBirth { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		public DateTime UpdatedAt { get; set; } = DateTime.Now;
	}
}
