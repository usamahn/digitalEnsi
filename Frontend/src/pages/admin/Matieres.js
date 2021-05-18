import React, { useState, useEffect } from "react";
import {getModuleByNiveau} from "services/ModuleService"

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

// core components
import Header from "components/Headers/Header.js";
import AjoutModuleModal from "modals/AjoutModuleModal"

import ModifModuleModal from "modals/ModifModuleModal"
import {deleteModule} from "services/ModuleService"


const Matieres = () => {
    const [niveau,setNiveau]=useState(1)
    const [modules,setModules] =useState([])

  const fetchModules=async(niv=niveau)=>{
    const resp=await getModuleByNiveau(niv)
    setModules(resp.data)
    console.log(resp.data);
    console.log(resp.data.filter(m=>m.semestre==2));
  }

  useEffect(() => { fetchModules(niveau) }, [] )



    return(
    <>
    <div className="header bg-gradient-info pb-8 pt-5 pt-md-8">
        <Container fluid>
          <div className="header-body">
          <Nav
              className="nav-fill flex-column flex-sm-row"
              id="tabs-text"
              pills
              role="tablist"
            >
            <NavItem>
              <NavLink
                className={classnames("mb-sm-3 mb-md-0", {
                  active: niveau===1
                })}
                onClick={e=>{e.preventDefault();setNiveau(1);fetchModules(1)}}
                href=""
                role="tab"
              >
                1ére année
              </NavLink>
            </NavItem>
            <NavItem>
              <NavLink
                className={classnames("mb-sm-3 mb-md-0", {
                  active: niveau===2
                })}
                onClick={e=>{e.preventDefault();setNiveau(2);fetchModules(2)}}
                href=""
                role="tab"
              >
                2éme année
              </NavLink>
            </NavItem>
            <NavItem>
              <NavLink
                className={classnames("mb-sm-3 mb-md-0", {
                  active: niveau===3
                })}
                onClick={e=>{e.preventDefault();setNiveau(3);fetchModules(3)}}
                href=""
                role="tab"
              >
                3éme année
              </NavLink>
            </NavItem>
            </Nav>
          </div>
          </Container>
          </div>
      {/* Page content */}
      <Container className="mt--5" fluid>
          <Row>
            <div className="col">
                <Card className="shadow" body inverse color="secondary">
                    <CardTitle className="border-0">
                        <Row>
                        <h3 className="mb-0" color="primary">Matieres semestre 1</h3>        
                        <AjoutModuleModal niveau={niveau} semestre={1} refetch={fetchModules}/>
                        </Row>
                    </CardTitle>
                    <CardBody>
                        <Container>
                            <Row >
                            {
                            modules.filter(m=>m.semestre==1).map(m=>
                                <Col lg="6" xl="3" className="mt-3">
                                    <Card className="card-stats mb-4 mb-xl-0" style={{boxShadow:"0 2px 4px 0 rgba(0, 0, 0, 0.2), 0 3px 10px 0 rgba(0, 0, 0, 0.19)"}}>
                                        <CardBody>
                                            <Row>
                                            <div className="col">
                                                <CardTitle
                                                tag="h5"
                                                className="text-uppercase text-muted mb-0"
                                                >
                                                <h2>{m.libelleModule}</h2>
                                                </CardTitle>
                                                <span className="h4 font-weight-bold mb-0">
                                                Module de {m.volumeHoraire}H
                                                </span>
                                            </div>
                                            
                                            </Row>
                                            <Row className="mt-3">
                                                    <Col className="col-auto">
                                                      <ModifModuleModal module={m} refetch={()=>fetchModules(niveau)} />
                                                  </Col>
                                                  <Col className="col-auto">
                                                      <Button color="danger" type="button" size="sm" onClick={async ()=>{await deleteModule(m.moduleId);fetchModules(niveau)}}>Supprimer</Button>
                                                  </Col>
                                                  
                                            </Row>
                                        </CardBody>
                                    </Card>
                                    
                               </Col>)
                                  }
                            </Row>
                            
                        </Container>
                        
                    </CardBody>
                </Card>
            </div>
        </Row>
        <Row className="mt-5">
        <div className="col">
        <Card className="shadow" body inverse color="secondary">
                    <CardTitle className="border-0">
                        <Row>
                        <h3 className="mb-0" color="primary">Matieres semestre 2</h3>        
                        <AjoutModuleModal niveau={niveau} semestre={2} refetch={fetchModules}/>
                        </Row>
                    </CardTitle>
                    <CardBody>
                        <Container>
                            <Row >
                            {
                            modules.filter(m=>m.semestre==2).map(m=>
                                <Col lg="6" xl="3" className="mt-3">
                                    <Card className="card-stats mb-4 mb-xl-0" style={{boxShadow:"0 2px 4px 0 rgba(0, 0, 0, 0.2), 0 3px 10px 0 rgba(0, 0, 0, 0.19)"}}>
                                        <CardBody>
                                            <Row>
                                            <div className="col">
                                                <CardTitle
                                                tag="h5"
                                                className="text-uppercase text-muted mb-0"
                                                >
                                                <h2>{m.libelleModule}</h2>
                                                </CardTitle>
                                                <span className="h4 font-weight-bold mb-0">
                                                Module de {m.volumeHoraire}H
                                                </span>
                                            </div>
                                            
                                            </Row>
                                            <Row className="mt-3">
                                                    <Col className="col-auto">
                                                      <Button color="info" type="button" size="sm">Modifier</Button>
                                                  </Col>
                                                  <Col className="col-auto">
                                                      <Button color="danger" type="button" size="sm">Supprimer</Button>
                                                  </Col>
                                                  
                                            </Row>
                                        </CardBody>
                                    </Card>
                                    
                               </Col>)
                                  }
                            </Row>
                            
                        </Container>
                        
                    </CardBody>
                </Card>
            </div>
        </Row>

      </Container>
    </>)

}

export default Matieres;