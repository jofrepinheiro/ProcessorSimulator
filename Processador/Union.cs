using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processador
{
    class Union
    {
        static void Main(String[] args)
        {
            /*Cria uma instância de Memoria*/
            Memoria mem = new Memoria();

            /*Carrega as instruções na Memória.*/
            mem.doMemoria(0, -22521, 1, 1); //mov AX, 7
            mem.doMemoria(1, -22463, 1, 1); //mov BX, 1
            mem.doMemoria(2, 66, 1, 1);     //add AX, BX
            //mem.doMemoria(3, -28672, 1, 1); //jz 6
            mem.doMemoria(3, -32762, 1, 1);
            mem.doMemoria(4, -22527, 1, 1); //mov AX 1
            //Posição 5: HALT
            mem.doMemoria(6, -22528, 1, 1); //mov AX 0
            //Posição 7: HALT
            Console.WriteLine();

            /*Cria uma Unidade de Controle e relaciona com a memória atual.*/
            Controle uc = new Controle(mem);

            /*Liga a unidade de Controle*/
            uc.doControle();

            Console.ReadKey();
        }
    }
}
