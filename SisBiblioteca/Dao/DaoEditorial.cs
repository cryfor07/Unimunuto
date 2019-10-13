using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisBiblioteca.Models;

namespace SisBiblioteca.Dao
{
    public interface DaoEditorial
    {
        void addEditorial(Editorial editorial);
        void updateEditorial(Editorial editorial);
        void deleteEditorial(Editorial editorial);
        List<Editorial> allEditorial();
        List<Editorial> allEditorial(string nombreEditorial);

    }
}
