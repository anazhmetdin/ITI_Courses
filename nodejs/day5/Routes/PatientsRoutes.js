const express = require("express");
const PatientsController = require("../Controllers/PatientsController");

const router = new express.Router();

//Get All Patients
router.get("/", PatientsController.GetAllPatients);
//Get Patient By ID
router.get("/:id", PatientsController.GetPatientByID);
//Add New Patient
router.post("/", PatientsController.AddNewPatient);
//Update Patient
router.put("/:id", PatientsController.UpdatePatientById);
//Delete Patient
router.delete("/:id", PatientsController.DeletePatientByID);

module.exports = router;
