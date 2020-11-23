using System;
using System.Data;
using System.Data.OleDb;
using System.Collections;

namespace Aterrizar
{
    class CBDVuelos
    {

        private static string cadConexion = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = \".\\BDAterrizar.accdb\"";//Archivo de BD en la carpeta de la aplicación .\bin\Debug
        public static ArrayList ObtenerVuelos()
        {
            OleDbConnection conexion;
            OleDbCommand comando;
            OleDbDataReader lector;
            ArrayList vuelos = null;
            try
            {
                vuelos = new ArrayList();
                conexion = new OleDbConnection(CBDVuelos.cadConexion);
                conexion.Open();
                if (conexion.State == ConnectionState.Open)
                {
                    string consultaSQL = "SELECT * FROM Vuelos;";
                    comando = new OleDbCommand(consultaSQL, conexion);
                    lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        string codigo, origen, destino, tipoVuelo;
                        float precio;
                        ETiposVuelo tVuelo;
                        codigo = (string)lector.GetValue(0);
                        origen = (string)lector.GetValue(1);
                        destino = (string)lector.GetValue(2);
                        precio = (float)lector.GetValue(3);
                        tipoVuelo = (string)lector.GetValue(4);
                        if (tipoVuelo == "Cabotaje") tVuelo = ETiposVuelo.Cabotaje;
                        else tVuelo = ETiposVuelo.Internacional;
                        vuelos.Add(new CAereo(codigo, origen, destino, precio, tVuelo));
                    }
                }
                conexion.Close();
                return vuelos;
            }
            catch (Exception excepcion)
            {
                Console.Write(excepcion.Message);
                Console.ReadLine();
                return vuelos;
            }
        }
        public static void GuardarVuelo(string codigo, string origen, string destino, float precio, string TipoVuelo)
        {
            OleDbConnection conexion;
            OleDbCommand comando;
            try
            {
                conexion = new OleDbConnection(CBDVuelos.cadConexion);
                conexion.Open();
                if (conexion.State == ConnectionState.Open)
                {
                    string strPrecio = precio.ToString().Replace(',', '.');
                    string comandoSQL = string.Format("INSERT INTO Vuelos (Codigo, Origen, Destino, Precio, TipoVuelo) VALUES (\"{0}\", \"{1}\", \"{2}\", {3}, \"{4}\");", codigo, origen, destino, strPrecio, TipoVuelo);
                    comando = new OleDbCommand(comandoSQL, conexion);
                    comando.ExecuteNonQuery();
                }
                conexion.Close();
            }
            catch (Exception excepcion)
            {
                Console.Write(excepcion.Message);
                Console.ReadLine();
            }
        }
        public static void EliminarVuelo(string codigo)
        {
            OleDbConnection conexion;
            OleDbCommand comando;
            try
            {
                conexion = new OleDbConnection(CBDVuelos.cadConexion);
                conexion.Open();
                if (conexion.State == ConnectionState.Open)
                {
                    string comandoSQL = string.Format("DELETE * FROM Vuelos WHERE Codigo=\"{0}\";", codigo);
                    comando = new OleDbCommand(comandoSQL, conexion);
                    comando.ExecuteNonQuery();
                }
                conexion.Close();
            }
            catch (Exception excepcion)
            {
                Console.Write(excepcion.Message);
                Console.ReadLine();
            }
        }
        public static void EliminarVuelos()
        {
            OleDbConnection conexion;
            OleDbCommand comando;
            try
            {
                conexion = new OleDbConnection(CBDVuelos.cadConexion);
                conexion.Open();
                if (conexion.State == ConnectionState.Open)
                {
                    string comandoSQL = string.Format("DELETE * FROM Vuelos;");
                    comando = new OleDbCommand(comandoSQL, conexion);
                    comando.ExecuteNonQuery();
                }
                conexion.Close();
            }
            catch (Exception excepcion)
            {
                Console.Write(excepcion.Message);
                Console.ReadLine();
            }
        }

    }
}
