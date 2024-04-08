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
        internal static bool isRunning;
        internal ListBox first, second;

        AdminTask adminTask;
        LoanTask loanTask;
        ReturnTask returnTask;
        UpdateGUI updateGUI;
        Thread adminThread, loanThread, returnThread, updateGuiThread;

        public LoanSysManager(ListBox FirstOutput, ListBox SecondOutput)
        {
            first = FirstOutput;
            second = SecondOutput;

            productManager = new ProductManager();
            memberManager = new MemberManager();
            loanItemManager = new LoanItemManager();

            adminTask = new AdminTask();
            loanTask = new LoanTask();
            returnTask = new ReturnTask();
            updateGUI = new UpdateGUI(this);

            productManager.AddTestProducts();
            memberManager.AddMembersOnStart();
        }

        /// <summary>
        /// Initializes the task threads and starts them
        /// </summary>
        public void Run()
        {
            adminThread = new Thread(new ThreadStart(adminTask.Run));
            loanThread = new Thread(new ThreadStart(loanTask.Run));
            returnThread = new Thread(new ThreadStart(returnTask.Run));
            updateGuiThread = new Thread(new ThreadStart(updateGUI.Run));

            adminThread.Start();
            loanThread.Start();
            returnThread.Start();
            updateGuiThread.Start();
        }

        /// <summary>
        /// Stops all threads except from the main thread
        /// </summary>
        public void StopThreads()
        {
            isRunning = false;

            adminThread = null;
            loanThread = null;
            returnThread = null;
            updateGuiThread = null;
        }
    }
}
