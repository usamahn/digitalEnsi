/*!

=========================================================
* Argon Dashboard React - v1.2.0
=========================================================

* Product Page: https://www.creative-tim.com/product/argon-dashboard-react
* Copyright 2021 Creative Tim (https://www.creative-tim.com)
* Licensed under MIT (https://github.com/creativetimofficial/argon-dashboard-react/blob/master/LICENSE.md)

* Coded by Creative Tim

=========================================================

* The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

*/
import React,{useContext,useState,createContext,useEffect} from "react";
import ReactDOM from "react-dom";
import { BrowserRouter, Route, Switch, Redirect } from "react-router-dom";

import {ProtectedRoute,LoggedinRoute} from "./ProtectedRoute"

import "assets/plugins/nucleo/css/nucleo.css";
import "@fortawesome/fontawesome-free/css/all.min.css";
import "assets/scss/argon-dashboard-react.scss";

import AdminLayout from "layouts/Admin.js";
import EnseignantLayout from "layouts/Enseignant";
import EtudiantLayout from "layouts/Etudiant";
import UserInfoContext from "UserInfoContext"
import Cookies from 'js-cookie'
import {getEnseignantInfo} from "services/EnseignantService"
import {getEtudiantInfo} from "services/EtudiantService"

import AuthLayout from "layouts/Auth.js";
  //const [userInfo, setUserInfo] = useState("en");
const App=()=>{
    const [userInfo, setUserInfo] = useState({"nom":"","prenom":""})
    const value = {userInfo, setUserInfo}


    const checkLogin=async()=>{    
        if(Cookies.get("isAuthentificated")=="true"){
        var userinfoResp={};
        switch(JSON.parse(Cookies.get('role'))[0]){ //les cookies sont de type chaine de caracteres, il faut les parser pour les rendre tableau (role est un tableau)
          case "Admin": break;
          case "Enseignant":userinfoResp = await getEnseignantInfo();break;
          case "Etudiant":userinfoResp = await getEtudiantInfo();break;
        }
        console.log(userinfoResp.data);
        setUserInfo(userinfoResp.data)
    }}

    useEffect(() => { checkLogin() }, [])

return(
    <BrowserRouter>
    <UserInfoContext.Provider value={value}>
        <Switch>
        
            <ProtectedRoute   path="/admin" role="Admin" component={(props) => <AdminLayout {...props} />} />
            <ProtectedRoute  path="/Enseignant" role="Enseignant" component={(props) => <EnseignantLayout {...props} />} />
            <ProtectedRoute  path="/Etudiant" role="Etudiant" component={(props) => <EtudiantLayout {...props} />} />

            <LoggedinRoute path="/auth" component={(props) => <AuthLayout {...props} />} />
            <Redirect to="/auth" />
        </Switch>
    </UserInfoContext.Provider>
    </BrowserRouter>
    );
}
export default App;