using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Escaner
    {
        List<Documento> listaDocumentos;
        Departamento locacion;
        string marca;
        TipoDoc tipo;
        public enum Departamento
        {
            nulo,
            mapoteca,
            procesosTecnicos
        }

        public enum TipoDoc
        {
            libro,
            mapa
        }


        public List<Documento> ListaDocumentos { get => listaDocumentos; }
        public string Marca { get => marca; }
        public Departamento Locacion { get => locacion; }
        public TipoDoc Tipo { get => tipo; }

        public bool CambiarEstadoDocumento(Documento d)
        {
            bool retorno = false;
            foreach(Documento doc in listaDocumentos)
            {
                if (doc == d)
                {
                    d.AvanzarEstado();
                    retorno = true;
                }
            }
            return retorno;
        }
        public Escaner(string marca, TipoDoc tipo)
        {
            this.marca = marca;
            this.tipo = tipo;
            this.listaDocumentos = new List<Documento>();

            if (tipo == TipoDoc.libro)
            {
                this.locacion = Departamento.procesosTecnicos;
            }
            else if (tipo == TipoDoc.mapa)
            {
                this.locacion = Departamento.mapoteca;
            }
        }

        public static bool operator ==(Escaner e, Documento d)
        {
            bool retorno = false;
            if (e.Tipo == TipoDoc.mapa)
            {
                try
                {
                    foreach (Mapa m in e.ListaDocumentos)
                    {
                        if (m == (Mapa)d)
                        {
                            retorno = true;
                            break;
                        }
                    }
                }
                catch (System.InvalidCastException ex)
                {
                    Console.WriteLine($"Error: Se ha intentado agregar un documento que no es un mapa al escaner - {ex}");
                }
            }
            else
            {
                try
                {
                    foreach (Libro l in e.ListaDocumentos)
                    {
                        if (l == (Libro)d)
                        {
                            retorno = true;
                            break;
                        }
                    }
                }
                catch (System.InvalidCastException ex)
                {
                    Console.WriteLine($"Error: Se ha intentado agregar un documento que no es un libro escaner - {ex}");
                }
            }
            return retorno;

        }

        public static bool operator !=(Escaner e, Documento d)
        {
            return !(e == d);
        }

        public static bool operator +(Escaner e, Documento d)
        {
            
            bool retorno = false;
            
            if (!(e == d) && d.Estado == Documento.Paso.Inicio)
            {
               d.AvanzarEstado();
                 e.ListaDocumentos.Add(d);
                    retorno = true;
            }
            else
            {
                Console.WriteLine("Este documento ya se ha agregado anteriormente");
            }
            
            return retorno;
        }
    }
}
