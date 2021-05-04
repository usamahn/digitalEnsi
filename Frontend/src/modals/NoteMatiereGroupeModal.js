import React, { useState } from "react";
// reactstrap components
import {
  Button,
  Card,
  CardHeader,
  CardBody,
  FormGroup,
  Form,
  Input,
  InputGroupAddon,
  InputGroupText,
  InputGroup,
  Modal,
  Row,
  Col,
  Table,
  UncontrolledDropdown,
  DropdownItem,
  DropdownToggle,
  DropdownMenu
} from "reactstrap";





const NoteMatiereGroupeModal = (props) => {
return(
        <Modal
            className="modal-dialog-centered"
            size="lg"
            isOpen={props.isOpen}
            
            toggle={() => {props.setModal(!props.isOpen)}}
            >


                                <Table className="align-items-center table-flush" responsive>
                                        <thead className="thead-light">
                                        <tr>
                                            
                                            <th scope="col">Nom et prenom</th>
                                            <th scope="col">Note DS</th>
                                            <th scope="col">Note CC</th>
                                            <th scope="col">Note Examen Principal</th>
                                            
                                            <th scope="col">Moyenne Principal</th>
                                            <th scope="col">Note Examen Ratrappage</th>
                                            <th scope="col">Moyenne Rattrapage</th>
                                            
                                            <th scope="col" />
                                        </tr>
                                        </thead>
                                        <tbody>
                                                
                                                    {
                                                    props.notesData.map(notedata=>
                                                    <tr>
                                                        <td>{notedata.nom}</td>
                                                        <td>{notedata.noteDs}</td>
                                                        <td>{notedata.noteCc}</td>
                                                        <td>{notedata.noteExamenP}</td>
                                                        <td>{notedata.moyennePrincipal}</td>
                                                        <td>{notedata.noteExamenR}</td>
                                                        <td>{notedata.moyenneRattrapage}</td>
                                                        <td className="text-right">
                                                            <UncontrolledDropdown>
                                                            <DropdownToggle
                                                                className="btn-icon-only text-light"
                                                                href="#pablo"
                                                                role="button"
                                                                size="sm"
                                                                color=""
                                                                onClick={(e) => e.preventDefault()}
                                                            >
                                                                <i className="fas fa-ellipsis-v" />
                                                            </DropdownToggle>
                                                            <DropdownMenu className="dropdown-menu-arrow" right>
                                                                <DropdownItem
                                                                href="#pablo"
                                                                onClick={(e) => e.preventDefault()}
                                                                >
                                                                Action
                                                                </DropdownItem>
                                                                <DropdownItem
                                                                href="#pablo"
                                                                onClick={(e) => e.preventDefault()}
                                                                >
                                                                Another action
                                                                </DropdownItem>
                                                                <DropdownItem
                                                                href="#pablo"
                                                                onClick={(e) => e.preventDefault()}
                                                                >
                                                                Something else here
                                                                </DropdownItem>
                                                            </DropdownMenu>
                                                            </UncontrolledDropdown>
                                                        </td>
                                                    </tr>
                                                        )
                                                    }
                        
                        
                        
                                            </tbody>
                                        </Table>
            
            
            </Modal>)





}
export default  NoteMatiereGroupeModal;