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
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$")]
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
