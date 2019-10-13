using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisBiblioteca.Models;

namespace SisBiblioteca.Dao
{
    public interface DaoCategoria
    {
        void addCategoria(Categoria categoria);
        void updateCategoria(Categoria categoria);
        void deleteCategoria(Categoria categoria);
        List<Categoria> allCategoria();
        List<Categoria> allCategoria(string nombreCategoria);
    }
}
