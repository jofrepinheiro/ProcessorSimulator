using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processador
{
    class Controle
    {
        int pc = -1;  /* Inicializa o contador de programa em -1 */
        Memoria mem = new Memoria(); /* Cria uma nova instância de Memória */
        Decodificador decode = new Decodificador(); /* Cria uma nova instância de Decodificador */
        Registrador reg = new Registrador(); /*Cria uma nova instância de Registrador*/
        ULA ula = new ULA();    /*Cria uma nova instância de ULA*/
        Barramento b = new Barramento(); /*Cria uma nova instância de Barramento*/
        int palavra; /*Atributo que será usado como palavra de 16 bits*/

        /*Relaciona a unidade de controle com a memória externa*/
        public Controle(Memoria memoria)
        {
            mem = memoria;
        }

        /* Estabelece a ordem da unidade de Controle
         * 1- Busca a palavra na memória
         * 2- Executa (inclui a decodificação) a instrução
         * OBS: O HALT será quando o contador de programa achar -1 na memória
        */
        public void doControle()
        {
            do
            {
                pc++;
                Console.WriteLine("PC: " + pc);
                palavra = busca(pc);
                Console.WriteLine("Busca: " + palavra);
                execucao();
                Console.WriteLine();
            } while (palavra != -1);
        }

        /* Faz o barramento receber o dado da memória
         * e depois entregá-lo para retorno da função.
         */
        public int busca(int pc)
        {
            b.enviar(mem.doMemoria(pc, 0, 2, 1));
            return b.receber();
        }

        /* Realiza a execução seguindo o padrão:
         * 1- Decodifica a palavra
         * 2- Seguindo a ordem do conjunto de instruções,
         * simula um seletor de instruções: se a operação é
         * de ULA ou não.
         */
        public void execucao()
        {
            int[] result = new int[3];
            result = decode.decode(palavra);
            //Simulação do Seletor de Instruções.
            if (result[0] < 8)
            {
                ula.registradorAccess(reg);
                ula.doULA(result[0], reg.leitura(result[1]), reg.leitura(result[2])); //Manda o conteúdo dos registradores para a ULA
            }
            else
                switch (result[0])
                {
                    case 8: jump(result[2]); break;
                    case 9: jz(result[2]); break;
                    case 10: mov(result[1], result[2]); break;
                    default: break;
                }
        }

        /*  Instrução de Movimento de Dados
         *  4 casos:
         *  Caso 1: Um dado para um registrador. (F1 = 1, F2 = 0) 
         *  Caso 2: De um registrador para outro. (F1 = 1, F2 = 1) 
         *  Caso 3: De um registrador para a memória. (F1 = 0, F2 = 1) 
         *  Caso 4: Um dado para a memória. (F1 = 0, F2 = 0) 
         */
        public void mov(int op1, int op2)
        {
            //Retira a flag dos operandos
            int end1 = op1 & 31;
            int end2 = op2 & 31;

            if ((op1 & 32) == 32)
            {
                if ((op2 & 32) == 0) reg.escrita(end1, op2); //Caso 1
                else reg.escrita(end1, reg.leitura(end2));  //Caso 2
            }
            else
            {
                if (((op2 & 32) == 32)) mem.doMemoria(op1, reg.leitura(end2), 1, 1); //Caso 3
                else mem.doMemoria(op1, op2, 1, 1); //Caso 4
            }
        }

        /*  Salto incondicional
         *  Muda a posição do contador de programa
         */
        public void jump(int posicao)
        {
            pc = posicao - 1;
        }

        /* Salto condicional
         * Muda a posição do contador de programa
         * se o registrador de estados for zero.
         */
        public void jz(int posicao)
        {
            if (ula.estado() == 0) { pc = posicao - 1; }
        }
    }
}
