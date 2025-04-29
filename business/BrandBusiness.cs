using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain;

namespace business
{
    public class BrandBusiness
    {
        public List<Brand> BrandsList()
        {
            List<Brand> brandsList = new List<Brand>();
            DataAcces dataAcces = new DataAcces();

            try
            {
                dataAcces.SetQuery("SELECT Id,Descripcion FROM Marcas");
                dataAcces.ExecuteReader();

                while(dataAcces.Reader.Read())
                {
                    Brand brand = new Brand();
                    brand.Id = (int)dataAcces.Reader["Id"];
                    brand.Description = (string)dataAcces.Reader["Descripcion"];
                    brandsList.Add(brand);
                }

                return brandsList;
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
