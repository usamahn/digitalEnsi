import axios from 'axios'
import Cookies from 'js-cookie'




export async function getEnseignants(){    
    const resp = await axios.get("http://localhost:5000/api/Enseignant")
                    .catch(error =>{
                        return error.response;
                    })
    return resp
}

export async function getEnseignantInfo(){    
    const resp = await axios.get("http://localhost:5000/api/Enseignant/info",{headers:{Authorization:Cookies.get("Authorization") }})
                    .catch(error =>{
                        return error.response;
                    })
    return resp
}



export async function UpdateEnseignant(enseignant){    
    const resp = await axios.put("http://localhost:5000/api/Enseignant",enseignant)
                    .catch(error =>{
                        return error.response;
                    })
    return resp
}


export async function DeleteEnseignant(cin){   
    console.log("deleted"); 
    const resp = await axios.delete("http://localhost:5000/api/Enseignant/"+cin)
                    .catch(error =>{
                        return error.response;
                    })
    return resp
}