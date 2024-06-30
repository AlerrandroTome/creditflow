using creditflow.services.creditcard.core.Enums;

namespace creditflow.services.creditcard.core.Entities
{
    public class Cartao : BaseEntity
    {
        public Cartao(Guid clienteId, decimal totalCredito)
            : base(Guid.NewGuid())
        {
            ClienteId = clienteId;
            TotalCredito = totalCredito;
            DataEmissao = DateTime.Now;
            // Todo cartão terá a validade de 10 anos
            DataValidade = DateTime.Now.AddYears(10);
            Status = ECartaoStatus.Valido;
            GerarNumeroDoCartao();
        }

        public Guid ClienteId { get; private set; }
        public Cliente? Cliente { get; private set; }
        public string NumeroCartao { get; private set; }
        public decimal TotalCredito { get; private set; }
        public DateTime DataEmissao { get; private set; }
        public DateTime DataValidade { get; private set; }
        public ECartaoStatus Status { get; private set; }

        public void ExpirarCartao()
        {
            Status = ECartaoStatus.Expirado;
        }        
        
        public void BloquearCartao()
        {
            Status = ECartaoStatus.Bloqueado;
        }        
        
        public void AtualizarLimite(decimal newValue)
        {
            TotalCredito = newValue;
        }

        private void GerarNumeroDoCartao()
        {
            NumeroCartao = GerarNumeroCartao();
        }

        private string GerarNumeroCartao()
        {
            Random random = new Random();
            int[] digitos = new int[16];

            for (int i = 0; i < 15; i++)
            {
                digitos[i] = random.Next(0, 10);
            }

            // Calcula o dígito verificador usando o algoritmo de Luhn
            int digitoVerificador = CalcularDigitoVerificador(digitos);
            digitos[15] = digitoVerificador;

            return string.Join("", digitos);
        }

        private static int CalcularDigitoVerificador(int[] digitos)
        {
            int soma = 0;
            bool alternar = true;

            // Percorre os dígitos de trás para frente
            for (int i = digitos.Length - 2; i >= 0; i--)
            {
                int n = digitos[i];
                if (alternar)
                {
                    n *= 2;
                    if (n > 9)
                    {
                        n -= 9;
                    }
                }
                soma += n;
                alternar = !alternar;
            }

            // Calcula o dígito verificador
            int digitoVerificador = (10 - (soma % 10)) % 10;
            return digitoVerificador;
        }
    }
}