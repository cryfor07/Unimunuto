using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisBiblioteca.Models
{
    public class Editorial
    {
        private int idEditorial;
        private String nombreEditorial;

        public Editorial()
        {
        }

        public Editorial(int idEditorial, string nombreEditorial)
        {
            this.idEditorial = idEditorial;
            this.nombreEditorial = nombreEditorial;
        }

        public int IdEditorial
        {
            get
            {
                return idEditorial;
            }

            set
            {
                idEditorial = value;
            }
        }

        public string NombreEditorial
        {
            get
            {
                return nombreEditorial;
            }

            set
            {
                nombreEditorial = value;
            }
        }

        public override string ToString()
        {
            return nombreEditorial;
        }
    }
}
