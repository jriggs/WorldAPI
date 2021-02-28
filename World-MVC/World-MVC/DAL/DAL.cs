using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace World_MVC
{
    public class DAL : IDAL
    {

        private readonly string connectionString;
        public DAL(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public IList<City> GetCities()
        {
            List<City> cities = new List<City>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM city;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        City city = ConvertReaderToCity(reader);
                        cities.Add(city);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred reading cities by country.");
                Console.WriteLine(ex.Message);
                throw;
            }

            return cities;
        }

        private City ConvertReaderToCity(SqlDataReader reader)
        {
            City city = new City();
            city.CityId = Convert.ToInt32(reader["id"]);
            city.Name = Convert.ToString(reader["name"]);
            city.CountryCode = Convert.ToString(reader["countrycode"]);
            city.District = Convert.ToString(reader["district"]);
            city.Population = Convert.ToInt32(reader["population"]);

            return city;
        }

        public IList<Country> GetCountries()
        {
            List<Country> countries = new List<Country>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Create a command to send to the database
                    SqlCommand cmd = new SqlCommand("SELECT * FROM country;", conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Read each row
                    while (reader.Read())
                    {
                        Country ctry = ConvertReaderToCountry(reader);
                        countries.Add(ctry);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred communicating with the database. ");
                Console.WriteLine(ex.Message);
                throw;
            }

            // Return the output
            return countries;
        }

        private Country ConvertReaderToCountry(SqlDataReader reader)
        {
            Country ctry = new Country();

            ctry.Code = Convert.ToString(reader["code"]);
            ctry.Name = Convert.ToString(reader["name"]);
            ctry.Continent = Convert.ToString(reader["continent"]);
            ctry.Region = Convert.ToString(reader["region"]);
            ctry.SurfaceArea = Convert.ToDouble(reader["surfacearea"]);
            ctry.Population = Convert.ToInt32(reader["population"]);
            ctry.GovernmentForm = Convert.ToString(reader["governmentform"]);

            return ctry;
        }

        public IList<Language> GetLanguages()
        {
            List<Language> languages = new List<Language>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM countrylanguage", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Language language = new Language();
                        language.CountryCode = Convert.ToString(reader["countrycode"]);
                        language.Name = Convert.ToString(reader["language"]);
                        language.IsOfficial = Convert.ToBoolean(reader["isofficial"]);
                        language.Percentage = Convert.ToInt32(reader["percentage"]);

                        languages.Add(language);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error retrieving languages.");
                throw;
            }

            return languages;
        }

    }
}
