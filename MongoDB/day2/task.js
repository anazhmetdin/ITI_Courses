//1
//a
db.Instructors.find()
//b
db.Instructors.find({salary:{$gt:4000}}, {firstName: 1, salary:1})
//c
db.Instructors.find({age:{$lte:25}})
//d
db.Instructors.find({"address.city":"mansoura", "address.street":{$in:[10,14]}}, {firstName:1, address:1, salary:1})
//e
db.Instructors.find({$and:[{courses:"js"}, {courses:"expressjs"}]})
//f
db.Instructors.find({courses:{$exists:true}}).forEach(ins => {
    print(`${ins.firstName}, courses: ${ins.courses.length}`)
})
//g
db.Instructors.find({firstName:{$exists:true}, lastName:{$exists:true}, age:{$exists:true}}).sort({firstName:1, lastName:-1}).forEach(ins => {
    print(`${ins.firstName} ${ins.lastName}, age: ${ins.age}`)
})
//
db.Instructors.find({firstName:{$exists:true}, lastName:{$exists:true}, age:{$exists:true}}).sort({firstName:1, lastName:-1}).forEach(ins => {
    db.InstructorsData.insertOne({Name:ins.firstName+" "+ins.lastName, Age: ins.age})
})
//
db.InstructorsData.find()
// h
db.InstructorsData.find({Name:{$regex:/mohammed/i}})
// i
db.Instructors.deleteOne({firstName:"ebtesam", courses: {$size: 5}})
// j
db.Instructors.updateMany({}, {$set: {active: true}})
// k
db.Instructors.updateOne({firstName:"mazen", lastName:"mohammed", courses:"EF"}, {$set:{"courses.$":"jquery"}})
//
db.Instructors.find()
//l
db.Instructors.updateOne({firstName:"noha", lastName:"hesham"}, {$addToSet:{courses:"jquery"}})
//m
db.Instructors.updateOne({firstName:"mazen", lastName:"mohammed"}, {$unset:{courses:1}})
//n
db.Instructors.updateMany({courses:{$size:4}, salary:{$exists:true}}, {$inc:{salary:-500}})
//o
db.Instructors.updateMany({}, {$rename:{address:"fullAddress"}})
//p
db.Instructors.updateOne({firstName:"noha", lastName:"hesham"}, {$set:{"fullAdress.street":20}})