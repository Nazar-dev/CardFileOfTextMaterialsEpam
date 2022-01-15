import React, {useState, useEffect} from "react";


import {variables} from "../../../Variables/Variables";
import ModalComp from "./ModalComp";
import {Button, Modal} from "react-bootstrap";

const SingleCard = (props) => {

    const [show, setShow] = useState(false);

    const [cards, setCards] = useState([]);

    const [books, setBooks] = useState([]);

    const [bookName, setBookName] = useState("");

    const [bookId, setBookId] = useState(0);

    const [refresh,setRefresh] = useState(false);


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

    const refreshPage = () =>
    {
        setRefresh(true)
    }
    const editBook = (card) => {
        setBookId(card.bookId);
        setBookName("HarryPotter")
    }
    const createAndSendCard = (name,categoryId) => {
        console.log(books.find(book => book.bookName === name && book.categoryId === categoryId).bookId)
        fetch(variables.API_URL+'card',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                bookId: books.find(book => book.bookName === name && book.categoryId === categoryId).bookId,
            })
        })
            .then(res=>res.json())
            .then((result)=>{
                alert(result);
            },(error)=>{
                alert('Card was not created');
            })
    }
    const createAndSendToDBBook = (name,categoryId) => {
        fetch(variables.API_URL+'book',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                bookName:name,
                categoryId:categoryId
            })

        })
            .then(res=>res.json())
            .then((result)=>{
                alert(result);
            },(error)=>{
                alert('Failed');
            })
        refreshPage()
    }


    const changeBookName = e => setBookName(e.target.value)



    const deleteBook = (card) => {
        if (window.confirm('Are you sure?')) {
            fetch(variables.API_URL + 'book/' + card.bookId, {
                method: 'DELETE',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                }
            })

                .then(res => res.json())
                .then((result) => {
                    alert(result);
                }, (error) => {
                    alert('Failed');
                })
        }
    }
    console.log(cards);
    console.log(books);

    if (books.length !== 0 && cards.length !== 0)
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
                            CardId
                        </th>
                        <th>
                            BookName
                        </th>
                        <th>
                            Options
                        </th>
                    </tr>

                    </thead>
                    <tbody>
                    {cards.map(card =>
                        <tr key={card.cardId}>
                            <td>{card.cardId}</td>
                            <td>{books.find(book => book.bookId === card.bookId).bookName}</td>
                            <td>
                                <button type="button"
                                        className="btn btn-light mr-1"
                                        onClick={editBook.bind(this, card)}>

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
                                        onClick={deleteBook.bind(this, card)}
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

                <ModalComp
                    createAndSendCard={createAndSendCard}
                    refreshPage={refreshPage}
                    createAndSendToDBBook = {createAndSendToDBBook}
                    show={show}
                    handleShow = {handleShow}
                    handleClose = {handleClose}
                    changeBookName={changeBookName}
                    bookName={bookName}
                    bookId={bookId}
                />

            </div>
        )

    else return (<div>Loading...</div>)


}
export default SingleCard;