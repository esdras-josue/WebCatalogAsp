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
                    prod.Category = new Category();
                    prod.Category.Description = data.Reader["Item"].ToString();
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
            //DataAcces data = new DataAcces();

            try
            {
                data.SetQuery("INSERT INTO ARTICULOS (Codigo,Nombre ,Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio)" +
                    "VALUES(" + "@Codigo,@Nombre,@Descripcion,@IdMarca,@idCategoria, @ImagenUrl, @Precio)");
                data.AddParameter("@Codigo", article.Code);
                data.AddParameter("@Nombre", article.Name);
                data.AddParameter("@Descripcion", article.Description);
                data.AddParameter("@IdMarca", article.Brand.Id);
                data.AddParameter("@IdCategoria", article.Category.Id);
                data.AddParameter("@ImagenUrl", article.ImageUrl);
                data.AddParameter("@Precio", article.Price);
                data.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { data.CloseConnection(); }

        }

        public Product GetProductById(int id)
        {
            Product product = null;
            try
            {
                data.SetQuery(@"SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, 
                                M.Id as IdMarca, M.Descripcion as Marca, 
                                C.Id as IdCategoria, C.Descripcion as Item, 
                                A.ImagenUrl, A.Precio  
                                FROM ARTICULOS A 
                                INNER JOIN Marcas M ON M.Id = A.IdMarca 
                                INNER JOIN Categorias C ON C.Id = A.IdCategoria 
                                WHERE A.Id = @id");
                data.AddParameter("@id", id);
                data.ExecuteReader();

                if (data.Reader.Read())
                {
                    product = new Product();
                    product.Id = (int)data.Reader["Id"];
                    product.Code = data.Reader["Codigo"].ToString();
                    product.Name = data.Reader["Nombre"].ToString();
                    product.Description = data.Reader["Descripcion"].ToString();
                    product.Brand = new Brand();
                    product.Brand.Id = (int)data.Reader["IdMarca"];
                    product.Brand.Description = data.Reader["Marca"].ToString();
                    product.Category = new Category();
                    product.Category.Id = (int)data.Reader["IdCategoria"];
                    product.Category.Description = data.Reader["Item"].ToString();
                    product.ImageUrl = data.Reader["ImagenUrl"].ToString();
                    product.Price = (decimal)data.Reader["Precio"];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.CloseConnection();
            }

            return product;
        }

        public void ModifyProduct(Product article)
        {
            try
            {
                data.SetQuery("UPDATE ARTICULOS SET Codigo= @codigo,Nombre= @nombre, Descripcion=@descripcion,IdMarca=@idMarca,Idcategoria=@idCategoria,ImagenUrl=@imagenUrl, Precio=@precio WHERE ID = @id");
                data.AddParameter("@codigo", article.Code);
                data.AddParameter("@nombre", article.Name);
                data.AddParameter("@descripcion",article.Description);
                data.AddParameter("@idMarca",article.Brand.Id);
                data.AddParameter("@idCategoria", article.Category.Id);
                data.AddParameter("@imagenUrl",article.ImageUrl);
                data.AddParameter("@precio", article.Price);
                data.AddParameter("@id", article.Id);
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
        public void DeleteProduct(int id)
        {
            data.SetQuery("DELETE FROM ARTICULOS WHERE Id = @id");
            data.AddParameter("@id", id);
            data.ExecuteNonQuery();
        }

        public void Disable(int id)
        {
            data.SetQuery("DELETE FROM ARTICULOS WHERE Id = @id");
            data.AddParameter("@id", id);
            data.ExecuteNonQuery();
        }
        // metodo para para modificar articulo
        // metodo para elimianar  articulo
        // metodo para eliminacion logica
        // metodo para filtrar articulos
    }
}
