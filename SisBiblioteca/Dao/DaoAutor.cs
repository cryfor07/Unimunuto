using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisBiblioteca.Models;

namespace SisBiblioteca.Dao
{
    public interface DaoAutor
    {
        void addAutor(Autor autor);
        void updateAutor(Autor autor);
        void deleteAutor(Autor autor);
        List<Autor> allAutor();
        List<Autor> allAutor(string nombreAutor);
    }
}
