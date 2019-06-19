using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ContasPagarRepository : IContasPagarRepository
    {
        private Conexao conexao;

        public ContasPagarRepository()
        {
            conexao = new Conexao();
        }

        public bool Apagar(int id)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = "DELETE FROM contas_a_pagar WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            int qunatidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return qunatidadeAfetada == 1;
        }

        public bool Atualizar(ContaPagar contaPagar)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = "UPDATE contas_a_pagar SET nome = @NOME, valor = @VALOR, tipo = @TIPO, descricao = @DESCRICAO, status = @STATUS WHERE id = @ID";
            comando.Parameters.AddWithValue("@NOME", contaPagar.Nome);
            comando.Parameters.AddWithValue("@VALOR", contaPagar.Valor);
            comando.Parameters.AddWithValue("@TIPO", contaPagar.Tipo);
            comando.Parameters.AddWithValue("@DESCRICAO", contaPagar.Descricao);
            comando.Parameters.AddWithValue("@STATUS", contaPagar.Status);
            comando.Parameters.AddWithValue("@ID", contaPagar.Id);
            int quantidadeAfetada = Convert.ToInt32(comando.ExecuteNonQuery());
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }

        public int Insert(ContaPagar contaPagar)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"INSERT INTO contas_a_pagar (nome,valor,tipo,descricao,status) OUTPUT INSERTED.ID VALUES (@NOME,@VALOR,@TIPO,@DESCRICAO,@STATUS)";
            comando.Parameters.AddWithValue("@NOME", contaPagar.Nome);
            comando.Parameters.AddWithValue("@VALOR", contaPagar.Valor);
            comando.Parameters.AddWithValue("@TIPO", contaPagar.Tipo);
            comando.Parameters.AddWithValue("@DESCRICAO", contaPagar.Descricao);
            comando.Parameters.AddWithValue("@STATUS", contaPagar.Status);
            int id = Convert.ToInt32(comando.ExecuteScalar());
            comando.Connection.Close();
            return id;
        }

        public ContaRecebida ObterPeloId(int id)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = "SELECT * FROM contas_a_pagar WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();
            if (tabela.Rows.Count == 0)
            {
                return null;
            }
            DataRow linha = tabela.Rows[0];
            ContaRecebida contaRecebida = new ContaRecebida();
            contaRecebida.Id = Convert.ToInt32(linha["id"]);
            contaRecebida.Nome = linha["nome"].ToString();
            contaRecebida.Valor = Convert.ToDecimal(linha["valor"]);
            contaRecebida.Tipo = linha["tipo"].ToString();
            contaRecebida.Descricao = linha["descricao"].ToString();
            contaRecebida.Status = linha["status"].ToString();
            return contaRecebida;
        }

        public List<ContaPagar> ObterTodos(string busca)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = "SELECT * FROM contas_a_pagar WHERE nome LIKE @NOME";
            busca = $"%{busca}%";
            comando.Parameters.AddWithValue("@NOME", busca);

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();
            List<ContaPagar> contaPagar = new List<ContaPagar>();
            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                DataRow Linha = tabela.Rows[i];
                ContaPagar conta = new ContaPagar();
                conta.Id = Convert.ToInt32(Linha["id"]);
                conta.Nome = Linha["nome"].ToString();
                conta.Valor = Convert.ToDecimal(Linha["valor"]);
                conta.Tipo = Linha["tipo"].ToString();
                conta.Descricao = Linha["descricao"].ToString();
                conta.Status = Linha["status"].ToString();
                contaPagar.Add(conta);
            }
            return contaPagar;
        }
    }
}
