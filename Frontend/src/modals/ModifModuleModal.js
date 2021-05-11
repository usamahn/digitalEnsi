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
  Label
} from "reactstrap";

import {putModule} from "services/ModuleService"


const ModifModuleModal = (props) => {
  const [isOpen, setIsOpen] = useState(false)

  const [libelleModule, setLibelleModule] = useState(props.module.libelleModule)
  const [type, setType] = useState(props.module.type)
  const [volumeHoraire, setVolumeHoraire] = useState(props.module.volumeHoraire)
  const [semestre, setSemestre] = useState(props.module.semestre)
  const [niveau, setNiveau] = useState(props.module.niveau)
  const [filieres, setFilieres] = useState(props.module.filieres)

  const onModifyClickHandler= async()=>{
    let module = {
      "moduleId":props.module.moduleId,
      "libelleModule":libelleModule,
      "type":type,
      "volumeHoraire":volumeHoraire,
      "semestre":semestre,
      "niveau":niveau,
      "filieres":filieres,
    }
    await putModule(module);
    setIsOpen(false);
    await props.refetch();
  }
return(
  <>
        <Button color="info" type="button" size="sm" onClick={(e)=>setIsOpen(true)}>Modifer</Button>
        <Modal
                    className="modal-dialog-centered"
                    isOpen={isOpen}
                    toggle={()=>setIsOpen(!isOpen)}
                  >
              <div className="modal-header">
                <h6 className="modal-title" id="modal-title-default">
                  Modifier Un Module
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
                    <Col md="6">
                            <FormGroup>
                                <Input  placeholder="Nom du module" type="text" value={libelleModule} onChange={(e)=>setLibelleModule(e.target.value)}/>
                            </FormGroup>
                        </Col>
                        <Col md="6">
                            <FormGroup>
                                <Input  placeholder="Volume horaire" type="number" value={volumeHoraire} onChange={(e)=>setVolumeHoraire(e.target.value)} />
                            </FormGroup>
                        </Col>
                  </Row>
                  <Row>
                        <Col md="6">
                            <FormGroup>
                            <Label >Niveau</Label>
                            <Input type="select" placeholder="Niveau" value={niveau} onChange={(e)=>setNiveau(e.target.value)} >
                              <option>1</option>
                              <option>2</option>
                              <option>3</option>

                            </Input>
                            </FormGroup>
                        </Col>
                        <Col md="6">
                            <FormGroup>
                            <Label >Semestre</Label>
                            <Input type="select" placeholder="Semestre" value={semestre} onChange={(e)=>setSemestre(e.target.value)} >
                              <option>1</option>
                              <option>2</option>
                            </Input>
                            </FormGroup>
                        </Col>
                  </Row>
                  <Row>
                  <Col md="6">
                            <FormGroup>
                            <Label >Filiere</Label>
                            <Input type="select" placeholder="Filiere" multiple value={["GL"]} onChange={(e)=>setFilieres(e.target.value)} >
                              <option>GL</option>
                              <option>Finance</option>
                            </Input>
                            </FormGroup>
                        </Col>
                  </Row>
                </Form>
              </div>
              <div className="modal-footer">
                <Button color="primary" type="button" onClick={()=>onModifyClickHandler()}>
                  Modifier
                </Button>
              </div>
        </Modal>
  </>
        
)


}

export default ModifModuleModal;