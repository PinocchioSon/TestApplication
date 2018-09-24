using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApplication.Models
{
    public class Estabelecimento
    {
        public int id { get; set; }
        public String razaoSocial { get; set; }
        public String nomeFantasia { get; set; }
        public String cnpj { get; set; }
        public String email { get; set; }
        public String endereco { get; set; }
        public String cidade { get; set; }
        public String estado { get; set; }
        public String telefone { get; set; }
        public String dataCadastro { get; set; }
        public int categoria { get; set; }
        public Boolean status { get; set; }
        public String agencia { get; set; }
        public String conta { get; set; }

    }
}