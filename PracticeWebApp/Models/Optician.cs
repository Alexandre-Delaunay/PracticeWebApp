﻿using System;
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

        [Key]
        public int Id { get; set; }
        public long Rpps { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }

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
