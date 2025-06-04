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
    public partial class MyProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Security.ActiveSession((User)Session["user"]))
                    {
                        User user = (User)Session["user"];
                        txtId.Text = user.Id;
                        txtId.ReadOnly = true;
                        txtEmail.Text = user.Email;
                        txtEmail.ReadOnly = true;
                        txtName.Text = user.Name;
                        txtLastName.Text = user.Lastname;
                        
                        if (!string.IsNullOrEmpty(user.ProfileImage))
                            imgUser.ImageUrl = "~/images/" + user.ProfileImage;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                UserBusiness userBusiness = new UserBusiness();
                User user = (User)Session["user"];

                if(txtImage.PostedFile.FileName != "")
                {
                    string path = Server.MapPath("./images/");
                    string fileName = "perfil-" + user.Id + ".jpg";
                    txtImage.PostedFile.SaveAs(path + fileName);
                    user.ProfileImage = fileName;
                }

                user.Name = txtName.Text;
                user.Lastname = txtLastName.Text;
               // user.DateBirth = DateTime.Parse(txtBirthDate.Text);

                userBusiness.Update(user);

                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/images/" +  user.ProfileImage;
                
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}