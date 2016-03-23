using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processador
{
    class Memoria
    {
        /* Cria um array com 256 endereços (0 a 255). */
        private int[] memoria = new int[256];

        /* Inicializa todos os espaços do array com -1*/
        public Memoria() { for (int i = 0; i < 256; i++) memoria[i] = -1; }


        /* Passa o endereço, dado, operação e habilitação.
         * Se tudo estiver correto, realiza a operação.
         */
        public int doMemoria(int endereco, int dado, int operacao, short habi)
        {
            if (checkHabi(habi))                            //Checa se pode ou não realizar a operação
            {
                if (checkEnd(endereco))                     //Checa se o endereço é válido
                {
                    if (checkDado(dado))                   //Checa se o dado é válido
                    {
                        return checkOp(operacao, endereco, dado);
                    }
                }
            }
            return -1;
        }

        /*Coloca o dado na posição do array dada.*/
        public void escrita(int endereco, int dado) //Escreve o dado no endereço dado.
        {
            memoria[endereco] = dado;
        }

        /*Retorna o dado presente no endereço passado*/
        public int leitura(int endereco)
        {
            return memoria[endereco];
        }

        /* Checa se o endereço passado está no intervalo 0~255, que é o limite da memória.*/
        public bool checkEnd(int endereco)
        {
            if ((endereco > 255) || (endereco < 0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /* Identifica se a operação é de escrita(1) ou leitura(0) e a executa.*/
        public int checkOp(int operacao, int endereco, int dado)
        {
            if (operacao == 1)
            {
                escrita(endereco, dado);
                Console.WriteLine("Carregado para a posição " + endereco + " da memória: " + dado);
                return -4096;     // Decimal para 1111 000000 000000 (apenas uma confirmação da escrita, uma vez que precisa retornar algo)
            }
            else if (operacao == 2)
            {
                return leitura(endereco);
            }
            return -1;
        }

        /*Checa se o dado é do tamanho da palavra da memória, 16 bits.*/
        public bool checkDado(int dado)
        {
            if ((dado > 32767) || (dado < -32768))
            {
                return false;
            }
            return true;
        }

        /*Checa se habi é 1(habilitado) ou 2(desabilitado).*/
        public bool checkHabi(short habi)
        {
            if (habi == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
