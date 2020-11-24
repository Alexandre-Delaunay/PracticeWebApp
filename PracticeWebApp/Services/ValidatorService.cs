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
        /// <summary>
        /// Verify EyeAmetropy properties
        /// </summary>
        /// <returns></returns>
        public (bool success, string errorMessage) IsEyeAmetropyValid(EyeAmetropy eyeAmetropy)
        {
            //TODO
            throw new NotImplementedException();
        }

        /// <summary>
        ///  Verify Ophthalmologist properties
        /// </summary>
        /// <returns></returns>
        public (bool success, string errorMessage) IsOphthalmologistValid(Ophthalmologist ophthalmologist)
        {
            //TODO
            throw new NotImplementedException();
        }

        /// <summary>
        /// Verify Optician properties
        /// </summary>
        /// <returns></returns>
        public (bool success, string errorMessage) IsOpticianValid(Optician optician)
        {
            //TODO
            throw new NotImplementedException();
        }

        /// <summary>
        /// Verify Prescription properties
        /// </summary>
        /// <returns></returns>
        public (bool success, string errorMessage) IsPrescriptionValid(Prescription prescription)
        {
            var success = true;
            var errorMessage = string.Empty;

            //Verify mimosa reference
            if (prescription.ReferenceMimosa.Length != 8)
            {
                success = false;
                errorMessage = Errors.ReferenceMimosaInvalid;
            }

            if (success)
                (success, errorMessage) = IsEyeAmetropyValid(prescription.EyeAmetropy);

            if (success)
                (success, errorMessage) = IsOphthalmologistValid(prescription.Ophthalmologist);

            if (success)
                (success, errorMessage) = IsOpticianValid(prescription.Optician);

            if (success)
                (success, errorMessage) = IsProductValid(prescription.Product);

            return (success, errorMessage);
        }

        /// <summary>
        /// Verify Product properties
        /// </summary>
        /// <returns></returns>
        public (bool success, string errorMessage) IsProductValid(Product product)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
