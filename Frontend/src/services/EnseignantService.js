import axios from 'axios'




export async function getEnseignants(){    
    const resp = await axios.get("http://localhost:5000/api/Enseignant")
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
