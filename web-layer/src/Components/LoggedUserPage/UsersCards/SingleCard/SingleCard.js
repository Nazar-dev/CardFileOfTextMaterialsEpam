import React, {useState, useEffect} from "react";

import {variables} from "../../../Variables/Variables";
import ModalComp from "./ModalComp";
import {Button, Dropdown, Modal} from "react-bootstrap";
import EditMenu from "./EditMenu";
import checkCategoryName from "./CheckCategoryName";


const SingleCard = (props) => {

    const [show, setShow] = useState(false);

    const [showEdit, setShowEdit] = useState(false);

    const [cards, setCards] = useState([]);

    const [books, setBooks] = useState([]);

    const [currentBook, setBook] = useState();

    const [bookName, setBookName] = useState("");

    const [category, setCategory] = useState([]);

    const [refresh, setRefresh] = useState(false);


    const handleCloseEdit = () => setShowEdit(false);

    const handleShowEdit = () => setShowEdit(true);

    const handleClose = () => setShow(false);

    const handleShow = () => setShow(true);

    useEffect(() => {
        fetch(variables.API_URL + 'card')
            .then(response => response.json())
            .then(data => {
                setCards(data);
                setRefresh(false)
            })
    }, [refresh])

    useEffect(() => {
        fetch(variables.API_URL + 'book')
            .then(response => response.json())
            .then(data => {
                setBooks(data);
                setRefresh(false)
            })

    }, [refresh]);
    useEffect(() => {
        fetch(variables.API_URL + 'category')
            .then(response => response.json())
            .then(data => {
                setCategory(data);
                setRefresh(false)
            })

    }, [refresh]);


    const updateBook = (bookName, categoryId) => {
        console.log(bookName + ' ' + categoryId + 'Upd')
        fetch(variables.API_URL + 'book', {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                BookId: currentBook.bookId,
                BookName: categoryId,
                CategoryId: checkCategoryName(bookName)
            })
        })
            .then(res => res.json())
            .then((result) => {
                alert(result);
                refreshPage()
                handleCloseEdit()
            }, (error) => {
                alert('Failed');
            })
    }


    const refreshPage = () => {
        setRefresh(true)
    }
    const editBook = (book) => {
        setBook(book)
        if(book !== undefined)
        {
            handleShowEdit()
        }
    }


    const createAndSendToDBBook = (name, categoryId) => {
        fetch(variables.API_URL + 'book', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                bookName: name,
                categoryId: categoryId
            })

        })
            .then(res => res.json())
            .then((result) => {
                alert(result);
                refreshPage()
                handleCloseEdit()
            }, (error) => {
                alert('Failed');
            })
    }


    const changeBookName = e => setBookName(e.target.value)


    const deleteBook = (book) => {
        if (window.confirm('Are you sure?')) {
            fetch(variables.API_URL + 'book/' + book.bookId, {
                method: 'DELETE',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                }
            })

                .then(res => res.json())
                .then((result) => {
                    alert(result);
                    refreshPage()
                    handleCloseEdit()
                }, (error) => {
                    alert('Failed');
                })
        }
    }
    console.log(category);
    console.log(books);

    if (books.length !== 0 && cards.length !== 0 && category.length !== 0)
        return (
            <div>

                <Button variant="primary" className="btn btn-primary m-2 float-end"
                        onClick={handleShow}>
                    AddBook
                </Button>

                <table className="table table-striped">
                    <thead>
                    <tr>
                        <th>
                            BookId
                        </th>
                        <th>
                            BookName
                        </th>
                        <th>
                            CategoryName
                        </th>
                        <th>
                            Options
                        </th>
                    </tr>

                    </thead>
                    <tbody>
                    {books.map(book =>
                        <tr key={book.bookId}>
                            <td>{book.bookId}</td>
                            <td>{book.bookName}</td>
                            <td>{category.find(ctg => ctg.categoryId === book.categoryId).categoryName}</td>
                            <td>
                                <button type="button"
                                        className="btn btn-light mr-1"
                                        onClick={editBook.bind(this, book)}>

                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16"
                                         fill="currentColor" className="bi bi-pencil-square" viewBox="0 0 1s6 16">
                                        <path
                                            d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
                                        <path fillRule="evenodd"
                                              d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z"/>
                                    </svg>
                                </button>
                                <button type="button"
                                        className="btn btn-light mr-1"
                                        onClick={deleteBook.bind(this, book)}
                                >

                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16"
                                         fill="currentColor" className="bi bi-trash-fill" viewBox="0 0 16 16">
                                        <path
                                            d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z"/>
                                    </svg>
                                </button>
                            </td>
                        </tr>
                    )}
                    </tbody>
                </table>
                <EditMenu
                    refreshPage={refreshPage}
                    showEdit={showEdit}
                    handleCloseEdit={handleCloseEdit}
                    handleShowEdit={handleShowEdit}
                    updateBook={updateBook}
                    currentBook={currentBook}

                />
                <ModalComp
                    refreshPage={refreshPage}
                    createAndSendToDBBook={createAndSendToDBBook}
                    show={show}
                    handleShow={handleShow}
                    handleClose={handleClose}
                    changeBookName={changeBookName}
                    bookName={bookName}
                />

            </div>
        )

    else return (<button className="btn btn-primary" disabled>
        <span className="spinner-border spinner-border-sm"></span>
        Loading..
    </button>)


}
export default SingleCard;