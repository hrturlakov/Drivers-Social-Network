namespace CarsAndDrivers.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using CarsAndDrivers.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "CarsAndDrivers.Data.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            SeedCars(context);
            SeedCountries(context);
        }

        private static void SeedCars(ApplicationDbContext context)
        {
            if (context.CarManufacturers.Count() != 0)
            {
                return;
            }

            IEnumerable<CarManufacturer> carsCollection = new List<CarManufacturer>()
            {
                new CarManufacturer()
                {
                    Name = "Audi",
                    CarModels = new List<CarModel>()
                    {
                        new CarModel(){ Name = "A3"},
                        new CarModel(){ Name = "A4"},
                        new CarModel(){ Name = "A5"},
                        new CarModel(){ Name = "A6"},
                        new CarModel(){ Name = "A7"}
                    }
                },
                new CarManufacturer()
                {
                    Name = "BMW",
                    CarModels = new List<CarModel>()
                    {
                        new CarModel(){ Name = "318"},
                        new CarModel(){ Name = "320"},
                        new CarModel(){ Name = "330"},
                        new CarModel(){ Name = "520"},
                        new CarModel(){ Name = "530"}
                    }
                },
                new CarManufacturer()
                {
                    Name = "Lada",
                    CarModels = new List<CarModel>()
                    {
                        new CarModel(){ Name = "1200"},
                        new CarModel(){ Name = "1300"},
                        new CarModel(){ Name = "1500"},
                        new CarModel(){ Name = "2105"},
                        new CarModel(){ Name = "2107"},
                        new CarModel(){ Name = "Samara"}
                    }
                },
                new CarManufacturer()
                {
                    Name = "Opel",
                    CarModels = new List<CarModel>()
                    {
                        new CarModel(){ Name = "Astra"},
                        new CarModel(){ Name = "Calibra"},
                        new CarModel(){ Name = "Corsa"},
                        new CarModel(){ Name = "Insidnia"},
                        new CarModel(){ Name = "Zafira"}
                    }
                },
                new CarManufacturer()
                {
                    Name = "VW",
                    CarModels = new List<CarModel>()
                    {
                        new CarModel(){ Name = "Golf"},
                        new CarModel(){ Name = "Jetta"},
                        new CarModel(){ Name = "Eos"},
                        new CarModel(){ Name = "Passat"},
                        new CarModel(){ Name = "Phaeton"}
                    }
                },
            };

            context.CarManufacturers.AddOrUpdate(carsCollection.ToArray());
        }

        private static void SeedCountries(ApplicationDbContext context)
        {
            if (context.Countries.Count() != 0)
            {
                return;
            }

            IEnumerable<Country> countriesCollection = new List<Country>(){
                        new Country(){ Name = "Argentina"}, 
                        new Country(){ Name = "Australia"}, 
                        new Country(){ Name = "Austria"}, 
                        new Country(){ Name = "Bahamas"}, 
                        new Country(){ Name = "Belgium"}, 
                        new Country(){ Name = "Belize"}, 
                        new Country(){ Name = "Bolivia"}, 
                        new Country(){ Name = "Brazil"}, 
                        new Country(){ Name = "Bulgaria"}, 
                        new Country(){ Name = "Canada"}, 
                        new Country(){ Name = "Cayman Islands"}, 
                        new Country(){ Name = "Chile"}, 
                        new Country(){ Name = "Colombia"}, 
                        new Country(){ Name = "Costa Rica"}, 
                        new Country(){ Name = "Croatia"}, 
                        new Country(){ Name = "Cyprus"}, 
                        new Country(){ Name = "Czech Republic"}, 
                        new Country(){ Name = "Denmark"}, 
                        new Country(){ Name = "Dominican Republic"}, 
                        new Country(){ Name = "Ecuador"}, 
                        new Country(){ Name = "Egypt"}, 
                        new Country(){ Name = "El Salvador"}, 
                        new Country(){ Name = "Estonia"}, 
                        new Country(){ Name = "Finland"}, 
                        new Country(){ Name = "France"}, 
                        new Country(){ Name = "Germany"}, 
                        new Country(){ Name = "Ghana"}, 
                        new Country(){ Name = "Greece"}, 
                        new Country(){ Name = "Guatemala"}, 
                        new Country(){ Name = "Guyana"}, 
                        new Country(){ Name = "Haiti"}, 
                        new Country(){ Name = "Honduras"}, 
                        new Country(){ Name = "Hong Kong"}, 
                        new Country(){ Name = "Hungary"}, 
                        new Country(){ Name = "Iceland"}, 
                        new Country(){ Name = "India"}, 
                        new Country(){ Name = "Indonesia"}, 
                        new Country(){ Name = "Ireland"}, 
                        new Country(){ Name = "Israel"}, 
                        new Country(){ Name = "Italy"}, 
                        new Country(){ Name = "Jamaica"}, 
                        new Country(){ Name = "Japan"}, 
                        new Country(){ Name = "Jordan"}, 
                        new Country(){ Name = "Kenya"}, 
                        new Country(){ Name = "Kuwait"}, 
                        new Country(){ Name = "Latvia"}, 
                        new Country(){ Name = "Lebanon"}, 
                        new Country(){ Name = "Lithuania"}, 
                        new Country(){ Name = "Luxembourg"}, 
                        new Country(){ Name = "Malaysia"}, 
                        new Country(){ Name = "Maldives"}, 
                        new Country(){ Name = "Malta"}, 
                        new Country(){ Name = "Mexico"}, 
                        new Country(){ Name = "Morocco"}, 
                        new Country(){ Name = "Netherlands"}, 
                        new Country(){ Name = "New Zealand"}, 
                        new Country(){ Name = "Nicaragua"}, 
                        new Country(){ Name = "Nigeria"}, 
                        new Country(){ Name = "Norway"}, 
                        new Country(){ Name = "Pakistan"}, 
                        new Country(){ Name = "Panama"}, 
                        new Country(){ Name = "Paraguay"}, 
                        new Country(){ Name = "Peru"}, 
                        new Country(){ Name = "Philippines"}, 
                        new Country(){ Name = "Poland"}, 
                        new Country(){ Name = "Portugal"}, 
                        new Country(){ Name = "Qatar"}, 
                        new Country(){ Name = "Romania"}, 
                        new Country(){ Name = "Russia"}, 
                        new Country(){ Name = "Saudi Arabia"}, 
                        new Country(){ Name = "Singapore"}, 
                        new Country(){ Name = "Slovakia"}, 
                        new Country(){ Name = "Slovenia"}, 
                        new Country(){ Name = "South Africa"}, 
                        new Country(){ Name = "South Korea"}, 
                        new Country(){ Name = "Spain"}, 
                        new Country(){ Name = "Suriname"}, 
                        new Country(){ Name = "Sweden"}, 
                        new Country(){ Name = "Switzerland"}, 
                        new Country(){ Name = "Taiwan"}, 
                        new Country(){ Name = "Tanzania"}, 
                        new Country(){ Name = "Thailand"}, 
                        new Country(){ Name = "Trinidad and Tobago"}, 
                        new Country(){ Name = "Turkey"}, 
                        new Country(){ Name = "Uganda"}, 
                        new Country(){ Name = "Ukraine"}, 
                        new Country(){ Name = "United Arab Emirates"}, 
                        new Country(){ Name = "United Kingdom"}, 
                        new Country(){ Name = "United States"}, 
                        new Country(){ Name = "Uruguay"}, 
                        new Country(){ Name = "Venezuela"}, 
                        new Country(){ Name = "Vietnam"}, 
                        new Country(){ Name = "Zambia"}, 
            };

            context.Countries.AddOrUpdate(countriesCollection.ToArray());
        }
    }
}
