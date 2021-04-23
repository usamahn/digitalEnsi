import axios from 'axios'




export async function loginService(username,password,role){
    const auth={UserName:username,Password:password}
    
    const resp = await axios.post("http://localhost:5000/"+role+"/login",auth)
                    .catch(error =>{
                        return error.response;
                    })
    //console.log(resp)
    return resp
}
