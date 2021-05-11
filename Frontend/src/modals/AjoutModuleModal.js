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
  Label
} from "reactstrap";
import {postModule} from "services/ModuleService"


const AjoutModuleModal = (props) => {
  const [isOpen, setIsOpen] = useState(false)

  const [libelleModule, setLibelleModule] = useState("")
  const [type, setType] = useState(1)
  const [volumeHoraire, setVolumeHoraire] = useState("")
  const [semestre, setSemestre] = useState(props.semestre)
  const [niveau, setNiveau] = useState(props.niveau)
  const [filieres, setFilieres] = useState([])
  const onAddClickHandler= async()=>{
    let module = {
      "libelleModule":libelleModule,
      "type":type,
      "volumeHoraire":volumeHoraire,
      "semestre":semestre,
      "niveau":niveau,
      "filieres":filieres,
    }
    console.log(module);
    await postModule(module);
    setIsOpen(false);
    await props.refetch();
  }
  useEffect(() => { setNiveau(props.niveau) }, [props.niveau] )

return(
  <>
        <Button color="success" type="button" size="sm" onClick={(e)=>setIsOpen(true)}>Ajouter une Matiere</Button>
        <Modal
                    className="modal-dialog-centered"
                    isOpen={isOpen}
                    toggle={()=>setIsOpen(!isOpen)}
                  >
              <div className="modal-header">
                <h6 className="modal-title" id="modal-title-default">
                  Ajouter Une Matiere
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
                                <Input  placeholder="Nom du module" type="text" onChange={(e)=>setLibelleModule(e.target.value)}/>
                            </FormGroup>
                        </Col>
                        <Col md="6">
                            <FormGroup>
                                <Input  placeholder="Volume horaire" type="number" onChange={(e)=>setVolumeHoraire(e.target.value)}/>
                            </FormGroup>
                        </Col>
                  </Row>
                  <Row>
                        <Col md="6">
                            <FormGroup>
                            <Label >Niveau</Label>
                            <Input type="select" placeholder="Niveau" value={niveau} onChange={(e)=>setNiveau(e.target.value)}>
                              <option>1</option>
                              <option>2</option>
                              <option>3</option>

                            </Input>
                            </FormGroup>
                        </Col>
                        <Col md="6">
                            <FormGroup>
                            <Label >Semestre</Label>
                            <Input type="select" placeholder="Semestre" value={semestre} onChange={(e)=>setSemestre(e.target.value)}>
                              <option>1</option>
                              <option>2</option>
                            </Input>
                            </FormGroup>
                        </Col>
                  </Row>
                  <Row>
                  <Col md="6">
                            <FormGroup>
                            <Label >Type</Label>
                            <Input type="select" placeholder="Type" value={type} onChange={(e)=>setType(e.target.value)}>
                              <option>1</option>
                              <option>2</option>
                            </Input>
                            </FormGroup>
                        </Col>
                  <Col md="6">
                            <FormGroup>
                            <Label >Filiere</Label>
                            <Input type="select" placeholder="Filiere" multiple>
                              <option>GL</option>
                              <option>Finance</option>
                            </Input>
                            </FormGroup>
                        </Col>
                  </Row>
                </Form>
              </div>
              <div className="modal-footer">
                <Button color="primary" type="button" onClick={(e)=>onAddClickHandler()}>
                  Ajouter
                </Button>
              </div>
        </Modal>
  </>
        
)


}

export default AjoutModuleModal;