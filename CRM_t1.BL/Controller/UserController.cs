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
    /// Контролер пользователя.
    /// </summary>
    public class UserController
    {
        #region --- Поля ---
        // небезопасно List<>
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public List<User> _users { get; }
        public User currentUser { get; }
        #endregion
        #region --- Конструктор ---
        public UserController()
        {
            _users = GetUsersData();
        }
        public UserController(int userId, string userPassword)
        {
            //TODO: проверка
            _users = GetUsersData();

            currentUser = _users.SingleOrDefault(u => u.ID == userId && u.password == userPassword);
        
            if (currentUser == null)
            {
                Console.ForegroundColor = ConsoleColor.Red; // устанавливаем цвет
                Console.WriteLine("Пользователь не найден :(");
                Console.ResetColor(); // сбрасываем в стандартный
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green; // устанавливаем цвет
                Console.WriteLine("Пользователь найден :)");
                Console.ResetColor(); // сбрасываем в стандартный
                Console.WriteLine(currentUser);
            }
        }
        /// <summary>
        /// Создание нового пользователя.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <param name="userPhoneNumber"></param>
        public UserController(string userName, string userPassword, int userPhoneNumber) : this()
        {
            // TODO: проверка
            var currentUser = new User(userName, userPassword, userPhoneNumber);
            _users.Add(currentUser);
        }
        #endregion
        #region --- Методы ---
        public bool AllPrint(string str)
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
        }
        // TODO:переписать
        /// <summary>
        /// Получить cписок пользователей (сериализация .dat).
        /// </summary>
        /// <returns> Список пользователей. </returns>
        private List<User> GetUsersData()
        {
            // TODO: перейти на XML или JSON
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                //if (fs.Length>0 && formatter.Deserialize(fs) is List<User> users)
                if (formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
                // TODO: если пользователя не прочитали
            }
        }
        /// <summary>
        /// Сохранить данные пользователя (сериализация .dat).
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            // TODO: перейти на XML или JSON
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, _users);
            }
            return true;
        }

        #endregion
    }
}
