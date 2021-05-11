
import axios from 'axios'


export async function CreateEtudiantAccount(etudiant){    
    const resp = await axios.post("http://localhost:5000/api/Etudiants/Register",etudiant)
                    .catch(error =>{
                        return error.response;
                    })
    return resp
}



export async function CreateEnseignantAccount(enseignant){    
    const resp = await axios.post("http://localhost:5000/api/Enseignants/Register",enseignant)
                    .catch(error =>{
                        return error.response;
                    })
    return resp
}