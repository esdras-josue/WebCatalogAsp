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
        protected void Page_Load(object sender, EventArgs e)
        {
            // cargar la lista de productos
            ProductService products = new ProductService();
            Session.Add("ProductsList", products.GetProducts());
            dgvProducts.DataSource = Session["ProductsList"]; // origen de datos
            dgvProducts.DataBind(); // renderiza los productos en la grilla

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
            dgvProducts.DataSource= filterList;
            dgvProducts.DataBind(); 
        }

        /*
        protected void dgvProducts_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
        */

    }
}