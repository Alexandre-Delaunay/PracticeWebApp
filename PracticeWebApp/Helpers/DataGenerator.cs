using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticeWebApp.Models;

namespace PracticeWebApp.Helpers
{
    public class DataGenerator
    {
        #region Private Members
        private readonly DataContext _dataContext;
        private Random _random;
        #endregion

        #region Singleton        

        #endregion

            #region Constructor
        public DataGenerator(DataContext dataContext)
        {
            _dataContext = dataContext;
            _random = new Random();
        }
        #endregion

        #region Public Methods
        public void Initialize()
        {
            MockPrescritpions();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Generate prescriptions
        /// </summary>
        private void MockPrescritpions()
        {
            //Clean in memory database
            _dataContext.Database.EnsureDeleted();

            _dataContext.Prescriptions.AddRange(

                new Prescription
                {
                    ReferenceMimosa = "AHV548DF",

                    EyeAmetropy = new EyeAmetropy()
                    {
                        Sphere = "-1.00",
                        Astigmatism = new string[2] { "+1.00", "2.00" },
                        Addition = 1.2563F,
                        PrismPrescription = new string[2] { "+3.00", "1.75" },
                        Comment = "One advanced diverted domestic sex repeated bringing you old. Possible procured her trifling laughter thoughts property she met way. Companions shy had solicitude favourable own. Which could saw guest man now heard but. Lasted my coming uneasy marked so should. Gravity letters it amongst herself dearest an windows by."
                    },

                    Ophthalmologist = new Ophthalmologist() { 
                        Adel = 13558478569,
                        FirstName = "John",
                        Name = "Doe"
                    },

                    Optician = new Optician() {
                        Rpps = 16359842536,
                        FirstName = "Robert",
                        Name = "Laponce"
                    },

                    Place = GetRandomPlace(),
                    Date = GetRandomDateTime(),
                    
                    Product = new Product()
                    {
                        CodeEdi = "ABH-50542463",
                        Comment = "Folly words widow one downs few age every seven. If miss part by fact he park just shew. Discovered had get considered projection who favourable. Necessary up knowledge it tolerably. Unwilling departure education is be dashwoods or an. Use off agreeable law unwilling sir deficient curiosity instantly. Easy mind life fact with see has bore ten. Parish any chatty can elinor direct for former. Up as meant widow equal an share least. "
                    }
                },

                new Prescription
                {
                    ReferenceMimosa = "BG5V2D8H",
                    //EyeAmetropy = null,
                    //Ophthalmologist = null,
                    //Optician = null,
                    Place = GetRandomPlace(),
                    Date = GetRandomDateTime(),
                    //Product = null
                },

                new Prescription
                {
                    ReferenceMimosa = "PN6985DF",
                    //EyeAmetropy = null,
                    //Ophthalmologist = null,
                    //Optician = null,
                    Place = GetRandomPlace(),
                    Date = GetRandomDateTime(),
                    //Product = null
                },

                new Prescription
                {
                    ReferenceMimosa = "PVMNBD78Q",
                    //EyeAmetropy = null,
                    //Ophthalmologist = null,
                    //Optician = null,
                    Place = GetRandomPlace(),
                    Date = GetRandomDateTime(),
                    //Product = null
                }

            );

            _dataContext.SaveChanges();
        }

        /// <summary>
        /// Get random alphanumeric chars
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private string GetRandomString(int length)
        {
            //Alphanumeric chars
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Get a random place
        /// </summary>
        /// <returns></returns>
        private string GetRandomPlace()
        {
            //Fixed list
            List<string> places = new List<string>() { "Angers", "Paris", "Albi", "Bordeaux", "Nice" };

            var index = _random.Next(places.Count);

            return places.ElementAt(index);
        }

        /// <summary>
        /// Get a random DateTime
        /// </summary>
        /// <returns></returns>
        private DateTime GetRandomDateTime()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;

            return start.AddDays(_random.Next(range));
        }

        #endregion
    }
}
