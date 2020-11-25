using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PracticeWebApp.Models;

namespace PracticeWebApp.ViewModels
{
    public class AskPrescriptionViewModel : IUser
    {
        #region Public Members
        public string Name { get; set; }
        public string FirstName { get; set; }
        
        public string PhoneNumber { get; set; }

        public string Answer { get; set; }

        public int QuestionNumber { get; set; }

        #endregion

        #region Constructor
        public AskPrescriptionViewModel()
        {

        }

        #endregion
    }
}
