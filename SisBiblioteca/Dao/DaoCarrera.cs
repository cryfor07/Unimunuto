using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisBiblioteca.Models;

namespace SisBiblioteca.Dao
{
    public interface DaoCarrera
    {
        void addCarrera(Carrera carrera);
        void updateCarrera(Carrera carrera);
        void deleteCarrera(Carrera carrera);
        List<Carrera> allCarrera();
        List<Carrera> allCarrera(string nombreCarrera);
    }
}
