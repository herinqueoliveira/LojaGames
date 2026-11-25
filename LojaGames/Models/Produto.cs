namespace LojaGames.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = String.Empty;
        public string Descricao { get; set; } = String.Empty;
        public string Categoria { get; set; } = String.Empty;
        public string Plataforma { get; set; } = String.Empty;
        public int Estoque { get; set; }
        public double Preco { get; set; }
        public string Imagem { get; set; } = String.Empty;
    }
}
