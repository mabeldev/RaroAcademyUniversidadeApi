using AutoMapper;
using demys_universidade.Domain.Contracts.Request;
using demys_universidade.Domain.Contracts.Response;
using demys_universidade.Domain.Entities;
using demys_universidade.Domain.Interfaces.Services;
using demys_universidade.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace demys_universidade.Controllers
{
    public class UsuarioController : BaseController<Usuario, UsuarioRequest, UsuarioResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IMapper mapper, IUsuarioService service) : base(mapper, service)
        {
            _mapper = mapper;
            _usuarioService = service;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(201)]
        public override async Task<ActionResult> PostAsync([FromBody] UsuarioRequest request)
        {
            var entity = _mapper.Map<Usuario>(request);
            await _usuarioService.CriarUsuarioAsync(entity);
            return Created(nameof(PostAsync), new { id = entity.Id });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        public override async Task<ActionResult> PutAsync(
            [FromRoute] int id,
            [FromBody] UsuarioRequest request
        )
        {
            var entity = _mapper.Map<Usuario>(request);
            entity.Id = id;
            await _usuarioService.AtualizarUsuarioAsync(entity);
            return NoContent();
        }

        [HttpGet("nome/{nome}")]
        [ProducesResponseType(200)]
        public virtual async Task<ActionResult> GetPorNome([FromRoute] string nome)
        {
            var entity = await _usuarioService.GetPorNome(nome);
            var usuario = _mapper.Map<UsuarioResponse>(entity);
            return Ok(usuario);
        }
    }

}

