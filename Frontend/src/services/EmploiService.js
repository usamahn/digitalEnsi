import axios from 'axios'
import Cookies from 'js-cookie'




export async function getSeancesByNomGroupe(nomGroupe){    
    const resp = await axios.get("http://localhost:5000/api/Groupe/"+nomGroupe+"/Seances")
                    .catch(error =>{
                        return error.response;
                    })
    return resp
}

export async function getSeances(){    
    const resp = await axios.get("http://localhost:5000/api/Seances",{headers:{Authorization:Cookies.get("Authorization") }})
                    .catch(error =>{
                        return error.response;
                    })
    return resp
}

export async function postSeance(seance){    
    const resp = await axios.post("http://localhost:5000/api/Seance",seance)
                    .catch(error =>{
                        return error.response;
                    })
    return resp
}


export async function getDatesSeance(groupeId,moduleId){    
    const resp = await axios.get("http://localhost:5000/api/Seances/Dates?groupeId="+groupeId+"&moduleId="+moduleId,{headers:{Authorization:Cookies.get("Authorization") }})
                    .catch(error =>{
                        return error.response;
                    })
                    console.log(resp.headers)
    return resp
}

export async function getSeanceId(groupeId,moduleId){    
    const resp = await axios.get("http://localhost:5000/api/SeanceId?groupeId="+groupeId+"&moduleId="+moduleId,{headers:{Authorization:Cookies.get("Authorization") }})
                    .catch(error =>{
                        return error.response;
                    })
                    console.log(resp.headers)
    return resp
}