using LoanManagementSys.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSys.Tasks
{
    internal class AdminTask
    {
        private Random rnd;
        public void Run()
        {
            rnd = new Random();

            while(LoanSysManager.isRunning)
            {
                int timer = rnd.Next(6, 16);
                LoanSysManager.productManager.AddNewTestProduct();
                Thread.Sleep(timer * 1000);                
            }
        }
    }
}
