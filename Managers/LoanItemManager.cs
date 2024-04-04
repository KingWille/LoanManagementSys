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
        private Dictionary<Product, Member> memberProductInfo;
        private List<Product> products;
        private Dictionary<Product, Member> returnedProduct;
        private Random random;
        private object lockObj;

        public LoanItemManager()
        {
            memberProductInfo = new Dictionary<Product, Member>();
            returnedProduct = new Dictionary<Product, Member>();
            products = new List<Product>();
            random = new Random();
        }
        internal void LoanProduct(int memberIndex, int productIndex)
        {
            memberProductInfo.Add(LoanSysManager.productManager.Get(productIndex), LoanSysManager.memberManager.GetMember(memberIndex));
            products.Add(LoanSysManager.productManager.Get(productIndex));
            LoanSysManager.productManager.Remove(productIndex);
            lockObj = new object();
        }

        internal void ReturnProduct()
        {
            if (memberProductInfo.Count() != 0)
            {
                int index = random.Next(0, products.Count());
                Product prodtoBeReturned = products[index];

                if(!returnedProduct.ContainsKey(prodtoBeReturned))
                {
                    returnedProduct.Add(prodtoBeReturned, memberProductInfo[prodtoBeReturned]);
                    LoanSysManager.productManager.Add(prodtoBeReturned);
                    memberProductInfo.Remove(prodtoBeReturned);
                    products.Remove(prodtoBeReturned);
                }
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

        internal Dictionary<Product, Member> GetReturnedProduct()
        {
            Dictionary<Product, Member> temp = returnedProduct;

            returnedProduct.Clear();
            
            return temp;
        }
    }
}
