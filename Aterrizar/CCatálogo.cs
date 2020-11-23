using System;
using System.Collections;
namespace Aterrizar
{
    class CCatálogo
    {
        private ArrayList listado;
        public CCatálogo()
        {
            this.listado = CBDVuelos.ObtenerVuelos();
            CAereo.SetImpuesto(CBDImpuestos.ObtenerImpuesto("impAer"));
        }
        public void SetImpuesto(float monto)
        {
            CAereo.SetImpuesto(monto);
            CBDImpuestos.GuardarImpuesto("impAer",monto);
        }
        public float GetImpuesto()
        {
           return CAereo.GetImpuesto();
        }
        public bool Registrar(string cod, string ori, string des, float pre, ETiposVuelo tV)
        {
            foreach (CAereo aux in this.listado)
            {
                if (aux.GetCodigo() == cod) return false;
            }
            this.listado.Add(new CAereo(cod, ori, des, pre, tV));
            CBDVuelos.GuardarVuelo(cod, ori, des, pre, tV.ToString());
            return true;
        }
        public bool Remover(string cod)
        {
            foreach (CAereo aux in this.listado)
            {
                if (aux.GetCodigo() == cod)
                {
                    this.listado.Remove(aux);
                    CBDVuelos.EliminarVuelo(cod);
                    return true;
                }
            }
            return false;
        }
        public string Mostrar(string cod)
        {
            foreach (CAereo aux in this.listado)
            {
                if (aux.GetCodigo() == cod)
                {
                    return aux.ToString();
                }
            }
            return "Vuelo inexistente";
        }
        public void Ordenar()
        {
            this.listado.Sort();
        }
        public string Mostrar()
        {
            string datos="";
            foreach (CAereo aux in this.listado)
            {
                datos += aux.ToString() + "\n";
            }
            return datos;
        }
        public void Remover()
        {
            this.listado.Clear();
            CBDVuelos.EliminarVuelos();
        }
    }
}
