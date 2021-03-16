/**         Sweet'NSalty 
* Print the numbers 1 to 1000 to the console. (console.log()).
* Print them in groups of 10 per line with a space separating each number. This will require string concatenation to print the 10 number/strings to the console at a time.
* When the number is a multiple of three, print “sweet” instead of the number on the console.  
* If the number is a multiple of five, print “salty” (instead of the number) to the console.  
* For numbers which are multiples of three and five, print “sweet’nSalty” to the console (instead of the number).  
* After the numbers have all been printed, print out how many sweet’s, how many salty’s, and how many sweet’nSalty’s.
* These are three separate groups, so sweet’nSalty does not increment sweet or salty (and vice versa). 
*/

var sweet_nSaltyCount = 0;              //to count number of sweetn'Salty when num is divisible by both 5 & 5
var sweetCount = 0;                     //to count number of sweet, when num is dibisible by 3
var saltyCount = 0;                     //to count number of salty, when num is dibisible by 5
var printString = ""                    // String to hold all the printing string

for(let i = 1; i < 1001; i++){

    // to print them in groups of 10 per line
    if((i-1) % 10 == 0){
        printString = printString.concat("\n");
    }

    //check if the number (i) is devisibal by both 5 & 3
    if(i % 15 == 0){
        //concatenation to printstring, (adding sweet’nSalty to printstring)
        printString = printString.concat(" sweet’nSalty ")
        sweet_nSaltyCount++;
        continue;       
    }
    if(i % 3 == 0){
         //concatenation to printstring, (adding ssweet to printstring)
         printString = printString.concat(" sweet ")
         sweetCount++;
         continue;
    }
    if(i % 5 == 0){
         //concatenation to printstring, (adding Salty to printstring)
         printString = printString.concat(" salty ")
         saltyCount++;
         continue;
    }
    //concatenation to printstring, (adding number (i) to printstring)
    printString = printString.concat(` ${i}  `);
}
console.log(printString);       //printing the whole thing 
console.log(); 
console.log();        
console.log("Num of sweet: " + sweetCount + " , Num of salty: "+ saltyCount + " Num of Sweet'nSalty: " + sweet_nSaltyCount);