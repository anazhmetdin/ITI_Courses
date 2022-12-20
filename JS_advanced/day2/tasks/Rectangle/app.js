function Rectangle(_width, _height) {
    if (!isFinite(_width)) {
        throw new Error("Width must be a number");
    } else if (!isFinite(_height)) {
        throw new Error("Height must be a number");
    }

    this.width = _width;
    this.height = _height;

    this.getArea = function() {
        return this.width * this.height;
    }

    this.getPerimeter = function() {
        return 2 * (this.width + this.height);
    }

    this.displayInfo = function() {
        return `width: ${this.width}
height: ${this.height}
area: ${this.getArea()}
perimeter: ${this.getPerimeter()}`
    }
}