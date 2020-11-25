using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticeWebApp.Helpers;
using PracticeWebApp.Models;
using PracticeWebApp.ViewModels;

namespace PracticeWebApp.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        #region Private Members

        private readonly DataContext _dataContext;
        private readonly IValidatorService _validatorService;

        #endregion

        #region Constructor

        /// <summary>
        /// The constructor
        /// </summary>
        public PrescriptionService(DataContext dataContext, IValidatorService validatorService)
        {
            _dataContext = dataContext;
            _validatorService = validatorService;

            //TODO changed the way to generate random datas
            var dataGenerator = new DataGenerator(_dataContext);
            dataGenerator.Initialize();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// On envoi une demande en paramètre de la méthode, c’est-à-dire, un objet JSON contenant, le nom, le prénom, 
        /// le numéro de téléphone et la réponse à une question secrète ainsi que le numéro de question à l’API qui va ensuite vérifier les données et renvoyer l’ordonnance. 
        /// Le retour est une ordonnance dans le cadre de cet exercice, en cas réel, nous aurions renvoyé l’ordonnance via un autre canal
        ///
        /// TODO voir pour remove task
        /// </summary>
        /// <param name="AskPrescritpionViewModel"></param>
        /// <returns></returns>
        public async Task<Prescription> AskPrescription(AskPrescriptionViewModel AskPrescritpionViewModel)
        {           
            return await Task.FromResult(_dataContext.Prescriptions.FirstOrDefault());
        }

        /// <summary>
        /// C’est la plus simple, on a une référence qui est l’identifiant d’une ordonnance, on envoi la reference mimosa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        public async Task<Prescription> Get(string referenceMimosa)
        {
            return await Task.FromResult(_dataContext.Prescriptions.FirstOrDefault(x => string.Equals(x.ReferenceMimosa, referenceMimosa, StringComparison.InvariantCulture)));
        }

        /// <summary>
        /// On envoie une référence MIMOSA et on reçoit une piste d’audit, la piste d’audit pour l’instant sera une chaine de caractère, on changera ça plus tard dans l’exercice.
        /// </summary>
        /// <param name="referenceMimosa"></param>
        /// <returns></returns>
        public async Task<string> GetAuditTrail(string referenceMimosa)
        {
            var prescription = await Task.FromResult(_dataContext.Prescriptions.FirstOrDefault(x => string.Equals(x.ReferenceMimosa, referenceMimosa, StringComparison.InvariantCulture)));

            return prescription != null ? "Retour d'une chaîne à remplir ultérieurement" 
                                            : string.Empty;
        }

        #endregion
    }
}
