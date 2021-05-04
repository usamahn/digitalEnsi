import axios from 'axios'




export async function getEtudiants(){    
    const resp = await axios.get("http://localhost:5000/api/Etudiants")
                    .catch(error =>{
                        return error.response;
                    })
    return resp
}


export async function UpdateEtudiant(etudiant){    
    const resp = await axios.put("http://localhost:5000/api/Etudiants",etudiant)
                    .catch(error =>{
                        return error.response;
                    })
    return resp
}
