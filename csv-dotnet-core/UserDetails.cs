using System.Collections.Generic;

namespace csv_dotnet_core
{
    public class UserDetails
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

    class Root
    {
        public IEnumerable<UserDetails> UserDetails { get; set; }
    }
}