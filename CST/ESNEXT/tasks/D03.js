// 1
class Point {
    x;
    y;
    constructor(x, y) {
        if (isFinite(x) && isFinite(y)) {
            this.x = x;
            this.y = y;
        } else {
            throw new Error("Point coordinates must be finite");
        }
    }

    toString() {
        return `(${this.x}, ${this.y})`;
    }
}

class Polygon {
    points = [];

    constructor(...coordinates) {
        if (coordinates.length % 2 != 0)
            throw new Error("Coordinates count must be even");

        for (let i = 0; i < coordinates.length; i += 2) {
            this.points.push(new Point(coordinates[i], coordinates[i+1]));
        }
    }

    draw(ctx, fillStyle = "#000") {
        ctx.fillStyle = fillStyle;
        ctx.beginPath();
        ctx.moveTo(this.points[0].x, this.points[0].y);

        for (let i = 1; i < this.points.length; i++) {
            ctx.lineTo(this.points[i].x, this.points[i].y);
        }

        // ctx.moveTo(this.points[0].x, this.points[1].y);
        ctx.closePath();
        ctx.fill();
    }

    toString() {
        let str =  'Points:\n';
        for (let point of this.points) {
            str += point.toString() + '\n';
        }
        return str;
    }
}

class Rectangle extends Polygon {
    width;
    height;
    constructor(x, y, width, height) {
        
        super(x, y, x, y+height, x+width, y+height, x+width, y);
        
        this.width = width;
        this.height = height;
    }

    area() {
        return this.width * this.height;
    }

    toString() {
        return `Area = ${this.area()}
Width = ${this.width}
Height = ${this.height}
${super.toString()}`;
    }
}

class Square extends Rectangle {
    constructor(x, y, side) {
        super(x, y, side, side);
    }
}

class Circle extends Polygon {
    radius;
    center;

    constructor(x, y, radius, resolution) {
        
        function generatepoints(x, y, radius, resolution, direction) {
            let tempPoints = [];
            
            for (let i = x - 1 * radius; i <= x + radius; i += radius * 2 / resolution) {
                let sqrt = Math.sqrt(radius*radius  - Math.pow((i - x), 2));
                let yp = y + direction * sqrt;
                tempPoints.push(i,yp);
            }
            
            return tempPoints;
        }
        
        super(...generatepoints(x, y, radius, resolution, 1),
        ...generatepoints(x, y, radius, resolution, -1));

        this.radius = radius;
        this.center = new Point(x, y);
    }

    area() {
        return Math.PI * Math.pow(this.radius, 2);
    }

    toString() {
        return `Area = ${this.area()}
Center = ${this.center}
Radius = ${this.radius}`;
    }
}

class Triangle extends Polygon {
    constructor(...coordinates) {
        if (coordinates.length != 6) {
            throw new Error("Triangle coordinates must be composed of 3 points");
        }

        super(...coordinates);
    }

    area() {
        return Math.abs(0.5 * (
            this.points[0].x * (this.points[1].y - this.points[2].y) +
            this.points[1].x * (this.points[2].y - this.points[0].y) +
            this.points[2].x * (this.points[0].y - this.points[1].y)));
    }    

    toString() {
        return `Area = ${this.area()}
${super.toString()}`;
    }
}

onload = async () => {
    let canvas = document.getElementById("canvas");
    let ctx = canvas.getContext('2d');

    let rect = new Rectangle(10,10, 100, 50);
    rect.draw(ctx);
    console.log(rect.toString());

    let circle = new Circle(60,120, 50, 200);
    circle.draw(ctx, "#d00");
    console.log(circle.toString());

    let sq = new Square(10,200, 100);
    sq.draw(ctx, "#0a0");
    console.log(sq.toString());

    let tr = new Triangle(10, 310, 10, 410, 110, 410);
    tr.draw(ctx, "#00a");
    console.log(tr.toString());


    // 3
    const tbody = document.getElementById("tbody");
    myFetch = url => fetch(url);

    myFetch("https://jsonplaceholder.typicode.com/users")
        .then((response) => response.json())
        .then((data) => {
            for (let i = 0; i < data.length; i++) {
                tbody.innerHTML += `
                <tr>
                    <th scope="row">${data[i].id}</th>
                    <td>${data[i].name}</td>
                    <td>${data[i].username}</td>
                    <td>@${data[i].email}</td>
                </tr>
                `
            }
        });
};


// 2
const myProxy = new Proxy({}, {
	set: function (target, key, value) {
        let add = false;

        if (typeof value == 'string') {
            if (key === "name" && value.length == 7) {
                add = true;
            }
            else if (key === "address") {
                add = true;
            }
        }
        else if (key === "age" && isFinite(value) && value >= 25 && value <= 60) {
            add = true;
        }
        
        if (add) {
            Reflect.set(target, key, value);
        }

        return add;
    }
})

// valid
myProxy.name = "1234567";
myProxy.address = "12345";
myProxy.age = 27;
// invalid
myProxy.name = "123456";
myProxy.address = 12345;
myProxy.age = "30";
myProxy.age = 20;
myProxy.another = "sdfsf";
// check
console.log(`myProxy: ${myProxy.name} ${myProxy.address} ${myProxy.age} ${myProxy.another}`);