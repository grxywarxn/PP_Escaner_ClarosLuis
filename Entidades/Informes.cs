using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Informes
    {
        private static void MostrarPorEstado(Escaner e, Documento.Paso estado, out int extension, out int cantidad, out string resumen)
        {

            extension = 0;
            cantidad = 0;
            resumen = string.Empty;
            foreach (Documento d in e.ListaDocumentos)
            {
                if (d.Estado == estado)
                {
                    switch (e.Tipo)
                    {
                        case Escaner.TipoDoc.mapa:
                            if (d is Mapa m)
                            {
                                extension += m.Superficie;
                                cantidad += 1;
                                resumen += m.ToString();
                            }
                            break;
                        case Escaner.TipoDoc.libro:
                            if (d is Libro l)
                            {
                                extension += l.NumPaginas;
                                cantidad += 1;
                                resumen += l.ToString();
                            }
                            break;
                        default:

                            break;
                    }

                }
            }
            Console.WriteLine($"Extensión: {extension}\nCantidad: {cantidad}\nResumen: \n{resumen}\n");
        }


        public static void MostrarDistribuidos(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarPorEstado(e, Documento.Paso.Distribuido, out extension, out cantidad, out resumen);
        }

        public static void MostrarEnEscaner(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarPorEstado(e, Documento.Paso.EnEscaner, out extension, out cantidad, out resumen);
        }

        public static void MostrarEnRevision(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarPorEstado(e, Documento.Paso.EnRevision, out extension, out cantidad, out resumen);
        }

        public static void MostrarTerminados(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarPorEstado(e, Documento.Paso.Terminado, out extension, out cantidad, out resumen);
        }
    }
}
