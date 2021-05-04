import axios from 'axios'




export async function getSeancesByNomGroupe(nomGroupe){    
    const resp = await axios.get("http://localhost:5000/api/Groupe/"+nomGroupe+"/Seances")
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