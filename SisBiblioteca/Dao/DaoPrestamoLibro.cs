using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisBiblioteca.Models;

namespace SisBiblioteca.Dao
{
    public interface DaoPrestamoLibro
    {
        void addPrestamoLibro(PrestamoLibro prestamoLibro);
        void updatePrestamooLibro(PrestamoLibro prestamoLibro);

    }
}
