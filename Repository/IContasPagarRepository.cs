using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    interface IContasPagarRepository
    {
        int Insert(ContaPagar contaPagar);

        bool Atualizar(ContaPagar contaPagar);

        bool Apagar(int id);

        ContaRecebida ObterPeloId(int id);

        List<ContaPagar> ObterTodos(string busca);
    }
}
