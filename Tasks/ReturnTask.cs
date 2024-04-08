using LoanManagementSys.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSys
{
    internal class ReturnTask
    {
        private Random random;

        public ReturnTask()
        {
            random = new Random();
        }

        /// <summary>
        /// Returns a product thats on loan if the the loan items list is not 0
        /// </summary>
        internal void Run()
        {
            while(LoanSysManager.isRunning)
            {
                int timer = random.Next(3, 15);

                if (LoanSysManager.loanItemManager.NumberOfLoans() > 0)
                {
                    LoanSysManager.loanItemManager.ReturnProduct();
                }

                Thread.Sleep(timer * 1000);
            }
        }
    }
}
