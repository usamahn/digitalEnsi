import axios from 'axios'




export async function getGroupes(){    
    const resp = await axios.get("http://localhost:5000/api/Groupe")
                    .catch(error =>{
                        return error.response;
                    })
    console.log(resp)
    return resp
}