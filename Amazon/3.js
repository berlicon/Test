'use strict';

const fs = require('fs');

process.stdin.resume();
process.stdin.setEncoding('utf-8');

let inputString = '';
let currentLine = 0;

process.stdin.on('data', function(inputStdin) {
    inputString += inputStdin;
});

process.stdin.on('end', function() {
    inputString = inputString.split('\n');

    main();
});

function readLine() {
    return inputString[currentLine++];
}



/*
 * Complete the 'getTotalImbalance' function below.
 *
 * The function is expected to return a LONG_INTEGER.
 * The function accepts INTEGER_ARRAY weight as parameter.
 */

function getTotalImbalance(weight) {
    let result = 0;
    
    //loop for 1, 2, 3... N subarrays
    for(let i = 1; i <= weight.length; i++) {
        for(let j = 0; j < weight.length - (i - 1); j++) {
/*            let subArray = weight.slice(j, j + i);
            let minElem = Math.min.apply(null, subArray);
            let maxElem = Math.max.apply(null, subArray);*/

            let minElem = weight[j];
            let maxElem = weight[j];
            
            //find min and max
            for(let k = j; k <= j + i; k++) {
                if (minElem < weight[k]) minElem = weight[k];
                if (maxElem > weight[k]) maxElem = weight[k];
            }            
            
            let imbalance = maxElem - minElem;
            result += imbalance;
        }
    }
    
    return result;
}

function main() {
    const ws = fs.createWriteStream(process.env.OUTPUT_PATH);

    const weightCount = parseInt(readLine().trim(), 10);

    let weight = [];

    for (let i = 0; i < weightCount; i++) {
        const weightItem = parseInt(readLine().trim(), 10);
        weight.push(weightItem);
    }

    const result = getTotalImbalance(weight);

    ws.write(result + '\n');

    ws.end();
}
