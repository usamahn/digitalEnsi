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

const ModifNoteModal = (props) => {

    const [isOpen,setIsOpen] = useState(false)

    const [noteDs , setNoteDs] = useState(props.noteData.noteDs)
    const [noteCc , setNoteCc] = useState(props.noteData.noteCc)
    const [noteExamenP , setExamenP] = useState(props.noteData.noteExamenP)
    const [noteExamenR , setExamenR] = useState(props.noteData.noteExamenR)


    const [groupeData,setGroupeData]=useState([])

    const onSupprimClickHandler= async ()=>{
        await DeleteInscrition(props.inscription.inscriptionId)
        await props.refetch()

    }


    const onModifClickHandler= async ()=>{
              let note ={
                "noteDs":noteDs,
                "noteCc":noteCc,
                "noteExamenP":noteExamenP,
                "noteExamenR":noteExamenR,
                "inscriptionId":props.noteData.inscriptionId,
                "moduleId":props.moduleId
              }
              if(props.noteData.noteId!=0)
                note["noteId"]=props.noteData.noteId;

                console.log(note)
                await props.updateNote(note)
                setIsOpen(false)
                await props.refetch()
    }

    const fetchGroupes = async () => {
        const result = await getGroupes()
        
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
                                <Label>Note DS</Label>
                                <Input type="number" min={0} max={20} placeholder="Note DS"  value={noteDs} onChange={(e)=>setNoteDs(e.target.value)} />
                                     
                              </FormGroup>
                          </Col>
                    </Row>
                    <Row>
                    <Col md="auto">
                              <FormGroup>
                                <Label>Note CC</Label>
                                <Input type="number" min={0} max={20} placeholder="Note CC" value={noteCc} onChange={(e)=>setNoteCc(e.target.value)} />
                                     
                              </FormGroup>
                          </Col>
                    </Row>
                    <Row>
                    <Col md="auto">
                              <FormGroup>
                                <Label>NOTE EXAMEN PRINCIPAL	</Label>
                                <Input type="number" min={0} max={20} placeholder="NOTE EXAMEN PRINCIPAL" value={noteExamenP} onChange={(e)=>setExamenP(e.target.value)} />
                                     
                              </FormGroup>
                          </Col>
                    </Row>
                    <Row>
                    <Col md="auto">
                              <FormGroup>
                                <Label>NOTE EXAMEN PRINCIPAL	</Label>
                                <Input type="number" min={0} max={20} placeholder="MOYENNE RATTRAPAGE" value={noteExamenR} onChange={(e)=>setExamenR(e.target.value)} />
                                     
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

export default  ModifNoteModal;