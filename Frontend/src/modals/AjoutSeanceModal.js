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
  Col
} from "reactstrap";

import CustomAutocomplete from "components/Inputs/Autocomplete"

import {getEnseignants} from "services/EnseignantService"

import {getModule} from "services/ModuleService"
import {postSeance} from "services/EmploiService"


const AjoutSeanceModal = (props) => {
  const [enseignantId, setEnseignantId] = useState("")
  const [moduleId, setModuleId] = useState("")

  const onClickAjouterSeance=async ()=>{


    const seance ={"enseignantId":enseignantId , 
                  "moduleId":moduleId, 
                  "jour":props.selectInfoData.start.getDay() , 
                  "HeureDeb" :props.selectInfoData.start.getHours()+ ":" + props.selectInfoData.start.getMinutes() + ":" + props.selectInfoData.start.getSeconds() ,
                  "HeureFin":props.selectInfoData.end.getHours()+ ":" + props.selectInfoData.end.getMinutes() + ":" + props.selectInfoData.end.getSeconds(),
                  "groupeId":props.groupe.groupeId}
    console.log(seance)
    await postSeance(seance)
    props.fetchSeances(props.groupe)
    props.setModal(false)
  }

        return(
        <Modal
        className="modal-dialog-centered"
        size="sm"
        isOpen={props.isOpen}
        
        toggle={() => {props.setModal(!props.isOpen)}}
        >
              <div className="modal-body p-0">
                <Card className="bg-secondary shadow border-0">
                  <CardHeader className="bg-transparent pb-5">
                    
                  </CardHeader>
                  <CardBody className="px-lg-5 py-lg-5">
                    
                    <Form role="form">

                      <FormGroup>
                        
                          
                          <CustomAutocomplete getOptions={getEnseignants} 
                          onChange={(e,v)=>{setEnseignantId(v.id)}}
                          renderOption={(option)=>(
                            <div>
                              {option.prenom+ " "+option.nom}<br/>
                              <small><i>{"CIN: "+option.cin}</i></small>
                            </div>
                          )}
                          getOptionLabel={(option) => option.prenom+" "+option.nom}
                          />
                          <CustomAutocomplete getOptions={getModule} 
                          onChange={(e,v)=>{setModuleId(v.moduleId)}}
                          renderOption={(option)=>(
                            <div>
                              {option.libelleModule}
                            </div>
                          )}
                          getOptionLabel={(option) => option.libelleModule}

                          />
                        
                      </FormGroup>

                      <div className="text-center">
                        <Button
                          className="my-4"
                          color="primary"
                          type="button"
                          onClick={(e)=>onClickAjouterSeance()}
                        >
                          Ajouter
                        </Button>
                      </div>
                    </Form>
                  </CardBody>
                </Card>
              </div>

        </Modal>)

}

export default  AjoutSeanceModal;