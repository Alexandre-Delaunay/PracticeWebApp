using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticeWebApp.Models;
using PracticeWebApp.ViewModels;

namespace PracticeWebApp.Services
{
    public interface IValidatorService
    {
        #region Prescription

        public (bool success, string errorMessage) IsPrescriptionValid(Prescription prescription);
        public (bool success, string errorMessage) IsReferenceMimosaValid(string referenceMimosa);

        #endregion

        #region EyeAmetropy

        public (bool success, string errorMessage) IsEyeAmetropyValid(EyeAmetropy eyeAmetropy);
        public (bool success, string errorMessage) IsSphereValid(string sphere);
        public (bool success, string errorMessage) IsPrismPrescritpionValid(Tuple<string, string> prismPrescritpion, Tuple<string, string> astigmatism);

        #endregion

        #region Ophthalmologist

        public (bool success, string errorMessage) IsOphthalmologistValid(Ophthalmologist ophthalmologist);
        public (bool success, string errorMessage) IsAdelValid(string adel);

        #endregion

        #region Optician

        public (bool success, string errorMessage) IsOpticianValid(Optician optician);
        public (bool success, string errorMessage) IsRppsValid(string rpps);

        #endregion

        #region Product

        public (bool success, string errorMessage) IsProductValid(Product product);

        #endregion        

        #region ViewModels

        public (bool success, string errorMessage) IsAskPrescriptionViewModelValid(AskPrescriptionViewModel askPrescriptionViewModel);

        #endregion                
    }
}
