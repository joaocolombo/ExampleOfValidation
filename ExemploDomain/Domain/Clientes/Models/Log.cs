using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models;

namespace Domain.Clientes.Models
{
    public class Log
    {
        private Log()
        {

        }

        public List<Error> Erros { get; private set; }
        public string Comando { get; private set; }
        public string ClienteId { get; protected set; }
        public bool TemErro { get; private set; }
        public string Messagem { get; private set; }
        public DateTime Data { get; private set; }
        public string Json { get; private set; }
        public string Usuario { get; private set; }
        public string RepresentanteId { get; private set; }

        private void GerarMenssagem()
        {
            if (Erros.Any())
            {
                TemErro = true;
                foreach (var erro in Erros)
                    Messagem += $"{erro.Title}:{erro.Message} |";
            }
            else
            {
                Messagem = "Cliente inserido com sucesso.";
            }
        }


        public static class LogFactory
        {
            public static Log MontarLog(string jsonCliente, string comando, string usuario,
                string representanteId, List<Error> erros, string clienteId="0")
            {
                var log = new Log()
                {
                    Json = jsonCliente,
                    Comando = comando,
                    Usuario = usuario,
                    ClienteId = clienteId,
                    RepresentanteId = representanteId,
                    Data = DateTime.Now,
                    Erros = erros,
                    TemErro = false,
                };

                log.GerarMenssagem();
                return log;
            }
        }
    }
}