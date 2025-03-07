using System;

namespace PlacementSystem.Models
{
	public class PlacementReport
	{
		public int Id { get; set; }
		public int StudentId { get; set; }
		public Student Student { get; set; }
		public int JobId { get; set; }
		public Job Job { get; set; }
		public string Status { get; set; } = "Placed";
		public DateTime ReportDate { get; set; } = DateTime.Now;
	}
}
