using CRM_t1.BL.Controller;
using CRM_t1.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_t1.CMD
{
    internal class Menu
    {
        private User user;

        public Menu()
        {
            MenuF();
        }
        public void MenuF()
        {
            for (; ; )
            {
                Console.WriteLine();
                Console.WriteLine("Выберите действие (-h помощь)");
                var str = Console.ReadLine();
                switch (str)
                {
                    case "-s":
                        Sale();
                        break;
                    case "-a":
                        AllUsee();
                        break;
                    case "-c":
                        Сlean();
                        break;
                    case "-nAdmin":
                        NewUseeTest();
                        break;
                    //////
                    case "-nu":
                        NewUsee();
                        break;
                    case "-li":
                        LogIn();
                        break;

                    case "-np":
                        NewProduct();
                        break;
                    case "-sp":
                        SearchProduct();
                        break;

                    case "-h":
                        Hellp();
                        break;
                    case "-e":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }

        private void Sale()
        {
            if (user == null)
            {
                Console.WriteLine("Войдите в систему");
                return;
            }
            Console.Write("Id товара: ");
            int.TryParse(Console.ReadLine(), out int id);

            Console.Write("Цена: ");
            int.TryParse(Console.ReadLine(), out int price);

            Console.Write("Количество: ");
            int.TryParse(Console.ReadLine(), out int quantity);

            var history = new WarehouseHistoryController(user.ID, id, price, quantity);

            Console.WriteLine("Продано");
        }
        private void SearchProduct()
        {
            Console.Write("Id: ");
            int.TryParse(Console.ReadLine(), out int id);

            var productController = new ProductController(id);
        }
        private void NewProduct()
        {
            Console.Write("Id: ");
            int.TryParse(Console.ReadLine(), out int id);


            Console.Write("Название продукта: ");
            var name = Console.ReadLine();

            Console.Write("Цена в закупке: ");
            int.TryParse(Console.ReadLine(), out int cost);


            Console.Write("Цена продажи: ");
            int.TryParse(Console.ReadLine(), out int price);



            var productController = new ProductController(id, name, cost, price);

            if (productController.Save())
            {
                Console.WriteLine("Успешно сохранён товар");
            }
            else
            {
                Console.WriteLine("Ошибка");
            }
        }
        private void NewUsee()
        {
            Console.Write("Имя пользователя: ");
            var name = Console.ReadLine();
            if (name.Length < 3)
            {
                Console.WriteLine("Ошибка короткое имя");
                return;
            }

            Console.Write("Пароль: ");
            var password = Console.ReadLine();
            if (password.Length < 2)
            {
                Console.WriteLine("Ошибка короткий пароль");
                return;
            }


            Console.Write("Номер телофона: ");
            int phoneNumber;
            int.TryParse(Console.ReadLine(), out phoneNumber);

            var userController = new UserController(name, password, phoneNumber);
            if (userController.Save())
            {
                Console.WriteLine("Успешно сохранён пользователь");
            }
            else
            {
                Console.WriteLine("Ошибка");
            }
        }
        private void LogIn()
        {
            Console.Write("ID (последние 4 цифры телефона): ");
            int id = Convert.ToInt32(Console.ReadLine()); //TODO: проверка
            Console.Write("Пароль: ");
            var password = Console.ReadLine();

            var Cuser = new UserController(id, password);
            user = Cuser.currentUser;
        }
        private void Hellp()
        {
            Console.WriteLine(
                            $"-li войти в систему\n" +
                            $"-nu новый пользователь\n" +
                            $"-np новый продукт\n" +
                            $"-sp поиск товара\n" +
                            $"-s  продажа\n" +
                            $"-h  помощь\n" +
                            $"-e  выход\n"
                           );
        }


        #region --- для админа ---
        private void Сlean()
        {
            Console.WriteLine("Пароль");
            var userController = new UserController();
            if (userController.Clear(Console.ReadLine()))
            {
                Console.WriteLine("Очистка завершина");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; // устанавливаем цвет
                Console.WriteLine("Неправильный пароль");
                Console.ResetColor(); // сбрасываем в стандартный
                return;
            }
        }
        private void NewUseeTest()
        {

            var name = "TestTest";
            var password = "TestTest";
            int phoneNumber = 957344556;

            var userController = new UserController(name, password, phoneNumber);
            Console.WriteLine();
            userController.Save();
        }
        private void AllUsee()
        {

            Console.WriteLine("Пароль");
            var userController = new UserController();
            if (userController.AllPrint(Console.ReadLine()))
            {
                for (int i = 0; userController._users.Count > i; i++)
                {
                    Console.WriteLine(userController._users[i]);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; // устанавливаем цвет
                Console.WriteLine("Неправильный пароль");
                Console.ResetColor(); // сбрасываем в стандартный
                return;
            }
        }
        #endregion
    }
}
