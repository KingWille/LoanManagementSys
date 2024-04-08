using LoanManagementSys.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSys.Tasks
{
    internal class LoanTask
    {
        private Random rnd = new Random();

        /// <summary>
        /// Loans an item from the products list 
        /// </summary>
        public void Run()
        {
            while (LoanSysManager.isRunning)
            {
                int timer = rnd.Next(2, 6);

                if (LoanSysManager.productManager.NumberOfProducts() > 0)
                {
                    int products = rnd.Next(0, LoanSysManager.productManager.NumberOfProducts() - 1);
                    int members = rnd.Next(0, LoanSysManager.memberManager.NumberOfMembers() - 1);
                    LoanSysManager.loanItemManager.LoanProduct(members, products);
                }

                Thread.Sleep(timer * 1000);

            }
        }
    }
}
