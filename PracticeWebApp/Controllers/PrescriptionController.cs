using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticeWebApp.Services;
using PracticeWebApp.ViewModels;

namespace PracticeWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrescriptionController : ControllerBase
    {

        #region Private Members

        private readonly IPrescriptionService _prescriptionService;
        private readonly IValidatorService _validatorService;

        #endregion

        #region Constructor

        /// <summary>
        /// The constructor
        /// </summary>
        public PrescriptionController(IPrescriptionService prescriptionService, IValidatorService validatorService)
        {
            _prescriptionService = prescriptionService;
            _validatorService = validatorService;
        }

        #endregion

        #region Routes

        /// <summary>
        /// Return prescription by mimosa reference
        /// </summary>
        /// <param name="referenceMimosa"></param>
        /// <returns></returns>
        [HttpGet("{referenceMimosa}")]
        public async Task<IActionResult> Get(string referenceMimosa)
        {
            try
            {
                //Verify mimosa reference
                (bool success, string errorMessage) = _validatorService.IsReferenceMimosaValid(referenceMimosa);

                if (!success)
                    return BadRequest(new { message = errorMessage });

                return Ok(await _prescriptionService.Get(referenceMimosa));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Send a prescription to others channels
        /// </summary>
        /// <param name="askPrescriptionViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AskPrescription(AskPrescriptionViewModel askPrescriptionViewModel)
        {
            try
            {                
                return Ok(await _prescriptionService.AskPrescription(askPrescriptionViewModel));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        
        /// <summary>
        /// AuditTrail route
        /// </summary>
        /// <param name="referenceMimosa"></param>
        /// <returns></returns>
        [HttpGet("{referenceMimosa}")]
        public async Task<IActionResult> GetAuditTrail(string referenceMimosa)
        {
            try
            {
                //Verify mimosa reference
                (bool success, string errorMessage) = _validatorService.IsReferenceMimosaValid(referenceMimosa);

                if (!success)
                    return BadRequest(new { message = errorMessage });

                return Ok(await _prescriptionService.GetAuditTrail(referenceMimosa));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        #endregion
    }
}
