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
  Button,
  CardBody,
  Form,FormGroup,
  Input,
  Col,Label
} from "reactstrap";

import AjoutInscriptionModal from "modals/AjoutInscriptionModal"
import {getInscriptions} from "services/InscriptionService"
import ModifSupprimInscriptionModal from "modals/ModifSupprimInscriptionModal"

const Inscriptions = () => {

    const [inscriptions, setInscriptions] = useState([])

    const fetchInscriptions=async()=>{
        let filterParamters={
            "cin":"",
            "nom":"",
            "prenom":"",
            "niveau":0,
            "année_Universitaire":"",
            "etat":""
        }
        const resp=await getInscriptions(filterParamters)
        setInscriptions(resp.data)
        console.log(resp);
      }
    
      useEffect(() => { fetchInscriptions() }, [] )



        return(
            <>
            <div className="header bg-gradient-info pb-8 pt-5 pt-md-5">
            <Container fluid>
              <div className="header-body">

              </div>
            </Container>
          </div>
            <Container className="mt--7" fluid>
            {/* Table */}
            <Row>
              <div className="col">
                <Card className="shadow">
                  <CardHeader className="border-0">
                    
                        
                        <Form role="form">
                            <Row>
                            
                            
                                <Col md="auto">
                                        <FormGroup>
                                        <Label >Année universitaire</Label>
                                        <Input type="select" placeholder="Année universitaire" >
                                            
                                            <option>2020-2021</option>
                                            <option>2019-2020</option>
                                        </Input>
                                        </FormGroup>
                                    </Col>
                                    <Col md="auto">
                                        <FormGroup>
                                        <Label >Niveau</Label>
                                        <Input type="select" placeholder="Niveau" >
                                            <option>1</option>
                                            <option>2</option>
                                            <option>3</option>
                                        </Input>
                                        </FormGroup>
                                    </Col>
                                    <Col md="auto">
                                        <FormGroup>
                                        <Label >Groupe</Label>
                                        <Input type="select" placeholder="Groupe" >
                                            <option>1</option>
                                            <option>2</option>
                                            <option>3</option>
                                        </Input>
                                        </FormGroup>
                                    </Col>
                                    <Col md="auto">
                                        <FormGroup>
                                        <Label >Etat</Label>
                                        <Input type="select" placeholder="Etat" >
                                            <option>Nouveau</option>
                                            <option>Redoublant</option>
                                            
                                        </Input>
                                        </FormGroup>
                                    </Col>
                                    <Col md="auto">
                                        <FormGroup>
                                        <Label >CIN</Label>
                                        <Input type="text" placeholder="" />                                       
                                        </FormGroup>
                                    </Col>
                                    <Col md="auto">
                                        <FormGroup>
                                        <Label >Nom et prenom</Label>
                                        <Input type="text" placeholder="" />                                       
                                        </FormGroup>
                                    </Col>
                                    
                            </Row>
                            <Row>
                                <Col>
                                    <AjoutInscriptionModal  refetch={fetchInscriptions}/>
                                </Col>
                            </Row>
                        </Form>
                  </CardHeader>
                  <hr></hr>
                  
                  <CardBody>
                  <Table className="align-items-center table-flush" responsive>
                <thead className="thead-light">
                  <tr>
                    <th scope="col">Année universitaire</th>
                    <th scope="col">Cin</th>
                    <th scope="col">Nom et prenom</th>
                    <th scope="col">Date de naissance</th>
                    <th scope="col">Niveau</th>
                    <th scope="col">Groupe</th>
                    <th scope="col">Etat</th>
                    
                    <th scope="col" />
                  </tr>
                </thead>
                <tbody>
                

                {
                      inscriptions.map(inscription=>
                        <tr>
                          <td>{inscription.année_Universitaire}</td>
                          <td>{inscription.etudiant.cin}</td>
                          <td>{inscription.etudiant.prenom +" "+ inscription.etudiant.nom}</td>
                          <td>{inscription.etudiant.dateNaissance}</td>
                          <td>{inscription.niveau}</td>
                          <td>{inscription.groupe.libellé_groupe}</td>
                          <td>{inscription.etat}</td>
                          <td><ModifSupprimInscriptionModal inscription={inscription} refetch={fetchInscriptions}/></td>
                        </tr>
                        )
                    }
                </tbody>
                </Table>
                </CardBody>
                  </Card>
                </div>
            </Row>
            </Container>
        </>
    
        )



}


export default Inscriptions
