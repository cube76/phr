namespace phr.Models
{
	public class Login
	{
		public int expiresIn { get; set; }
		public string userName { get; set; }
		public string jwtToken { get; set; }
		public List<string> role { get; set; }
	}
}
