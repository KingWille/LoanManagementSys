using LoanManagementSys.Managers;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSys;

/*
  The task of this thread class is to send request to the controller to
  update the list of products that are on loand as wekk as  the list
  available products on the UI using at certain intervals (e.g 2 seconds).

  Note: loanSys is a reference to an object of the LoanSystem which
  is a class which creates the threads and  also updates the MainForm.
  It has the reference to the listboxes for updating.
*/
internal class UpdateGUI
{
    private Random random;
    private LoanSysManager loanSys;

    //constructor
    public UpdateGUI(LoanSysManager loanSys)
    {
        this.loanSys = loanSys;
        random = new Random();
    }

    //Sets isRunning to true/fals; when true, the thread continues processing and
    //if false, it stops
    public bool IsRunning { get; set; } = true;


    //This method is run by the thread assigned to perform the task. It requests
    //updating the list of products and the list of items on loan by the controller.
    public void Run()
    {
        while (LoanSysManager.isRunning)
        {

            for (int i = 0; i < LoanSysManager.productManager.NumberOfProducts(); i++)
            {
                if (i == 0)
                {
                    for(int j = 0; j < LoanSysManager.loanItemManager.GetListLoanItems().Count; j++)
                    {
                        UpdateProductsSecond(LoanSysManager.loanItemManager.GetLoanItem(j).Product.Name, j);
                    }

                    UpdateProductsSecond("Number of products available: " + LoanSysManager.productManager.NumberOfProducts(), 1);
                    UpdateProductsSecond(LoanSysManager.productManager.Get(i).Name, 1);
                }
                else 
                { 
                    UpdateProductsSecond(LoanSysManager.productManager.Get(i).Name, i);
                }
            }

            LoanItem lastLoan = LoanSysManager.loanItemManager.GetLastProductInfo();

            if (lastLoan != null)
            {
                UpdateProductFirst(lastLoan.Product.Name, lastLoan.Member.Name, 0);
            }

            LoanItem returnedProd = LoanSysManager.loanItemManager.GetReturnedProduct();

            if (returnedProd != null)
            {
                UpdateProductFirst(returnedProd.Product.Name, returnedProd.Member.Name, 1);
            }

            Thread.Sleep(2000);


        }

    }

    private void UpdateProductFirst(string item, string item2, int i)
    {
        // Check if we need to call Invoke to marshal the call to the UI thread
        if (loanSys.first.InvokeRequired)
        {
            loanSys.first.Invoke(new Action<string, string, int>(UpdateProductFirst), item, item2, i);
        }
        else if (i == 0)
        {
            loanSys.first.Items.Add(item + " loaned out to " + item2);
        }
        else if (i == 1)
        {
            loanSys.first.Items.Add(item2 + " returned " + item);
        }
    }

    private void UpdateProductsSecond(string item, int i)
    {
        if (loanSys.second.InvokeRequired)
        {
            loanSys.second.Invoke(new Action<string, int>(UpdateProductsSecond), item, i);
        }
        else
        {
            if (i == 0)
            {
                loanSys.second.Items.Clear();
                loanSys.second.Items.Add("Products on loan: " + LoanSysManager.loanItemManager.NumberOfLoans());
            }

            loanSys.second.Items.Add(item);
        }
    }
}

