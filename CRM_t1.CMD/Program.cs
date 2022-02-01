using System;
using CRM_t1.BL.Controller;

namespace CRM_t1.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Приложение запущено");
            MenuF();
        }
        static void MenuF()
        {
            for (; ; )
            {
                Console.WriteLine();
                Console.WriteLine("Выберите действие (-h помощь)");
                var str = Console.ReadLine();
                switch (str)
                {
                    case "-a":
                        AllUsee();
                        break;
                    case "-n":
                        NewUsee();
                        break;
                    case "-li":
                        LogIn();
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
        static void AllUsee()
        {
            var userController = new UserController();
            for (int i = 0; userController._users.Count > i; i++)
            {
                Console.WriteLine(userController._users[i]);
            }
        }
        static void NewUsee()
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
        static void LogIn()
        {
            Console.Write("ID (последние 4 цифры телефона): ");
            int id = Convert.ToInt32(Console.ReadLine()); //TODO: проверка
            Console.Write("Пароль: ");
            var password = Console.ReadLine();

            var userController = new UserController(id, password);
        }
        static void Hellp()
        {
            Console.WriteLine(
                            $"-li войти в систему\n" +
                            $"-n новый пользователь\n" +
                            $"-h помощь\n" +
                            $"-e выход\n");
        }
        static void NewUseeTest()
        {

            var name = "TestTest";
            var password = "TestTest";
            int phoneNumber = 957344556;

            var userController = new UserController(name, password, phoneNumber);
            Console.WriteLine();
            userController.Save();
        }

    }
}
