using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processador
{
    class RegEstado
    {
        int estado;

        /*Muda o estado ZERO do registrador de estado para 1.*/
        public void zero() { estado = estado | 1; }
        /*Muda o estado OVERFLOW do registrador de estado para 1.*/
        public void overflow() { estado = estado | 2; }
        /*Muda o estado NEGATIVO do registrador de estado para 1.*/
        public void negativo() { estado = estado | 4; }
        /*Muda o estado DIVISÃO POR ZERO do registrador de estado para 1.*/
        public void divisaoPorZero() { estado = estado | 8; }

        /*Reseta o registrador de estado para o estado inicial: 0000.*/
        public void resetaEstado()
        {
            estado = 0;
            Console.WriteLine("Estado Resetado.");
        }

        /*Acesso ao estado para classes externas*/
        public int getEstado() { return estado; }

        /*Impressão do Estado*/
        public void imprimir() { Console.WriteLine("Registrador de Estado: " + estado); }
    }
}
