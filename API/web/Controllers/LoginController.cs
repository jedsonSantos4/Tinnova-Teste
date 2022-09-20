
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Web.Model.Interface.Service;
using Web.Model.Models;

namespace web.Controllers
{
    public class LoginController : Controller
    {

        private readonly ILogarServ logarServ;


        public LoginController(ILogarServ _logarServ)
        {
            logarServ = _logarServ;

        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> Cadastar(string user)
        {
            try
            {
                var veiculo = JsonConvert.DeserializeObject<Register>(user);
                var teste = await logarServ.Casdastro(veiculo);

                return Json(true);

            }
            catch (Exception)
            {
                return Json(false);
            }
        }

        public async Task<JsonResult> UpdateVeiculo(string user)
        {
            try
            {
                var veiculo = JsonConvert.DeserializeObject<veiculos>(user);
                var teste = await logarServ.Update(veiculo);

                return Json(true);

            }
            catch (Exception)
            {
                return Json(false);
            }
        }

        public async Task<JsonResult> FindPatamiter(string marca, string cor, string ano)
        {
            try
            {
                var resul = await logarServ.GetId(marca, cor, ano);

                return Json(resul);

            }
            catch (Exception)
            {
                return Json(false);
            }
        }


        public async Task<JsonResult> GetId(string user)
        {
            try
            {
                var resul = await logarServ.GetId(user);

                return Json(resul);

            }
            catch (Exception)
            {
                return Json(false);
            }
        }

        public async Task<JsonResult> Delete(string user)
        {
            try
            {
                var resul = await logarServ.Delete(user);

                return Json(resul);

            }
            catch (Exception)
            {
                return Json(false);
            }
        }

        public async Task<JsonResult> GetAll()
        {
            try
            {
                var resul = await logarServ.GetAll();

                return Json(resul);

            }
            catch (Exception)
            {
                return Json(false);
            }
        }

    }
}
