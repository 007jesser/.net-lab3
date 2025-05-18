using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServicePatient : Service<Patient>, IServicePatient
    {
        public ServicePatient(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
