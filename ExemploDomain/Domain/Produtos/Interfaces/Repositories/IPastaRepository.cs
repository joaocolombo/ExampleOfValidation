using System.Collections.Generic;
using Domain.Produtos.Models;
using Domain.Produtos.Models.Negotti;

namespace Domain.Produtos.Interfaces.Repositories
{
    public interface IPastaRepository
    {
        List<Pasta> BuscarPastasValidas(string grife);
        List<Pasta> BuscarPastasValidas(string grife, string tipo);
        void AtualizarPastaBanco(Pasta pasta);

    }
}