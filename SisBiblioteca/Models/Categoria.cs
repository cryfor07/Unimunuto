using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisBiblioteca.Models
{
    public class Categoria
    {
        private int idCategoria;
        private string nombreCategoria;

        public Categoria()
        {

        }

        public Categoria(int idCategoria, string nombreCategoria)
        {
            this.idCategoria = idCategoria;
            this.nombreCategoria = nombreCategoria;
        }

        public int IdCategoria
        {
            get
            {
                return idCategoria;
            }

            set
            {
                idCategoria = value;
            }
        }

        public string NombreCategoria
        {
            get
            {
                return nombreCategoria;
            }

            set
            {
                nombreCategoria = value;
            }
        }

        public override string ToString()
        {
            return nombreCategoria;
        }
    }
}
