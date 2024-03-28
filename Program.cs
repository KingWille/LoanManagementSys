using LoanManagementSys.Managers;
using LoanManagementSys.Tasks;

namespace LoanManagementSys
{
    internal static class Program
    {
        internal static ProductManager productManager;
        internal static MemberManager memberManager;
        internal static LoanItemManager loanItemManager;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            productManager = new ProductManager();
            memberManager = new MemberManager();
            loanItemManager = new LoanItemManager();

            AdminTask adminTask = new AdminTask();
            LoanTask loanTask = new LoanTask();
            ReturnTask returnTask = new ReturnTask();
            UpdateGUI updateGUI = new UpdateGUI();

            Thread t1, t2, t3, t4;

            t1 = new Thread(new ThreadStart(adminTask.Run));
            t2 = new Thread(new ThreadStart());
            t3 = new Thread(new ThreadStart());
            t4 = new Thread(new ThreadStart());

            t1.Start();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());

            productManager.AddTestProducts();
        }
    }
}