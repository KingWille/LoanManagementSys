using LoanManagementSys.Managers;

namespace LoanManagementSys;

public partial class MainForm : Form
{
    private LoanSysManager loanSystem;
    private Thread appThread;

    public MainForm()
    {
        InitializeComponent();
        loanSystem = new LoanSysManager(lstOutput, lstItems);
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
        appThread = new Thread(new ThreadStart(loanSystem.Run));

        appThread.Start();   
    }



    private void btnStop_Click(object sender, EventArgs e)
    {
        appThread = null;
    }



    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        appThread = null;
        Application.Exit();
    }
}