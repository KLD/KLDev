using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Timers;

namespace FirstProject
{
    class Program
    {

        static void Main(string[] args)
        {     
            int i = 0; 
            for(;;) //while, do while, switch 
            {
                i++; 
                Debug.WriteLine("hello " + i);

                if(i == 10)
                {
                    break; 
                }
            }
        }
    }
}















/*
  int friendsNumber = 3;
            float moneyBox = 0;

            //get input from first 
            Console.WriteLine("1 - how much money: ");
            string input1 = Console.ReadLine();
            moneyBox += float.Parse(input1);
            
            //get input from second
            Console.WriteLine("2 - how much money: ");
            string input2 = Console.ReadLine();
            moneyBox += float.Parse(input2);

            //get input from third
            Console.WriteLine("3 - how much money: ");
            string input3 = Console.ReadLine();
            moneyBox += float.Parse(input3);

            //print total and average
            Console.Write("You have total of ");
            Console.WriteLine(moneyBox);

            Console.Write("And your average is ");
            Console.WriteLine(moneyBox/friendsNumber);
 */












/*
Debug.Write(5);
Debug.Write(" + ");
Debug.Write(4);
Debug.Write(" = ");
Debug.WriteLine(5 + 4);

Debug.Write(2);
Debug.Write(" + ");
Debug.Write(9);
Debug.Write(" = ");
Debug.Write(2 + 9);
*/
