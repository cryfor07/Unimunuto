using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisBiblioteca.Models
{
    public class GridPrestamoLibro
    {
        private int idPrestamoLibro;
        private string nombreAlumno;
        private string apellidoAlumno;
        private int nCarnet;
        private string nombreLibro;
        private DateTime fechaPrestamo;
        private DateTime fechaEntrega;
        private string prestamoSolvente;
        private DateTime fechaLimite;

        public int IdPrestamoLibro
        {
            get
            {
                return idPrestamoLibro;
            }

            set
            {
                idPrestamoLibro = value;
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

        public DateTime FechaPrestamo
        {
            get
            {
                return fechaPrestamo;
            }

            set
            {
                fechaPrestamo = value;
            }
        }

        public DateTime FechaEntrega
        {
            get
            {
                return fechaEntrega;
            }

            set
            {
                fechaEntrega = value;
            }
        }

        public string PrestamoSolvente
        {
            get
            {
                return prestamoSolvente;
            }

            set
            {
                prestamoSolvente = value;
            }
        }

        public DateTime FechaLimite
        {
            get
            {
                return fechaLimite;
            }

            set
            {
                fechaLimite = value;
            }
        }

        public GridPrestamoLibro()
        {

        }

        public GridPrestamoLibro(int idPrestamoLibro, string nombreAlumno, string apellidoAlumno, int nCarnet, string nombreLibro, DateTime fechaPrestamo, DateTime fechaEntrega, string prestamoSolvente, DateTime fechaLimite)
        {
            this.IdPrestamoLibro = idPrestamoLibro;
            this.NombreAlumno = nombreAlumno;
            this.ApellidoAlumno = apellidoAlumno;
            this.NCarnet = nCarnet;
            this.NombreLibro = nombreLibro;
            this.FechaPrestamo = fechaPrestamo;
            this.FechaEntrega = fechaEntrega;
            this.PrestamoSolvente = prestamoSolvente;
            this.FechaLimite = fechaLimite;

        }
    }
}
