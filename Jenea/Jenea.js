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
 * Complete the 'cosine_similarity' function below.
 *
 * The function is expected to return a DOUBLE.
 * The function accepts following parameters:
 *  1. INTEGER_ARRAY a_keys
 *  2. DOUBLE_ARRAY a_values
 *  3. INTEGER_ARRAY b_keys
 *  4. DOUBLE_ARRAY b_values
 */

function cosine_similarity(a_keys, a_values, b_keys, b_values) {
    let result = 0;
    let dot = 0;
    let magA = 0;
    let magB = 0;
    //let maxIndex = 

    for(let i = 0; i < a_keys.length; i++) {        
        if (a_keys[i] == b_keys[i]) {
            dot += (a_values[i] * b_values[i]);
        }

        magA += (a_values[i] * a_values[i]);
        magB += (b_values[i] * b_values[i]);
    }
    
    result = dot / (Math.sqrt(magA) * Math.sqrt(magB));
    
    return result;
}

function main() {
    const ws = fs.createWriteStream(process.env.OUTPUT_PATH);

    const a_keysCount = parseInt(readLine().trim(), 10);

    let a_keys = [];

    for (let i = 0; i < a_keysCount; i++) {
        const a_keysItem = parseInt(readLine().trim(), 10);
        a_keys.push(a_keysItem);
    }

    const a_valuesCount = parseInt(readLine().trim(), 10);

    let a_values = [];

    for (let i = 0; i < a_valuesCount; i++) {
        const a_valuesItem = parseFloat(readLine().trim());
        a_values.push(a_valuesItem);
    }

    const b_keysCount = parseInt(readLine().trim(), 10);

    let b_keys = [];

    for (let i = 0; i < b_keysCount; i++) {
        const b_keysItem = parseInt(readLine().trim(), 10);
        b_keys.push(b_keysItem);
    }

    const b_valuesCount = parseInt(readLine().trim(), 10);

    let b_values = [];

    for (let i = 0; i < b_valuesCount; i++) {
        const b_valuesItem = parseFloat(readLine().trim());
        b_values.push(b_valuesItem);
    }

    const result = cosine_similarity(a_keys, a_values, b_keys, b_values);

    ws.write(result + '\n');

    ws.end();
}
