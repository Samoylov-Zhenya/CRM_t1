using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_t1.BL.Model
{
    [Serializable]
    public class Product
    {
        #region --- Поля  ---
        /// <summary>
        /// Артикул товара в системе или id.
        /// </summary>
        public int ID { get; }
        /// <summary>
        /// Название товара.
        /// </summary>
        public string name { get; }
        /// <summary>
        /// Цена в закупке.
        /// </summary>
        public int cost { get; }
        /// <summary>
        /// Цена продажи.
        /// </summary>
        public int price { get; }
        /// <summary>
        /// Количество на складе.
        /// </summary>
        private int quantity { get; set; }
        #endregion
        #region --- Конструктор ---
        /// <summary>
        /// Создание нового товара.
        /// </summary>
        /// <param name="Id">Артикул товара в системе или id.</param>
        /// <param name="Name">Название товара.</param>
        /// <param name="Cost">Цена продажи.</param>
        /// <param name="Price">Цена продажи.</param>
        public Product(int Id, string Name, int Cost, int Price)
        {
            ID = Id;
            name = Name;
            cost = Cost;
            price = Price;
        }
        #endregion
        #region --- Методы ---
        public override string ToString()
        {
            return
                $"\nId\t{ID} " +
                $"\nName\t{name} " +
                $"\nCost\t{cost} " +
                $"\nQuan.\t{quantity} " +
                $"\nPrice\t{price}" +
                $"\nType\t{base.ToString()}";
        }
        /// <summary>
        /// Изменение количества товара на складе при продажи.
        /// </summary>
        /// <param name="Quantity">Количество проданого товара</param>
        /// <returns>True если операция прошла упала в остальных случаях false</returns>
        public bool IsSale(int Quantity)
        {
            if (Quantity <= 0 || Quantity > quantity)
            {
                return false;
            }
            quantity -= Quantity;
            return true;
        }
        /// <summary>
        /// Добавления количества товара на складе.
        /// </summary>
        /// <param name="Quantity">Количество добавляемого товара</param>
        /// <returns>True если операция прошла упала в остальных случаях false</returns>
        public bool IsBuy(int Quantity)
        {
            if (Quantity <= 0)
            {
                return false;
            }
            quantity += Quantity;
            return true;
        }
        #endregion
    }
}
