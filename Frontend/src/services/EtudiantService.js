import axios from 'axios'




export async function getEtudiants(){    
    const resp = await axios.get("http://localhost:5000/api/Etudiants")
                    .catch(error =>{
                        return error.response;
                    })
    return resp
}


export async function getEtudiantsByfilers(filters=null){  
    var url="http://localhost:5000/api/Etudiants"  
    if(filters!=null){
    url+="?année_Universitaire="+filters.année_Universitaire+"&groupeId="+filters.groupeId
    }
    const resp = await axios.get(url)
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


export async function DeleteEtudiant(cin){    
    const resp = await axios.delete("http://localhost:5000/api/Etudiant/"+cin)
                    .catch(error =>{
                        return error.response;
                    })
    return resp
}