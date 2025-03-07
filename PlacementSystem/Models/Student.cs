using System;

namespace PlacementSystem.Models
{
	public class Student : User
	{
		public string Resume { get; set; } = string.Empty;
		public string SSC { get; set; } = string.Empty;
		public string HSC { get; set; } = string.Empty;
		public string Diploma { get; set; } = string.Empty;
		public string Degree { get; set; } = string.Empty;
		public double CGPA { get; set; }
	}
}
