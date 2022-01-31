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
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public User user { get; }
        #endregion
        #region --- Конструктор ---
        /// <summary>
        /// Создание нового пользователя.
        /// </summary>
        /// <param name="User"> Пользователь. </param>
        /// <exception cref="ArgumentNullException">Пользователь не может быть Null</exception>
        public UserController(User User)
        {
            user = User ?? throw new ArgumentNullException("Пользователь не может быть Null", nameof(User));
        }
        #endregion
        #region --- Методы ---
        /// <summary>
        /// Сохранить данные пользователя (сериализация .dat).
        /// </summary>
        /// <returns></returns>
        public bool IsSave()
        {
            // TODO: перейти на XML или JSON
            // пока что только 1 пользователь доступен для cериализации.
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, user);
            }
            return true;
        }
        /// <summary>
        /// Получить данные пользователя (сериализация .dat).
        /// </summary>
        /// <returns> Пользователь или NULL. </returns>
        public User Load()
        {
            // TODO: перейти на XML или JSON
            // пока что только 1 пользователь доступен для десериализации.
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                return formatter.Deserialize(fs) as User;
            }
        }
        #endregion
    }
}
