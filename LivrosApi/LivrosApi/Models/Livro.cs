using System.Text.Json.Serialization;

namespace LivrosApi.Models
{
    public class Livro
    {
        public int LivrosId { get; set; }
        public string Titulo { get; set; }
        public decimal Preco { get; set; }
        public string ISBN { get; set; }
        public int Estoque { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public int EditoraId { get; set; }  

        [JsonIgnore]
        public Editora Editora { get; set;  }
    }
}
