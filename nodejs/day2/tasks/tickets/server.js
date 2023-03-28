const {Tickets} = require("./TicketsSystem")

let user1 = new Tickets();
user1.Add("A103", "B101", "Cairo", "Paris", "24/4/2023");
user1.Add("A104", "B101", "Cairo", "Paris", "24/4/2023");
user1.Add("A105", "B101", "Cairo", "Paris", "24/4/2023");

user1.Add("A103", "B101", "Alex", "Paris", "24/4/2023");
user1.Update("A104", "B101", "Alex", "Paris", "24/4/2023");

console.log(user1.Get("A103", "B101"));
console.log(user1.Get("A104", "B101"));