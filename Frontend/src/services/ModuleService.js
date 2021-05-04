import axios from 'axios'




export async function getModule(){    
    const resp = await axios.get("http://localhost:5000/api/Module")
                    .catch(error =>{
                        return error.response;
                    })
    return resp
}

export async function getModuleByNiveau(niveau){    
    const resp = await axios.get("http://localhost:5000/api/Module/Niveau/"+niveau)
                    .catch(error =>{
                        return error.response;
                    })
    return resp
}



export async function getModuleByNivGetNoteModuleParGroupeeau(année_Universitaire,groupeId,moduleId){    
    const resp = await axios.get("http://localhost:5000/api/ModuleNote?année_Universitaire="+année_Universitaire+"&groupeId="+groupeId+"&moduleId="+moduleId)
                    .catch(error =>{
                        return error.response;
                    })
    return resp
}

