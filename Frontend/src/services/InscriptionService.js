import axios from 'axios'
import Cookies from 'js-cookie'

export async function getInscriptions(filterParamters){    
    
    const resp = await axios.get("http://localhost:5000/api/Inscription?"+JSON.stringify(filterParamters),{headers:{Authorization:Cookies.get("Authorization") }})
                    .catch(error =>{
                        return error.response;
                    })
    return resp
}


export async function postInscrition(inscription){
    const resp = await axios.post("http://localhost:5000/api/Inscription",inscription,{headers:{Authorization:Cookies.get("Authorization") }})
    .catch(error =>{
        return error.response;
    })
    return resp
}

export async function UpdateInscrition(inscription){
    const resp = await axios.put("http://localhost:5000/api/Inscription/"+inscription.inscriptionId,inscription,{headers:{Authorization:Cookies.get("Authorization") }})
    .catch(error =>{
        return error.response;
    })
    return resp
}

export async function DeleteInscrition(inscriptionId){
    const resp = await axios.delete("http://localhost:5000/api/Inscription/"+inscriptionId,{headers:{Authorization:Cookies.get("Authorization") }})
    .catch(error =>{
        return error.response;
    })
    return resp
}