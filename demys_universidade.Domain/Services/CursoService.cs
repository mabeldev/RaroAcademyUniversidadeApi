using demys_universidade.Domain.Entities;
using demys_universidade.Domain.Interfaces.Repositories;
using demys_universidade.Domain.Interfaces.Services;

namespace demys_universidade.Domain.Services
{
    public class CursoService : BaseService<Curso>, ICursoService
        {
        public CursoService(ICursoRepository cursoRepository) : base(cursoRepository) { }

        //public async Task<Curso> GetPorTurno(Turno turno)
        //{
        //    return await base.ObterAsync(p => p.Turno == turno);
        //}
    }
}
