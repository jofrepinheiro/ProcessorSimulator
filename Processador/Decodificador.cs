using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processador
{
    class Decodificador
    {
        /*  Decodificação. Separa o OpCode e operandos 
         * e os coloca em um array
         *  ShiftR 12: 1111 111111 111111 = 1111 (OpCode)
         *  ShiftR 6: 1111 111111 11111 = 1111 111111
         *  1111 111111 AND 111111 = 111111  (Operando 1)
         *  1111 11111 111111 AND 111111 = 111111 (Operando 2)
         */        
        public int[] decode(int palavra)
        {
            int[] resultado = new int[3];
            resultado[0] = (palavra >> 12)& 15; //Opcode
            resultado[1] = (palavra>>6) & 63; //Operador 1
            resultado[2] = palavra & 63; //Operador 2      
            imprimir(resultado);
            return resultado; //Retorna o array com a palavra separada
        }

        //Impressão da palavra decodificada
        public void imprimir(int[] x)
        {
            Console.WriteLine("Opcode: " + x[0] + " Operando 1: " + x[1] + " Operando 2: " + x[2]);
        }
    }
}
