using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisBiblioteca.Models
{
    public class GridMoras
    {
        private int idMora;
        private string nombreAlumno;
        private string apellidoAlumno;
        private int nCarnet;
        private string nombreLibro;
        private double cantidadMora;
        private DateTime fechaPrestamo;
        private DateTime fechaEntrega;
        private DateTime fechaLimite;
        private string moraCancelada;
        private DateTime fechaPagoMora;

        public int IdMora
        {
            get
            {
                return idMora;
            }

            set
            {
                idMora = value;
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

        public double CantidadMora
        {
            get
            {
                return cantidadMora;
            }

            set
            {
                cantidadMora = value;
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

        public GridMoras()
        {

        }

        public GridMoras(int idMora, string nombreAlumno, string apellidoAlumno, int nCarnet, string nombreLibro, double cantidadMora, DateTime fechaPrestamo, DateTime fechaEntrega, DateTime fechaLimite, string moraCancelada, DateTime fechaPagoMora)
        {
            this.IdMora = idMora;
            this.NombreAlumno = nombreAlumno;
            this.ApellidoAlumno = apellidoAlumno;
            this.NCarnet = nCarnet;
            this.NombreLibro = nombreLibro;
            this.CantidadMora = cantidadMora;
            this.FechaPrestamo = fechaPrestamo;
            this.FechaEntrega = fechaEntrega;
            this.FechaLimite = fechaLimite;
            this.MoraCancelada = moraCancelada;
            this.FechaPagoMora = fechaPagoMora;
        }
    }
}
