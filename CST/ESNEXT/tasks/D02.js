// 1
function courseInfo(obj)
{
    let defaultObj={
        courseName:'ES6',
        courseDuration:'3days',
        courseOwner:'JavaScript'
    }

    for (let key in obj){
        if (!defaultObj.hasOwnProperty(key)) {
            throw new Error(`Wrong object key: ${key}`);
        }
    };

    let result = Object.assign({}, defaultObj, obj);
    return `Course name: ${result.courseName}\nCourse duration ${result.courseDuration}\nCourse owner: ${result.courseOwner}`;
}

console.log("1-");

try {
    courseInfo({x:10});
} catch (e) {
    console.log(e.message);
}
console.log();
console.log(courseInfo({}));
console.log();
console.log(courseInfo({courseName:'Advanced'}));


// 2
console.log();
console.log("2-");

function* fibCount(n) {
    let first = 0, second = 1;

    for (let i = 0; i < n; i++) {
        yield second;
        [first, second] = [second, first+second];
    }
};

for (let val of fibCount(5)) {
    console.log(val);
}

console.log();

function* fibMax(n) {
    let first = 0, second = 1;

    while (second < n)
    {
        yield second;
        [first, second] = [second, first+second];
    }
};

for (let val of fibMax(5)) {
    console.log(val);
}

// 3
console.log();
console.log("3-");

let myObj ={
    [Symbol.replace]:function(str){
        if (str.length > 15)
            return str.substring(0,15) + "...";
        
        return str;
    }
}

console.log("123456789012345".replace(myObj));
console.log("1234567890123456".replace(myObj));

// 4
console.log();
console.log("4-");

let myObj2 ={
    x: 1,
    y: 2,
    z: 3,

    [Symbol.iterator]:function* (){
        for (let key in this)
            yield [key, this[key]]
    }
}

for (let [key, val] of myObj2) {
    console.log(key, val);
}