/*!

=========================================================
* Argon Dashboard React - v1.2.0
=========================================================

* Product Page: https://www.creative-tim.com/product/argon-dashboard-react
* Copyright 2021 Creative Tim (https://www.creative-tim.com)
* Licensed under MIT (https://github.com/creativetimofficial/argon-dashboard-react/blob/master/LICENSE.md)

* Coded by Creative Tim

=========================================================

* The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

*/
import React,{useState}  from "react";
import Cookies from 'js-cookie'
import {loginService} from 'services/Authentification'

import classnames from "classnames";
import { useHistory } from "react-router-dom";


// reactstrap components
import {
  Button,
  Card,
  CardHeader,
  CardBody,
  FormGroup,
  Form,
  Input,
  InputGroupAddon,
  InputGroupText,
  InputGroup,
  Row,
  Col,
  NavLink,
  NavItem,
  Nav
} from "reactstrap";



const Login = () => {
  const [username,setUsername]=useState("");
  const [password,setPassword]=useState("");
  let history = useHistory();
  const [role,setRole]=useState("Admin")





  const login = async (username,password,role) =>{
    var resp = await loginService(username,password,role);
    console.log(resp);
    
    if(resp.status===200){
      for (const [key, value] of Object.entries(resp.data)) {
        Cookies.set(key, value);
      }
      Cookies.set("Authorization","bearer"+" "+resp.data.bearerToken);
      Cookies.set("isAuthentificated", true);
      console.log(JSON.parse(Cookies.get('role'))[0]);
      switch(JSON.parse(Cookies.get('role'))[0]){ //les cookies sont de type chaine de caracteres, il faut les parser pour les rendre tableau (role est un tableau)
        case "Admin":history.push('/admin/index'); break;
        case "Enseignant":history.push('/Enseignant');break;
        case "Etudiant":history.push('/Etudiant');break;
    }
  
    }
    
  }
  return (
    <>
      <Col lg="5" md="7">
        <Card className="bg-secondary shadow border-0">
          <CardHeader className="bg-transparent pb-5">
            <div className="text-muted text-center mt-2 mb-3">
              <small>Sign in with</small>
            </div>
            <Nav
              className="nav-fill flex-column flex-sm-row"
              id="tabs-text"
              pills
              role="tablist"
            >
            <NavItem>
              <NavLink
                className={classnames("mb-sm-3 mb-md-0", {
                  active: role==="Admin"
                })}
                onClick={e=>{e.preventDefault();setRole("Admin")}}
                href=""
                role="tab"
              >
                Admin
              </NavLink>
            </NavItem>
            <NavItem>
              <NavLink
                className={classnames("mb-sm-3 mb-md-0", {
                  active: role==="Enseignant"
                })}
                onClick={e=>{e.preventDefault();setRole("Enseignant")}}
                href=""
                role="tab"
              >
                Enseignant
              </NavLink>
            </NavItem>
            <NavItem>
              <NavLink
                className={classnames("mb-sm-3 mb-md-0", {
                  active: role==="Etudiant"
                })}
                onClick={e=>{e.preventDefault();setRole("Etudiant")}}
                href=""
                role="tab"
              >
                Etudiant
              </NavLink>
            </NavItem>
            </Nav>
          </CardHeader>
          <CardBody className="px-lg-5 py-lg-5">
            <div className="text-center text-muted mb-4">
              <small>Or sign in with credentials</small>
            </div>
            <Form role="form">
              <FormGroup className="mb-3">
                <InputGroup className="input-group-alternative">
                  <InputGroupAddon addonType="prepend">
                    <InputGroupText>
                      <i className="ni ni-email-83" />
                    </InputGroupText>
                  </InputGroupAddon>
                  <Input
                    placeholder="Email"
                    type="email"
                    autoComplete="new-email"
                    onChange={e=>setUsername(e.target.value)}
                  />
                </InputGroup>
              </FormGroup>
              <FormGroup>
                <InputGroup className="input-group-alternative">
                  <InputGroupAddon addonType="prepend">
                    <InputGroupText>
                      <i className="ni ni-lock-circle-open" />
                    </InputGroupText>
                  </InputGroupAddon>
                  <Input
                    placeholder="Password"
                    type="password"
                    autoComplete="new-password"
                    onChange={e=>setPassword(e.target.value)}
                  />
                </InputGroup>
              </FormGroup>
              <div className="custom-control custom-control-alternative custom-checkbox">
                <input
                  className="custom-control-input"
                  id=" customCheckLogin"
                  type="checkbox"
                />
                <label
                  className="custom-control-label"
                  htmlFor=" customCheckLogin"
                >
                  <span className="text-muted">Remember me</span>
                </label>
              </div>
              <div className="text-center">
                <Button className="my-4" color="primary" type="button" onClick={(e)=>{login(username,password,role);}}>
                  Sign in
                </Button>
              </div>
            </Form>
          </CardBody>
        </Card>
        <Row className="mt-3">
          <Col xs="6">
            <a
              className="text-light"
              href="#pablo"
              onClick={(e) => e.preventDefault()}
            >
              <small>Forgot password?</small>
            </a>
          </Col>
          <Col className="text-right" xs="6">
            <a
              className="text-light"
              href="#pablo"
              onClick={(e) => e.preventDefault()}
            >
              <small>Create new account</small>
            </a>
          </Col>
        </Row>
      </Col>
    </>
  );
};

export default Login;
