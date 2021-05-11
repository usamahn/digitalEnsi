
import React, { useState, useEffect } from "react";
import {getModuleByEnseignant,getNoteModuleParGroupe,postNoteModule,putNoteModule} from "services/ModuleService"
import {getGroupeByEnseignant} from "services/GroupeService"

import {getDatesSeance} from "services/EmploiService"

import {getEtudiantsByfilers} from "services/EtudiantService"

import ModifNoteModal from "modals/ModifNoteModal"

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
  Col,Label,Modal
} from "reactstrap";




const Presences = () => {
    const [semestre, setSemestre] = useState(0)
    const [groupesData, setGroupesData] = useState([])
    const [modulesData, setmodulesData] = useState([])
    const [moduleId, setmoduleId] = useState(null)
    const [groupeId, setGroupeId] = useState(null)

    const [dateData, setDateData] = useState([])
    const [isOpen, setIsOpen] = useState(false)

    const [etudiantsData, setEtudiantsData] = useState([])

    const fetchDate=async(groupeId)=>{
      const Dates=await getDatesSeance(groupeId,moduleId)
      console.log(Dates.data)
      setDateData(Dates.data)
    }

    const fetchEtudiants=async (groupeId)=>{
      let filters ={
        "groupeId":groupeId,
        "année_Universitaire":""

      }
      const etudiants= await getEtudiantsByfilers(filters);
      console.log(etudiants)
      setEtudiantsData(etudiants.data)
    }

    ////////////////////////////
    ////////// getEtudiantsByfilers(filters=null)
             // get la liste des etudiants etleur id afin d enregistrer les absences

    /////////////////////////////

    /*const fetchInscriptions=async()=>{
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

      
    
      useEffect(() => { fetchInscriptions() }, [] )*/
      const fetchModules =async ()=>{
        const resp = await getModuleByEnseignant(semestre);
        setmodulesData(resp.data)
      }

      async function fetchgroupes()
      {
        const groupes=await getGroupeByEnseignant(semestre);
        setGroupesData(groupes.data)
  
      }

      useEffect(() => { fetchModules() }, [semestre])
      useEffect(() => { fetchgroupes() }, [moduleId])

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
                                        <Label >Semestre</Label>
                                        <Input type="select" placeholder="Semestre" onChange={(e)=>{setSemestre(e.target.value);setmoduleId(null);setGroupesData([]);setGroupeId(null);setDateData([])}}>
                                            <option disabled selected value> Selectionner une semestre </option>
                                            <option value={1}>1</option>
                                            <option value={2}>2</option>
                                        </Input>
                                        </FormGroup>
                                    </Col>
                                    <Col md="auto">
                                        <FormGroup>
                                        <Label >Matiere</Label>
                                        <Input type="select" placeholder="Matiere" onChange={(e)=>{if(e.target.value==null) setGroupesData([]);else{setmoduleId(parseInt(e.target.value));setGroupeId(null);setDateData([])} }}>
                                            <option selected value={null}> Selectionner une Matiere </option>
                                            {
                                                modulesData.map(module=>
                                                    <option selected={module.moduleId==moduleId} value={module.moduleId}>{module.libelleModule}</option>
                                                )}
                                        </Input>
                                        </FormGroup>
                                    </Col>
                                    <Col md="auto">
                                        <FormGroup>
                                        <Label >Groupe</Label>
                                        
                                        <Input type="select" placeholder="Groupe" onChange={(e)=>{setGroupeId(e.target.value);fetchDate(e.target.value);fetchEtudiants(e.target.value)}}>
                                            <option selected value={null}> Selectionner un Groupe </option>
                                            {groupesData.map(groupe=>
                                              <option selected={groupe.groupeId==groupeId} value={groupe.groupeId}>{groupe.libellé_groupe}</option>
                                              )}
                                        </Input>
                                        </FormGroup>
                                    </Col>
                                  
                                    
   
                                    
                            </Row>

                        </Form>
                  </CardHeader>
                  <hr></hr>
                  
                  <CardBody>
                    <Container>
                  {dateData.map(d=>
                  <Row>
                    <Button color="default" type="button" block outline onClick={(e)=>{setIsOpen(true)}}>Seance de {d.split("T")[0]}</Button>
                    </Row>
                    )}
                    </Container>
                  </CardBody>
                  </Card>
                </div>
            </Row>
            </Container>


            <Modal
              className="modal-dialog-centered"
              isOpen={isOpen}
              toggle={()=>setIsOpen(!isOpen)}
            >
              <div className="modal-header">
                <h6 className="modal-title" id="modal-title-default">
                  Liste des etudiants
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
                  {etudiantsData.map(e=>
                    <Row>
                    <Col md="auto">
                      {e.prenom+" "+e.nom}
                    </Col>
                  </Row>)}
              </Form>
            </div>

            </Modal>




        </>
    
        )



}


export default Presences
