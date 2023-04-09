const userModel = require("../Models/UsersModel");
const bcrypt = require("bcrypt");

let AddNewUser = async (req,res)=>{

    let newUser = req.body;

    userModel.validate(newUser).then(()=> {
        
        bcrypt.genSalt(10).then((genSalt) => {
            bcrypt.hash(newUser.password, genSalt).then((hashedPassword) => {
    
                newUser.password = hashedPassword;
            
                let newUSER = new userModel(newUser);   
        
                newUSER.save().then((user)=>{
                    res.status(201).json({message: "User Created Successfully", user});
                }).catch((err)=>{
                    res.status(400).json({message: "Email already exists"});
                });
            })
        });

    }).catch((reason) => {
        res.status(400).json({message: reason.message});
    })
}


let LoginUser = async (req,res)=>{
    let logUser = req.body;
    if (logUser.email && logUser.password) {

        // 1)find user with this email
        userModel.findOne({email:logUser.email}).exec().then((foundUser)=> {

            if(!foundUser) return res.status(401).json({message:"Invalid Email Or Password"});
        
            // 2)Check Password
            bcrypt.compare(logUser.password, foundUser.password).then((checkPass) => {

                if(!checkPass) return res.status(401).json({message:"Invalid Email Or Password"});
            
                res.status(200).json({message:"Logged-In Successfully"})
            })
        })
    }
    else {
        return res.status(401).json({message:"Email and Password are required"});
    }
}

let EditUser = async (req,res)=>{
    let ID = req.params.id;
    let newUser = req.body;

    userModel.validate(newUser).then(()=> {   

        bcrypt.genSalt(10).then((genSalt) => {
            bcrypt.hash(newUser.password, genSalt).then((hashedPassword) => {
    
                newUser.password = hashedPassword;
                
                userModel.findOneAndUpdate({_id: ID}, newUser).then((user)=>{
                if (user)
                    res.status(200).json({message: "User updated successfully", user});
                else
                    res.status(404).json({message: "User not found"});
                }).catch(()=>{
                    res.status(400).json({message: "This email is used by another user"});
                });
            });
        });
    }).catch((reason) => {
        res.status(400).json({message: reason.message});
    })
}

let DeleteUser = (req, res) => {
    let ID = req.params.id;
  
    userModel.deleteOne({_id: ID}).then((deleteResult)=>{
      if (deleteResult.deletedCount)
        res.status(200).json({message: "User deleted successfully", deleteResult});
      else
        res.status(404).json({message: "User not found"});
    }).catch(()=>{
        res.status(500).json({message: "Server Error"});
    });
  }

module.exports = {
    AddNewUser,
    LoginUser,
    EditUser,
    DeleteUser
}