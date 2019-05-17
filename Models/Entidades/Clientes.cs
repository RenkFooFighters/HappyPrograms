using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgendaTelefonica.Models.Entidades
{
    public class Clientes
    {
        #region GET SET- CLIENTES, CONTATOS_CLIENTES, ENDERECO_CLIENTES
        //DEFINIÇÕES TABELA CLIENTES
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public string CNPJ { get; set; }

        //DEFINIÇÕES TABELA CONTATO
        public int Id_Contato { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public string DDD { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public string TelefoneCorporativo { get; set; }

        public string TelefoneCelCorporativo { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public string Email { get; set; }

        //DEFINIÇÕES TABELA ENDEREÇO

        public int Id_Endereco { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public string UF { get; set; }
        #endregion
    }
}