using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticeWebApp.Models;

namespace PracticeWebApp.Services
{
    public interface IValidatorService
    {
        public (bool success, string errorMessage) IsPrescriptionValid(Prescription prescription);

        public (bool success, string errorMessage) IsEyeAmetropyValid(EyeAmetropy eyeAmetropy);

        public (bool success, string errorMessage) IsOphthalmologistValid(Ophthalmologist ophthalmologist);

        public (bool success, string errorMessage) IsOpticianValid(Optician optician);

        public (bool success, string errorMessage) IsProductValid(Product product);
    }
}
