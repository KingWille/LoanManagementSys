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

        /// <summary>
        /// Adds a new loanitem to the loanitems list, and removes it from the product list
        /// </summary>
        /// <param name="memberIndex"></param>
        /// <param name="productIndex"></param>
        internal void LoanProduct(int memberIndex, int productIndex)
        {
            loanItems.Add(new LoanItem(LoanSysManager.productManager.Get(productIndex), LoanSysManager.memberManager.GetMember(memberIndex)));
            LoanSysManager.productManager.Remove(productIndex);
        }

        /// <summary>
        /// Adds the product back to the product list, and removes it from the loan item list
        /// </summary>
        internal void ReturnProduct()
        {
            int index = random.Next(0, loanItems.Count());

            LoanSysManager.productManager.Add(loanItems[index].Product);
            returnedItem = loanItems[index];
            loanItems.RemoveAt(index);
        }

        /// <summary>
        /// Returns the number of items in the loanitems list
        /// </summary>
        /// <returns></returns>
        internal int NumberOfLoans()
        {
            return loanItems.Count;
        }

        /// <summary>
        /// Returns the last product of the loanitems list 
        /// </summary>
        /// <returns></returns>
        internal LoanItem GetLastProductInfo()
        {
            if(lastReturnedLoanItem != loanItems.Last() && loanItems != null)
            {
                lastReturnedLoanItem = loanItems.Last();
            }
            else
            {
                lastReturnedLoanItem = null;
            }

            return lastReturnedLoanItem;
        }

        /// <summary>
        /// Returns the loanitems list
        /// </summary>
        /// <returns></returns>
        internal List<LoanItem> GetListLoanItems()
        {
            return loanItems;
        }

        /// <summary>
        /// Returns a loan item at a specific index in the list
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        internal LoanItem GetLoanItem(int index)
        {
            return loanItems[index];
        }

        /// <summary>
        /// Returns the last returned item
        /// </summary>
        /// <returns></returns>
        internal LoanItem GetReturnedProduct()
        {
            var returnValue = returnedItem;
            returnedItem = null;
            return returnValue;
        }

        /// <summary>
        /// Returns a string array which contains the name and ID of all the products in the loanitem list
        /// </summary>
        /// <returns></returns>
        internal  string[] GetLoanItemInfoStrings()
        {
            if(loanItems.Count < 1 || loanItems.Count == null)
            {
                return new string[] { "Products on loan: ", " " };
            }
            else
            {
                string[] returnArray = new string[loanItems.Count() + 3];
                returnArray[0] = "Products on loan: " + loanItems.Count();
                returnArray[1] = "";

                for(int i = 0; i < loanItems.Count(); i++) 
                {
                    returnArray[i + 2] = loanItems[i].Product.Name + " ID: " + loanItems[i].Product.ID;
                }

                returnArray[returnArray.Count() - 1] = "";

                return returnArray;
            }
        }
    }
}
