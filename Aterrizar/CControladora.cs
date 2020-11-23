using System;
namespace Aterrizar
{
    public class CControladora
    {
        public static void Main()
        {
            CCatálogo listadoVuelos = new CCatálogo();
            char opcion;
            string codigo;
            do
            {
                char.TryParse(CInterfaz.DarOpcion().ToUpper(), out opcion);
                //.ToUpper() Convierte la cadena a MAYÚSCULAS.
                switch (opcion)
                {
                    case 'E':
                        listadoVuelos.SetImpuesto(Convert.ToSingle(CInterfaz.PedirDato("Impuesto")));
                        break;
                    case 'C':
                        CInterfaz.MostrarInfo(Convert.ToString(listadoVuelos.GetImpuesto()));
                        break;
                    case 'A':
                        codigo = CInterfaz.PedirDato("Código de vuelo").ToUpper();
                        string origen = CInterfaz.PedirDato("Origen");
                        string destino = CInterfaz.PedirDato("Destino");
                        float precio =Convert.ToSingle( CInterfaz.PedirDato("Precio"));
                        string tV= CInterfaz.PedirDato("Cabotaje [C] - Internacional [I]");
                        ETiposVuelo tipoVuelo;
                        if (tV.ToUpper() == "C") tipoVuelo = ETiposVuelo.Cabotaje;
                        else tipoVuelo = ETiposVuelo.Internacional;

                        if (!listadoVuelos.Registrar(codigo, origen, destino, precio, tipoVuelo))
                        {
                            CInterfaz.MostrarInfo("Código de vuelo preexistente");
                        }
                        break;
                    case 'M':
                        codigo = CInterfaz.PedirDato("Código de vuelo").ToUpper();
                        CInterfaz.MostrarInfo(listadoVuelos.Mostrar(codigo));
                        break;
                     case 'L':
                        listadoVuelos.Ordenar();
                        CInterfaz.MostrarInfo(listadoVuelos.Mostrar());
                        break;
                    case 'R':
                        codigo = CInterfaz.PedirDato("Código de vuelo").ToUpper();
                        if (!listadoVuelos.Remover(codigo))
                        {
                            CInterfaz.MostrarInfo("Vuelo inexistente");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("Vuelo removido");
                        }
                        break;
                    case 'T':
                        listadoVuelos.Remover();
                        CInterfaz.MostrarInfo("Vuelos removidos");
                        break;
                    case 'S':
                        break;
                    default:
                        CInterfaz.MostrarInfo("Opción inválida");
                        break;
                }
            } while (opcion != 'S');
        }
    }
}

