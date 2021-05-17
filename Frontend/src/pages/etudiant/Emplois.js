import React, { useState, useEffect } from "react";
import {getEtudiants} from "services/EtudiantService"

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
  CardBody,
  Col,
  CardTitle,
  NavLink,
  NavItem,
  Nav,
  Button
} from "reactstrap";
import AjoutSeanceModal from "modals/AjoutSeanceModal"

import classnames from "classnames";
import FullCalendar, { formatDate } from '@fullcalendar/react'
import dayGridPlugin from '@fullcalendar/daygrid'
import timeGridPlugin from '@fullcalendar/timegrid'
import interactionPlugin from '@fullcalendar/interaction'
//import 'bootstrap/dist/css/bootstrap.css';
//import '@fortawesome/fontawesome-free/css/all.css'; 

import {getSeances} from "services/EmploiService"
import {getGroupes} from "services/GroupeService"


const Emplois = () => {
    
    const [groupes,setGroupes]=useState([])
    const [selectedGroupe,setSelectedGroupe]=useState(null)
    const [seances,setSeances]=useState([])
    const [ajoutSeanceModalOpen,setAjoutSeanceModalOpen]=useState(false)
    const [selectInfoData,setSelectInfoData]=useState(null);

    
    async function fetchSeances()
    {
      setSeances([])
      const seancesData = await getSeances();
      console.log(seancesData.data)
      seancesData.data.forEach(s=>{
        let eventInfo={title:s.nomModule+" - "+s.libellé_groupe,start:s.dateHeureDebut,end:s.dateHeureFin}
        setSeances(prevData=>([...prevData,eventInfo]))
      }
        )
      
    }


    const handleTimeSelect = (selectInfo) => {
      let calendarApi = selectInfo.view.calendar
      setSelectInfoData(selectInfo)
      setAjoutSeanceModalOpen(true)
    
    }
    useEffect(()=>{

      fetchSeances()
    },[]
    )


    return(
    <>
    <div className="header bg-gradient-info pb-8 pt-5 pt-md-8">
        <Container fluid>
          <div className="header-body">
     
          </div>
          </Container>
          </div>
          <Container className="mt-3" fluid>
          <FullCalendar
                            plugins={[dayGridPlugin, timeGridPlugin, interactionPlugin]}
                            initialView="timeGridWeek"
                            headerToolbar = { {
                              left: '',
                              center: '',
                              right: ''
                              
                            } }
                            visibleRange= {{
                              start: '2021-04-19',
                              end: '2021-04-23'
                            }}
                            validRange={{
                              start: '2021-04-19',
                              end: '2021-04-24'
                            }}
                            nowIndicator={true}
                            locale="fr"
                            allDaySlot={false}
                            dayHeaderFormat={{ weekday: 'long'}}
                            hiddenDays={[0,6]}
                            slotDuration='00:15:00'
                          themeSystem="bootstrap" 
                          slotMinTime="8:00:00"
                          slotMaxTime="18:30:00"
                          editable={false}
                          selectable={false}
                          selectMirror={true}
                          dayMaxEvents={true}
                          events={seances}
                          select={ handleTimeSelect }
                          />
                          <AjoutSeanceModal isOpen={ajoutSeanceModalOpen} 
                          setModal={setAjoutSeanceModalOpen} 
                          selectInfoData={selectInfoData} 
                          groupe={selectedGroupe==null ? 0:selectedGroupe }
                          fetchSeances={fetchSeances}/>
          </Container>
</>
    )}
export default  Emplois;