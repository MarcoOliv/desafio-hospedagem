namespace desafio_hospedagem.Models
{
    public class Pessoa
    {
        // Construtor padrão
        public Pessoa() { }

        // Construtor para nome apenas
        public Pessoa(string nome)
        {
            Nome = nome;
            Sobrenome = string.Empty; // Inicializa o sobrenome como vazio
        }

        // Construtor para nome e sobrenome
        public Pessoa(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }

        // Propriedades públicas para Nome e Sobrenome
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        // Propriedade calculada para o Nome Completo
        public string NomeCompleto => $"{Nome} {Sobrenome}".Trim().ToUpper();
    }
}
