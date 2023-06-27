using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using acceso_datos;
using System.Data.OleDb;

namespace negocio
{
    public class UsuarioNegocio
    {
        public bool Loguear(Usuario usuario)
        {
            //AccesoDatos datos = new AccesoDatos();
            //datos.AccesoDatosAcc();
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
            return true;

        }
    }
}