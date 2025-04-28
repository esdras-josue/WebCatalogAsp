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
            dgvProducts.DataSource = products.GetProducts(); // origen de datos
            dgvProducts.DataBind(); // renderiza los productos en la grilla

        }

        protected void dgvProducts_SelectedIndexChanged(object sender, GridViewSelectEventArgs e)
        {
            var id = dgvProducts.SelectedValue.ToString();
            Response.Redirect("ProductForm.aspx?id=" + id);
        }

        protected void dgvProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        /*
        protected void dgvProducts_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
        */

    }
}