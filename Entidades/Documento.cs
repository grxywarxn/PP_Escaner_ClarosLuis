using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Documento
    {
        int anio;
        string autor;
        string barcode;
        Paso estado;
        string numNormalizado;
        string titulo;

        public int Anio { get => anio; }
        public string Autor { get => autor; }
        public string Barcode { get => barcode; }
        protected string NumNormalizado { get => numNormalizado; }
        public string Titulo { get => titulo; }
        public Paso Estado { get => estado; }

        public enum Paso
        {
            Inicio,
            Distribuido,
            EnEscaner,
            EnRevision,
            Terminado
        }

        public bool AvanzarEstado()
        {
            bool retorno = false;
            try
            {
                if (this.estado == Paso.Terminado)
                {
                    retorno = false;
                }
                else
                {
                    int estadoActual = (int)this.estado;

                    this.estado = (Paso)(estadoActual + 1);

                    retorno = true;
                }
            }


            catch (Exception ex)
            {
                Console.WriteLine($"error: {ex}");
            }

            return retorno;
        }

        public Documento(string titulo, string autor, int anio, string numNormalizado, string barcode)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anio = anio;
            this.numNormalizado = numNormalizado;
            this.barcode = barcode;
            this.estado = Paso.Inicio;
        }

        public override string ToString()
        {
            StringBuilder texto = new StringBuilder();

            texto.AppendLine($"Titulo: {this.Titulo}");
            texto.AppendLine($"Autor: {this.Autor}");
            texto.AppendLine($"Año: {this.Anio}");
            return texto.ToString();
        }

    }
}
