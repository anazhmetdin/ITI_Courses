const PatientModel = require("../Models/PatientsModel");

let GetAllPatients = async (req, res) => {  
  PatientModel.find().populate('user', '-password').exec().then((AllPatients) => {          
    res.status(200).json(AllPatients);
  });
}

let GetPatientByID = async (req, res) => {
  let ID = req.params.id;
  PatientModel.findOne({_id: ID}).populate('user', '-password').exec().then((patient) => {
    if (patient)         
      res.status(200).json(patient);
    else
      res.status(404).json("Patient not found");
  });
}

let AddNewPatient = (req, res) => {

  let newPatient = req.body;

  PatientModel.validate(newPatient).then(()=> {
      
    let patientDoc = new PatientModel(newPatient);   

    patientDoc.save().then((patient)=>{
        res.status(201).json({message: "Patient Created Successfully", patient});
    }).catch(()=>{
        res.status(400).json({message: "This user is registered as a patient before"});
    });

  }).catch((reason) => {
      res.status(400).json({message: reason.message});
  })
}

let UpdatePatientById = (req, res) => {
  let ID = req.params.id;
  let newPatient = req.body;

  PatientModel.validate(newPatient).then(()=> {    
    PatientModel.findOneAndUpdate({_id: ID}, newPatient).then((patient)=>{
      if (patient)
        res.status(204).json();
      else
        res.status(404).json();
    }).catch(()=>{
        res.status(400).json({message: "This user is registered as another patient"});
    });

  }).catch((reason) => {
      res.status(400).json({message: reason.message});
  })
}

let DeletePatientByID = (req, res) => {
  let ID = req.params.id;

  PatientModel.deleteOne({_id: ID}).then((deleteResult)=>{
    if (deleteResult.deletedCount)
      res.status(200).json({message: "Patient deleted successfully", deleteResult});
    else
      res.status(404).json({message: "Patient not found"});
  }).catch(()=>{
      res.status(500).json({message: "Server Error"});
  });
}

module.exports = {
    GetAllPatients,
    GetPatientByID,
    UpdatePatientById,
    AddNewPatient,
    DeletePatientByID
}