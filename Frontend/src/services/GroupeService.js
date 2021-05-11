import axios from 'axios'
import Cookies from 'js-cookie'




export async function getGroupes(){    
    const resp = await axios.get("http://localhost:5000/api/Groupe")
                    .catch(error =>{
                        return error.response;
                    })
    return resp
}

export async function getGroupeByEnseignant(semestre=0){    
    const resp = await axios.get("http://localhost:5000/api/Enseignant/Groupe?semestre="+semestre,{headers:{Authorization:Cookies.get("Authorization") }})
                    .catch(error =>{
                        return error.response;
                    })
    return resp
}