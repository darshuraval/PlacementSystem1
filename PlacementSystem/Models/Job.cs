using System;

namespace PlacementSystem.Models
{
	public class Job
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string SkillsRequired { get; set; } = string.Empty;
		public double Salary { get; set; }
		public string Location { get; set; } = string.Empty;
		public DateTime PostedAt { get; set; } = DateTime.Now;
		public int CompanyId { get; set; }
		public Company Company { get; set; }
	}
}
