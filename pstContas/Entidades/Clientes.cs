using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contas.Entidades
{
    class Clientes
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public string[] email { get; set; }

        public double dinheiro { get; set; }

        public double depPoupanca { get; set; }

        public double depCorrente { get; set; }

        public bool corrente { get; set; }

        public bool poupanca { get; set; }
    }
}
