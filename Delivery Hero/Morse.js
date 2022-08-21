exports.solution = function(listOfWords) {
  let morse = [
    ".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."];
  let alpha = "abcdefghijklmnopqrstuvwxyz";
  let aTom = [];
  listOfWords.forEach((word) => {
	word = word.toLowerCase().trim();
    let temp = "";
    for (let ch of [...word]) {
      temp += morse[alpha.indexOf(ch)];
    }
    if (!aTom.includes(temp)) {
      aTom.push(temp);
    }
  });
  //console.log(aTom);
  return aTom.length;
}

//это корректно, 4 теста прошли. там были в апперкейсе GIN gin и пробелы. за минуту до конца увидел и догадался и засабмитил ок