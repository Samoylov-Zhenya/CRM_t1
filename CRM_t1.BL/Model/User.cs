using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_t1.BL.Model
{
    public class User
    {
        #region --- Поля  ---
        public int ID { get; }
        public string name { get; }
        public string password { get; }
        public int phoneNumber { get; }
        #endregion
        #region --- Конструктор ---
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
        #endregion
    }
}
