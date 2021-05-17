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
import Index from "pages/admin/Index.js";
import Etudiants from "pages/admin/Etudiants"
import Enseignants from "pages/admin/Enseignants"

import Matieres from "pages/admin/Matieres"
import Notes from "pages/admin/Notes"
import Emplois from "pages/admin/Emplois"
import Inscriptions from "pages/admin/Inscriptions"


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
    icon: "ni ni-chart-bar-32 text-primary",
    component: Index,
    layout: "/admin",
  },
  {
    path: "/etudiants",
    name: "Etudiants",
    icon: "ni ni-hat-3 text-primary",
    component: Etudiants,
    layout: "/admin",
  },
  {
    path: "/inscriptions",
    name: "Inscriptions",
    icon: "ni ni-collection text-primary",
    component: Inscriptions,
    layout: "/admin",
  },
  {
    path: "/Enseignants",
    name: "Enseignants",
    icon: "ni ni-circle-08 text-primary",
    component: Enseignants,
    layout: "/admin",
  },
  {
    path: "/matieres",
    name: "Matieres",
    icon: "ni ni-books text-primary",
    component: Matieres,
    layout: "/admin",
  },
  {
    path: "/notes",
    name: "Notes",
    icon: "ni ni-paper-diploma text-primary",
    component: Notes,
    layout: "/admin",
  },
  {
    path: "/emplois",
    name: "Emplois",
    icon: "ni ni-calendar-grid-58 text-primary",
    component: Emplois,
    layout: "/admin",
  },


];
export default adminRoutes;
