using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisBiblioteca.Models;

namespace SisBiblioteca.Dao
{
    interface DaoLibro
    {
        void addLibro(Libro libro);
        void updateLibro(Libro libro);
        void deleteLibro(Libro libro);
        List<Libro> allLibro();
        List<Libro> allLibro(string libron);
    }
}
