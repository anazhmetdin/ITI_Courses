const express = require("express");
const DoctorsController = require("../Controllers/DoctorsController");

const router = new express.Router();

//Get All Doctors
router.get("/", DoctorsController.GetAllDoctors);
//Get Doctor By ID
router.get("/:id", DoctorsController.GetDoctorByID);
//Add New Doctor
router.post("/", DoctorsController.AddNewDoctor);
//Update Doctor
router.put("/:id", DoctorsController.UpdateDoctorById);
//Delete Doctor
router.delete("/:id", DoctorsController.DeleteDoctorByID);

module.exports = router;
