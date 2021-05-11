import React ,{useState,useEffect}from "react";
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
  DropdownToggle,Label

} from "reactstrap";


import ReactDatetime from "react-datetime";
import moment from 'moment';
import 'moment/locale/fr';
import {UpdateInscrition,DeleteInscrition} from "services/InscriptionService"
import CustomAutocomplete from "components/Inputs/Autocomplete"
import {getGroupes} from "services/GroupeService"
import {getEtudiants} from "services/EtudiantService"

const ModifSupprimInscriptionModal = (props) => {

    const [isOpen,setIsOpen]=useState(false)
    const [anneeUniversitaire, setAnneeUniversitaire] = useState(props.inscription.année_Universitaire)
    const [etudiantCin, setEtudiantCin] = useState(props.inscription.etudiant.cin)
    const [niveau, setNiveau] = useState(props.inscription.niveau)
    const [groupe, setGroupe] = useState(props.inscription.groupeId)
    const [etat, setEtat] = useState(props.inscription.etat)
    const [filiere, setFiliere] = useState(props.inscription.filiere)

    const [groupeData,setGroupeData]=useState([])

    const onSupprimClickHandler= async ()=>{
        await DeleteInscrition(props.inscription.inscriptionId)
        await props.refetch()

    }


    const onModifClickHandler= async ()=>{
        let inscription = {
            "inscriptionId":props.inscription.inscriptionId,
            "année_Universitaire":anneeUniversitaire,
            "cin":etudiantCin,
            "niveau":niveau,
            "groupeId":groupe,
            "etat":etat,
            "filiere":filiere
    
        }
                    console.log(inscription)
                    await UpdateInscrition(inscription);
                    setIsOpen(false)
                    await props.refetch()
    }

    const fetchGroupes = async () => {
        const result = await getGroupes()
        
        setGroupeData(result.data)
      }
    
      useEffect(() => { fetchGroupes() }, [] )


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
                                      onClick={async (e) => {e.preventDefault();await onSupprimClickHandler()}}
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
                    <Col md="auto">
                              <FormGroup>
                                <Label>année Universitaire</Label>
                                <Input type="select" placeholder="Niveau" value={anneeUniversitaire} onChange={(e)=>setAnneeUniversitaire(e.target.value)}>
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
                                <h2> {props.inscription.etudiant.prenom+" "+props.inscription.etudiant.nom}</h2>
                                   
                              </FormGroup>
                          </Col>

                    </Row>
                    <Row>
                    <Col md="auto">
                              <FormGroup>
                                <Label>Niveau</Label>
                                <Input type="select" placeholder="Niveau" value={niveau} onChange={(e)=>setNiveau(e.target.value)}>
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
                                <Input type="select" placeholder="Groupe" value={groupe} onChange={(e)=>{console.log(e.target.value); setGroupe(e.target.value)}}>
                                    {groupeData.map(groupe=>
                                        <option value={groupe.groupeId}>{groupe.libellé_groupe}</option>
                                        )}
                                    
                                </Input>
                              </FormGroup>
                          </Col>
                          <Col md="auto">
                              <FormGroup>
                                <Label>Etat</Label>
                                <Input type="select" placeholder="Etat" value={etat} onChange={(e)=>setEtat(e.target.value)}>
                                    <option disabled selected value> -- select an option -- </option>
                                    <option value="Nouveau">Nouveau</option>
                                    <option value="Redoublant">Redoublant</option>
                                </Input>
                              </FormGroup>
                          </Col>
                          <Col md="auto">
                              <FormGroup>
                                <Label>Filiere</Label>
                                <Input type="select" placeholder="Filiere" value={filiere} onChange={(e)=>setFiliere(e.target.value)}>
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

            <Button color="primary" type="button" onClick={()=>onModifClickHandler()}>
              Modifier
            </Button>
          </div>
        </Modal>
  </>
    )

}

export default  ModifSupprimInscriptionModal;