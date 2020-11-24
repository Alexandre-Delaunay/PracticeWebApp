using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PracticeWebApp.Models;
using PracticeWebApp.ViewModels;

namespace PracticeWebApp.Helpers
{
    public class AutoMapper : Profile
    {
        /// <summary>
        /// The constructor
        /// </summary>
        public AutoMapper()
        {
            CreateMap<AskPrescriptionViewModel, Prescription>();
        }

    }
}
