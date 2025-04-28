using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using business;
using domain;

namespace WebCatalogAsp
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Product> productList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductService productService = new ProductService();
            productList = productService.GetProducts();
            if (!IsPostBack)
            {
                repeater.DataSource = productList;
                repeater.DataBind();    
            }
        }

        protected void btnProduct_Click(object sender, EventArgs e)
        {

        }
    }
}