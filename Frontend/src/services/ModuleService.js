import axios from 'axios'
import Cookies from 'js-cookie'



export async function getModule(){    
    const resp = await axios.get("http://localhost:5000/api/Module",{headers:{Authorization:Cookies.get("Authorization") }})
                    .catch(error =>{
                        return error.response;
                    })
    return resp
}


export async function getFicheNoteModuleByEtudiant(){    
    const resp = await axios.get("http://localhost:5000/api/Module")
                    .catch(error =>{
                        return error.response;
                    })
    return resp
}

export async function getModuleByEnseignant(semestre=0){    
    const resp = await axios.get("http://localhost:5000/api/Enseignant/Module?semestre="+semestre,{headers:{Authorization:Cookies.get("Authorization") }})
                    .catch(error =>{
                        return error.response;
                    })
    return resp
}

export async function getFicheNote(){ 
    console.log("ficheNote");   
    const resp = await axios.get("http://localhost:5000/api/FicheNote",{headers:{Authorization:Cookies.get("Authorization") }})
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



export async function getNoteModuleParGroupe(groupeId,moduleId,année_Universitaire=""){    
    const resp = await axios.get("http://localhost:5000/api/ModuleNote?année_Universitaire="+année_Universitaire+"&groupeId="+groupeId+"&moduleId="+moduleId)
                    .catch(error =>{
                        return error.response;
                    })
        console.log(resp.data)
    return resp
}


export async function postModule(module){
    const resp = await axios.post("http://localhost:5000/api/Module",module)
    .catch(error =>{
        return error.response;
    })
    return resp
}


export async function postNoteModule(note){
    console.log("new note");
    console.log(note);
    const resp = await axios.post("http://localhost:5000/api/Module/"+note.moduleId+"/Note",note)
    .catch(error =>{
        return error.response;
    })
    console.log(resp)
    return resp
}

export async function putNoteModule(note){
    console.log("existed note");
    console.log(note);
    const resp = await axios.put("http://localhost:5000/api/Module/"+note.moduleId+"/Note",note)
    .catch(error =>{
        return error.response;
    })
    return resp
}

export async function putModule(module){
    const resp = await axios.put("http://localhost:5000/api/Module/"+module.moduleId,module)
    .catch(error =>{
        return error.response;
    })
    return resp
}
export async function deleteModule(moduleId){
    const resp = await axios.delete("http://localhost:5000/api/Module/"+moduleId)
    .catch(error =>{
        return error.response;
    })
    return resp
}


