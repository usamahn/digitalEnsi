
import React, { useState, useEffect } from "react";
import {getModuleByEnseignant,getNoteModuleParGroupe,postNoteModule,putNoteModule} from "services/ModuleService"
import {getGroupeByEnseignant} from "services/GroupeService"

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
  Col,Label
} from "reactstrap";




const Notes = () => {
    const [semestre, setSemestre] = useState(0)
    const [groupesData, setGroupesData] = useState([])
    const [modulesData, setmodulesData] = useState([])
    const [moduleId, setmoduleId] = useState(null)
    const [groupeId, setGroupeId] = useState(null)
    const [notesData, setnotesData] = useState([])


    const fetchNotes=async(groupeId)=>{
      const Notes=await getNoteModuleParGroupe(groupeId,moduleId)
      console.log(Notes.data)
      setnotesData(Notes.data)
    }

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
      //useEffect(() => { fetchNotes() }, [semestre,moduleId])

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
                                        <Input type="select" placeholder="Semestre" onChange={(e)=>{setSemestre(e.target.value);setmoduleId(null);setGroupesData([]);setGroupeId(null);setnotesData([])}}>
                                            <option disabled selected value> Selectionner une semestre </option>
                                            <option value={1}>1</option>
                                            <option value={2}>2</option>
                                        </Input>
                                        </FormGroup>
                                    </Col>
                                    <Col md="auto">
                                        <FormGroup>
                                        <Label >Matiere</Label>
                                        <Input type="select" placeholder="Matiere" onChange={(e)=>{if(e.target.value==null) setGroupesData([]);else{setmoduleId(parseInt(e.target.value));setGroupeId(null);setnotesData([])} }}>
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
                                        
                                        <Input type="select" placeholder="Groupe" onChange={(e)=>{setGroupeId(e.target.value);fetchNotes(e.target.value)}}>
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
                
                {notesData.map(notedata=>
                                                    <tr>
                                                        <td>{notedata.nom}</td>
                                                        <td>{notedata.noteDs}</td>
                                                        <td>{notedata.noteCc}</td>
                                                        <td>{notedata.noteExamenP}</td>
                                                        <td>{notedata.moyennePrincipal}</td>
                                                        <td>{notedata.noteExamenR}</td>
                                                        <td>{notedata.moyenneRattrapage}</td>
                                                        <td><ModifNoteModal updateNote={notedata.noteId==0?postNoteModule:putNoteModule} noteData={notedata} moduleId={moduleId} refetch={()=>fetchNotes(groupeId)} /></td>
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


export default Notes
