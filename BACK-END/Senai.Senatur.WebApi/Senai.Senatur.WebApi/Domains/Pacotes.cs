using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Senatur.WebApi.Domains
{
    public partial class Pacotes
    {
        [Required(ErrorMessage = "O id do pacote é obrigatório")]
        public int IdPacote { get; set; }

        [Required(ErrorMessage = "O nome do pacote é obrigatório")]
        [DataType(DataType.Text)]
        public string NomePacote { get; set; }

        [Required(ErrorMessage = "O nome do pacote é obrigatório")]
        [DataType(DataType.Text)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "É preciso inserir a data da volta")]
        [DataType(DataType.Date)]
        public DateTime DataIda { get; set; }

        [Required(ErrorMessage = "É preciso inserir a data da volta")]
        [DataType(DataType.Date)]
        public DateTime DataVolta { get; set; }

        [Required(ErrorMessage = "O valor do pacote é obrigatório")]
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O nome da cidade é obrigatório")]
        [DataType(DataType.Text)]
        public string NomeCidade { get; set; }

        [Range(typeof(bool), "false", "true", ErrorMessage = "O valor tem que ser um booleano")]
        public bool Ativo { get; set; }
    }
}
