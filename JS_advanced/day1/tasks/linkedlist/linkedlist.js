var linkedlist = {
    data: [],
    pushVal: function(val) {
        if (this.data.length > 0) {
            if (val < this.data[this.data.length - 1].val) {
                throw new Error('Pushed value is not in order');
            } else if (val == this.data[this.data.length - 1].val) {
                throw new Error('Duplicate value');
            }
        }
        this.data.push({val});
    },
    enqueueVal: function(val) {
        if (this.data.length > 0) {
            if (val > this.data[0].val) {
                throw new Error('Enqueued value is not in order');
            } else if (val === this.data[0].val) {
                throw new Error('Duplicate value');
            }
        }
        this.data.unshift({val});
    },
    popVal: function() {
        if (this.data.length === 0) {
            throw new Error('List is empty');
        }
        return this.data.splice(this.data.length - 1, 1)[0];
    },
    dequeueVal: function() {
        if (this.data.length === 0) {
            throw new Error('List is empty');
        }
        return this.data.splice(0, 1)[0];
    },
    display: function() {
        return this.data;
    },
    remove: function(val) {
        for (var i in this.data) {
            if (this.data[i].val == val) {
                this.data.splice(i, 1);
                return;
            }
        }
        throw new Error("Value doesn't exist");
    },
    insert: function(val, index) {
        if (arguments.length == 1 && typeof val === 'number') {
            for (index = 0; index < this.data.length; index++) {
                if (this.data[index].val === val) {
                    throw new Error('duplicate value');
                }
                if (this.data[index].val > val) {
                    break;
                }
            }
        } else if (arguments.length == 2 && typeof val === 'number' && typeof index === 'number') {
            if ((!!this.data[index] && this.data[index].val > val) || (!!this.data[index+1] && this.data[index+1].val < val)) {
                throw new Error('invalid index, out of order');
            } else if (!!this.data[index] && this.data[index].val === val) {
                throw new Error('duplicate value');
            }
        } else {
            throw new Error('invalid parameters');
        }
        
        this.data.splice(index, 0, {val});
    }
}