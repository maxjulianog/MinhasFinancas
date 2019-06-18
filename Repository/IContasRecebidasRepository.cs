using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    interface IContasRecebidasRepository
    {
        int Insert(ContaRecebida contaRecebida);

        bool Atualizar(ContaRecebida contaRecebida);

        bool Apagar(int id);

        ContaRecebida ObterPeloId(int id);

        List<ContaRecebida> ObterTodos(string busca);
    }
}
