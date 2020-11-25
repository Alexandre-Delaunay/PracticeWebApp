using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticeWebApp.Models;
using PracticeWebApp.Traductions;

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
            //Verify Sphere property
            if (!eyeAmetropy.Sphere.StartsWith("-") || !eyeAmetropy.Sphere.StartsWith("+"))
                return (false, Errors.SphereFirstCharInvalid);

            //Verify if sphere can be cast as decimal
            if (!decimal.TryParse(eyeAmetropy.Sphere, out decimal sphere))
                return (false, Errors.SphereIsNotDecimal);

            //Verify PrismPrescription property
            if (MockAstigmatismHaveChanged()
                && (string.IsNullOrEmpty(eyeAmetropy.PrismPrescription.Item1) || string.IsNullOrEmpty(eyeAmetropy.PrismPrescription.Item2)))
                return (false, Errors.PrismPrescriptionInvalid);

            return (true, string.Empty);
        }

        /// <summary>
        /// Used to mock changes from astigmatism property
        /// </summary>
        /// <returns></returns>
        private static bool MockAstigmatismHaveChanged() => true;

        #endregion

        #region Opthalmologist Validators

        /// <summary>
        ///  Verify Ophthalmologist properties
        /// </summary>
        /// <returns></returns>
        public (bool success, string errorMessage) IsOphthalmologistValid(Ophthalmologist ophthalmologist)
        {
            //Verify adel property length
            if (ophthalmologist.Adel.ToString().Length == 11)
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
            if (optician.Rpps.ToString().Length == 11)
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
            var success = true;
            var errorMessage = string.Empty;

            //Verify mimosa reference            

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
            if (referenceMimosa.Length != 8)
                return (false, Errors.ReferenceMimosaInvalid);
            else
                return (true, string.Empty);
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
    }
}
