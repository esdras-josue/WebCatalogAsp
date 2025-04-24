using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain;

namespace business
{
    /// <summary>
    /// Provides methods to interact with the SQL Server database.
    /// Supports executing queries, non-queries, and managing connections.
    /// </summary>

    public class DataAcces
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        /// <summary>
        /// Gets the SqlDataReader used to read query results.
        /// </summary>
        public SqlDataReader Reader
        {
            get { return reader; }
        }

        /// <summary>
        /// Initializes a new instance of the DataAcces class.
        /// Sets up the connection and command objects for future queries.
        /// </summary>
        public DataAcces()
        {
            connection = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_WEB_DB; integrated security=true");
            command = new SqlCommand();
        }


        /// <summary>
        /// Prepares an SQL query to be executed.
        /// </summary>
        /// <param name="consulta">The SQL query string to be executed.</param>
        public void SetQuery(string consulta)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consulta;
        }

        /// <summary>
        /// Executes the current query and initializes the SqlDataReader with the results.
        /// </summary>
        public void ExecuteReader()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Parameters.Clear();
            }

        }

        /// <summary>
        /// Executes a command that does not return results (e.g., INSERT, UPDATE, DELETE).
        /// </summary>
        public void ExecuteNonQuery()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                command.Parameters.Clear();
            }

        }

        /// <summary>
        /// Adds a parameter to the current command.
        /// Useful for parameterized queries to prevent SQL injection.
        /// </summary>
        /// <param name="nombre">The name of the parameter (e.g., "@id").</param>
        /// <param name="valor">The value of the parameter.</param>
        public void AddParameter(string nombre, object valor)
        {
            command.Parameters.AddWithValue(nombre, valor);

        }

        /// <summary>
        /// Closes the open reader and database connection.
        /// </summary> 
        public void CloseConnection()
        {
            if (reader != null)
                reader.Close();
            connection.Close();
        }
    }
}
