const DoctorModel = require("../Models/DoctorsModel");

let GetAllDoctors = async (req, res) => {  
  DoctorModel.find().populate('user', '-password').exec().then((AllDoctors) => {          
    res.status(200).json(AllDoctors);
  });
}

let GetDoctorByID = async (req, res) => {
  let ID = req.params.id;
  DoctorModel.findOne({_id: ID}).populate('user', '-password').exec().then((doctor) => {
    if (doctor)         
      res.status(200).json(doctor);
    else
      res.status(404).json("Doctor not found");
  });
}

let AddNewDoctor = (req, res) => {

  let newDoctor = req.body;

  DoctorModel.validate(newDoctor).then(()=> {
      
    let doctorDoc = new DoctorModel(newDoctor);   

    doctorDoc.save().then((doctor)=>{
        res.status(201).json({message: "Doctor Created Successfully", doctor});
    }).catch(()=>{
        res.status(400).json({message: "This user is registered as a doctor before"});
    });

  }).catch((reason) => {
      res.status(400).json({message: reason.message});
  })
}

let UpdateDoctorById = (req, res) => {
  let ID = req.params.id;
  let newDoctor = req.body;

  DoctorModel.validate(newDoctor).then(()=> {    
    DoctorModel.findOneAndUpdate({_id: ID}, newDoctor).then((doctor)=>{
      if (doctor)
        res.status(204).json();
      else
        res.status(404).json({message: "Doctor not found"});
    }).catch(()=>{
        res.status(400).json({message: "This user is registered as another doctor"});
    });

  }).catch((reason) => {
      res.status(400).json({message: reason.message});
  })
}

let DeleteDoctorByID = (req, res) => {
  let ID = req.params.id;

  DoctorModel.deleteOne({_id: ID}).then((deleteResult)=>{
    if (deleteResult.deletedCount)
      res.status(200).json({message: "Doctor deleted successfully", deleteResult});
    else
      res.status(404).json({message: "Doctor not found"});
  }).catch(()=>{
      res.status(500).json({message: "Server Error"});
  });
}

module.exports = {
    GetAllDoctors,
    GetDoctorByID,
    UpdateDoctorById,
    AddNewDoctor,
    DeleteDoctorByID
}