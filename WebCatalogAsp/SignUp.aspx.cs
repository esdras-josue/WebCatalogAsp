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
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                UserBusiness userBusiness = new UserBusiness();
                User user = new User();
                user.Email = txtEmail.Text;
                user.Name = txtName.Text;
                user.Password = txtPassword.Text;
                user.Id = userBusiness.InsertNewUser(user).ToString();
                Session.Add("user",user);


                Response.Redirect("Home.aspx",false);


            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
            }
        }
    }
}