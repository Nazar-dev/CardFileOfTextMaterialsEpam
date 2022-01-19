import React, {Component, useEffect, useState} from "react";
import {Button, Form} from "react-bootstrap";
import {variables} from "../Variables/Variables";

function Authorization() {
    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')
    const [users,setUsers] = useState([])
    const [authResponse,setAuthResponse] = useState([]);
    const checkPassword = (email,password) =>
    {
        signInUser(email,password)
        if(authResponse.length !== 0) {
            localStorage.setItem('authUserID',authResponse.id.toString())
            if(authResponse.role === "Admin")
                localStorage.setItem('role',authResponse.role.toString())
            console.log("Was authorized")
            console.log(authResponse)
            window.location.href = "http://localhost:3000/books";
        }
        else
            console.log("Wrong password")
    }
    useEffect(() => {
        fetch(variables.API_URL + 'authorization')
            .then(response => response.json())
            .then(data => {
                setUsers(data);
            })
    }, [])
    const signInUser = (email,password) => {
        fetch(variables.API_URL + 'authorization/signin', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                Email:email,
                Password:password
            })

        })
            .then(res => res.json())
            .then((result) => {
                setAuthResponse(result);
            }, (error) => {
            })
    }
    const authorizeUserClicked = () => {

        if (email !== '' && password !== '') {
            checkPassword(email, password)
        } else {
            alert("You forgot to fill some fields.")
        }
    }
        return (
            <>
                <div style={{display: 'flex', justifyContent: 'center'}}>
                    <Form>
                        <Form.Group className="mb-3" controlId="formBasicEmail">
                            <Form.Label>Email address</Form.Label>
                            <Form.Control type="email"
                                          placeholder="Enter email"
                                          value={email}
                                          onChange={(e) =>
                                              setEmail(e.target.value)}
                            />
                            <Form.Text className="text-muted">
                            </Form.Text>
                        </Form.Group>

                        <Form.Group className="mb-3" controlId="formBasicPassword">
                            <Form.Label>Password</Form.Label>
                            <Form.Control type="password"
                                          placeholder="Password"
                                          value={password}
                                          onChange={(e) =>
                                              setPassword(e.target.value)}
                            />
                        </Form.Group>
                        <Button variant="primary"
                                onClick={authorizeUserClicked}>
                            Submit
                        </Button>
                        <Button variant="link" href='/signup'>I don't have an account</Button>
                    </Form>
                </div>

            </>
        )
}

export default Authorization;