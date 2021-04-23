import React from 'react';
import { Redirect, Route } from 'react-router-dom';
import Cookies from 'js-cookie'


export const ProtectedRoute = ({ component: Component, ...rest }) => {
  
  return (
    <Route {...rest} render={
      props =>{if (Cookies.get('isAuthentificated')!==undefined)
                 {return <Component {...rest} {...props} />} 
               else {
                   return <Redirect to={{pathname:"/auth/login", state:{from:props.location}}}/>
               }
    }
    } />
  )
 
}


export const LoggedinRoute = ({ component: Component, ...rest }) => {
  
    return (
      <Route {...rest} render={
        props =>{
                    let isAuthentificated =Cookies.get('isAuthentificated')
                    if (isAuthentificated===undefined || !isAuthentificated)
                    {return <Component {...rest} {...props} />} 
                    else {
                        
                        switch(JSON.parse(Cookies.get('role'))[0]){ //les cookies sont de type chaine de caracteres, il faut les parser pour les rendre tableau (role est un tableau)
                            case "Admin":return <Redirect to={{pathname:"/admin", state:{from:props.location}}}/>
                            case "Enseignant":return <Redirect to={{pathname:"/Enseignant", state:{from:props.location}}}/>
                            case "Etudiant":return <Redirect to={{pathname:"/Etudiant", state:{from:props.location}}}/>
                        }
                        
                    }
      }
      } />
    )
   
  }

export default ProtectedRoute;


