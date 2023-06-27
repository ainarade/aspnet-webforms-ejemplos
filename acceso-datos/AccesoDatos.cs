using System;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace acceso_datos
{
    public class AccesoDatos
    {
        private SqlDataReader lector;
        public SqlDataReader Lector
        {
            get { return lector; }
        }
        public SqlConnection conexion { get; }
        private SqlCommand comando;

        public AccesoDatos()
        {
            //conexion = new SqlConnection("data source=.\\SQLEXPRESS; initial catalog=POKEDEX_DB2; integrated security=sspi");
            //comando = new SqlCommand();
            //comando.Connection = conexion;
        }
        public void AccesoDatosAcc()
        {
            string ruta = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Administrador\source\repos\login.mdb";
            string consulta = "SELECT * FROM palabras";
            // Create a connection    
            using (OleDbConnection conexion = new OleDbConnection(ruta))
            {
                // Create a command and set its connection    
                OleDbCommand comando = new OleDbCommand(consulta, conexion);
                // Open the connection and execute the select command.    
                try
                {
                    // Open connecton    
                    conexion.Open();
                    // Execute command    
                    using (OleDbDataReader miTabla = comando.ExecuteReader())
                    {
                        Console.WriteLine("------------Tabla Palabras----------------");
                        while (miTabla.Read())
                        {
                            /////EVOLUCIONAR!!!!
                            Console.WriteLine("{0} {1} {2} ", miTabla["id"], miTabla["usuario"].ToString(), miTabla["password"]);
                        }
                    }
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Problemicas txato!!" + ex.Message);
                }

            }
            System.Console.ReadKey();

        }

        public void setearQuery(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void setearSP(string sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }

        public void agregarParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void ejecutarLector()
        {
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ejecutarAccion()
        {
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void cerrarConexion()
        {
            if(conexion != null)
                conexion.Close();
        }


    }
}
