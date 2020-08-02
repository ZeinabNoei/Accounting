using System;
using System.Linq;
using Accounting.ViewModels.Accounting;
using Accounting.DataLayer.Context;

namespace Accounting.Business
{
   public  class Account
    {
        public static ReportViewModel Reportformain() {
            ReportViewModel rp = new ReportViewModel();
            using (UnitOfWork db=new UnitOfWork ())
            {
                var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01);
                var endtDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 30);
                var recieve = db.AccountingRepository.Get(a => a.TypeID == 1 && a.DateTitle >= startDate && a.DateTitle <= endtDate).Select(a => a.Amount).ToList();
                var pay = db.AccountingRepository.Get(a => a.TypeID == 2 && a.DateTitle >= startDate && a.DateTitle <= endtDate).Select(a => a.Amount).ToList();

                //rp.Recieve = recieve.Sum();
                //rp.pay = pay.Sum();
                //rp.AccountBalance = (recieve.Sum() - pay.Sum());

            }
            return rp;
        }
    }
}
