using Microsoft.Data.Sqlite;
using LojaGames.Data;
using LojaGames.Models;

namespace LojaGames.Dao
{
    public class ProdutoDao
    {
        public List<Produto> ListarProdutos()
        {
            string sql = "SELECT * FROM Produto ORDER BY id DESC";
            using SqliteConnection conexao = Banco.obterConexao();
            using SqliteCommand comando = new SqliteCommand(sql, conexao);
            using SqliteDataReader dados = comando.ExecuteReader();

            List<Produto> lista = new List<Produto>();
            while (dados.Read())
            {
                Produto p = new Produto();
                p.Id = dados.GetInt32(0);
                p.Nome = dados.GetString(1);
                p.Descricao = dados.GetString(2);
                p.Categoria = dados.GetString(3);
                p.Plataforma = dados.GetString(4);
                p.Estoque = dados.GetInt32(5);
                p.Preco = dados.GetDouble(6);
                p.Imagem = dados.IsDBNull(7) ? "" : dados.GetString(7);
                lista.Add(p);
            }
            return lista;
        }

        public void inserir(Produto p)
        {
            string sql = @"
                INSERT INTO Produto
                (nome, descricao, categoria, plataforma, estoque, preco, imagem)
                VALUES
                (@nome, @descricao, @categoria, @plataforma, @estoque, @preco, @imagem)";
            using SqliteConnection con = Banco.obterConexao();
            using SqliteCommand cmd = new SqliteCommand(sql, con);
            cmd.Parameters.AddWithValue("@nome", p.Nome);
            cmd.Parameters.AddWithValue("@descricao", p.Descricao);
            cmd.Parameters.AddWithValue("@categoria", p.Categoria);
            cmd.Parameters.AddWithValue("@plataforma", p.Plataforma);
            cmd.Parameters.AddWithValue("@estoque", p.Estoque);
            cmd.Parameters.AddWithValue("@preco", p.Preco);
            cmd.Parameters.AddWithValue("@imagem", p.Imagem ?? "");
            cmd.ExecuteNonQuery();
        }

        public void Excluir(int id)
        {
            using SqliteConnection con = Banco.obterConexao();
            using SqliteCommand cmd = new SqliteCommand("DELETE FROM Produto WHERE id = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
