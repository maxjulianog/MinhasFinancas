using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public class ContasRecebidasRepository : IContasRecebidasRepository
    {
        private Conexao conexao;

        public ContasRecebidasRepository()
        {
            conexao = new Conexao();
        }

        public bool Apagar(int id)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = "DELETE FROM recebidas WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            int qunatidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return qunatidadeAfetada == 1;

        }

        public bool Atualizar(ContaRecebida contaRecebida)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = "UPDATE recebidas SET nome = @NOME,valor = @VALOR,tipo = @TIPO,descricao = @DESCRICAO, status = @STATUS WHERE id =@ID";
            comando.Parameters.AddWithValue("@NOME", contaRecebida.Nome);
            comando.Parameters.AddWithValue("@VALOR",contaRecebida.Valor);
            comando.Parameters.AddWithValue("@TIPO", contaRecebida.Tipo);
            comando.Parameters.AddWithValue("@DESCRICAO", contaRecebida.Descricao);
            comando.Parameters.AddWithValue("@STATUS", contaRecebida.Status);
            comando.Parameters.AddWithValue("@ID", contaRecebida.Id);
            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }

        public int Insert(ContaRecebida contaRecebida)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"INSERT INTO recebidas (nome,valor,tipo,descricao,status) OUTPUT INSERTED.ID VALUES (@NOME,@VALOR,@TIPO,@DESCRICAO,@STATUS)";
            comando.Parameters.AddWithValue("@NOME", contaRecebida.Nome);
            comando.Parameters.AddWithValue("@VALOR", contaRecebida.Valor);
            comando.Parameters.AddWithValue("@TIPO", contaRecebida.Tipo);
            comando.Parameters.AddWithValue("@DESCRICAO", contaRecebida.Descricao);
            comando.Parameters.AddWithValue("@STATUS", contaRecebida.Status);
            int id = Convert.ToInt32(comando.ExecuteNonQuery());
            comando.Connection.Close();
            return id;
        }

        public ContaRecebida ObterPeloId(int id)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = "SELECT * FROM recebidas WHERE id = @ID";
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

        public List<ContaRecebida> ObterTodos(string busca)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = "SELECT * FROM recebidas WHERE nome LIKE @NOME";
            busca = $"%{busca}%";
            comando.Parameters.AddWithValue("@NOME", busca);

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();
            List<ContaRecebida> contaRecebida = new List<ContaRecebida>();
            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                DataRow Linha = tabela.Rows[i];
                ContaRecebida conta = new ContaRecebida();
                conta.Id = Convert.ToInt32(Linha["id"]);
                conta.Nome = Linha["nome"].ToString();
                conta.Valor = Convert.ToDecimal(Linha["valor"]);
                conta.Tipo = Linha["tipo"].ToString();
                conta.Descricao = Linha["descricao"].ToString();
                conta.Status = Linha["status"].ToString();
                contaRecebida.Add(conta);
            }
            return contaRecebida;
        }
    }
}
