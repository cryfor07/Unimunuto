using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisBiblioteca.Models
{
    public class GridReporteMoras
    {
        private string nombreLibro;
        private string nombreCategoria;
        private string nombreAlumno;
        private string apellidoAlumno;
        private int nCarnet;
        private string nombreCarrera;
        private DateTime fechaPrestamo;
        private DateTime fechaLimite;
        private DateTime fechaEntrega;
        private string moraCancelada;
        private DateTime fechaPagoMora;

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

        public string MoraCancelada
        {
            get
            {
                return moraCancelada;
            }

            set
            {
                moraCancelada = value;
            }
        }

        public DateTime FechaPagoMora
        {
            get
            {
                return fechaPagoMora;
            }

            set
            {
                fechaPagoMora = value;
            }
        }

        public GridReporteMoras()
        {

        }

        public GridReporteMoras(string nombreLibro, string nombreCategoria, string nombreAlumno, string apellidoAlumno, int nCarnet, string nombreCarrera, DateTime fechaPrestamo, DateTime fechaLimite, DateTime fechaEntrega, string moraCancelada, DateTime fechaPagoMora)
        {
            this.NombreLibro = nombreLibro;
            this.NombreCategoria = nombreCategoria;
            this.NombreAlumno = nombreAlumno;
            this.ApellidoAlumno = apellidoAlumno;
            this.NCarnet = nCarnet;
            this.NombreCarrera = nombreCarrera;
            this.FechaPrestamo = fechaPrestamo;
            this.FechaLimite = fechaLimite;
            this.FechaEntrega = fechaEntrega;
            this.MoraCancelada = moraCancelada;
            this.FechaPagoMora = fechaPagoMora;
        }
    }
}
