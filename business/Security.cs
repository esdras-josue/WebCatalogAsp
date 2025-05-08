using domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace business
{
    public static class Security
    {
        public static bool ActiveSession(User user)
        {
            // Intenta obtener el objeto 'user' desde la sesión.
            // Si existe, lo convierte a tipo User. Si no existe, asigna null.
            User userSession = user != null ? (User) user : null;

            // Verifica si el usuario es inválido:
            // La condición '!(user != null && !string.IsNullOrEmpty(user.Id))' se cumple si:
            // - 'user' es null (no hay nadie en sesión), o
            // - 'user.Id' es null o una cadena vacía (no tiene un ID válido).
            if (user != null && !string.IsNullOrEmpty(user.Id)) // sesion activa
            {
                return true;
            }
            else
            {
                return false; 
            }
        }

        public static bool isAdmin(User user)
        {
            User userActive = user != null ? user : null;
            return user != null ? user.IsAdmin : false;
        }

    }
}
