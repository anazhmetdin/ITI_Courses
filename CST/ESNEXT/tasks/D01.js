// 1 - swap
let x = 2, y = 1;
[x, y] = [y, x];
console.log(x, y);

// 2 - min max

function MinMax(...params)
{
    return [Math.min(...params), Math.max(...params)];
}

let numbers = [4,6,3,0,5,1,70,3,8,-4];
[x, y] = MinMax(...numbers);
console.log(x, y);

// 3 
var fruits = ["apple", "strawberry", "banana", "orange", "mango"];
// a - all string
console.log(fruits.every((v)=>{return typeof v == 'string'}));
// b - some start with a
console.log(fruits.some((v)=>{return v[0] === 'a'}));
// c - new string
x = fruits.map((v)=>{return `I like ${v}`});
// d - 
x.forEach(element => {
    console.log(element);
});