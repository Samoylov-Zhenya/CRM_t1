﻿using CRM_t1.BL.Model;
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
        public User User { get; }
        #endregion
        #region --- Конструктор ---
        /// <summary>
        /// Создание нового пользователя.
        /// </summary>
        /// <param name="User"> Пользователь. </param>
        /// <exception cref="ArgumentNullException">Пользователь не может быть Null</exception>
        public UserController(User User)
        {
            this.User = User ?? throw new ArgumentNullException("Пользователь не может быть Null", nameof(User));
        }
        // TODO:переписать
        /// <summary>
        /// Получить данные пользователя (сериализация .dat).
        /// </summary>
        /// <returns> Пользователь или NULL. </returns>
        public UserController()
        {
            // TODO: перейти на XML или JSON
            // пока что только 1 пользователь доступен для десериализации.
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
                // TODO: если пользователя не прочитали
            }
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
                formatter.Serialize(fs, User);
            }
            return true;
        }
        
        #endregion
    }
}
