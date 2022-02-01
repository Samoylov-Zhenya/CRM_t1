using CRM_t1.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CRM_t1.BL.Controller
{
    /// <summary>
    /// Контролер.
    /// </summary>
    public class WarehouseHistoryController
    {
        #region --- Поля ---

        public List<WarehouseHistory> _warehouseHistory { get; }
        public WarehouseHistory currentHistory { get; }
        #endregion

        #region --- Конструктор ---
        public WarehouseHistoryController()
        {
            _warehouseHistory = GetProductData();
        }

        public WarehouseHistoryController(int HistoryId) : this()
        {
            //TODO: проверка

            //currentHistory = _warehouseHistory.SingleOrDefault(p => p.ID == HistoryId);

            if (currentHistory == null)
            {
                Console.ForegroundColor = ConsoleColor.Red; // устанавливаем цвет
                Console.WriteLine("Покупка не найден :(");
                Console.ResetColor(); // сбрасываем в стандартный
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green; // устанавливаем цвет
                Console.WriteLine("Покупка найден :)");
                Console.ResetColor(); // сбрасываем в стандартный
                Console.WriteLine(currentHistory);
            }
        }
        public WarehouseHistoryController(int userId, int productsId, int productsPrice, int productsQuantity) : this()
        {
            // TODO: проверка
            var currentHistory = new WarehouseHistory(userId, productsId, productsPrice, productsQuantity, _warehouseHistory.Count);
            _warehouseHistory.Add(currentHistory);
            IsSave();
        }
        #endregion
        #region --- Методы ---

        private List<WarehouseHistory> GetProductData()
        {
            // TODO: перейти на XML или JSON
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("History.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is List<WarehouseHistory> history)
                {
                    return history;
                }
                else
                {
                    return new List<WarehouseHistory>();
                }
                // TODO: если пользователя не прочитали
            }
        }
        public bool IsSave()
        {
            // TODO: перейти на XML или JSON
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("History.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, _warehouseHistory);
            }
            return true;
        }

        #endregion
    }
}
