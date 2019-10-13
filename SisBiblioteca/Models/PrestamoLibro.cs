using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisBiblioteca.Models
{
    public class PrestamoLibro
    {
        private int idPrestamoLibro;
        private Alumno alumno;
        private Libro libro;
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

        public Alumno Alumno
        {
            get
            {
                return alumno;
            }

            set
            {
                alumno = value;
            }
        }

        public Libro Libro
        {
            get
            {
                return libro;
            }

            set
            {
                libro = value;
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

        public PrestamoLibro()
        {
            alumno = new Alumno();
            libro = new Libro();
        }

        public PrestamoLibro(int idPrestamoLibro, Alumno alumno, Libro libro, DateTime fechaPrestamo, 
            DateTime fechaEntrega, string prestamoSolvente, DateTime fechaLimite)
        {
            this.IdPrestamoLibro = idPrestamoLibro;
            this.Alumno = alumno;
            this.Libro = libro;
            this.FechaPrestamo = fechaPrestamo;
            this.FechaEntrega = fechaEntrega;
            this.PrestamoSolvente = prestamoSolvente;
            this.FechaLimite = fechaLimite;
        }
    }
}
