const express = require("express");
const UsersController = require("../Controllers/UsersController");

const router = new express.Router();

router.post("/reg",UsersController.AddNewUser);
router.post("/login",UsersController.LoginUser);
router.put("/:id",UsersController.EditUser);
router.delete("/:id",UsersController.DeleteUser);

module.exports = router;