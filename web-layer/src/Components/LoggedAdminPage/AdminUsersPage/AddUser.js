import React, {useState} from "react";
import {Button, Dropdown, Modal} from "react-bootstrap";
import transitionEndListener from "react-bootstrap/transitionEndListener";


function AddUser(props) {


    const [email, setEmail] = useState('');
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [cardId, setCardId] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPass, setConfirmPass] = useState('');

    const [values, setValues] = useState({
        password: "",
        showPassword: false,
    });
    const validEmail = () =>
    {
        if(props.users.find(user => user.email === email) === undefined)
        {
            return true
        }
        else {
            alert("Email is already taken")
        }
    }
    const validCardId = () => {
        if (props.cards.find(card => card.cardId === parseInt(cardId)) !== undefined) {
            return true
        } else {
            alert("Card id wasn't found")
        }
    }

    const confirmPassword = () => {
        if(validatePassword()) {
            if (confirmPass === password) {
                return true;
            } else {
                alert("Password didnt match")
            }
        }
        else
        {
            alert("Password must contain at least:\n 8 characters,\n 1 capital letter,\n 1 lower letter,\n 1 special symbol ")
        }
    }

    const validatePassword = () =>
    {
        const lowerCaseLetters = /[a-z]/g;
        const upperCaseLetters = /[A-Z]/g;
        const numbers = /[0-9]/g;
        if(password.length >= 8 &&
            password.match(lowerCaseLetters) &&
            password.match(upperCaseLetters) &&
            password.match(numbers))
            return true;
        return false;
    }

    const closeWindow = () => {
        props.handleCloseAddButton()
        setFieldToEmpty()
    }
    const setFieldToEmpty = () => {
        setPassword('')
        setFirstName('')
        setCardId('')
        setLastName('')
        setEmail('')
        setConfirmPass('')

    }

    const addUserClicked = () => {

        if (email !== ''
            && firstName !== ''
            && lastName !== ''
            && password !== ''
            && confirmPass !== '') {
            if(validEmail()) {
                    if (confirmPassword()) {
                        props.createAndSendToDbUser(email, firstName, lastName, 2, password)
                        props.refreshPage()
                        setFieldToEmpty()
                        props.handleCloseAddButton()
                    }
                }

        } else {
            alert("You forgot to fill some fields.")
        }


    }


    return (
        <>

            <Modal show={props.showAddBtn} onHide={props.handleCloseAddButton}>
                <Modal.Header closeButton>
                    <Modal.Title>Add User</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <div>
                        <h5>Enter Email</h5>
                        <input type="text" className="form-control"
                               value={email}
                               onChange={(e) =>
                                   setEmail(e.target.value)}
                        />
                        <h5>Enter First Name</h5>
                        <input type="text" className="form-control"
                               value={firstName}
                               onChange={(e) =>
                                   setFirstName(e.target.value)}
                        />
                        <h5>Enter Last Name</h5>
                        <input type="text" className="form-control"
                               value={lastName}
                               onChange={(e) =>
                                   setLastName(e.target.value)}
                        />
                        <h5>Enter Password</h5>
                        <input type={values.showPassword ? "text" : "password"} className="form-control"
                               value={password}
                               onChange={(e) =>
                                   setPassword(e.target.value)}
                        />
                        <h5>Confirm Password</h5>
                        <input type={values.showPassword ? "text" : "password"} className="form-control"
                               value={confirmPass}
                               onChange={(e) =>
                                   setConfirmPass(e.target.value)}
                        />
                    </div>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={
                        closeWindow
                    }>
                        Close
                    </Button>
                    <Button variant="primary" onClick={addUserClicked}>
                        Add user
                    </Button>
                </Modal.Footer>
            </Modal>


        </>

    )


}

export default AddUser;