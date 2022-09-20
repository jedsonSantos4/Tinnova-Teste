using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Web.Model.Models;
using WebModel.Interface.Repos;

namespace WebAcess
{
    public class LogarAcess : ILogarRepo
    {
        public async Task<HttpResponseMessage> AsyncPostGet(string pUrl, string pParam)
        {
            var Client_getCnpj = new HttpClient
            {
                BaseAddress = new Uri(pUrl),
                Timeout = TimeSpan.FromMilliseconds(30000),
            };
            Client_getCnpj.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var resp = new HttpResponseMessage();
                var controleServ = true;
                var tentativa = 0;

                while (controleServ)
                {
                    resp = await Client_getCnpj.GetAsync($"{Client_getCnpj.BaseAddress}");
                    var lErro = resp.Content.ReadAsStringAsync().Result;

                    if (tentativa >= 5)
                    {
                        controleServ = false;
                    }

                    if (resp.StatusCode != HttpStatusCode.OK || lErro.ToLower().Contains("error"))
                    {
                        Thread.Sleep(500);
                        tentativa++;
                        var msg = string.Format(lErro.ToLower(), ((int)resp.StatusCode), pUrl, pParam);
                        throw new ArgumentException(msg);
                    }
                    else
                    {
                        controleServ = false;
                    }
                }
                return resp;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<HttpResponseMessage> AsyncPost(string pUrl, string pParam)
        {
            var lPost = new StringContent(pParam, Encoding.UTF8, "application/json");


            var http_Client = new HttpClient
            {
                BaseAddress = new Uri(pUrl),
                Timeout = TimeSpan.FromMilliseconds(30000),
            };
            http_Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var resp = new HttpResponseMessage();
                var controleServ = true;
                var tentativa = 0;

                while (controleServ)
                {
                    resp = await http_Client.PostAsync($"{http_Client.BaseAddress}", lPost);
                    var lErro = resp.Content.ReadAsStringAsync().Result;

                    if (tentativa >= 5)
                    {
                        controleServ = false;
                    }

                    if (resp.StatusCode != HttpStatusCode.OK || lErro.ToLower().Contains("error"))
                    {
                        Thread.Sleep(500);
                        tentativa++;
                        var msg = string.Format(lErro.ToLower(), ((int)resp.StatusCode), pUrl, pParam);
                        throw new ArgumentException(msg);
                    }
                    else
                    {
                        controleServ = false;
                    }
                }
                return resp;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<HttpResponseMessage> AsyncPut(string pUrl, string pParam)
        {
            var lPost = new StringContent(pParam, Encoding.UTF8, "application/json");


            var http_Client = new HttpClient
            {
                BaseAddress = new Uri(pUrl),
                Timeout = TimeSpan.FromMilliseconds(30000),
            };
            http_Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var resp = new HttpResponseMessage();
                var controleServ = true;
                var tentativa = 0;

                while (controleServ)
                {
                    resp = await http_Client.PutAsync($"{http_Client.BaseAddress}", lPost);
                    var lErro = resp.Content.ReadAsStringAsync().Result;

                    if (tentativa >= 5)
                    {
                        controleServ = false;
                    }

                    if (resp.StatusCode != HttpStatusCode.OK || lErro.ToLower().Contains("error"))
                    {
                        Thread.Sleep(500);
                        tentativa++;
                        var msg = string.Format(lErro.ToLower(), ((int)resp.StatusCode), pUrl, pParam);
                        throw new ArgumentException(msg);
                    }
                    else
                    {
                        controleServ = false;
                    }
                }
                return resp;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<HttpResponseMessage> AsyncDelete(string pUrl)
        {
            var http_Client = new HttpClient
            {
                BaseAddress = new Uri(pUrl),
                Timeout = TimeSpan.FromMilliseconds(30000),
            };
            http_Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var resp = new HttpResponseMessage();
                var controleServ = true;
                var tentativa = 0;

                while (controleServ)
                {
                    resp = await http_Client.DeleteAsync($"{http_Client.BaseAddress}");
                    var lErro = resp.Content.ReadAsStringAsync().Result;

                    if (tentativa >= 5)
                    {
                        controleServ = false;
                    }

                    if (resp.StatusCode != HttpStatusCode.OK || lErro.ToLower().Contains("error"))
                    {
                        Thread.Sleep(500);
                        tentativa++;
                        var msg = string.Format(lErro.ToLower(), ((int)resp.StatusCode), pUrl);
                        throw new ArgumentException(msg);
                    }
                    else
                    {
                        controleServ = false;
                    }
                }
                return resp;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<string> Casdastro(Register register)
        {
            var lParam = JsonConvert.SerializeObject(register);

            var result = await AsyncPost("https://localhost:44321/Veiculos", lParam);
            return result.Content.ReadAsStringAsync().Result;
        }

        public async Task<Frota> GetAll()
        {
            var JsTool2 = new JavaScriptSerializer();
            var result = await AsyncPostGet("https://localhost:44321/Veiculos", "");
            var resultContent = result.Content.ReadAsStringAsync().Result;

            return JsTool2.Deserialize<Frota>(resultContent);
        }

        public async Task<veiculos> GetId(string id)
        {
            try
            {
                var JsTool2 = new JavaScriptSerializer();
                var result = await AsyncPostGet($"https://localhost:44321/Veiculos/{id}", "");
                var resultContent = result.Content.ReadAsStringAsync().Result;
                var con = JsTool2.Deserialize<dynamic>(resultContent).veiculos;
                return JsTool2.Deserialize<veiculos>(con.ToString());
            }
            catch (Exception)
            {
                return new veiculos();
            }

        }

        public async Task<string> Delete(string id)
        {
            try
            {
                var JsTool2 = new JavaScriptSerializer();
                var result = await AsyncDelete($"https://localhost:44321/Veiculos/{id}");
                var resultContent = result.Content.ReadAsStringAsync().Result;

                return resultContent;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public async Task<Frota> GetId(string marca, string cor, string ano)
        {
            try
            {

                var url = $"https://localhost:44321/Veiculos/{marca}/{cor}/{ano}/";
                var JsTool2 = new JavaScriptSerializer();
                var result = await AsyncPostGet(url, "");
                var resultContent = result.Content.ReadAsStringAsync().Result;
                return JsTool2.Deserialize<Frota>(resultContent);
            }
            catch (Exception ex)
            {
                return new Frota();
            }
        }

        public async Task<string> Update(veiculos veic)
        {
            var lParam = JsonConvert.SerializeObject(veic);
            try
            {
                var result = await AsyncPut($"https://localhost:44321/Veiculos/{veic.Id}", lParam);
                return result.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
