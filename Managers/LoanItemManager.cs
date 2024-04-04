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
            loanItems.RemoveAt(index);
        }
        
        internal Member GetMemberInfo(Product product)
        {
            
        }

        internal Product GetLastProductInfo()
        {
            
        }

        internal int NumberOfLoans()
        {
            
        }

        internal Dictionary<Product, Member> GetReturnedProduct()
        {
            
        }
    }
}
