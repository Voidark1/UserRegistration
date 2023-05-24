using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRegistration.Engine
{
    internal class RegUser_engine
    {
        public void RegUser(string username, string login, string password)
        {
            if (IsLogin(login) == true) throw new Exception("Такой логин уже есть в базе");
            if (string.IsNullOrEmpty(username)) throw new Exception("Задайте имя");
            if (string.IsNullOrEmpty(login)) throw new Exception("Задайте логин");
            if (string.IsNullOrEmpty(password)) throw new Exception("Задайте пароль");
            
            var userNew =  new DB.User();
            userNew.UserName = username.Trim();
            userNew.Password = password;
            userNew.Login = login.Trim();

            using DB.SQL_DB _Context = new DB.SQL_DB();

            try
            {
                _Context.Add(userNew);
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool IsLogin (string login)
        {
            using DB.SQL_DB _Context = new DB.SQL_DB();

            try
            {
                bool res = _Context.Users.Any(x => x.Login == login);
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal string Auth(string login, string pass)
        {
            if (IsLogin (login) == false)
                throw new Exception("Пользователь не найден");
                using DB.SQL_DB _Context = new DB.SQL_DB();

            try
            {
                return _Context.Users.Single(x => x.Login == login && x.Password == pass).UserName;
            }
            catch (Exception ex)
            {
                throw new Exception("Неверный логин или пароль");
            }
        }
    }
}
