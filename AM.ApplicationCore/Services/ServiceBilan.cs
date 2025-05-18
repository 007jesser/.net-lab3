using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceBilan : Service<Bilan>, IServiceBilan
    {
        public ServiceBilan(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public double CalculerMontantTotal(Bilan bilan)
        {
            double montantTotal = bilan.Analyses.Sum(a => a.PrixAnalyse);

            int nombrePrelevements = GetMany(b => b.CodePatient == bilan.CodePatient).Count();

            if (nombrePrelevements > 5)
            {
                montantTotal *= 0.9;
            }

            return montantTotal;
        }

        public IEnumerable<(Bilan Bilan, IEnumerable<Analyse> AnalysesAnormales)> ObtenirAnalysesAnormalesParBilan(int codePatient)
        {
            var bilans = GetMany(b => b.CodePatient == codePatient && b.DatePrelevement.Year == DateTime.Now.Year);

            foreach (var bilan in bilans)
            {
                var analysesAnormales = bilan.Analyses
                    .Where(a =>
                        a.ValeurAnalyse > a.ValeurMaxNormale ||
                        a.ValeurAnalyse < a.ValeurMinNormale);

                if (analysesAnormales.Any())
                {
                    yield return (bilan, analysesAnormales);
                }
            }
        }

        public DateTime ObtenirDateRecuperationBilan(Bilan bilan)
        {

            var dateRecuperation = bilan.Analyses
                .Select(a => bilan.DatePrelevement.AddDays(a.DureeResultat))
                .Max();

            return dateRecuperation;
        }
    }
}
