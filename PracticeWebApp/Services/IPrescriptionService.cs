using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticeWebApp.Models;
using PracticeWebApp.ViewModels;

namespace PracticeWebApp.Services
{
    public interface IPrescriptionService
    {
        public Task<Prescription> Get(int id);

        public Task<Prescription> AskPrescription(AskPrescriptionViewModel AskPrescritpionViewModel);

        public Task<string> GetAuditTrail(string referenceMimosa);
    }
}
