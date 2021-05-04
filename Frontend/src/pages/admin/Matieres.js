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

// core components
import Header from "components/Headers/Header.js";



const Matieres = () => {
    const [niveau,setNiveau]=useState(1)
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
                onClick={e=>{e.preventDefault();setNiveau(1)}}
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
                onClick={e=>{e.preventDefault();setNiveau(2)}}
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
                onClick={e=>{e.preventDefault();setNiveau(3)}}
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
                        <h3 className="mb-0" color="primary">Matieres sem1</h3>        
                        <Button color="success" type="button" size="sm">Ajouter une matiere</Button>
                        </Row>
                    </CardTitle>
                    <CardBody>
                        <Container>
                            <Row >
                                <Col lg="6" xl="3" className="mt-3">
                                    <Card className="card-stats mb-4 mb-xl-0" style={{boxShadow:"0 2px 4px 0 rgba(0, 0, 0, 0.2), 0 3px 10px 0 rgba(0, 0, 0, 0.19)"}}>
                                        <CardBody>
                                            <Row>
                                            <div className="col">
                                                <CardTitle
                                                tag="h5"
                                                className="text-uppercase text-muted mb-0"
                                                >
                                                Traffic
                                                </CardTitle>
                                                <span className="h2 font-weight-bold mb-0">
                                                350,897
                                                </span>
                                            </div>
                                            <Col className="col-auto">
                                                <div className="icon icon-shape bg-danger text-white rounded-circle shadow">
                                                <i className="fas fa-chart-bar" />
                                                </div>
                                            </Col>
                                            </Row>
                                            <p className="mt-3 mb-0 text-muted text-sm">
                                            <span className="text-success mr-2">
                                                <i className="fa fa-arrow-up" /> 3.48%
                                            </span>{" "}
                                            <span className="text-nowrap">Since last month</span>
                                            </p>
                                        </CardBody>
                                    </Card>
                                    
                               </Col>
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
                        <h3 className="mb-0" color="primary">Matieres sem2</h3>
                    </CardTitle>
                    <CardBody>
                        <Container>
                            <Row >
                                <Col lg="6" xl="3" className="mt-3">
                                    <Card className="card-stats mb-4 mb-xl-0">
                                        <CardBody>
                                            <Row>
                                            <div className="col">
                                                <CardTitle
                                                tag="h5"
                                                className="text-uppercase text-muted mb-0"
                                                >
                                                <h2>Math</h2>
                                                </CardTitle>
                                                <span className="h4 font-weight-bold mb-0">
                                                Module de 42H
                                                </span>
                                            </div>
                                            
                                            </Row>
                                            <Row className="mt-3">
                                            <div className="col">
                                                <Button color="info" type="button" size="sm">Modifier</Button>
                                            </div>
                                            <div className="col">
                                                <Button color="danger" type="button" size="sm">Supprimer</Button>
                                            </div>
                                            </Row>
                                        </CardBody>
                                    </Card>
                                    
                               </Col>
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