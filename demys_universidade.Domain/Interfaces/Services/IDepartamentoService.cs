using demys_universidade.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demys_universidade.Domain.Interfaces.Services
{
    public interface IDepartamentoService : IBaseService<Departamento>
    {
        //Task<Departamento> GetPorNome(string nome);
    }
}
