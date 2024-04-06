using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSys.Managers
{
    internal class LoanItemManager
    {
        private List<LoanItem> loanItems;
        private LoanItem lastReturnedLoanItem;
        private LoanItem returnedItem;
        private Random random;

        public LoanItemManager()
        {
            random = new Random();
            loanItems = new List<LoanItem>();
        }
        internal void LoanProduct(int memberIndex, int productIndex)
        {
            loanItems.Add(new LoanItem(LoanSysManager.productManager.Get(productIndex), LoanSysManager.memberManager.GetMember(memberIndex)));
            LoanSysManager.productManager.Remove(productIndex);
        }

        internal void ReturnProduct()
        {
            int index = random.Next(0, loanItems.Count());

            LoanSysManager.productManager.Add(loanItems[index].Product);
            returnedItem = loanItems[index];
            loanItems.RemoveAt(index);
        }

        internal int NumberOfLoans()
        {
            return loanItems.Count;
        }
        internal LoanItem GetLastProductInfo()
        {
            if(lastReturnedLoanItem != loanItems.Last())
            {
                lastReturnedLoanItem = loanItems.Last();
            }
            else
            {
                lastReturnedLoanItem = null;
            }

            return lastReturnedLoanItem;
        }

        internal List<LoanItem> GetListLoanItems()
        {
            return loanItems;
        }

        internal LoanItem GetLoanItem(int index)
        {
            return loanItems[index];
        }

        internal LoanItem GetReturnedProduct()
        {
            var returnValue = returnedItem;
            returnedItem = null;
            return returnValue;
        }
    }
}
