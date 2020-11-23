using System;
namespace Aterrizar
{
    class CViaje:IComparable
    {
        private string codigo;
        private string origen;
        private string destino;
        private float precio;
        public CViaje(string cod, string ori, string des)
        {
            this.codigo = cod;
            this.origen = ori;
            this.destino = des;
        }
        public string GetOrigen()
        {
            return this.origen;
        }
        public string GetDestino()
        {
            return this.destino;
        }
        public string GetCodigo()
        {
            return this.codigo;
        }
        public float PrecioViaje
        {
            set { this.precio = value; }
            get { return this.precio; }
        }
        public float DarPrecio(ushort cuotas)
        {
            switch (cuotas)
            {
                case 1: return this.precio;
                case 3: return this.precio * 1.1F;
                case 6: return this.precio * 1.2F;
                case 12: return this.precio * 1.4F;
                default:
                    Exception miExcepcion= new Exception(String.Format("Cantidad de cuotas inválida ({0}) - Deben ser 1,3,6 o 12.", cuotas));
                    throw miExcepcion;
            }
        }
        public override string ToString()
        {
            return "[" + this.codigo + "] - " + this.origen + " => " + this.destino + " - $: " + this.precio.ToString();
        }
        public int CompareTo(object obj)
        {
            if (obj is CViaje)
            {
                return this.codigo.CompareTo(((CViaje)obj).codigo);
            }
            else
            {
                throw new Exception("Sólo se puede comparar instancias de CViaje");
            }
        }
        public override bool Equals(object obj)
        {
            if (obj is CViaje)
            {
                if (this.origen == ((CViaje)obj).GetOrigen() && this.destino == ((CViaje)obj).GetDestino()) return true;
                return false;
            }
            else
            {
                throw new Exception("Sólo se puede comparar instancias de CViaje");
            }
        }
        public override int GetHashCode()//Si la llamada a Equals para dos objetos devuelve true, entonces GetHashCode() debe devolver el mismo valor para ambos objetos.
        {
            return this.codigo.GetHashCode();
        }
  }
}
