using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processador
{
    class Registrador
    {
        /* Cria 8 registradores, iniciando com -1. */
        public int AX, BX, CX, DX, EX, FX, GX, HX = -1; 

        /* Identifica o registrador e copia o dado passado para ele.*/
        public void escrita(int id, int dado)
        {
            switch (id)
            {
                case 0: AX = dado; imprimir(id); break;
                case 1: BX = dado; imprimir(id); break;
                case 2: CX = dado; imprimir(id); break;
                case 3: DX = dado; imprimir(id); break;
                case 4: EX = dado; imprimir(id); break;
                case 5: FX = dado; imprimir(id); break;
                case 6: GX = dado; imprimir(id); break;
                case 7: HX = dado; imprimir(id); break;
                default:
                    break;
            }
        }

        /*Identifica o registrador e retorna o conteúdo dele.*/
        public int leitura(int id)
        {
            switch (id)
            {
                case 0: return AX;
                case 1: return BX;
                case 2: return CX;
                case 3: return DX;
                case 4: return EX;
                case 5: return FX;
                case 6: return GX;
                case 7: return HX;
                default:
                    break;
            }
            return -1;

        }

        /* Imprime o conteúdo do registrador passado como parâmetro.*/
        public void imprimir(int id)
        {
            switch (id)
            {
                case 0: Console.WriteLine("Registrador AX: " + leitura(id)); break;
                case 1: Console.WriteLine("Registrador BX: " + leitura(id)); break;
                case 2: Console.WriteLine("Registrador CX: " + leitura(id)); break;
                case 3: Console.WriteLine("Registrador DX: " + leitura(id)); break;
                case 4: Console.WriteLine("Registrador EX: " + leitura(id)); break;
                case 5: Console.WriteLine("Registrador FX: " + leitura(id)); break;
                case 6: Console.WriteLine("Registrador GX: " + leitura(id)); break;
                case 7: Console.WriteLine("Registrador HX: " + leitura(id)); break;
                default:
                    break;
            }
        }
    }
}
