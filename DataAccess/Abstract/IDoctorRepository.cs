using Core;
using Entities.Concrete;
using OnlineRandevuSistemi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IDoctorRepository : IBaseRepository<Doctor>
    {
    }
}
