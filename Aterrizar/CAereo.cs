namespace Aterrizar
{
    class CAereo:CViaje
    {
        
        private static float impuesto;
        private ETiposVuelo tipoVuelo ;
        public static void SetImpuesto (float imp)
        {
            CAereo.impuesto = imp;
        }
        public static float GetImpuesto()
        {
            return CAereo.impuesto;
        }
        public CAereo(string cod, string ori, string des, float pre, ETiposVuelo tV) : base(cod, ori, des)
        {
            this.PrecioViaje = pre;
            this.tipoVuelo = tV;
        }
        public override string ToString()
        {
            return base.ToString() + " - (IMP $: " + CAereo.impuesto.ToString() + ") - " + this.tipoVuelo.ToString();
        }
    }
}
