
/*
Print the numbers 1 to 1000 to the console. 
Print them in groups of 10 per line with a space separating each number.  
When the number is multiple of three, print “sweet” instead of the number on the console.  
If the number is a multiple of five, print “salty” (instead of the number) to the console.  
For numbers which are multiples of three and five, print “sweet’nSalty” to the console (instead of the number).  
After the numbers have all been printed, print out how many sweet’s, how many salty’s, and how many sweet’nSalty’s. These are three separate groups, so sweet’nSalty does not increment sweet or salty (and vice versa). 
Include verbose commentary in the source code to tell me what each few lines are doing. 
The coding Challenge is due by midnight, today, 03.10.21. 
Push the “compilable” source code to your P0 repo. 
*/

using System;

namespace sweet_nSalty
{
    class Program
    {
        int sweetCount = 0;         // to count Sweet
        int saltyCount = 0;         // to count salty 
        int sweet_nSaltyCount = 0;
        static void Main(string[] args)
        {
            Program p = new Program();

            //calling pringjob 
            p.printJob();

            Console.WriteLine();        
            Console.WriteLine("Num of sweet: " + p.sweetCount + " , Num of salty: "+ p.saltyCount + " Num of Sweet'nSalty: " + p.sweet_nSaltyCount);
        }

        //mathod to print everything
        private void printJob(){

            for(int i = 1; i < 1001; i++){
                
                //to create newline everafter 10 numbers
                if((i-1) % 10 == 0){
                    Console.WriteLine();
                }
                if(i % 15 == 0){
                    Console.Write(" sweet’nSalty ");
                    sweet_nSaltyCount++;
                    continue;       
                }
                if(i % 3 == 0){
                     Console.Write(" sweet ");
                     sweetCount++;
                     continue;
                }
                if(i % 5 == 0){
                     Console.Write(" salty ");
                     saltyCount++;
                     continue;
                }

                Console.Write(" " + i + " ");
                
            }

        }

    }
}
