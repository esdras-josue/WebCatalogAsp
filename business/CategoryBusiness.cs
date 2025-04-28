using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain;

namespace business
{
    public class CategoryBusiness
    {
        public List<Category> categories()
        {
            DataAcces dataAcces = new DataAcces();
            List<Category> categoriesList = new List<Category>();

            try
            {
                dataAcces.SetQuery("SELECT Id, Descripcion FROM categorias");
                dataAcces.ExecuteReader();

                while (dataAcces.Reader.Read())
                {
                    Category category = new Category();
                    category.Id = (int)dataAcces.Reader["Id"];
                    category.Description = (string)dataAcces.Reader["Descripcion"];
                    categoriesList.Add(category);
                }

                return categoriesList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                dataAcces.CloseConnection();    
            }   
        }
    }
}
