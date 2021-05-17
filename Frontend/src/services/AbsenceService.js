
import axios from 'axios'
import Cookies from 'js-cookie'

export async function getAbsenceListe(filters){   
    var url="http://localhost:5000/api/Absence"  
    if(filters!=null){
    url+="?année_Universitaire="+filters.année_Universitaire+"&groupeId="+filters.groupeId+"&date="+filters.date+"&SeanceId="+filters.seanceId
    } 
    const resp = await axios.get(url)
                    .catch(error =>{
                        return error.response;
                    })
    return resp
}

export async function PostAbsence(absence){    
    const resp = await axios.post("http://localhost:5000/api/Absence",absence)
                    .catch(error =>{
                        return error.response;
                    })
    return resp
}
export async function DeleteAbsence(id){    
    const resp = await axios.delete("http://localhost:5000/api/Absence/"+id)
                    .catch(error =>{
                        return error.response;
                    })
    return resp
}