namespace Assessment.ViewModels
{
    public class SecurityOptions
    {
        public string SecretKey { get; set; }
        public string PasswordSalt { get; set; }
        public bool Enable2FactorAuthentication { get; set; }
		public string ViewAPP { get; set; }
		
	}
   
  }
