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
            _dataContext.Prescriptions.AddRange(

                new Prescription
                {
                    ReferenceMimosa = GetRandomString(8),
                    EyeAmetropy = null,
                    Ophthalmologist = null,
                    Optician = null,
                    Place = GetRandomPlace(),
                    Date = GetRandomDateTime(),
                    Product = null
                },

                new Prescription
                {
                    ReferenceMimosa = GetRandomString(8),
                    EyeAmetropy = null,
                    Ophthalmologist = null,
                    Optician = null,
                    Place = GetRandomPlace(),
                    Date = GetRandomDateTime(),
                    Product = null
                },

                new Prescription
                {
                    ReferenceMimosa = GetRandomString(8),
                    EyeAmetropy = null,
                    Ophthalmologist = null,
                    Optician = null,
                    Place = GetRandomPlace(),
                    Date = GetRandomDateTime(),
                    Product = null
                },

                new Prescription
                {
                    ReferenceMimosa = GetRandomString(8),
                    EyeAmetropy = null,
                    Ophthalmologist = null,
                    Optician = null,
                    Place = GetRandomPlace(),
                    Date = GetRandomDateTime(),
                    Product = null
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
