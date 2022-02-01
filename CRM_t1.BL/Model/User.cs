using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_t1.BL.Model
{
    [Serializable]
    public class User
    {
        #region --- Поля  ---
        /// <summary>
        /// Артикул товара в системе или id.
        /// </summary>
        public int ID { get; }
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string name { get; }
        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        public string password { get; }//TODO: хранить хеш
        /// <summary>
        /// Номер телефона.
        /// </summary>
        public int phoneNumber { get; }
        #endregion
        #region --- Конструктор ---
        /// <summary>
        /// Создание нового пользователя.
        /// </summary>
        /// <param name="Name">Имя пользователя.</param>
        /// <param name="Password">Пароль пользователя.</param>
        /// <param name="PhoneNumber">Номер телефона.</param>
        public User(string Name, string Password, int PhoneNumber)
        {
            // TODO: проверка
            name = Name;
            password = Password;
            phoneNumber = PhoneNumber;
            ID = ConvertID(PhoneNumber);
        }
        #endregion
        #region --- Методы ---
        private int ConvertID(int strID)
        {
            // TODO: проверка
            string str = strID.ToString();
            strID = Convert.ToInt32(str.Substring(str.Length - 4));

            return strID;
        }
        public override string ToString()
        {
            
            return 
                $"\nID\t{ID} " +
                $"\nname\t{name} " +
                $"\npass\t{password} " +
                $"\nphone\t{phoneNumber} " +
                $"\nType\t{base.ToString()}";
        }
        #endregion
    }
}
