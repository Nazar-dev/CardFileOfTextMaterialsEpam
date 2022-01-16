import React, {useState} from "react";
import {Button, Dropdown, Modal} from "react-bootstrap";
import CheckCategoryName from "./CheckCategoryName";
import {variables} from "../../../Variables/Variables";


function ModalComp(props) {

    const [dropDownValue, setDropDownValue] = useState("SelectCategory");

    const [textValue, setTextValue] = useState();

    const changeValue = (text) => {
        setDropDownValue(text)
        console.log(textValue + " " + dropDownValue)
    }

    const closeWindow = () => {
        props.handleClose()
        setTextValue(null)
        setDropDownValue("SelectCategory")
    }
    const addBookClicked = () => {
        props.handleClose()
        if (textValue !== null && dropDownValue !== "SelectCategory") {
            props.createAndSendToDBBook(textValue, CheckCategoryName(dropDownValue))
            props.refreshPage()
        } else {
            alert("You forgot to fill some fields.")
        }

    }


    return (
        <>

            <Modal show={props.show} onHide={props.handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>Add Book</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <div>

                        <h5>Enter BookName</h5>
                        <input type="text" className="form-control"
                               value={textValue}
                               onChange={(e) =>
                                   setTextValue(e.target.value)}
                        />
                        <h5>Select BookCategory</h5>

                        <Dropdown>
                            <Dropdown.Toggle variant="success" id="dropdown-basic">
                                {dropDownValue}
                            </Dropdown.Toggle>

                            <Dropdown.Menu>
                                <Dropdown.Item>
                                    <div
                                        onClick={(e) =>
                                            changeValue(e.target.textContent)}
                                    >Roman
                                    </div>
                                </Dropdown.Item>
                                <Dropdown.Item>
                                    <div
                                        onClick={(e) =>
                                            changeValue(e.target.textContent)}

                                    >Drama
                                    </div>
                                </Dropdown.Item>
                                <Dropdown.Item>
                                    <div
                                        onClick={(e) =>
                                            changeValue(e.target.textContent)}
                                    >Poem
                                    </div>
                                </Dropdown.Item>
                            </Dropdown.Menu>
                        </Dropdown>
                    </div>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={
                        closeWindow
                    }>
                        Close
                    </Button>
                    <Button variant="primary" onClick={addBookClicked}>
                        Add book
                    </Button>
                </Modal.Footer>
            </Modal>


        </>

    )

}

export default ModalComp;