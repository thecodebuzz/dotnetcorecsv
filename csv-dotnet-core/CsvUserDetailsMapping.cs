using TinyCsvParser.Mapping;

namespace csv_dotnet_core
{
    partial class Program
    {
        private class CsvUserDetailsMapping : CsvMapping<UserDetails>
        {
            public CsvUserDetailsMapping()
                : base()
            {
                MapProperty(0, x => x.ID);
                MapProperty(1, x => x.Name);
                MapProperty(2, x => x.City);
                MapProperty(3, x => x.Country);
            }
        }
    }
}
