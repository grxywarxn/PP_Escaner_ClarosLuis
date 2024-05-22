using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro : Documento
    {
        int numPaginas;

        public int NumPaginas { get => numPaginas; }

        public string ISBN { get => NumNormalizado; }

        public Libro(string titulo, string autor, int anio, string numNormalizado, string codebar, int numPaginas) : base(titulo, autor, anio, numNormalizado, codebar)
        {
            this.numPaginas = numPaginas;
        }


        public static bool operator ==(Libro l1, Libro l2)
        {
            return l1.Barcode == l2.Barcode || l1.ISBN == l2.ISBN || (l1.Autor == l2.Autor && l1.Titulo == l2.Titulo);
        }

        public static bool operator !=(Libro l1, Libro l2)
        {
            return !(l1 == l2);
        }
        public override string ToString()
        {
            StringBuilder texto = new StringBuilder();
            texto.Append(base.ToString());
            texto.AppendLine($"ISBN: {this.ISBN}");
            texto.AppendLine($"Cód. de barras: {this.Barcode}");
            texto.AppendLine($"Número de páginas: {this.NumPaginas}.\n");
            return texto.ToString();
        }
    }
}
