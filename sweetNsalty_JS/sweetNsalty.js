var sweet_nSaltyCount = 0;
var sweetCount = 0;
var saltyCount = 0;
for(let i = 1; i < 1001; i++){
    if((i-1) % 10 == 0){
        console.log();
    }

    if(i % 15 == 0){
        console.log(" sweet’nSalty ");
        sweet_nSaltyCount++;
        continue;       
    }
    if(i % 3 == 0){
         console.log(" sweet ");
         sweetCount++;
         continue;
    }
    if(i % 5 == 0){
         console.log(" salty ");
         saltyCount++;
         continue;
    }

    console.log(` ${i}  `);
}
console.log();        
console.log("Num of sweet: " + sweetCount + " , Num of salty: "+ saltyCount + " Num of Sweet'nSalty: " + sweet_nSaltyCount);