using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeWebApp.Models
{
    [Serializable()]
    public class EyeAmetropy
    {
        #region Public Members

        //TODO add annotations with regular expression
        public string Sphere { get; set; }

        public Dictionary<string, string> Astigmatism { get; set; }

        public float Addition { get; set; }

        public Dictionary<string, string>  PrismPrescription { get; set; }

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
