
import React, { useState,useEffect } from "react";
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
  Label
} from "reactstrap";
import {getEtudiants} from "services/EtudiantService"
import {getGroupes} from "services/GroupeService"
import {postInscrition} from "services/InscriptionService"
import CustomAutocomplete from "components/Inputs/Autocomplete"


const AjoutInscriptionModal = (props) => {

    const [isOpen, setIsOpen] = useState(false)
    const [anneeUniversitaire, setAnneeUniversitaire] = useState("")
    const [etudiantCin, setEtudiantCin] = useState("")
    const [niveau, setNiveau] = useState("")
    const [groupe, setGroupe] = useState("")
    const [etat, setEtat] = useState("")
    const [filiere, setFiliere] = useState("")

    const [groupeData,setGroupeData]=useState([])

    const onAjoutClickHandle=async()=>{
    console.log("here");
    let inscription = {
        "année_Universitaire":anneeUniversitaire,
        "cin":etudiantCin,
        "niveau":niveau,
        "groupeId":groupe,
        "etat":etat,
        "filiere":filiere

    }
    await postInscrition(inscription);
    await props.refetch()
    setIsOpen(false)
}

const fetchGroupes = async () => {
    const result = await getGroupes()
    
    setGroupeData(result.data)
  }

  useEffect(() => { fetchGroupes() }, [] )

return(
    <>
          <Button color="success" type="button" size="sm" onClick={()=>setIsOpen(true)} >Ajouter une inscription</Button>
          <Modal
                      className="modal-dialog-centered"
                      isOpen={isOpen}
                      toggle={()=>setIsOpen(!isOpen)}
                    >
                <div className="modal-header">
                  <h6 className="modal-title" id="modal-title-default">
                    Ajouter Une Inscription
                  </h6>
                  <button
                    aria-label="Close"
                    className="close"
                    data-dismiss="modal"
                    type="button"
                    onClick={()=>setIsOpen(false)}
                  >
                    <span aria-hidden={true}>×</span>
                  </button>
                </div>
                <div className="modal-body">
                  <Form role="form">
                  <Row>
                    <Col md="auto">
                              <FormGroup>
                                <Label>année Universitaire</Label>
                                <Input type="select" placeholder="Niveau" onChange={(e)=>setAnneeUniversitaire(e.target.value)}>
                                     <option disabled selected value> -- select an option -- </option>
                                    <option value="2020-2021">2020-2021</option>
                                    <option value="2019-2020">2019-2020</option>
                                </Input>
                              </FormGroup>
                          </Col>
                </Row>
                    <Row>
                      <Col md="6">
                              <FormGroup>
                                <Label>Etudiant</Label>
                                <CustomAutocomplete getOptions={getEtudiants} 
                                    onChange={(e,v)=>{setEtudiantCin(v.cin)}}
                                    renderOption={(option)=>(
                                        <div>
                                        {option.prenom+ " "+option.nom}<br/>
                                        <small><i>{"CIN: "+option.cin}</i></small>
                                        </div>
                                    )}
                                    getOptionLabel={(option) => option.prenom+" "+option.nom}
                                    />
                              </FormGroup>
                          </Col>

                    </Row>
                    <Row>
                    <Col md="auto">
                              <FormGroup>
                                <Label>Niveau</Label>
                                <Input type="select" placeholder="Niveau" onChange={(e)=>setNiveau(e.target.value)}>
                                    <option disabled selected value> -- select an option -- </option>
                                    <option value="1">1</option>
                                    <option value="2">2</option>
                                    <option value="3">3</option>
                                </Input>
                              </FormGroup>
                          </Col>
                          <Col md="auto">
                              <FormGroup>
                                <Label>Groupe</Label>
                                <Input type="select" placeholder="Groupe"  onChange={(e)=>{console.log(e.target.value); setGroupe(e.target.value)}}>
                                    {groupeData.map(groupe=>
                                        <option value={groupe.groupeId}>{groupe.libellé_groupe}</option>
                                        )}
                                    
                                </Input>
                              </FormGroup>
                          </Col>
                          <Col md="auto">
                              <FormGroup>
                                <Label>Etat</Label>
                                <Input type="select" placeholder="Etat"  onChange={(e)=>setEtat(e.target.value)}>
                                    <option disabled selected value> -- select an option -- </option>
                                    <option value="Nouveau">Nouveau</option>
                                    <option value="Redoublant">Redoublant</option>
                                </Input>
                              </FormGroup>
                          </Col>
                          <Col md="auto">
                              <FormGroup>
                                <Label>Filiere</Label>
                                <Input type="select" placeholder="Filiere" onChange={(e)=>setFiliere(e.target.value)}>
                                    <option disabled selected value> -- select an option -- </option>
                                    <option>GL</option>
                                    <option>Finance</option>
                                </Input>
                              </FormGroup>
                          </Col>
                    </Row>
                    </Form>
                    
                </div>
                <div className="modal-footer">
                <Button color="primary" type="button" onClick={()=>onAjoutClickHandle()}>
                  Ajouter
                </Button>
              </div>
          </Modal>
    </>
          
  )
  
  
  }
  
  export default AjoutInscriptionModal;