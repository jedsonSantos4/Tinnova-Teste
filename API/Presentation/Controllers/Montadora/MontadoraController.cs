using AppCore.Entities;
using AppCore.Interface.Services;
using AppCore.Model.Montadora;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Controllers.Montadora
{
    public class MontadoraController : Controller
    {
        private readonly IMemoryCache _cache;
        private readonly IMapper _mapper;
        private readonly IMontadoraService _montadora;
        public MontadoraController(IMapper mapper, IMontadoraService montadora, IMemoryCache cache)
        {
            _mapper = mapper;
            _montadora = montadora;
            _cache = cache;
        }

        [HttpGet]
        [Route("Veiculos")]
        public async Task<ActionResult<dynamic>> GetAll()
        {
            // Recupera o usuário
            var Veiculos = await _montadora.GetAll();

            // Verifica se o usuário existe
            if (Veiculos.Value == null)
                return NotFound(new { message = "Veículo não localizados" });

            return new
            {
                veiculos = _mapper.Map<List<Automovel>>(Veiculos.Value)
            };
        }


        [HttpGet]
        [Route("Veiculos/{id}")]
        public async Task<ActionResult<dynamic>> Get(string id)
        {
            try
            {
                var cacheEntry = new AutomovelEntity();
                if (!_cache.TryGetValue(id, out cacheEntry))
                {
                    cacheEntry = await _montadora.Get(id);

                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(30));

                    _cache.Set(id, cacheEntry, cacheEntryOptions);
                }
                var res = cacheEntry;

                return new
                {
                    veiculos = _mapper.Map<Automovel>(res)
                };
            }
            catch (Exception)
            {
                return NotFound(new { message = "Usuário não localizado" });
            }

        }

        [HttpGet]
        [Route("Veiculos/{marca}/{ano}/{cor}")]
        public async Task<ActionResult<dynamic>> Get(string marca, string ano, string cor)
        {
            try
            {
                var res = await _montadora.Get(marca, ano, cor);

                return new
                {
                    veiculos = _mapper.Map<List<Automovel>>(res.Value)
                };
            }
            catch (Exception)
            {
                return NotFound(new { message = "Usuário não localizado" });
            }

        }


        [HttpPost]
        [Route("Veiculos")]
        public async Task<ActionResult<dynamic>> Insert([FromBody] CreatAutomo model)
        {
            var result = await _montadora.InsertAsync(_mapper.Map<AutomovelEntity>(model));

            if (!result.Status)
                return NotFound(result.Message);

            return Ok("Successo");
        }

        [HttpPut]
        [Route("Veiculos/{id}")]
        public async Task<ActionResult<dynamic>> Put([FromBody] Automovel model)
        {
            var result = await _montadora.UpdateAsync(_mapper.Map<AutomovelEntity>(model));

            if (!result.Status)
                return NotFound(new { message = "Veículo não pode ser atualizado" });

            return new
            { users = model };
        }

        [HttpPatch]
        [Route("Veiculos/{id}")]
        public async Task<ActionResult<dynamic>> Patch([FromBody] Automovel model)
        {
            var result = await _montadora.UpdateAsync(_mapper.Map<AutomovelEntity>(model));

            if (!result.Status)
                return NotFound(new { message = "Veículo não pode ser atualizado" });

            return new
            { users = model };
        }


        [HttpDelete]
        [Route("Veiculos/{id}")]
        public async Task<ActionResult<dynamic>> Delete(string id)
        {
            var result = await _montadora.DeleteAsync(id);

            if (!result.Status)
                return NotFound(result.Message);

            return Ok("Successo");
        }

    }
}
