using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processador
{
    class Barramento
    {
        private int dado;

        /*   A única função do Barramento é a de repassar dados
         *   Logo, duas simples funções.
         *   Uma para receber, outra para enviar o dado.
         */

        public int receber() { return dado; }
        public void enviar(int dado) { this.dado = dado; }
    }
}
