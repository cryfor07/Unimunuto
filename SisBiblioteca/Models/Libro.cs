using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisBiblioteca.Models
{
    public class Libro
    {
        private int idLibro;
        private string nombreLibro;
        private Editorial editorial;
        private int anio;
        private Categoria categoria;
        private string descripcion;
        private Autor autor;

        public int IdLibro
        {
            get
            {
                return idLibro;
            }

            set
            {
                idLibro = value;
            }
        }

        public string NombreLibro
        {
            get
            {
                return nombreLibro;
            }

            set
            {
                nombreLibro = value;
            }
        }

        public Editorial Editorial
        {
            get
            {
                return editorial;
            }

            set
            {
                editorial = value;
            }
        }

        public int Anio
        {
            get
            {
                return anio;
            }

            set
            {
                anio = value;
            }
        }

        public Categoria Categoria
        {
            get
            {
                return categoria;
            }

            set
            {
                categoria = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public Autor Autor
        {
            get
            {
                return autor;
            }

            set
            {
                autor = value;
            }
        }

        public Libro()
        {
            Editorial = new Editorial();
            Categoria = new Categoria();
            Autor = new Autor();
        }

        public Libro(int idLibro, string nombreLibro, Editorial editorial, int anio, Categoria categoria, string descripcion, string estadoLibro, Autor autor)
        {
            this.IdLibro = idLibro;
            this.NombreLibro = nombreLibro;
            this.Editorial = editorial;
            this.Anio = anio;
            this.Categoria = categoria;
            this.Descripcion = descripcion;
            this.Autor = autor;
        }

        public override string ToString()
        {
            return nombreLibro;
        }

    }
}
