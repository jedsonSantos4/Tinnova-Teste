using AppCore.Entities;
using AppCore.Helpers;
using AppCore.Interface.Repositores;
using AppCore.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Services
{
    public class MontadoraService : IMontadoraService
    {

        private readonly IMontadoraRepository _montaRepo;
        public MontadoraService(IMontadoraRepository montaRepo)
        {
            _montaRepo = montaRepo;
        }

        public async Task<AutomovelEntity> Get(string id)
        {
            try
            {
                return await _montaRepo.Get(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task<ValidResult<List<AutomovelEntity>>> Get(string marca, string ano, string cor)
        {
            var result = new ValidResult<List<AutomovelEntity>>();
            try
            {
                var all = await GetAll();
                if (!all.Status)
                {
                    return all;
                }
                var carros = all.Value;

                if (!string.IsNullOrEmpty(marca))
                {
                    carros = carros.Where(c => c.Marca.ToUpper().Equals(marca.ToUpper())).ToList();
                }
                var number = 0;
                var validType = int.TryParse(ano, out number);
                if (!string.IsNullOrEmpty(ano) && validType)
                {
                    var valid = Convert.ToInt32(ano);
                    carros = carros.Where(c => c.Ano == valid).ToList();
                }
                if (!string.IsNullOrEmpty(cor))
                {
                    carros = carros.Where(c => c.Cor.ToUpper().Equals(cor.ToUpper())).ToList();
                }

                result.Value = carros;
                result.Status = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<ValidResult<List<AutomovelEntity>>> GetAll()
        {
            var result = new ValidResult<List<AutomovelEntity>>();
            try
            {
                result.Value = (List<AutomovelEntity>)await _montaRepo.GeAll();
                result.Status = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<ValidResult<bool>> InsertAsync(AutomovelEntity obj)
        {
            var result = new ValidResult<bool>();
            try
            {
                var automoveis = await GetAll();

                if (automoveis.Value == null || !automoveis.Status)
                {
                    result.Message = "Error: when querying user existence. Please try again!";
                    return result;
                }

                if (!ValidationVeiculo.IsNameFabricaVeiculo(obj.Marca))
                {
                    result.Message = "Erro: Vehicle manufacturer name not found. Please try again!";
                    return result;
                }
                await _montaRepo.InsertAsync(obj);
                result.Status = true;
                result.Value = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<ValidResult<bool>> UpdateAsync(AutomovelEntity obj)
        {
            var result = new ValidResult<bool>();
            try
            {
                var automovel = await _montaRepo.Get(obj.Id);

                automovel.Veiculo =   obj.Veiculo != automovel.Veiculo? obj.Veiculo : automovel.Veiculo;
                automovel.Marca = obj.Marca != automovel.Marca ? obj.Marca : automovel.Marca;
                automovel.Descricao = obj.Descricao != automovel.Descricao ? obj.Descricao : automovel.Descricao;
                automovel.Ano = obj.Ano != automovel.Ano ? obj.Ano : automovel.Ano;
                automovel.Vendido = obj.Vendido != automovel.Vendido ? obj.Vendido : automovel.Vendido;
                automovel.Updated = DateTime.UtcNow;
                await _montaRepo.UpdateAsync(automovel);
                result.Status = true;
                result.Value = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<ValidResult<bool>> DeleteAsync(string id)
        {
            var result = new ValidResult<bool>();
            try
            {
                await _montaRepo.DeleteAsync(id);
                result.Status = true;
                result.Value = true;

                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }

    }
}
