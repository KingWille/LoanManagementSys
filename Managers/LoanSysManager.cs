using LoanManagementSys.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSys.Managers
{
    internal class LoanSysManager
    {
        //TODO: När productlistan bara har en produkt kvar, försvinner den inte när den lånas ut
        internal static ProductManager productManager;
        internal static MemberManager memberManager;
        internal static LoanItemManager loanItemManager;
        internal ListBox first, second;

        public LoanSysManager(ListBox FirstOutput, ListBox SecondOutput)
        {
            first = FirstOutput;
            second = SecondOutput;
        }

        public void Run()
        {
            productManager = new ProductManager();
            memberManager = new MemberManager();
            loanItemManager = new LoanItemManager();

            AdminTask adminTask = new AdminTask();
            LoanTask loanTask = new LoanTask();
            ReturnTask returnTask = new ReturnTask();
            UpdateGUI updateGUI = new UpdateGUI(this);
            Thread t1, t2, t3, t4;

            t1 = new Thread(new ThreadStart(adminTask.Run));
            t2 = new Thread(new ThreadStart(loanTask.Run));
            t3 = new Thread(new ThreadStart(returnTask.Run));
            //t4 = new Thread(new ThreadStart());

            productManager.AddTestProducts();
            memberManager.AddMembersOnStart();

            t1.Start();
            t2.Start();
            t3.Start();

        }
    }
}
