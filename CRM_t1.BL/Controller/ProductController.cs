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

    public class ProductController
    {
        #region --- Поля ---

        public List<Product> _products { get; }
        public Product currentProducts { get; }
        #endregion
        #region --- Конструктор ---
        public ProductController()
        {
            _products = GetProductData();
        }
        
        public ProductController(int productsId) : this()
        {
            //TODO: проверка

            currentProducts = _products.SingleOrDefault(p => p.ID == productsId);

            if (currentProducts == null)
            {
                Console.ForegroundColor = ConsoleColor.Red; // устанавливаем цвет
                Console.WriteLine("Товар не найден :(");
                Console.ResetColor(); // сбрасываем в стандартный
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green; // устанавливаем цвет
                Console.WriteLine("Товар найден :)");
                Console.ResetColor(); // сбрасываем в стандартный
                Console.WriteLine(currentProducts);
            }
        }
        public ProductController(int productsId, string productsName, int productsCost, int productsPrice) : this()
        {
            // TODO: проверка
            var currentUser = new Product(productsId, productsName, productsCost, productsPrice);
            _products.Add(currentUser);
        }
        #endregion
        #region --- Методы ---

        private List<Product> GetProductData()
        {
            // TODO: перейти на XML или JSON
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("product.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is List<Product> product)
                {
                    return product;
                }
                else
                {
                    return new List<Product>();
                }
                // TODO: если пользователя не прочитали
            }
        }
        public bool Save()
        {
            // TODO: перейти на XML или JSON
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("product.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, _products);
            }
            return true;
        }

        #endregion
    }
}
/*public bool AllPrint(string str)
        {
            if (str != "qaz")
            {
                return false;
            }
            return true;
        }
        public bool Clear(string str)
        {
            if (str != "qazqaz")
            {
                return false;
            }
            var userController = new UserController();
            userController._users.Clear();
            userController.Save();
            return true;
        }*/