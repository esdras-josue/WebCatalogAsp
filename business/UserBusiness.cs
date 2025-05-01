using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain;

namespace business
{
    public class UserBusiness
    {
        public int InsertNewUser(User user)
        {
            DataAcces datas = new DataAcces();
            try
            {
                datas.SetQuery("INSERT INTO USERS (email,nombre,pass,admin) OUTPUT INSERTED.id values (@email,@nombre,@pass,0)");
                datas.AddParameter("@email",user.Email);
                datas.AddParameter("@nombre", user.Name);
                datas.AddParameter("@pass", user.Password);

                int newUserId = (int)datas.ExecuteScalar();
                return newUserId;


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datas.CloseConnection();
            }
        }

        public bool Login(User user)
        {
            DataAcces data = new DataAcces();

            try
            {
                data.SetQuery("SELECT Id, TypeUser WHERE email = @email AND pass = @password");
                data.AddParameter("@email", user.Email);
                data.AddParameter("@pass",user.Password);
                data.ExecuteNonQuery();

                while(data.Reader.Read())
                {
                    user.Id = (int)data.Reader["Id"];
                    user.TypeUser = (int)(data.Reader["TypeUser"]) == 2 ? TypeUser.administrator : TypeUser.user;
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.CloseConnection();
            }

        }
        
    }
}
