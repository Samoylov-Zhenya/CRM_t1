using System;

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
                Console.WriteLine("Выберите действие (-h помощь)");
                var str = Console.ReadLine();
                switch (str)
                {
                    case "-n":
                        NewUsee();
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
        static void NewUsee()
        {

        }
        static void Hellp()
        {
            Console.WriteLine(
                            $"-n новый пользователь\n" +
                            $"-h помощь\n" +
                            $"-e выход\n");
        }
    }
}
