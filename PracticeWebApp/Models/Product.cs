using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeWebApp.Models
{
    [Serializable()]
    public class Product
    {
        #region Public Members
        public string CodeEdi { get; set; }

        public string Comment { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// The constructor
        /// </summary>
        public Product()
        {

        }

        #endregion
    }
}
