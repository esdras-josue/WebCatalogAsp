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
    public partial class Products : System.Web.UI.Page
    {
        public bool getFilteredProduct {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Security.isAdmin((User)Session["user"]))
            {
                Session.Add("Error","You need admin credentials to access this Windown");
                Response.Redirect("Error.aspx");
            }
            
            getFilteredProduct = chkFilteredProduct.Checked;
            if (!IsPostBack)
            {
                // cargar la lista de productos
                ProductService products = new ProductService();
                Session.Add("ProductsList", products.GetProducts());
                dgvProducts.DataSource = Session["ProductsList"]; // origen de datos
                dgvProducts.DataBind(); // renderiza los productos en la grilla
            }


        }

        protected void dgvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvProducts.SelectedDataKey.Value.ToString();
            Response.Redirect("ProductForm.aspx?id=" + id);
        }

        protected void dgvProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void filter_TextChanged(object sender, EventArgs e)
        {
            List<Product> productList = (List<Product>)Session["ProductsList"];
            List<Product> filterList = productList.FindAll(x=>x.Name.ToUpper().Contains(filter.Text.ToUpper()));
            dgvProducts.DataSource = filterList;
            dgvProducts.DataBind(); 
        }

        protected void chkFilteredProduct_CheckedChanged(object sender, EventArgs e)
        {
            getFilteredProduct = chkFilteredProduct.Checked;
            filter.Enabled = !chkFilteredProduct.Checked;
        }

        protected void ddlField_SelectedIndexChanged(object sender, EventArgs e)
        {
             ddlSearchBy.Items.Clear();
             if (ddlField.SelectedItem.ToString() == "Price")
             {
                ddlSearchBy.Items.Add("Greater than");
                ddlSearchBy.Items.Add("Less than");
                ddlSearchBy.Items.Add("Equal than");
             }

            else
            {
                ddlSearchBy.Items.Add("Starts With");
                ddlSearchBy.Items.Add("Ends With");
                ddlSearchBy.Items.Add("Constains With");
            } 

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ProductService service = new ProductService();
                dgvProducts.DataSource = service.GetFilteredProduct(ddlField.SelectedItem.ToString(),
                ddlSearchBy.SelectedItem.ToString(),
                txtGetFilteredProduct.Text);
                dgvProducts.DataBind();
                
            }
            catch (Exception ex)
            {

                Session.Add("error",ex);
            }
        }

        protected void btnClean_Click(object sender, EventArgs e)
        {
            ProductService products = new ProductService();
            Session.Add("ProductsList", products.GetProducts());
            dgvProducts.DataSource = Session["ProductsList"]; // origen de datos
            dgvProducts.DataBind(); // renderiza los productos en la grilla
            ddlSearchBy.Items.Clear();
            txtGetFilteredProduct.Text = string.Empty;

        }

        protected void btnCleanSearch_Click(object sender, EventArgs e)
        {
            ProductService products = new ProductService();
            Session.Add("ProductsList", products.GetProducts());
            dgvProducts.DataSource = Session["ProductsList"]; // origen de datos
            dgvProducts.DataBind(); // renderiza los productos en la grilla
            ddlSearchBy.Items.Clear();
            filter.Text = string.Empty;
        }
        
        /*
        protected void dgvProducts_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
        */

    }
}