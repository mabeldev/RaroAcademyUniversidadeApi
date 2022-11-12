using demys_universidade.Domain.Entities;
using demys_universidade.Domain.Interfaces.Repositories;
using demys_universidade.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demys_universidade.Domain.Services
{
    public class DepartamentoService : BaseService<Departamento>, IDepartamentoService
    {
        public DepartamentoService(IDepartamentoRepository departamentoRepository)
                                                    : base(departamentoRepository) { }

        //public async Task<Departamento> GetPorNome(string nome)
        //{
        //    return await base.ObterAsync(p => p.Nome == nome);
        //}
    }
}