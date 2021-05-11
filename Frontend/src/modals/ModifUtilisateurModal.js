import React ,{useState}from "react";
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
  DropdownItem,
  DropdownMenu,
  UncontrolledDropdown,
  DropdownToggle

} from "reactstrap";

import ReactDatetime from "react-datetime";
import moment from 'moment';
import 'moment/locale/fr';
import {UpdateEtudiant} from "services/EtudiantService"

const ModifUtilisateurModal = (props) => {

    const [isOpen,setIsOpen]=useState(false)
    const [cin, setCin] = useState(props.user.cin)
    const [nom, setNom] = useState(props.user.nom)
    const [prenom, setPrenom] = useState(props.user.prenom)
    const [dateNaissance, setDateNaissance] = useState(props.user.dateNaissance)
    const [email, setEmail] = useState(props.user.email)
    const [tel, setTel] = useState(props.user.tel)
    const [userName, setUserName] = useState(props.user.userName)

    

    const onModifClickHandler= async ()=>{
        const person = {"cin":cin,
                        "nom":nom,
                        "prenom": prenom,
                        "userName":userName,
                        "dateNaissance":dateNaissance,
                        "email":email,
                        "PhoneNumber":tel       
                    }
                    console.log(person)
                    await props.UpdateUser(person);
                    setIsOpen(false)
                    await props.refetch()
    }


    return(
    <>
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
                                      onClick={(e) => {e.preventDefault();setIsOpen(true);}}
                                    >
                                      Modifier
                                    </DropdownItem>
                                    <DropdownItem
                                      href="#pablo"
                                      onClick={(e) => {e.preventDefault();props.DeleteUser(cin);props.refetch()}}
                                    >
                                      Supprimer
                                    </DropdownItem>
                                    </DropdownMenu>
                        </UncontrolledDropdown>
        
        <Modal
              className="modal-dialog-centered"
              isOpen={isOpen}
              toggle={()=>setIsOpen(!isOpen)}
            >
              <div className="modal-header">
                <h6 className="modal-title" id="modal-title-default">
                  Type your modal title
                </h6>
                <button
                  aria-label="Close"
                  className="close"
                  data-dismiss="modal"
                  type="button"
                  onClick={()=>setIsOpen(!isOpen)}
                >
                  <span aria-hidden={true}>×</span>
                </button>
              </div>
              <div className="modal-body">
                <Form role="form">
                <Row>
                <Col md="6">
                        <FormGroup>
                            <Input  placeholder="CIN" type="text" value={cin} onChange={(e)=>setCin(e.target.value)}/>
                        </FormGroup>
                    </Col>
                    <Col md="6">
                        <FormGroup>
                            <Input  placeholder="Username" type="text" value={userName} onChange={(e)=>setUserName(e.target.value)}/>
                        </FormGroup>
                    </Col>
                </Row>
                <Row>
                    <Col md="6">
                        <FormGroup>
                            <Input  placeholder="Prénom" type="text" value={prenom} onChange={(e)=>setPrenom(e.target.value)}/>
                        </FormGroup>
                    </Col>
                    <Col md="6">
                        <FormGroup>
                            <Input  placeholder="Nom" type="text" value={nom} onChange={(e)=>setNom(e.target.value)}/>
                        </FormGroup>
                    </Col>
                </Row>
                <Row>
                <Col md="12">
                <FormGroup>
                        <InputGroup >
                            <InputGroupAddon addonType="prepend">
                            <InputGroupText>
                                <i className="ni ni-calendar-grid-58" />
                            </InputGroupText>
                            </InputGroupAddon>
                            <ReactDatetime
                            locale="fr-ca"
                            value={dateNaissance}
                            //dateFormat="dd/MM/YYYY"
                            inputProps={{
                                placeholder: "Date de naissance"
                            }}
                            timeFormat={false}
                            onChange={(e)=>{setDateNaissance(e.format("YYYY-MM-DD"));console.log(dateNaissance);}}
                            />
                        </InputGroup>
                    </FormGroup>
                    </Col>
                </Row>
                <Row>
                    <Col md="6">
                        <FormGroup>
                            <Input  placeholder="Email" type="Email" value={email} onChange={(e)=>setEmail(e.target.value)}/>
                        </FormGroup>
                    </Col>
                    <Col md="6">
                        <FormGroup>
                            <Input  placeholder="Tél" type="text" value={tel} onChange={(e)=>setTel(e.target.value)}/>
                        </FormGroup>
                    </Col>
                </Row>
                
                </Form>
              </div>
              <div className="modal-footer">

            <Button color="primary" type="button" onClick={()=>onModifClickHandler()}>
              Modifier
            </Button>
          </div>
        </Modal>
  </>
    )

}

export default  ModifUtilisateurModal;