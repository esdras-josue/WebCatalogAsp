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
                if(string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text)){
                    Session.Add("Error","email or password incorrect");
                }

                user.Email = txtEmail.Text;
                user.Password = txtPassword.Text;

                if (userBusiness.Login(user))
                {
                    Session.Add("user",user);
                    Response.Redirect("MyProfile.aspx", false); // hacer rediriccion a mi perfil por ahora a home;
                }
                else
                {
                    Session.Add("error", "email or pass incorrect");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");

            }
        }
    }
}