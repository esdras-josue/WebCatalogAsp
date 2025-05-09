using domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using business;

namespace WebCatalogAsp
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgAvatar.ImageUrl = "https://simg.nicepng.com/png/small/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png";
            if (!(Page is Login || Page is Default))
            {
                if (!Security.ActiveSession((User)Session["user"]))
                    Response.Redirect("Login.aspx", false); // If there is no active session, redirect to login
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            ProductService service = new ProductService();
            List<Product> productList = (List<Product>)Session["ProductsList"];
            List<Product> filterList = productList.FindAll(x => x.Name.ToUpper().Contains(SearchTextBox.Text.ToUpper()));
            // mostrar el resultado de la busqueda
            // <asp:Label ID="lblResultado" runat="server" CssClass="mt-2 d-block"></asp:Label> crear una lable para mostrar el resultado
        }
    }
}