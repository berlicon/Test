exports.solution = function(words) {
  if(words.length === 0) return 0

  const alpha = [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."];
  count = {};
  str = words.join(' ');

  let fullCode = '';

  for(char in str) {
    if(str[char] !== ' ') fullCode += alpha[(str.charCodeAt(char) - 97)]
    else fullCode += ' '
  }

  fullCode.split(' ').forEach(phrase => count[phrase] = count[phrase] ? ++count[phrase] : 1);

  return Object.values(count).length;
}
