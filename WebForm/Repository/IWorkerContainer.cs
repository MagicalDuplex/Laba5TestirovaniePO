using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForm.Repository
{
    public interface IWorkerContainer
    {
        HumanResourcesDepartment.HumanResourcesDepartment GetHumanDepartment();
    }
}
