using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticeWebApp.Models;
using PracticeWebApp.ViewModels;

namespace PracticeWebApp.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        /// <summary>
        /// On envoi une demande en paramètre de la méthode, c’est-à-dire, un objet JSON contenant, le nom, le prénom, 
        /// le numéro de téléphone et la réponse à une question secrète ainsi que le numéro de question à l’API qui va ensuite vérifier les données et renvoyer l’ordonnance. 
        /// Le retour est une ordonnance dans le cadre de cet exercice, en cas réel, nous aurions renvoyé l’ordonnance via un autre canal
        /// </summary>
        /// <param name="AskPrescritpionViewModel"></param>
        /// <returns></returns>
        public Task<Prescription> AskPrescription(AskPrescriptionViewModel AskPrescritpionViewModel)
        {
            //TODO
            throw new NotImplementedException();
        }

        /// <summary>
        /// C’est la plus simple, on a une référence qui est l’identifiant d’une ordonnance, on envoi l’ordonnance correspondant à l’identifiant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Prescription> Get(int id)
        {
            //TODO
            throw new NotImplementedException();
        }

        /// <summary>
        /// On envoie une référence MIMOSA et on reçoit une piste d’audit, la piste d’audit pour l’instant sera une chaine de caractère, on changera ça plus tard dans l’exercice.
        /// </summary>
        /// <param name="referenceMimosa"></param>
        /// <returns></returns>
        public Task<string> GetAuditTrail(string referenceMimosa)
        {
            //TODO
            throw new NotImplementedException();
        }

        /// <summary>
        /// Une méthode pour envoyer une ordonnance et vérifier qu’elle est bien formée et que les champs respectent les règles indiquées en commentaire. 
        /// En retour, on envoi une référence MIMOSA générée aléatoirement.
        /// </summary>
        /// <param name="prescription"></param>
        /// <returns></returns>
        public Task<string> IsValid(Prescription prescription)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
