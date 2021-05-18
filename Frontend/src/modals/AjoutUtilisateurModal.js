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
  Col
} from "reactstrap";

import ReactDatetime from "react-datetime";
import moment from 'moment';
import 'moment/locale/fr';


const AjoutUtilisateurModal = (props) => {


    const [cin, setCin] = useState("")
    const [nom, setNom] = useState("")
    const [prenom, setPrenom] = useState("")
    const [dateNaissance, setDateNaissance] = useState("")
    const [email, setEmail] = useState("")
    const [tel, setTel] = useState("")
    const [userName, setUserName] = useState("")

    const onAjoutClickHandler= async ()=>{
        const person = {"cin":cin,
                        "nom":nom,
                        "prenom": prenom,
                        "userName":userName,
                        "dateNaissance":dateNaissance,
                        "email":email,
                        "PhoneNumber":tel       
                    }
                    console.log(person)
                    await props.addUser(person);
                    
                    await props.refetch();
                    props.setModal(false)
    }


    return(
        <Modal
              className="modal-dialog-centered"
              isOpen={props.isOpen}
              toggle={()=>props.setModal(!props.isOpen)}
            >
              <div className="modal-header">
                <h6 className="modal-title" id="modal-title-default">
                  Ajouter un utilisateur
                </h6>
                <button
                  aria-label="Close"
                  className="close"
                  data-dismiss="modal"
                  type="button"
                  onClick={()=>props.setModal(!props.isOpen)}
                >
                  <span aria-hidden={true}>×</span>
                </button>
              </div>
              <div className="modal-body">
                <Form role="form">
                <Row>
                <Col md="6">
                        <FormGroup>
                            <Input  placeholder="CIN" type="text" onChange={(e)=>setCin(e.target.value)}/>
                        </FormGroup>
                    </Col>
                    <Col md="6">
                        <FormGroup>
                            <Input  placeholder="Username" type="text" onChange={(e)=>setUserName(e.target.value)}/>
                        </FormGroup>
                    </Col>
                </Row>
                <Row>
                    <Col md="6">
                        <FormGroup>
                            <Input  placeholder="Prénom" type="text" onChange={(e)=>setPrenom(e.target.value)}/>
                        </FormGroup>
                    </Col>
                    <Col md="6">
                        <FormGroup>
                            <Input  placeholder="Nom" type="text" onChange={(e)=>setNom(e.target.value)}/>
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
                            <Input  placeholder="Email" type="Email" onChange={(e)=>setEmail(e.target.value)}/>
                        </FormGroup>
                    </Col>
                    <Col md="6">
                        <FormGroup>
                            <Input  placeholder="Tél" type="text" onChange={(e)=>setTel(e.target.value)}/>
                        </FormGroup>
                    </Col>
                </Row>
                
                </Form>
              </div>
              <div className="modal-footer">

            <Button color="primary" type="button" onClick={()=>onAjoutClickHandler()}>
              Ajouter
            </Button>
          </div>
        </Modal>
    )

}

export default  AjoutUtilisateurModal;