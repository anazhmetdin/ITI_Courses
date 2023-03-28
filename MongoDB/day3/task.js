//1
use FacultySystemV2

db.createCollection("Student", {
    validator: {
        $jsonSchema: {
            bsonType: "object",
            required: ["FirstName", "LastName", "IsFired", "FacultyID", "Courses"],
            additionalProperties:false,
            properties: {
                _id:{bsonType:"objectId"},
                FirstName: {
                    bsonType: "string",
                },
                LastName: {
                    bsonType: "string",
                },
                IsFired: {
                    bsonType: "bool",
                },
                FacultyID: {
                    bsonType: "objectId",
                },
                Courses: {
                    bsonType: "array",
                    items: {
                        bsonType: "object",
                        required: ["CourseID", "grade"],
                        properties: {
                            CourseID: {
                                bsonType: "objectId",
                            },
                            grade: {
                                bsonType: "int"
                            }
                        }
                    }
                }
            }
        }
    }
});


db.createCollection("Faculty", {
    validator: {
        $jsonSchema: {
            bsonType: "object",
            required: ["FacultyName", "Address"],
            additionalProperties:false,
            properties: {
                _id:{bsonType:"objectId"},
                FacultyName: {
                    bsonType: "string",
                },
                Address: {
                    bsonType: "string",
                }
            }
        }
    }
});


db.createCollection("Course", {
    validator: {
        $jsonSchema: {
            bsonType: "object",
            required: ["CourseName", "FinalMark"],
            additionalProperties:false,
            properties: {
                _id:{bsonType:"objectId"},
                CourseName: {
                    bsonType: "string",
                },
                FinalMark: {
                    bsonType: "int"
                }
            }
        }
    }
});


db.Faculty.insertMany([{
        FacultyName: "faculty 1",
        Address: "address 1"
    },
    {
        FacultyName: "faculty 2",
        Address: "address 2"
    },
    {
        FacultyName: "faculty 3",
        Address: "address 3"
    }
]);

db.Course.insertMany([{
        CourseName: "cours 1",
        FinalMark: 100
    },
    {
        CourseName: "course 2",
        FinalMark: 150
    },
    {
        CourseName: "course 3",
        FinalMark: 120
    }
]);

db.Student.insertMany([{
        FirstName: "John",
        LastName: "Doe",
        IsFired: false,
        FacultyID: ObjectId("60b0136da974b08e03b513d7"),
        Courses: [{
                CourseID: ObjectId("60b01f3da974b08e03b513db"),
                grade: 90
            },
            {
                CourseID: ObjectId("60b01f4ea974b08e03b513dc"),
                grade: 88
            }
        ]
    },
    {
        FirstName: "Jane",
        LastName: "Doe",
        IsFired: false,
        FacultyID: ObjectId("60b0136da974b08e03b513d8"),
        Courses: [{
                CourseID: ObjectId("60b01f3da974b08e03b513db"),
                grade: 92
            },
            {
                CourseID: ObjectId("60b01f4ea974b08e03b513dc"),
                grade: 85
            }
        ]
    },
    {
        FirstName: "Bob",
        LastName: "Smith",
        IsFired: true,
        FacultyID: ObjectId("60b0136da974b08e03b513d9"),
        Courses: [{
            CourseID: ObjectId("60b01f3da974b08e03b513dc"),
            grade: 78
        }]
    }
]);

//2
db.Student.find({}, {
    FullName: {
        $concat: ["$FirstName", " ", "$LastName"]
    },
    GradeAvg: {
        $avg: "$Courses.grade"
    }
});

//3
db.Course.aggregate(
    {$match: {}},
    {
        $group: {
            _id: null,
            TotalFinalMark: {
                $sum: "$FinalMark"
            }
    }
});

//4
db.Student.runCommand("collMod",{
    validator:
    {
        $jsonSchema: {
            bsonType: "object",
            required: ["FirstName", "LastName", "IsFired", "FacultyID", "CourseIDs", "Courses"],
            additionalProperties:false,
            properties: {
                _id:{bsonType:"objectId"},
                FirstName: {
                    bsonType: "string",
                },
                LastName: {
                    bsonType: "string",
                },
                IsFired: {
                    bsonType: "bool",
                },
                FacultyID: {
                    bsonType: "objectId",
                },
                CourseIDs: {
                    bsonType: "array",
                    items: {
                        bsonType: "objectId"
                    }
                },
                Courses: {
                    bsonType: "array",
                    items: {
                        bsonType: "object",
                        required: ["CourseID", "grade"],
                        properties: {
                            CourseID: {
                                bsonType: "objectId",
                            },
                            grade: {
                                bsonType: "int"
                            }
                        }
                    }
                }
            }
        }
    }    
})

db.Student.updateMany({},
    {
        $set: {
            CourseIDs: [
                ObjectId("6422b5bfc8b83e7d39350b93"),
                ObjectId("6422b5bfc8b83e7d39350b94"),
                ObjectId("6422b5bfc8b83e7d39350b95")
            ]
        }
    }
)

let student = db.Student.findOne({FirstName: "student"})

db.Course.find({_id: {$in: student.CourseIDs}})

//5
db.Student.aggregate([{
    $lookup: {
        from: "Faculty",
        localField: "FacultyID",
        foreignField: "_id",
        as: "Faculty"
    }
}])

db.Faculty.find({_id: student.FacultyID})