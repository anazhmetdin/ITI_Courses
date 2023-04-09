//#region Requires
const express = require("express");
const app = express();
const bodyParser = require("body-parser");
const PORT = process.env.PORT||7010;
//#endregion
//#region MiddleWares
app.use(bodyParser.urlencoded({extended:true}));
app.use(bodyParser.json());
//#endregion
//#region End Points
    //#region Patients Routes
        const PatientsRoutes = require("./Routes/PatientsRoutes");
        app.use("/api/Patients",PatientsRoutes);
   //#endregion
    //#region Doctors
        const DoctorsRoutes = require("./Routes/DoctorsRoutes");
        app.use("/api/Doctors",DoctorsRoutes);
    //#endregion

    //#region Auth [Registration - Login]
        const UsersRoutes = require("./Routes/UsersRoutes");
        app.use("/api/users",UsersRoutes);
    //#endregion

//#endregion
app.listen(PORT, ()=>{console.log("http://localhost:"+PORT)});