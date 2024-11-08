

using DataLayer;

namespace Api.Model
{
    public class Country
    {
        public int ID { set; get; }
        public string CountryName { set; get; }

        public Country()

        {
            this.ID = -1;
            this.CountryName = "";

        }

        private Country(int ID, string CountryName)

        {
            this.ID = ID;
            this.CountryName = CountryName;
        }

        public static Country Find(int ID)
        {

            string CountryName = "";

            if (TestCountry.GetCountryByID(ID, ref CountryName))

                return new Country(ID, CountryName);
            else
                return null;

        }
    }
}
