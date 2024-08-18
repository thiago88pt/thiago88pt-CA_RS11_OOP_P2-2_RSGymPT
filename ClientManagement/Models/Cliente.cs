using System;
using System.ComponentModel.DataAnnotations;

namespace RSGymPT.ClientManagement.Models
{
    public class Cliente
    {
        #region Classes
        public int Id { get; set; }
        public string Nome { get; set; }
        public string TipoPagamento { get; set; } // Pontual ou Mensal
        public bool? Fidelizado { get; set; } // Sim ou Não
        public DateTime DataInscricao { get; set; } = DateTime.Now;
        public decimal ValorMensalidade { get; set; }
        public int ServicosUtilizados { get; set; } // Número de serviços permitidos
        public int MesesFidelizacao { get; set; } // Número de meses de fidelização (se for mensal)

        #endregion

        #region CalcularValorMensalidade
        public decimal CalcularValorMensalidade()
        {
            if (TipoPagamento == "Mensal" && Fidelizado == true && MesesFidelizacao >= 4)
            {
                return ValorMensalidade * 0.80m; // Aplicar desconto de 20% para clientes fidelizados por 4 meses ou mais
            }
            return ValorMensalidade; // Valor total sem desconto
        }
        #endregion

        #region CalcularServicosDisponiveis
        public int CalcularServicosDisponiveis()
        {
            if (TipoPagamento == "Mensal" && Fidelizado == true)
            {
                return int.MaxValue; // Clientes fidelizados podem usar todos os serviços
            }
            else if (TipoPagamento == "Mensal" && Fidelizado == false)
            {
                return 2; // Clientes não fidelizados podem usar apenas 2 serviços
            }
            else if (TipoPagamento == "Pontual")
            {
                return 1; // Clientes pontuais podem usar 1 serviço
            }
            return 0; 
        }

        // Valor com desconto aplicado, se for o caso
        #endregion

        #region CalcularValorComDesconto
        public decimal CalcularValorComDesconto()
        {
            if (TipoPagamento == "Mensal" && Fidelizado == true && MesesFidelizacao >= 4)
            {
                return ValorMensalidade * 0.80m; // Aplica o desconto de 20%
            }
            return ValorMensalidade; // Retorna o valor original se não houver desconto
        }
        #endregion

    }


}
