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
        private bool isRunning;
        public void Run()
        {
            rnd = new Random();
            isRunning = true;

            while(isRunning)
            {
                int timer = rnd.Next(6, 16);
                Program.productManager.AddNewTestProduct();
                Thread.Sleep(timer * 1000);                
            }
        }
    }
}
