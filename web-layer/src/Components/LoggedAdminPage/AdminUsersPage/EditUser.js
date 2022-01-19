import React, {useEffect, useState} from "react";
import {Button, Dropdown, Modal} from "react-bootstrap";
import {variables} from "../../Variables/Variables";


function EditUser(props) {

    const [email, setEmail] = useState('');
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [cardId, setCardId] = useState('');


    const closeWindow = () => {
        props.handleCloseEditButton()
        setFieldToEmpty()
    }
    const setFieldToEmpty = () => {
        setFirstName('')
        setCardId('')
        setLastName('')
        setEmail('')

    }

    const updateUserClicked = () => {

        if (email !== ''
            && firstName !== ''
            && lastName !== ''
            && cardId !== '') {
            if(validEmail()) {
                if (validCardId()) {
                        props.updateUser(email, firstName, lastName, cardId)
                        props.refreshPage()
                        setFieldToEmpty()
                        props.handleCloseEditButton()
                }
            }
        } else {
            alert("You forgot to fill some fields.")
        }


    }


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
    const validCardId = () =>
    {
        if(props.cards.find(card => card.cardId === parseInt(cardId)) !== undefined)
        {
            return true
        }
        else {
            alert("Card id wasn't found")
        }
    }


    if(props.currentuser !== undefined) {
        return (
                <>
                    <Modal show={props.showEditBtn} onHide={props.handleCloseEditButton}>
                        <Modal.Header closeButton>
                            <Modal.Title>Update User</Modal.Title>
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
                                <h5>Enter Card Id</h5>
                                <input type="text" className="form-control"
                                       value={cardId}
                                       onChange={(e) =>
                                           setCardId(e.target.value)}
                                />
                            </div>
                        </Modal.Body>
                        <Modal.Footer>
                            <Button variant="secondary" onClick={
                                closeWindow
                            }>
                                Close
                            </Button>
                            <Button variant="primary" onClick={updateUserClicked}>
                                Add user
                            </Button>
                        </Modal.Footer>
                    </Modal>


                </>
        )
    }
    else return (<></>)

}

export default EditUser;