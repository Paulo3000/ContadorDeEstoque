using System;

using System.IO;

using System.Collections.Generic;

using System.Runtime.Serialization.Formatters;

using System.Xml;



namespace Estoque3
{

    class Program
    {

        static void Main(string[] args)
        {

        volta:



            List<string> produto = new List<string>();

            List<int> qtd = new List<int>();

            List<string> transforma = new List<string>();

            int cont = 0;

            using (StreamReader ler = new StreamReader(@"C:\Users\1988p\Desktop\programação\c#\ProgrmasConcluidos\38-Conta-estoque\Estoque3\bin\Debug\estoque.txt"))
            {

                while (!ler.EndOfStream)
                {



                    string linha = ler.ReadLine();

                    string[] divide = linha.Split(' ');



                    produto.Add(divide[0]);

                    //qtd.Add(int.Parse(divide[1]));

                    transforma.Add(linha);

                    transforma.Sort();

                }

            }





            foreach (var item in transforma)
            {

                cont++;

                Console.WriteLine(cont + ")" + item);

            }

            Console.WriteLine("\nEntrada.....1\nSaida.......2\n");



            int digito = int.Parse(Console.ReadLine());



            //Entrada de estoque................

            if (digito == 1)
            {



                Console.WriteLine("\ndigite qual produto deseja alterar\n");





                int escolha = int.Parse(Console.ReadLine());

                Console.WriteLine(transforma[escolha - 1]);

                string linha = transforma[escolha - 1];

                string[] divide1 = linha.Split(' ');



                qtd.Add(int.Parse(divide1[1]));

                int num = qtd[0];// coletou o a quantidade do estoque



                Console.WriteLine("Incluir\n");

                int inclusao = int.Parse(Console.ReadLine());

                int soma = num + inclusao;



                string incluir = divide1[0] + " " + soma;

                transforma.RemoveAt(escolha - 1);

                transforma.Add(incluir);

                transforma.Sort();



                //busca de um araquivo txt local

                using (StreamWriter escreve = new StreamWriter(@"C:\Users\1988p\Desktop\programação\c#\ProgrmasConcluidos\38-Conta-estoque\Estoque3\bin\Debug\estoque.txt"))
                {

                    foreach (var item in transforma)
                    {

                        escreve.WriteLine(item);

                    }

                }

                Console.WriteLine("Produto Incluso o sitema");



            }



            //-------------------------------------

            //saida

            if (digito == 2)
            {

                Console.WriteLine("\ndigite qual produto deseja alterar\n");

                int escolha = int.Parse(Console.ReadLine());

                Console.WriteLine(transforma[escolha - 1]);

                string linha = transforma[escolha - 1];

                string[] divide1 = linha.Split(' ');


                qtd.Add(int.Parse(divide1[1]));

                int num = qtd[0];// coletou o a quantidade do estoque



                Console.WriteLine("Remover\n");

                int inclusao = int.Parse(Console.ReadLine());

                int soma = num - inclusao;



                Console.WriteLine("Nome\n");

                string nome = Console.ReadLine();

                Console.WriteLine("Data\n");

                string data = Console.ReadLine();



                string incluir = divide1[0] + " " + soma;

                transforma.RemoveAt(escolha - 1);

                transforma.Add(incluir);

                transforma.Sort();



                List<string> exportacao_lista = new List<string>();//-----test



                using (StreamWriter escreve = new StreamWriter(@"C:\Users\1988p\Desktop\programação\c#\ProgrmasConcluidos\38-Conta-estoque\Estoque3\bin\Debug\estoque.txt"))
                {

                    foreach (var item in transforma)
                    {

                        escreve.WriteLine(item);

                        exportacao_lista.Add(item);

                    }

                }

                Console.WriteLine("Quantidade removida do sitema");



                //mostra as saidas

                List<string> estoque_ranking = new List<string>();



                using (StreamReader ler_ranking = new StreamReader(@"C:\Users\1988p\Desktop\programação\c#\ProgrmasConcluidos\38-Conta-estoque\Estoque3\bin\Debug\ranking.txt"))
                {

                    while (!ler_ranking.EndOfStream)
                    {

                        string linha_rk = ler_ranking.ReadLine();

                        estoque_ranking.Add(linha_rk);

                    }

                }



            //Bloco de registro de retirada de mercadoria

                using (StreamWriter ranking = new StreamWriter(@"C:\Users\1988p\Desktop\programação\c#\ProgrmasConcluidos\38-Conta-estoque\Estoque3\bin\Debug\ranking.txt"))
                {



                    string[] corta = incluir.Split('-');

                    estoque_ranking.Add(corta[0] + "---retirado " + inclusao + " unidades" + " em " + data + " por " + nome);





                    foreach (var item in estoque_ranking)
                    {

                        ranking.WriteLine(item);



                    }



                }



            }



             Console.ReadLine();

            Console.Clear();

            goto volta;







        }

    }

}

/*tipo de saída do programa exemplo:



Estes registros ficam num bloco de notas local, o programa chama-os e atualiza:

=======================================

AÇUCAR-------------------------- 2(será modificado este valor em caso de entrada ou saída)

AÇUCAR/MASKAVO-------- 1

AZEITE/DE/OLIVA------------- 17

AZEITONA/FATIADA--------- 2

BANHA------------------ 0

BARBECUE(3,6)------------------- 4

===================================

REGISTRO DE SAÍDA

transportadora/DO_FULANO/QUEIJO/FATIADO---retirado 1 unidades em 16/01/21 por JOÃO

transportadora/DO_FULANO/BATATA/PALITO---retirado 6 unidades em 16/01/21 por BELTRANO

transportadora/DO_FULANO/ANÉIS/DE/CEBOLA---retirado 1 unidades em 16/01/21 MARIA

*/






