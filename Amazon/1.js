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
 * Complete the 'maxSubarrayLength' function below.
 *
 * The function is expected to return an INTEGER.
 * The function accepts INTEGER_ARRAY badges as parameter.
 */

//!!! I don't understand what is 'subarray that the product of all the elements is 1' What is the PRODUCT?
//Is it max len subarray with first and last elem are 1? - my case
//Is it max len subarray with all elem are 1?
//Or subarray with SUM of all elem is 1?
//Or smth else?

function maxSubarrayLength(badges) {
    let firstOneIndex = 0;
    let lastOneIndex = badges.length - 1;
    let result = 0;
    
    for(let i = 0; i < badges.length; i++) {
        if (badges[i] == 1) {
            firstOneIndex = i;
            break;
        }
    }
    
    for(let i = badges.length - 1; i >=0; i--) {
        if (badges[i] == 1) {
            lastOneIndex = i;
            break;
        }
    }
    
    result = lastOneIndex - firstOneIndex + 1;
    
    return result;
}

function main() {
    const ws = fs.createWriteStream(process.env.OUTPUT_PATH);

    const badgesCount = parseInt(readLine().trim(), 10);

    let badges = [];

    for (let i = 0; i < badgesCount; i++) {
        const badgesItem = parseInt(readLine().trim(), 10);
        badges.push(badgesItem);
    }

    const result = maxSubarrayLength(badges);

    ws.write(result + '\n');

    ws.end();
}
