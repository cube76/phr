namespace phr.Models
{
	public class ExceptionDetails
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public int RoleId { get; set; }
		public string ExceptCode { get; set; }
		public string ExceptName { get; set; }
		public string ExceptDesc { get; set; }
		public string ExceptKind { get; set; }
		public string ExceptType { get; set; }
		public int Priority { get; set; }
		public int TotalException { get; set; }
	}

}
