using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeWebApp.Models
{
    [Serializable()]
    public class Optician : IUser
    {
        #region Public Members

        public int Id { get; set; }

        [Range(11, 11)] //TODO voir si plus propre
        public int Rpps { get; set; }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        #endregion

        #region Constructor

        /// <summary>
        /// The constructor
        /// </summary>
        public Optician()
        {

        }

        #endregion
    }
}
