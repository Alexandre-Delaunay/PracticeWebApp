using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PracticeWebApp.Models;
using PracticeWebApp.Traductions;
using PracticeWebApp.ViewModels;

namespace PracticeWebApp.Services
{
    public class ValidatorService : IValidatorService
    {
        //TODO : Check Fluent Validation

        #region EyeAmetro Validators

        /// <summary>
        /// Verify EyeAmetropy properties
        /// </summary>
        /// <returns></returns>
        public (bool success, string errorMessage) IsEyeAmetropyValid(EyeAmetropy eyeAmetropy)
        {
            bool success;
            string errorMessage;

            //Verify Sphere property
            (success, errorMessage) = IsSphereValid(eyeAmetropy.Sphere);

            //Verify PrismPrescription property
            if(success)
                (success, errorMessage) = IsPrismPrescritpionValid(eyeAmetropy.PrismPrescription, eyeAmetropy.Astigmatism);

            return (success, errorMessage);
        }

        public (bool success, string errorMessage) IsSphereValid(string sphere)
        {
            //Verify if sphere start with negative or positive sign
            if (!sphere.StartsWith("-") || !sphere.StartsWith("+"))
                return (false, Errors.SphereFirstCharInvalid);

            //Verify if sphere can be cast as decimal
            if (!decimal.TryParse(sphere, out decimal sphereToDecimal))
                return (false, Errors.SphereIsNotDecimal);

            return (true, string.Empty);
        }

        public (bool success, string errorMessage) IsPrismPrescritpionValid(string[] prismPrescritpion, string[] astigmatism)
        {
            if (MockAstigmatismHaveChanged(astigmatism)
             && (string.IsNullOrEmpty(prismPrescritpion[0]) || string.IsNullOrEmpty(prismPrescritpion[1])))
                return (false, Errors.PrismPrescriptionInvalid);
            else
                return (true, string.Empty);
        }

        /// <summary>
        /// Used to mock changes from astigmatism property
        /// </summary>
        /// <returns></returns>
        private static bool MockAstigmatismHaveChanged(string[] astigmatism) => true;

        #endregion

        #region Opthalmologist Validators

        /// <summary>
        ///  Verify Ophthalmologist properties
        /// </summary>
        /// <returns></returns>
        public (bool success, string errorMessage) IsOphthalmologistValid(Ophthalmologist ophthalmologist)
        {
            //Verify adel property length
            return IsAdelValid(ophthalmologist.Adel.ToString());
        }

        public (bool success, string errorMessage) IsAdelValid(string adel)
        {
            if (!string.IsNullOrEmpty(adel) && adel.Length == 11)
                return (true, string.Empty);
            else
                return (false, Errors.AdelLengthInvalid);
        }

        #endregion

        #region Optician Validators

        /// <summary>
        /// Verify Optician properties
        /// </summary>
        /// <returns></returns>
        public (bool success, string errorMessage) IsOpticianValid(Optician optician)
        {
            //Verify rpps property length
            return IsRppsValid(optician.Rpps.ToString());
        }

        public (bool success, string errorMessage) IsRppsValid(string rpps)
        {
            if (!string.IsNullOrEmpty(rpps) && rpps.Length == 11)
                return (true, string.Empty);
            else
                return (false, Errors.RppsLengthInvalid);
        }

        #endregion

        #region Prescription Validators

        /// <summary>
        /// Verify Prescription properties
        /// </summary>
        /// <returns></returns>
        public (bool success, string errorMessage) IsPrescriptionValid(Prescription prescription)
        {
            bool success;
            string errorMessage;

            //Verify mimosa reference       
            (success, errorMessage) = IsReferenceMimosaValid(prescription.ReferenceMimosa);

            if (success && prescription.EyeAmetropy != null)
                (success, errorMessage) = IsEyeAmetropyValid(prescription.EyeAmetropy);

            if (success && prescription.Ophthalmologist != null)
                (success, errorMessage) = IsOphthalmologistValid(prescription.Ophthalmologist);

            if (success && prescription.Optician != null)
                (success, errorMessage) = IsOpticianValid(prescription.Optician);

            if (success && prescription.Product != null)
                (success, errorMessage) = IsProductValid(prescription.Product);

            return (success, errorMessage);
        }

        /// <summary>
        /// Check ReferenceMimosa property
        /// </summary>
        /// <param name="referenceMimosa"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) IsReferenceMimosaValid(string referenceMimosa)
        {
            if (!string.IsNullOrEmpty(referenceMimosa) && referenceMimosa.Length == 8)
                return (true, string.Empty);
            else
                return (false, Errors.ReferenceMimosaInvalid);
        }

        #endregion

        #region Product Validators

        /// <summary>
        /// Verify Product properties
        /// </summary>
        /// <returns></returns>
        public (bool success, string errorMessage) IsProductValid(Product product)
        {
            //Verify codeEdi property
            if (CodeEdiIsUnique())
                return (true, string.Empty);
            else
                return (false, Errors.CodeEdiIsNotUnique);
        }

        private static bool CodeEdiIsUnique() => true;

        #endregion

        #region ViewModels Validators

        public (bool success, string errorMessage) IsAskPrescriptionViewModelValid(AskPrescriptionViewModel askPrescriptionViewModel)
        {
            //Verify Name
            if (!IsNameValid(askPrescriptionViewModel.Name))
                return (false, Errors.NameInvalid);

            //Verify First Name
            if (!IsFirstNameValid(askPrescriptionViewModel.FirstName))
                return (false, Errors.FirstNameInvalid);

            //Verify Phone Number
            if (!Regex.Match(askPrescriptionViewModel.PhoneNumber, @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$").Success)
                return (false, Errors.PhoneNumberInvalid);

            //Verify Answer
            if (!IsAnswerValid(askPrescriptionViewModel.QuestionNumber))
                return (false, Errors.AnswerInvalid);

            return (true, string.Empty);
        }

        private static bool IsAnswerValid(int questionNumber) => true;

        private static bool IsNameValid(string name) => true;

        private static bool IsFirstNameValid(string firstName) => true;

        #endregion
    }
}
