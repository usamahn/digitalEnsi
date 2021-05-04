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
  CardBody,
  Col,
  CardTitle,
  NavLink,
  NavItem,
  Nav,
  Button
} from "reactstrap";
import classnames from "classnames";

import NoteMatiereGroupeModal from "modals/NoteMatiereGroupeModal"

// core components
import Header from "components/Headers/Header.js";
import {getGroupes} from "services/GroupeService"

import {getModuleByNiveau,getModuleByNivGetNoteModuleParGroupeeau} from "services/ModuleService"



const Notes = () => {
  const [groupes,setGroupes]=useState([])
  const [selectedGroupe,setSelectedGroupe]=useState(null)
  const [modules,setModules]=useState([])
  const [noteData, setNoteData] = useState([])


  const [noteMatiereGroupeModalOpen,setNoteMatiereGroupeModalOpen] = useState(false)

  async function fetchgroupes()
  {
    const groupes=await getGroupes();
    setGroupes(groupes.data)
    setSelectedGroupe(groupes.data[0])
    fetchmodules(groupes.data[0].niveau)

  }

  async function fetchmodules(niveau)
  {
    const modulesData=await getModuleByNiveau(niveau);
    console.log(modules.data);
    setModules(modulesData.data)

  }
  useEffect(()=>{

    fetchgroupes()
  },[]
  )

  const onModuleClicked=async (année_Universitaire,groupeId,moduleId)=>{
    const Notes=await getModuleByNivGetNoteModuleParGroupeeau(année_Universitaire,groupeId,moduleId)
    console.log(Notes.data);
    setNoteData(Notes.data)
    setNoteMatiereGroupeModalOpen(true)
  }


  return(
    <>
      <div className="header bg-gradient-info pb-8 pt-5 pt-md-5">
        <Container fluid>
          <div className="header-body"></div>
        </Container>
      </div>
      <Container className="mt--5" fluid>
                <Row>
                  <div className="col">
                      <Card className="shadow" body inverse color="secondary">
                          <CardTitle className="border-0">
                              <Row>
                              <h3 className="mb-0" color="primary">Notes</h3>        
                              
                              </Row>
                          </CardTitle>
                          <CardBody>
                              <Container>
                              <Nav
                                  className="nav-fill flex-column flex-sm-row"
                                  id="tabs-text"
                                  pills
                                  role="tablist"
                                >
                                  <Row>
                                {
                                  groupes.map(g=>
                                    <Col lg="3" xl="2" className="mt-2">
                                    <NavItem>
                                      <NavLink
                                        className={classnames("mb-sm-3 mb-md-0", {
                                          active: selectedGroupe===g
                                        })}
                                        onClick={e=>{e.preventDefault();setSelectedGroupe(g);fetchmodules(g.niveau)}}
                                        href=""
                                        role="tab"
                                      >
                                        {g.libellé_groupe}
                                      </NavLink>
                                    </NavItem>
                                    </Col>
                                    )
                                }
                                </Row>
                                
                                </Nav>
                                <hr/>
                                <Row>
                                {modules.map(m=>
                                
                                  <Col lg="6" xl="3" className="mt-3">
                                      <a href="" onClick={e=>{e.preventDefault();onModuleClicked("2020-2021",selectedGroupe.groupeId,m.moduleId)}}>
                                        <Card className="card-stats mb-4 mb-xl-0" style={{boxShadow:"0 2px 4px 0 rgba(0, 0, 0, 0.2), 0 3px 10px 0 rgba(0, 0, 0, 0.19)"}}>
                                              <CardBody>
                                                  <h3>{m.libelleModule}</h3>
                                              </CardBody>
                                          </Card>
                                        </a>
                                  </Col>
                              )}
                              </Row>
                                    
                                    

                              </Container>
                          </CardBody>
                      </Card>

                  </div>
                </Row>
                <NoteMatiereGroupeModal isOpen={noteMatiereGroupeModalOpen} setModal={setNoteMatiereGroupeModalOpen} notesData={noteData}/>
      </Container>
     </> 
    )
}
export default Notes;