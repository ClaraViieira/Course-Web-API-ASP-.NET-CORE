using System.Text.Json.Serialization;

namespace LivrosApi.Models
{
    public class Editora
    {
        public int EditoraId { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }

        [JsonIgnore]
        public ICollection<Livro> Livros { get; set; }
    }
}
