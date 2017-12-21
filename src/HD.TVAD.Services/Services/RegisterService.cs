using System;
using System.Collections.Generic;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HD.Station;


namespace HD.TVAD.Web.Services
{	
    [Service(ServiceType = typeof(IRegisterService))]
    public class RegisterService : Service<Register, IRegisterRepository>, IRegisterService
    {
        public RegisterService(IRegisterRepository repository) : base(repository)
        {
        }
    }
}
