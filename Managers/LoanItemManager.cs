using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSys.Managers
{
    internal class LoanItemManager
    {
        private Dictionary<Product, Member> memberProductInfo;
        private List<Product> products;
        private Random random;

        public LoanItemManager()
        {
            memberProductInfo = new Dictionary<Product, Member>();
            products = new List<Product>();
            random = new Random();
        }
        internal void LoanProduct(int memberIndex, int productIndex)
        {
            memberProductInfo.Add(LoanSysManager.productManager.Get(productIndex), LoanSysManager.memberManager.GetMember(memberIndex));
            products.Add(LoanSysManager.productManager.Get(productIndex));
            LoanSysManager.productManager.Remove(productIndex);
        }

        internal void ReturnProduct()
        {
            if (memberProductInfo.Count() != 0)
            {
                int index = random.Next(0, products.Count());
                Product prodtoBeReturned = products[index];

                LoanSysManager.productManager.Add(prodtoBeReturned);
                memberProductInfo.Remove(prodtoBeReturned);
            }
        }
        
        internal Member GetMemberInfo(Product product)
        {
            return memberProductInfo[product];
        }

        internal Product GetLastProductInfo()
        {
            return products.Last();
        }

        internal int NumberOfLoans()
        {
            return memberProductInfo.Count();
        }
    }
}
