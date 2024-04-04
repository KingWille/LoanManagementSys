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
            productManager = new ProductManager();
            memberManager = new MemberManager();
            loanItemManager = new LoanItemManager();
            productManager.AddTestProducts();
            memberManager.AddMembersOnStart();
        }

        public void Run()
        {
            AdminTask adminTask = new AdminTask();
            LoanTask loanTask = new LoanTask();
            ReturnTask returnTask = new ReturnTask();
            UpdateGUI updateGUI = new UpdateGUI(this);
            Thread adminThread, loanThread, returnThread, updateGuiThread;

            adminThread = new Thread(new ThreadStart(adminTask.Run));
            loanThread = new Thread(new ThreadStart(loanTask.Run));
            returnThread = new Thread(new ThreadStart(returnTask.Run));
            updateGuiThread = new Thread(new ThreadStart(updateGUI.Run));

            adminThread.Start();
            loanThread.Start();
            returnThread.Start();
            updateGuiThread.Start();

            adminThread.IsBackground = true;
            loanThread.IsBackground= true;
            returnThread.IsBackground = true;
            updateGuiThread.IsBackground = true;

        }
    }
}
