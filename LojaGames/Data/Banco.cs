using Microsoft.Data.Sqlite;

namespace LojaGames.Data
{
    public class Banco
    {
        private static string caminho = "Data Source=loja_games.db";

        public static SqliteConnection obterConexao()
        {
            SqliteConnection conexao = new SqliteConnection(caminho);
            conexao.Open();
            return conexao;
        }

        public static void CriarBanco()
        {
            using SqliteConnection conexao = obterConexao();
            string sql = """
                CREATE TABLE IF NOT EXISTS Produto(
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    nome TEXT NOT NULL,
                    descricao TEXT NOT NULL,
                    categoria TEXT NOT NULL,
                    plataforma TEXT NOT NULL,
                    estoque INTEGER NOT NULL,
                    preco REAL NOT NULL,
                    imagem TEXT
                )
                """;
            using SqliteCommand cmd = new SqliteCommand(sql, conexao);
            cmd.ExecuteNonQuery();

            using SqliteCommand total = new SqliteCommand("SELECT COUNT(*) FROM Produto", conexao);
            long quantidade = (long)total.ExecuteScalar()!;
            if (quantidade == 0)
            {
                string inserir = """
                    INSERT INTO Produto (nome, descricao, categoria, plataforma, estoque, preco, imagem)
                    VALUES
                    ('PlayStation 5 Slim', 'Console Sony com SSD de alta velocidade e controle DualSense.', 'Console', 'PlayStation 5', 8, 3499.90, 'https://images.unsplash.com/photo-1606813907291-d86efa9b94db?auto=format&fit=crop&w=900&q=80'),
                    ('Xbox Series X', 'Console Microsoft para jogos em 4K e alto desempenho.', 'Console', 'Xbox', 5, 3999.90, 'https://images.unsplash.com/photo-1621259182978-fbf93132d53d?auto=format&fit=crop&w=900&q=80'),
                    ('The Legend of Zelda: Tears of the Kingdom', 'Aventura épica em mundo aberto para Nintendo Switch.', 'Jogo', 'Nintendo Switch', 12, 299.90, 'https://images.unsplash.com/photo-1612287230202-1ff1d85d1bdf?auto=format&fit=crop&w=900&q=80')
                    """;
                using SqliteCommand seed = new SqliteCommand(inserir, conexao);
                seed.ExecuteNonQuery();
            }
        }
    }
}
