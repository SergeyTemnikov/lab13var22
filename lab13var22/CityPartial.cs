using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13var22
{
    public partial class City
    {

        CountriesEntities db = new CountriesEntities();

        public string CitiesCountry 
        { get
            {
                return db.Country.Where(x => x.Id_Country == Id_Country).FirstOrDefault().CountryName;
            }
        }

        public string CitiesContinent
        {
            get
            {
                return db.Country.Where(x => x.Id_Country == Id_Country).FirstOrDefault().Continent;
            }
        }

    }
}
