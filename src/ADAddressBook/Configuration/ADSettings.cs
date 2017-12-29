namespace ADAddressBook
{
    public class ADSettings
    {
        public string host { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public int port { get; set; }

        public bool ssl { get; set; }

        public string SearchBase { get; set; }
    }
}