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
                data.SetQuery("SELECT Id, email,pass,admin,nombre,apellido,urlImagenPerfil FROM USERS WHERE email = @email AND pass = @password");
                data.AddParameter("@email", user.Email);
                data.AddParameter("@password", user.Password);
                data.ExecuteReader();

                while(data.Reader.Read())
                {
                    user.Id = data.Reader["Id"].ToString();
                    user.IsAdmin = (bool)data.Reader["admin"];
                    user.Name = data.Reader["nombre"].ToString();
                    user.Lastname = data.Reader["apellido"].ToString();
                    if (!(data.Reader["urlImagenPerfil"] is DBNull))
                        user.ProfileImage = (string)data.Reader["urlImagenPerfil"];

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

        public void Update(User user)
        {
            DataAcces data = new DataAcces();
            try
            {
                data.SetQuery("Update USERS SET urlImagenPerfil = @imagen, Nombre = @nombre, Apellido = @apellido, WHERE Id = @id");
                data.AddParameter("@imagen", user.ProfileImage != null ? user.ProfileImage : (object)DBNull.Value);
                data.AddParameter("@nombre", user.Name);
                data.AddParameter("@apellido", user.Lastname);
                data.AddParameter("@id", user.Id);
                data.ExecuteNonQuery();
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
