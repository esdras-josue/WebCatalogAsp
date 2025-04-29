using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using domain;
using business;

namespace WebCatalogAsp
{
    public partial class ProductForm : System.Web.UI.Page
    {
        public bool ConfirmElimination { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            ConfirmElimination = false;
            // Load DropDownList
            try
            {
                if (!IsPostBack)
                {
                    BrandBusiness brandBusiness = new BrandBusiness();
                    List<Brand> brandList = brandBusiness.BrandsList();
                    ddlBrand.DataSource = brandList;
                    ddlBrand.DataValueField = "Id";
                    ddlBrand.DataTextField = "Description";
                    ddlBrand.DataBind();

                    CategoryBusiness categoryBusiness = new CategoryBusiness();
                    List<Category> ListCategories = categoryBusiness.CategoriesList();

                    ddlCategory.DataSource = ListCategories;
                    ddlCategory.DataValueField = "Id";
                    ddlCategory.DataTextField = "Description";
                    ddlCategory.DataBind();
                }
                if (!string.IsNullOrEmpty(Request.QueryString["id"]) && !IsPostBack)
                {
                    if (int.TryParse(Request.QueryString["id"], out int productId))
                    {
                        try
                        {
                            ProductService productService = new ProductService();
                            Product selectedProduct = productService.GetProductById(productId);

                            if (selectedProduct != null)
                            {
                                // Cargar los campos con los datos del producto
                                // Por ejemplo:
                                txtId.Text = selectedProduct.Id.ToString();
                                txtCode.Text = selectedProduct.Code;
                                txtName.Text = selectedProduct.Name;
                                txtDescription.Text = selectedProduct.Description;
                                //imgProduct.ImageUrl = selectedProduct.ImageUrl;
                                txtUrlImage.Text = selectedProduct.ImageUrl;
                                txtPrice.Text = selectedProduct.Price.ToString("F2");
                                ddlBrand.SelectedValue = selectedProduct.Brand.Id.ToString();
                                ddlCategory.SelectedValue = selectedProduct.Category.Id.ToString();
                                txtUrlImage_TextChanged(sender, e);
                            }
                        }
                        catch (Exception ex)
                        {
                            // Aquí puedes loggear el error o mostrar un mensaje amigable
                            Session.Add("error", ex);
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
                throw;
            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = new Product();
                ProductService productService = new ProductService();
                product.Code = txtCode.Text;
                product.Name = txtName.Text;
                product.Brand = new Brand();
                product.Brand.Id = int.Parse(ddlBrand.SelectedValue);
                product.Category = new Category();
                product.Category.Id = int.Parse(ddlCategory.SelectedValue);
                product.Description = txtDescription.Text;
                product.Price = decimal.Parse(txtPrice.Text);
                product.ImageUrl = txtUrlImage.Text;

                productService.AddArticles(product);
                Response.Redirect("ProductsList.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
                throw;
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            ProductService productService = new ProductService();
            product.Code = txtCode.Text;
            product.Name = txtName.Text;
            product.Brand = new Brand();
            product.Brand.Id = int.Parse(ddlBrand.SelectedValue);
            product.Category = new Category();
            product.Category.Id = int.Parse(ddlCategory.SelectedValue);
            product.Description = txtDescription.Text;
            product.Price = decimal.Parse(txtPrice.Text);
            product.ImageUrl = txtUrlImage.Text;

            if (Request.QueryString["id"] != null)
            {
                product.Id = int.Parse(txtId.Text);
                productService.ModifyProduct(product);
                Response.Redirect("ProductsList.aspx", false);
            }
        }

        protected void txtUrlImage_TextChanged(object sender, EventArgs e)
        {
            imgProduct.ImageUrl = txtUrlImage.Text;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ConfirmElimination = true;
        }

        protected void btnConfirmElimination_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmDelete.Checked)
                {
                    ProductService service = new ProductService();
                    service.DeleteProduct(int.Parse(txtId.Text));
                    Response.Redirect("ProductsList.aspx", false);
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }
    }
}