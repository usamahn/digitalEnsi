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
import React, { useState, useEffect } from "react";
import {getEtudiants} from "services/EtudiantService"

// reactstrap components
import {
  Badge,
  Card,
  CardHeader,
  CardFooter,
  DropdownMenu,
  DropdownItem,
  UncontrolledDropdown,
  DropdownToggle,
  Media,
  Pagination,
  PaginationItem,
  PaginationLink,
  Progress,
  Table,
  Container,
  Row,
  UncontrolledTooltip,
  Button
} from "reactstrap";
// core components
import Header from "components/Headers/Header.js";
import AjoutUtilisateurModal from "modals/AjoutUtilisateurModal"
import ModifUtilisateurModal from "modals/ModifUtilisateurModal"
import {CreateEtudiantAccount} from "services/AccountService"
import {UpdateEtudiant,DeleteEtudiant} from "services/EtudiantService"

const Etudiants = () => {
  const [data, setData] = useState([])
  const [ajoutModalOpen,setAjoutModalOpen]=useState(false)


  const getData = async () => {
    const result = await getEtudiants()
    
    setData(result.data)
  }

  useEffect(() => { getData() }, [] )

  return (
    <>
        <div className="header bg-gradient-info pb-8 pt-5 pt-md-8">
        
        </div>
      {/* Page content */}
      <Container className="mt--7" fluid>
        {/* Table */}
        <Row>
          <div className="col">
            <Card className="shadow">
              <CardHeader className="border-0">
                <Row>
                <h3 className="mb-0">Liste des etudiants</h3>
                <Button color="success" type="button" size="sm" onClick={(e)=>{setAjoutModalOpen(true)}}>Ajouter un etudiant</Button>
                </Row>
              </CardHeader>
              <Table className="align-items-center table-flush" responsive>
                <thead className="thead-light">
                  <tr>
                    <th scope="col">Cin</th>
                    <th scope="col">Nom et prenom</th>
                    <th scope="col">Date de naissance</th>
                    <th scope="col">Groupe</th>
                    <th scope="col">Email</th>
                    <th scope="col">Téléphone</th>
                    
                    <th scope="col" />
                  </tr>
                </thead>
                <tbody>
                  
                    {
                      data.map(etudiant=>
                        <tr>
                          <td>{etudiant.cin}</td>
                          <td>{etudiant.prenom +" "+ etudiant.nom}</td>
                          <td>{etudiant.dateNaissance}</td>
                          <td>{etudiant.groupe}</td>
                          <td>{etudiant.email}</td>
                          <td>{etudiant.phoneNumber}</td>
                          <td className="text-right">
                              <ModifUtilisateurModal UpdateUser={UpdateEtudiant} DeleteUser={DeleteEtudiant} user={etudiant} refetch={getData}/>
     
                          </td>
                        </tr>
                        )
                    }
                  
                  
                 
                </tbody>
              </Table>
            </Card>
          </div>
        </Row>
        <AjoutUtilisateurModal isOpen={ajoutModalOpen} setModal={setAjoutModalOpen} addUser={CreateEtudiantAccount} refetch={getData}/>
        
      </Container>
      
    </>
  );
};

export default Etudiants;
