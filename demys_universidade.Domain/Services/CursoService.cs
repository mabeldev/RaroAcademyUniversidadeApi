using demys_universidade.Domain.Entities;
using demys_universidade.Domain.Interfaces.Repositories;
using demys_universidade.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace demys_universidade.Domain.Services
{
    public class CursoService : BaseService<Curso>, ICursoService
        {
        public CursoService(ICursoRepository cursoRepository, IHttpContextAccessor httpContextAccessor) : base(cursoRepository, httpContextAccessor) { }

        
    }
}
