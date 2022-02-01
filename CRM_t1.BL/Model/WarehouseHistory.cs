using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_t1.BL.Model
{
    [Serializable]
    public class WarehouseHistory
    {
        int ID;
        int userId;
        //TODO: несколько продаж
        int productId;
        int productPrice;
        int productQuantity;

        public WarehouseHistory(int UserId, int ProductsId, int ProductsPrice, int ProductsQuantity, int Count)
        {
            ID = Count;
            userId = UserId;
            productId = ProductsId;
            productPrice = ProductsPrice;
            productQuantity = ProductsQuantity;
        }
        public override string ToString()
        {
            return
               $"\nId\t{ID} " +
               $"\nUser\t{userId} " +
               $"\nProd.\t{productId} " +
               $"\nQuan.\t{productQuantity} " +
               $"\nPrice\t{productPrice}" +
               $"\nType\t{base.ToString()}";
        }
    }
}
