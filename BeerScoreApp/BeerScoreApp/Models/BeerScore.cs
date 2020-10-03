using SQLite;

namespace BeerScoreApp.Models
{
	public class BeerScore
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Name { get; set; }
		public string Notes { get; set; }
		public int Score { get; set; }
	}
}