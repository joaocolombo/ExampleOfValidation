using System.Collections.Generic;
using Core.Models;
using Domain.Clientes.Interfaces.Services;
using Domain.Clientes.Models;
using Domain.Clientes.Interfaces.Repositories;

namespace Domain.Clientes.Services
{
    public class LogService : ILogClienteService
    {
        private readonly ILogClienteRepository _iLogRepository;

        public LogService(ILogClienteRepository iLogRepository)
        {
            _iLogRepository = iLogRepository;
        }
        public void GravarLog(string jsonCliente, string comando, string usuario
                ,string representanteId, List<Error> erros, string clienteId)
        {
            _iLogRepository.GravarLog(Log.LogFactory.MontarLog(jsonCliente, comando, usuario, representanteId, erros, clienteId));
        }

    }
}