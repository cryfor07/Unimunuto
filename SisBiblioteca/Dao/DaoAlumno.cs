using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisBiblioteca.Models;
namespace SisBiblioteca.Dao
{
    public interface DaoAlumno 
    {
        void addAlumno(Alumno alumno);
        void updateAlumno(Alumno alumno);
        void deleteAlumno(Alumno alumno);
        List<Alumno> allAlumno();

    }
}
