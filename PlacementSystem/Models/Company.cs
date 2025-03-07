using System;

namespace PlacementSystem.Models
{
	public class Company : User
	{
		public string CompanyName { get; set; } = string.Empty;
		public string CompanyAddress { get; set; } = string.Empty;
		public string? CompanyProfile { get; set; }
		public string? PersonName { get; set; }
		public string? PersonMobileNumber { get; set; }
		public string? PersonEmail { get; set; }
	}
}
