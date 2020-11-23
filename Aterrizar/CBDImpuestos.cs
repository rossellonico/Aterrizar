using System;
using System.Data;
using System.Data.OleDb;

namespace Aterrizar
{
    class CBDImpuestos
    {
        private static string cadConexion = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = \".\\BDAterrizar.accdb\"";//Archivo de BD en la carpeta de la aplicación .\bin\Debug
        public static float ObtenerImpuesto(string codigo)
        {
            OleDbConnection conexion;
            OleDbCommand comando;
            OleDbDataReader lector;
            float monto = 0.0F;
            try
            {
                conexion = new OleDbConnection(CBDImpuestos.cadConexion);
                conexion.Open();
                if (conexion.State == ConnectionState.Open)
                {
                    string consultaSQL = string.Format("SELECT * FROM Impuestos WHERE Codigo=\"{0}\";", codigo);
                    comando = new OleDbCommand(consultaSQL, conexion);
                    lector = comando.ExecuteReader();
                    if (lector!=null)
                    {
                        lector.Read();
                        monto = (float)(lector.GetValue(2));
                    }
                }
                conexion.Close();
                return monto;
            }
            catch (Exception excepcion)
            {
                Console.Write(excepcion.Message);
                Console.ReadLine();
                return monto;
            }
        }
        public static void GuardarImpuesto(string codigo, float monto)
        {
            OleDbConnection conexion;
            OleDbCommand comando;
            try
            {
                conexion = new OleDbConnection(CBDImpuestos.cadConexion);
                conexion.Open();
                if (conexion.State == ConnectionState.Open)
                {
                    string strMonto = monto.ToString().Replace(',', '.');
                    string comandoSQL = string.Format("UPDATE Impuestos SET Monto={0} WHERE Codigo=\"{1}\";",strMonto,codigo);
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
