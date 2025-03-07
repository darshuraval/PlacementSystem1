using System;

namespace PlacementSystem.Models
{
	public class JobApplication
	{
		public int Id { get; set; }
		public int JobId { get; set; }
		public Job Job { get; set; }
		public int StudentId { get; set; }
		public Student Student { get; set; }
		public DateTime AppliedAt { get; set; } = DateTime.Now;
		public string Status { get; set; } = "Pending";
	}
}
