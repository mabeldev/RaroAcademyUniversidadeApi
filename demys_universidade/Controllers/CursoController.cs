using AutoMapper;
using demys_universidade.Domain.Contracts.Request;
using demys_universidade.Domain.Contracts.Response;
using demys_universidade.Domain.Entities;
using demys_universidade.Domain.Interfaces.Services;
using demys_universidade.Domain.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace demys_universidade.Controllers
{
    [Authorize(Roles = ConstanteUtil.PerfilLogadoNome)]
    public class CursoController : BaseController<Curso, CursoRequest, CursoResponse>
    {

        #region Constructor
        private readonly IMapper _mapper;
        private readonly ICursoService _cursoService;

        public CursoController(IMapper mapper, ICursoService service) : base(mapper, service)
        {
            _mapper = mapper;
            _cursoService = service;
        }

        #endregion

        #region Post (Allow Anonymous)
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(201)]
        public override async Task<ActionResult> PostAsync([FromBody] CursoRequest request)
        {
            var entity = _mapper.Map<Curso>(request);
            await _cursoService.AdicionarAsync(entity);
            return Created(nameof(PostAsync), new { id = entity.Id });
        }

        #endregion

    }

}

