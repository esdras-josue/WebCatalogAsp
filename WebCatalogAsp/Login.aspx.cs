using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using business;
using domain;

namespace WebCatalogAsp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User user = new User();
            UserBusiness userBusiness = new UserBusiness();

            try
            {
                if(string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassord.Text)){
                    Session.Add("Error","email or password incorrect");
                }

                user.Email = txtEmail.Text;
                user.Password = txtPassord.Text;

                if (userBusiness.Login(user))
                {
                    Session.Add("user",user);
                    Response.Redirect("Homes.aspx", false); // hacer rediriccion a mi perfil por ahora a home;
                }
            }
            catch (Exception ex)
            {

                Session.Add("Error",ex.ToString());
            }
        }
    }
}