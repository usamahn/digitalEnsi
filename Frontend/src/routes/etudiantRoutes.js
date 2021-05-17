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
import Index from "pages/etudiant/Index.js";
import Etudiants from "pages/admin/Etudiants"
import Enseignants from "pages/admin/Enseignants"

import Matieres from "pages/admin/Matieres"
import Emplois from "pages/etudiant/Emplois"

import Notes from "pages/etudiant/Notes"
import Presences from "pages/enseignant/Presences"

import Profile from "views/examples/Profile.js";
import Maps from "views/examples/Maps.js";
import Register from "views/examples/Register.js";
//import Login from "views/examples/Login.js";
import Login from "pages/Login"
import Tables from "views/examples/Tables.js";
import Icons from "views/examples/Icons.js";

var etudiantRoutes = [
  {
    path: "/index",
    name: "Dashboard",
    icon: "ni ni-tv-2 text-primary",
    component: Index,
    layout: "/etudiant",
  },
  {
    path: "/emplois",
    name: "Emploi",
    icon: "ni ni-calendar-grid-58 text-primary",
    component: Emplois,
    layout: "/etudiant",
  },

  {
    path: "/notes",
    name: "Notes",
    icon: "ni ni-paper-diploma text-primary",
    component: Notes,
    layout: "/etudiant",
  },

];
export default  etudiantRoutes ;
