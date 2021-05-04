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
import Index from "views/Index.js";
import Etudiants from "pages/admin/Etudiants"
import Enseignants from "pages/admin/Enseignants"

import Matieres from "pages/admin/Matieres"
import Notes from "pages/admin/Notes"
import Emplois from "pages/admin/Emplois"


import Profile from "views/examples/Profile.js";
import Maps from "views/examples/Maps.js";
import Register from "views/examples/Register.js";
//import Login from "views/examples/Login.js";
import Login from "pages/Login"
import Tables from "views/examples/Tables.js";
import Icons from "views/examples/Icons.js";

var adminRoutes = [
  {
    path: "/index",
    name: "Dashboard",
    icon: "ni ni-tv-2 text-primary",
    component: Index,
    layout: "/admin",
  },
  {
    path: "/etudiants",
    name: "Etudiants",
    icon: "ni ni-tv-2 text-primary",
    component: Etudiants,
    layout: "/admin",
  },
  {
    path: "/Enseignants",
    name: "Enseignants",
    icon: "ni ni-tv-2 text-primary",
    component: Enseignants,
    layout: "/admin",
  },
  {
    path: "/matieres",
    name: "Matieres",
    icon: "ni ni-tv-2 text-primary",
    component: Matieres,
    layout: "/admin",
  },
  {
    path: "/notes",
    name: "Notes",
    icon: "ni ni-tv-2 text-primary",
    component: Notes,
    layout: "/admin",
  },
  {
    path: "/emplois",
    name: "Emplois",
    icon: "ni ni-tv-2 text-primary",
    component: Emplois,
    layout: "/admin",
  },
  {
    path: "/icons",
    name: "Icons",
    icon: "ni ni-planet text-blue",
    component: Icons,
    layout: "/admin",
  },
  {
    path: "/maps",
    name: "Maps",
    icon: "ni ni-pin-3 text-orange",
    component: Maps,
    layout: "/admin",
  },
  {
    path: "/user-profile",
    name: "User Profile",
    icon: "ni ni-single-02 text-yellow",
    component: Profile,
    layout: "/admin",
  },
  {
    path: "/tables",
    name: "Tables",
    icon: "ni ni-bullet-list-67 text-red",
    component: Tables,
    layout: "/admin",
  },
  {
    path: "/login",
    name: "Login",
    icon: "ni ni-key-25 text-info",
    component: Login,
    layout: "/auth",
  },
  {
    path: "/register",
    name: "Register",
    icon: "ni ni-circle-08 text-pink",
    component: Register,
    layout: "/auth",
  },
];
export default adminRoutes;
