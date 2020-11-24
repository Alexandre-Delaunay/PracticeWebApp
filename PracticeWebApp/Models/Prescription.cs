using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeWebApp.Models
{
    [Serializable()]
    public class Prescription
    {
        #region Public Members

        [Key]
        [MaxLength(8)]
        public string ReferenceMimosa { get; set; }

        public string Place { get; set; }

        public DateTime Date { get; set; }

        public EyeAmetropy EyeAmetropy { get; set; }

        public Ophthalmologist Ophthalmologist { get; set; }

        public Optician Optician { get; set; }

        public Product Product { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// The constructor
        /// </summary>
        public Prescription()
        {

        }

        #endregion
    }
}
