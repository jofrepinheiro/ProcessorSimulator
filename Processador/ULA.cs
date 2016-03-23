using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processador
{
    class ULA
    {
        RegEstado regEstado = new RegEstado();
        Registrador reg = new Registrador();


        /*Direciona a ULA de acordo com o código de instrução dado. */
        public void doULA(int end1, int end2, int cod)
        {
            switch (cod)
            {
                case 0: //SOMA.
                    reg.escrita(end1, add(reg.leitura(end1), reg.leitura(end2)));
                    break;
                case 1: //SUBTRAÇÃO.
                    reg.escrita(end1, sub(reg.leitura(end1), reg.leitura(end2)));
                    break;
                case 2: //MULTIPLICAÇÃO.
                    reg.escrita(end1, mul(reg.leitura(end1), reg.leitura(end2)));
                    break;
                case 3: //DIVISÃO.
                    reg.escrita(end1, div(reg.leitura(end1), reg.leitura(end2)));
                    break;
                case 4: //AND.
                    reg.escrita(end1, and(reg.leitura(end1), reg.leitura(end2)));
                    break;
                case 5: //OR.
                    reg.escrita(end1, or(reg.leitura(end1), reg.leitura(end2)));
                    break;
                case 6: //NOT.
                    reg.escrita(end1, not(reg.leitura(end2), reg.leitura(end2)));
                    break;
                case 7: //XOR
                    reg.escrita(end1, xor(reg.leitura(end1), reg.leitura(end2)));
                default:
                    break;
            }

        }

        /* Atualiza o resultado da soma no primeiro operador, por padrão.
         * Antes de retornar o resultado, atualiza o registrador de estados.
         */
        public int add(int op1, int op2)
        {
            regEstado.resetaEstado();
            int resultado = op1 + op2;
            imprimir(op1, op2);
            if (!checar(resultado)) //Analisa se algum dos estados(ZERO, OVERFLOW ou NEGATIVO) é possível na operação. Se der overflow, não realiza a operação.
            {
                op1 = resultado;
            }
            regEstado.imprimir();
            return op1;

        }

        /* Atualiza o resultado da subtração no primeiro operador, por padrão.
        * Antes de retornar o resultado, atualiza o registrador de estados.
        */
        public int sub(int op1, int op2)
        {
            regEstado.resetaEstado();
            int resultado = op1 - op2;
            imprimir(op1, op2);
            if (!checar(resultado))
            {
                op1 = resultado;
            }
            regEstado.imprimir();
            return op1;
        }

        /* Atualiza o resultado da multiplicação no primeiro operador, por padrão.
        * Antes de retornar o resultado, atualiza o registrador de estados.
        */
        public int mul(int op1, int op2)
        {
            regEstado.resetaEstado();
            int resultado = op1 * op2;
            imprimir(op1, op2);
            if (!checar(resultado))
            {
                op1 = resultado;
                regEstado.imprimir();
            }
            imprimir(op1, op2);
            regEstado.imprimir();
            return op1;
        }

        /* Atualiza o resultado da divisão no primeiro operador, por padrão.
        * Antes de retornar o resultado, atualiza o registrador de estados.
        * OBS: Antes de realizar a divisão, checa se a operação vai ser uma divisão por
        * zero, atualiza o registrador de estados e ignora a operação.
        */
        public int div(int op1, int op2)
        {
            imprimir(op1, op2);
            regEstado.imprimir();

            if (op2 == 0)
            {
                regEstado.divisaoPorZero(); //Analisa se está se tratando de uma divisão por zero. Se sim, não realiza a operação. Se não, continua.
            }
            else
            {
                int resultado = op1 / op2;
                if (!checar(resultado)) { op1 = resultado; regEstado.imprimir(); }
                Console.WriteLine(resultado);
            }
            imprimir(op1, op2);
            regEstado.imprimir();
            return op1;
        }

        /* Atualiza o resultado do AND no primeiro operador, por padrão.
         * Antes de retornar o resultado, atualiza o registrador de estados.
         */
        public int and(int op1, int op2)
        {
            regEstado.resetaEstado();
            int resultado = op1 & op2;
            imprimir(op1, op2);
            if (!checar(resultado))
            {
                op1 = resultado;
                regEstado.imprimir();
            }
            imprimir(op1, op2);
            regEstado.imprimir();
            return op1;
        }

        /* Atualiza o resultado do OR no primeiro operador, por padrão.
        * Antes de retornar o resultado, atualiza o registrador de estados.
        */
        public int or(int op1, int op2)
        {
            regEstado.resetaEstado();
            int resultado = op1 | op2;
            imprimir(op1, op2);
            if (!checar(resultado))
            {
                op1 = resultado;
                regEstado.imprimir();
            }
            imprimir(op1, op2);
            regEstado.imprimir();
            return op1;
        }


        /* Atualiza o resultado do NOT no primeiro operador, por padrão.
        * Antes de retornar o resultado, atualiza o registrador de estados.
        */
        public int not(int op1, int op2)
        {
            regEstado.resetaEstado();
            int resultado = ~op1;
            imprimir(op1, op2);
            if (!checar(resultado))
            {
                op1 = resultado;
                regEstado.imprimir();
            }
            imprimir(op1, op2);
            regEstado.imprimir();
            return op1;

        }

        /* Atualiza o resultado do XOR no primeiro operador, por padrão.
        * Antes de retornar o resultado, atualiza o registrador de estados.
        */
        public int xor(int op1, int op2)
        {
            regEstado.resetaEstado();
            int resultado = op1 ^ op2;
            imprimir(op1, op2);
            if (!checar(resultado))
            {
                op1 = resultado;
            }
            regEstado.imprimir();
            return op1;

        }
        /*Checa se teve alguma mudança no resultado que altere o registrador de estado.*/
        public bool checar(int i)
        {
            if (i == 0)
            {
                regEstado.zero(); //Teste de Zero
            }

            if (i < 0)
            {
                regEstado.negativo(); //Teste de Negativo
            }

            if ((i > 31) || (i < -32)) //Teste de Overflow
            {
                regEstado.overflow();
                return true;
            }
            return false;
        }

        /* Retorna o estado do registrador de estados.
         * Necessário para o acesso da Unidade de Controle.
         */
        public int estado() { return regEstado.getEstado(); }

        /* Coloca o registrador geral no registrador específico. */
        public int registradorAccess(Registrador regist) { reg = regist; return -1; }

        /* Impressão dos operadores. */
        public void imprimir(int x, int y)
        {
            Console.WriteLine("Op1: " + x);
            Console.WriteLine("Op2: " + y);
        }
    }
}
