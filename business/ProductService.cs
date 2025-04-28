using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain;

namespace business
{
    /// <summary>
    /// Handles bussines logic related to products, acting as a service layer between 
    /// tha data access and the presentation layer
    /// </summary>
    public class ProductService
    {
        private DataAcces data;
        /// <summary>
        /// Initializes a new instance of the ProductService class.
        /// It creates a new DataAccess object for querying the database.
        /// </summary>
        public ProductService()
        {
            data = new DataAcces();
        }

        /// <summary>
        /// Retrieves a list of products from the database.
        /// Includes product details along with brand and category descriptions.
        /// </summary>
        /// <returns>List of Product objects populated from the database.</returns>
        public List<Product> GetProducts()
        {
            List<Product> product = new List<Product>();

            try
            {
                data.SetQuery
                    ("SELECT A.Id,A.Codigo,A.Nombre, A.Descripcion, M.Descripcion as Marca, C.Descripcion as Item, A.ImagenUrl,A.Precio " +
                    "From ARTICULOS A, Marcas M, CATEGORIAS C " +
                    "WHERE M.Id = A.IdMarca and C.Id = A.IdCategoria;"
                    );

                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    Product prod = new Product();
                    prod.Id = (int)data.Reader["Id"];
                    prod.Code = data.Reader["Codigo"].ToString();
                    prod.Name = data.Reader["Nombre"].ToString();
                    prod.Description = data.Reader["Descripcion"].ToString();
                    prod.Brand = new Brand();
                    prod.Brand.Description = data.Reader["Marca"].ToString();
                    prod.CategoryDescription = new Category();
                    prod.CategoryDescription.Description = data.Reader["Item"].ToString();
                    prod.ImageUrl = data.Reader["ImagenUrl"].ToString();
                    prod.Price = (decimal)data.Reader["Precio"];

                    product.Add(prod);
                }

                return product;
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

        public void AddArticles(Product article)
        {
            DataAcces data = new DataAcces();
            try
            {
                data.SetQuery("INSERT INTO ARTICULOS (Codigo,Nombre ,Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio)" +
                    "VALUES(" + "@Codigo,@Nombre,@Descripcion,@IdMarca,@idCategoria, @UrlImagen, @Precio)");
                data.AddParameter("@Codigo",article.Code);
                data.AddParameter("@Nombre", article.Name);
                data.AddParameter("@Descripcion", article.Description);
                data.AddParameter("@IdMarca", article.Brand.Id);
                data.AddParameter("@IdCategoria", article.CategoryDescription.Id);
                data.AddParameter("@ImagenUrl",article.ImageUrl);
                data.AddParameter("@Precio", article.Price);
                data.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { data.CloseConnection(); } 

        }
        
        // metodo para para modificar articulo
        // metodo para elimianar  articulo
        // metodo para eliminacion logica
        // metodo para filtrar articulos
    }
}
