use ITI

db.createCollection("Instructors")
//a
db.Instructors.insertOne({firstName:"Ahmed",lastName:"Negm"})
//b
db.Instructors.find()
//c
let instructorsArray=[{_id:6,firstName:"noha",lastName:"hesham",
                age:21,salary:3500,
                address:{city:"cairo",street:10,building:8},
                courses:["js","mvc","signalR","expressjs"]},
                
                {_id:7,firstName:"mona",lastName:"ahmed",
                age:21,salary:3600,
                address:{city:"cairo",street:20,building:8},
                courses:["es6","mvc","signalR","expressjs"]},
                
                {_id:8,firstName:"mazen",lastName:"mohammed",
                age:21,salary:7040,
                address:{city:"Ismailia",street:10,building:8},
                courses:["asp.net","mvc","EF"]},
                
                {_id:9,firstName:"ebtesam",lastName:"hesham",
                age:21,salary:7500,
                address:{city:"mansoura",street:14,building:3},
                courses:["js","html5","signalR","expressjs","bootstrap"]}
		];
		
db.Instructors.insertMany(instructorsArray)

// 7
// a
db.Instructors.find()
// b
db.Instructors.find({},{lastName:1, firstName:1, address:1})
// c
db.Instructors.find({age:21},{firstName:1, address: {city:1}})
// d
db.Instructors.find({"address.city":"mansoura"},{firstName:1, age:1})
// e
// 1
db.Instructors.find({firstName:"mona"},{lastName:"ahmedd", age:"22"},{lastName:1})
// 2
db.Instructors.find({courses:"mvc"},{firstName:1,courses:1})