
import React, { useState, useEffect } from "react";
import {getModuleByEnseignant,getNoteModuleParGroupe,postNoteModule,putNoteModule,getFicheNote} from "services/ModuleService"
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


    const fetchNotes=async()=>{
      const Notes=await getFicheNote()
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
      /*const fetchModules =async ()=>{
        const resp = await getModuleByEnseignant(semestre);
        setmodulesData(resp.data)
      }

      async function fetchgroupes()
      {
        const groupes=await getGroupeByEnseignant(semestre);
        setGroupesData(groupes.data)
  
      }*/

      /*useEffect(() => { fetchModules() }, [semestre])
      useEffect(() => { fetchgroupes() }, [moduleId])*/
      useEffect(() => { fetchNotes() },[] )

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
                  </CardHeader>
                  <hr></hr>
                  
                  <CardBody>
                <h3>Semestre 1</h3>
                  <Table className="align-items-center table-flush" >
                <thead className="thead-light">
                  <tr>
                    <th scope="col">Module</th>
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
                
                {notesData.filter(n=>n.semestre==1).map(notedata=>
                                                    <tr>
                                                        <td>{notedata.libelleModule}</td>
                                                        <td>{notedata.noteDs}</td>
                                                        <td>{notedata.noteCc}</td>
                                                        <td>{notedata.noteExamenP}</td>
                                                        <td>{notedata.moyennePrincipal}</td>
                                                        <td>{notedata.noteExamenR}</td>
                                                        <td>{notedata.moyenneRattrapage}</td>
                                                      </tr>
                                )
                  }


                  


                </tbody>
                </Table>

                <br/>
                <h3>Semestre 2</h3>
                <Table className="align-items-center table-flush" responsive>
                <thead className="thead-light">
                  <tr>
                    <th scope="col">Module</th>
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
                
                {notesData.filter(n=>n.semestre==2).map(notedata=>
                                                    <tr>
                                                        <td>{notedata.libelleModule}</td>
                                                        <td>{notedata.noteDs}</td>
                                                        <td>{notedata.noteCc}</td>
                                                        <td>{notedata.noteExamenP}</td>
                                                        <td>{notedata.moyennePrincipal}</td>
                                                        <td>{notedata.noteExamenR}</td>
                                                        <td>{notedata.moyenneRattrapage}</td>
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
