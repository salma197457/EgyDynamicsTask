using EgyDynamics2.GenericRepo;
using EgyDynamics2.Models;

namespace EgyDynamics2.UnitOfWork
{
    public class UnitOf_Work
    {
        EgyDynamicsContext db;

        private GenericRepo<العميل> customerRepository;
        private GenericRepo<الموظف> employeeRepository;
        private GenericRepo<مكالمهالعميل> callRepository;

        public UnitOf_Work(EgyDynamicsContext db)
        {
            this.db = db;
        }

        public GenericRepo<العميل> CustomerRepository
        {
            get
            {
                if (customerRepository == null)
                {
                    customerRepository = new GenericRepo<العميل>(db);
                }
                return customerRepository;
            }
        }

        public GenericRepo<الموظف> EployeeRepository
        {
            get
            {
                if (employeeRepository == null)
                {
                    employeeRepository = new GenericRepo<الموظف>(db);
                }
                return employeeRepository;
            }
        }

        public GenericRepo<مكالمهالعميل> CallRepository
        {
            get
            {
                if (callRepository == null)
                {
                    callRepository = new GenericRepo<مكالمهالعميل>(db);
                }
                return callRepository;
            }
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
