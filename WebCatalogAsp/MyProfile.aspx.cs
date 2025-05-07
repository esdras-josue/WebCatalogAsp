using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using domain;

namespace WebCatalogAsp
{
    public partial class MyProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Intenta obtener el objeto 'user' desde la sesión.
            // Si existe, lo convierte a tipo User. Si no existe, asigna null.
            User user = Session["user"] != null ? (User)Session["user"] : null;

            // Verifica si el usuario es inválido:
            // La condición '!(user != null && !string.IsNullOrEmpty(user.Id))' se cumple si:
            // - 'user' es null (no hay nadie en sesión), o
            // - 'user.Id' es null o una cadena vacía (no tiene un ID válido).
            if (!(user != null && !string.IsNullOrEmpty(user.Id)))
            {
                Response.Redirect("Login.aspx", false);
            }
        }
    }
}