var obj = {
    id:"SD-10",
    location:"SV",
    addr:"123 st.",
    getSetGen: function(){
        var keys = Object.keys(this);

        for (var i in keys) {

            if (typeof this[keys[i]] != "function") {

                this[`set${keys[i][0].toUpperCase() + keys[i].slice(1)}`] = (function(i) {
                    console.log('adding setter');
                    return function(val) {
                        console.log('setter');
                        this[keys[i]] = val;
                    };
                }(i));
                
                this[`get${keys[i][0].toUpperCase() + keys[i].slice(1)}`] = (function(i) {
                    return function() {
                        return this[keys[i]];
                    }
                }(i));
            }
        }
    }
};