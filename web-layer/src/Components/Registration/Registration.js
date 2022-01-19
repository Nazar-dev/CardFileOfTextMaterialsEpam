import React, {Component, useEffect, useState} from "react";
import {Button, Form} from "react-bootstrap";
import {variables} from "../Variables/Variables";
import AdminUserPage from "../LoggedAdminPage/AdminUsersPage/AdminUserPage";

function Registration() {
    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')
    const [firstName, setFirstName] = useState('')
    const [lastName, setLastName] = useState('')
    const [confirmPass, setConfirmPass] = useState('')
    const [users, setUsers] = useState([]);

    const [cards, setCards] = useState([]);

    useEffect(() => {
        fetch(variables.API_URL + 'card')
            .then(response => response.json())
            .then(data => {
                setCards(data);
            })
    }, [])

    useEffect(() => {
        fetch(variables.API_URL + 'authorization')
            .then(response => response.json())
            .then(data => {
                setUsers(data);
            })
    }, [])
    const validEmail = () => {
        if (users.find(user => user.email === email) === undefined) {
            return true
        } else {
            alert("Email is already taken")
        }
    }


    const confirmPassword = () => {
        if (validatePassword()) {
            if (confirmPass === password) {
                return true;
            } else {
                alert("Password didnt match")
            }
        } else {
            alert("Password must contain at least:\n 8 characters,\n 1 capital letter,\n 1 lower letter,\n 1 special symbol ")
        }
    }

    const validatePassword = () => {
        const lowerCaseLetters = /[a-z]/g;
        const upperCaseLetters = /[A-Z]/g;
        const numbers = /[0-9]/g;
        if (password.length >= 8 &&
            password.match(lowerCaseLetters) &&
            password.match(upperCaseLetters) &&
            password.match(numbers))
            return true;
        return false;
    }


    const addUserClicked = () => {

        if (email !== ''
            && firstName !== ''
            && lastName !== ''
            && password !== ''
            && confirmPassword !== '') {
            if (validEmail()) {
                if (confirmPassword()) {
                    createAndSendToDbUser(email, firstName, lastName, cards[0].cardId, password)
                    window.location.href = "http://localhost:3000/signin";

                }
            }
        } else {
            alert("You forgot to fill some fields.")
        }


    }
    const createAndSendToDbUser = (email, firstname,lastname,cardId,password) => {
        fetch(variables.API_URL + 'authorization/signup', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                Email:email,
                FirstName:firstname,
                LastName:lastname,
                CardId:parseInt(cardId),
                Password:password
            })

        })
            .then(res => res.json())
            .then((result) => {
            }, (error) => {
            })
    }

    if (users.length !== 0 && cards.length !== 0) {
        return (
            <>
                <div style={{display: 'flex', justifyContent: 'center'}}>
                    <Form>
                        <Form.Group className="mb-3">
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
                        <Form.Group className="mb-3">
                            <Form.Label>First Name</Form.Label>
                            <Form.Control type="text"
                                          placeholder="Enter First Name"
                                          value={firstName}
                                          onChange={(e) =>
                                              setFirstName(e.target.value)}
                            />
                            <Form.Text className="text-muted">
                            </Form.Text>
                        </Form.Group>
                        <Form.Group className="mb-3">
                            <Form.Label>Last Name </Form.Label>
                            <Form.Control type="text"
                                          placeholder="Enter Last Name"
                                          value={lastName}
                                          onChange={(e) =>
                                              setLastName(e.target.value)}
                            />
                            <Form.Text className="text-muted">
                            </Form.Text>
                        </Form.Group>
                        <Form.Group className="mb-3">
                            <Form.Label>Password</Form.Label>
                            <Form.Control type="password"
                                          placeholder="Password"
                                          value={password}
                                          onChange={(e) =>
                                              setPassword(e.target.value)}
                            />
                        </Form.Group>
                        <Form.Group className="mb-3">
                            <Form.Label>Confirm Password</Form.Label>
                            <Form.Control type="password"
                                          placeholder="Password"
                                          value={confirmPass}
                                          onChange={(e) =>
                                              setConfirmPass(e.target.value)}
                            />
                        </Form.Group>

                        <Button variant="primary"
                                onClick={addUserClicked}>
                            Submit
                        </Button>
                        <Button variant="link" href='/signin'>I have an account</Button>
                    </Form>
                </div>

            </>
        )
    }     else return (<button className="btn btn-primary" disabled>
        <span className="spinner-border spinner-border-sm"></span>
        Loading..
    </button>)


}

export default Registration;

