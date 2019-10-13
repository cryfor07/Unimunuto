using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisBiblioteca.Models
{
    public class Alumno 
    {
        private int idAlumno;
        private string nombreAlumno;
        private string apellidoAlumno;
        private int nCarnet;
        private string genero;
        private Carrera carrera;

        public Alumno()
        {
            carrera = new Carrera();
        }

        public int IdAlumno
        {
            get
            {
                return idAlumno;
            }

            set
            {
                idAlumno = value;
            }
        }

        public string NombreAlumno
        {
            get
            {
                return nombreAlumno;
            }

            set
            {
                nombreAlumno = value;
            }
        }

        public string ApellidoAlumno
        {
            get
            {
                return apellidoAlumno;
            }

            set
            {
                apellidoAlumno = value;
            }
        }

        public int NCarnet
        {
            get
            {
                return nCarnet;
            }

            set
            {
                nCarnet = value;
            }
        }

        
        public string Genero
        {
            get
            {
                return genero;
            }

            set
            {
                genero = value;
            }
        }

        public Carrera Carrera
        {
            get
            {
                return carrera;
            }

            set
            {
                carrera = value;
            }
        }

        public Alumno(int idAlumno, string nombreAlumno, string apellidoAlumno, int nCarnet, string genero)
        {
            this.IdAlumno = idAlumno;
            this.NombreAlumno = nombreAlumno;
            this.ApellidoAlumno = apellidoAlumno;
            this.NCarnet = nCarnet;
            this.Genero = genero;
        }

        public override string ToString()
        {
            return NCarnet.ToString();
        }
    }
}
