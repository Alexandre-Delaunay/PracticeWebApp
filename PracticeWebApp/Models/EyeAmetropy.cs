using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeWebApp.Models
{
    [Serializable()]
    public class EyeAmetropy
    {
        #region Public Members

        [Key]
        public int Id { get; set; }
        public string Sphere { get; set; }

        [NotMapped]
        public string[] Astigmatism { get; set; }

        public float Addition { get; set; }

        [NotMapped]
        public string[] PrismPrescription { get; set; }

        public string Comment { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// The constructor
        /// </summary>
        public EyeAmetropy()
        {

        }

        #endregion
    }
}
