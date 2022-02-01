using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_t1.BL.Model
{
    internal class WarehouseHistory
    {
        static int count = 0;
        int ID;
        int IdUser;
        int IdProduct;
        int priceProduct;
        int quantityProduct;

        public WarehouseHistory()
        {
            ID = count;
            count++;
        }
        public override string ToString()
        {
            return
               $"\nId\t{ID} " +
               $"\nUser\t{IdUser} " +
               $"\nProd.\t{IdProduct} " +
               $"\nQuan.\t{quantityProduct} " +
               $"\nPrice\t{priceProduct}" +
               $"\nType\t{base.ToString()}";
        }
    }
}
