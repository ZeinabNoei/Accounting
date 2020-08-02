using System;
using Accounting.DataLayer.Repositories;
using Accounting.DataLayer.Services;

namespace Accounting.DataLayer.Context
{
    public class UnitOfWork : IDisposable
    {
        Accounting_DBEntities db = new Accounting_DBEntities();

        private ICustomerRepository _customerRepository;
        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (_customerRepository == null)
                {
                    _customerRepository = new CustomerRepository(db);
                }

                return _customerRepository;
            }
        }


        private GenericRepository<Accounting> _accountingRepository;

        public GenericRepository<Accounting> AccountingRepository
        {
            get
            {
                if (_accountingRepository == null)
                {
                    _accountingRepository = new GenericRepository<Accounting>(db);
                }

                return _accountingRepository;
            }
        }

        private GenericRepository<Login> _loginRepository;

        public GenericRepository<Login> LoginRepository
        {
            get
            {
                if (_loginRepository==null )
                {
                    _loginRepository = new GenericRepository<Login>(db );
                }
                return _loginRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }




    //comment
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
            //in ravesh khob nist chon layerha hichkodom nabayad mostaghi, ba layer data dar ertebat bashan be khatere hamin az pattern UnitOfWork estefade mikonim
            //  Accounting_DBEntities db = new Accounting_DBEntities();
            //ICustomerRepository customer = new CustomerRepository(db);
            // Customers Addcustomer = new Customers() {
            //     FullName ="fariba",
            //     Mobile="9999999",
            //     Email ="Ali@yahoo.com",
            //     Address ="no",
            //     CustomerImage ="n"
            // };

            // customer.InsertCustomer(Addcustomer);
            // customer.save();
            // var list = customer.GetAllCustomer();

            //UnitOfWork db = new UnitOfWork();
            //var list = db.CustomerRepository.GetAllCustomer();
            //db.Dispose();

            //Accounting_DBEntities db = new Accounting_DBEntities();
            //Accounting.DataLayer.Services.GenericRepository<Customers> customerRepository = new Accounting.DataLayer.Services.GenericRepository<Customers>(db);

            //var result = customerRepository.GetById(6);
            //var result1 = customerRepository.Get(c => c.FullName.Contains("I"));

    //    }
    //}


}
