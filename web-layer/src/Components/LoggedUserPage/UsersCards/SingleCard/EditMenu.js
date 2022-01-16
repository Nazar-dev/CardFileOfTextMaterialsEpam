import React, {useState} from "react";
import {Button, Dropdown, Modal} from "react-bootstrap";
import CheckCategoryName from "./CheckCategoryName";


function EditMenu(props) {

    const [dropDownValue, setDropDownValue] = useState("SelectCategory");

    const [textValue, setTextValue] = useState();

    const changeValue = (text) => {
        setDropDownValue(text)
        console.log(textValue + " " + dropDownValue)
    }
    const closeWindow = () => {
        props.handleCloseEdit()
        setTextValue(null)
        setDropDownValue("SelectCategory")
    }

    const updateBookClick = () => {
        props.handleCloseEdit()
        if (textValue !== null && dropDownValue !== "SelectCategory") {
                props.updateBook( dropDownValue, textValue)
        } else {
            alert("You forgot to fill some fields.")
        }

    }
    if(props.currentBook !== undefined) {
        return (
            <>

                <Modal show={props.showEdit} onHide={props.handleCloseEdit}>
                    <Modal.Header closeButton>
                        <Modal.Title>UpdateBook</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <div>
                            <h5>Selected Book Id= {props.currentBook.bookId}</h5>
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
                        <Button variant="primary" onClick={updateBookClick}>
                            UpdateBook
                        </Button>
                    </Modal.Footer>
                </Modal>


            </>

        )
    }
    else return (<></>)

}

export default EditMenu;