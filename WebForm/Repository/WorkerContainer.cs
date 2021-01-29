using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebForm.Repository
{
    public class WorkerContainer : IWorkerContainer
    {
        private readonly HumanResourcesDepartment.HumanResourcesDepartment _hd;

        public WorkerContainer()
        {
            _hd = new HumanResourcesDepartment.HumanResourcesDepartment();
        }

        public HumanResourcesDepartment.HumanResourcesDepartment GetHumanDepartment()
        {
            return _hd;
        }
    }
}
