using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisBiblioteca.Models
{
    public class Autor
    {
        private int idAutor;
        private String nombreAutor;

        public Autor()
        {

        }

        public Autor(int idAutor, string nombreAutor)
        {
            this.idAutor = idAutor;
            this.nombreAutor = nombreAutor;
        }

        public int IdAutor
        {
            get
            {
                return idAutor;
            }

            set
            {
                idAutor = value;
            }
        }

        public string NombreAutor
        {
            get
            {
                return nombreAutor;
            }

            set
            {
                nombreAutor = value;
            }
        }

        public override string ToString()
        {
            return nombreAutor;
        }
    }
}
