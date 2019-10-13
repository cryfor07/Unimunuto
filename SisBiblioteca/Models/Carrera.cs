using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisBiblioteca.Models
{
    public class Carrera
    {
        private int idCarrera;
        private string nombreCarrera;

        public Carrera()
        {

        }

        public Carrera(int idCarrera, string nombreCarrera)
        {
            this.idCarrera = idCarrera;
            this.nombreCarrera = nombreCarrera;
        }

        public int IdCarrera
        {
            get
            {
                return idCarrera;
            }

            set
            {
                idCarrera = value;
            }
        }

        public string NombreCarrera
        {
            get
            {
                return nombreCarrera;
            }

            set
            {
                nombreCarrera = value;
            }
        }

        public override string ToString()
        {
            return nombreCarrera;
        }
    }
}
