import React, {useState, useEffect} from "react";

import {variables} from "../../Variables/Variables";
import {Button} from "react-bootstrap";
import AddUser from "./AddUser";
import checkCategoryName from "../../LoggedUserPage/UsersCards/SingleCard/CheckCategoryName";
import EditUser from "./EditUser";

const AdminUserPage = (props) => {

    const [showAddBtn, setShowAddBtn] = useState(false);

    const [showEditBtn, setShowEditBtn] = useState(false);

    const [users, setUsers] = useState([]);

    const [cards, setCards] = useState([]);

    const handleCloseEditButton = () => setShowEditBtn(false);

    const handleShowEditButton = () => setShowEditBtn(true);

    const handleCloseAddButton = () => setShowAddBtn(false);

    const handleShowAddButton = () => setShowAddBtn(true);

    const [currentUser, setCurrentUser] = useState();


    const [refresh, setRefresh] = useState(false);

    const refreshPage = () => {
        setRefresh(true)
    }
    useEffect(() => {
        fetch(variables.API_URL + 'card')
            .then(response => response.json())
            .then(data => {
                setCards(data);
                setRefresh(false)
            })
    }, [refresh])

    useEffect(() => {
        fetch(variables.API_URL + 'authorization')
            .then(response => response.json())
            .then(data => {
                setUsers(data);
                setRefresh(false)
            })
    }, [refresh])


    const updateUser = (email, firstname, lastname, cardId) => {
        fetch(variables.API_URL + 'authorization', {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                id: currentUser.id,
                Email: email,
                FirstName: firstname,
                Lastname: lastname,
                cardId: parseInt(cardId)
            })
        })
            .then(res => res.json())
            .then((result) => {
                alert(result);
                refreshPage()
                handleCloseEditButton()
            }, (error) => {
                alert('Failed');
            })
    }

    const createAndSendToDbUser = (email, firstname, lastname, cardId, password) => {
        fetch(variables.API_URL + 'authorization/signup', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                Email: email,
                FirstName: firstname,
                LastName: lastname,
                CardId: parseInt(cardId),
                Password: password
            })

        })
            .then(res => res.json())
            .then((result) => {
                alert(result);
                refreshPage()
                handleCloseAddButton()
            }, (error) => {
                alert('Failed');
            })
    }
    const editUser = (user) => {
        setCurrentUser(user)
        if (user !== undefined) {
            handleShowEditButton()
        }
    }

    const deleteUser = (user) => {
        if (window.confirm('Are you sure?')) {
            fetch(variables.API_URL + 'authorization/' + user.id, {
                method: 'DELETE',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                }
            })

                .then(res => res.json())
                .then((result) => {
                    alert(result);
                    refreshPage();
                }, (error) => {
                    alert('Failed');
                })
        }
    }
    console.log(users);

    if (users.length !== 0)
        return (
            <div>
                <Button variant="primary" className="btn btn-primary m-2 float-end"
                        onClick={handleShowAddButton}>
                    AddUser
                </Button>
                <table className="table table-striped">
                    <thead>
                    <tr>
                        <th>
                            UserId
                        </th>

                        <th>
                            Email
                        </th>

                        <th>
                            FirstName
                        </th>

                        <th>
                            SecondName
                        </th>

                        <th>
                            Role
                        </th>
                        <th>
                            Options
                        </th>
                    </tr>

                    </thead>
                    <tbody>
                    {users.map(user =>
                        <tr key={user.id}>
                            <td>{user.id}</td>
                            <td>{user.email}</td>
                            <td>{user.firstName}</td>
                            <td>{user.secondName}</td>
                            <td>{user.role}</td>
                            <td>
                                <button type="button"
                                        className="btn btn-light mr-1"
                                        onClick={editUser.bind(this, user)}>
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16"
                                         fill="currentColor" className="bi bi-pencil-square" viewBox="0 0 16 16">
                                        <path
                                            d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
                                        <path fillRule="evenodd"
                                              d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z"/>
                                    </svg>
                                </button>
                                <button type="button"
                                        className="btn btn-light mr-1"
                                        onClick={deleteUser.bind(this, user)}>

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
                <AddUser
                    handleShowAddButton={handleShowAddButton}
                    handleCloseAddButton={handleCloseAddButton}
                    showAddBtn={showAddBtn}
                    createAndSendToDbUser={createAndSendToDbUser}
                    refreshPage={refreshPage}
                    cards={cards}
                    users={users}
                    updateUser={updateUser}
                    currentuser={currentUser}

                />
                <EditUser
                    handleShowEditButton={handleShowEditButton}
                    handleCloseEditButton={handleCloseEditButton}
                    showEditBtn={showEditBtn}
                    refreshPage={refreshPage}
                    cards={cards}
                    users={users}
                    updateUser={updateUser}
                    currentuser={currentUser}

                />
            </div>
        )
    else return (<button className="btn btn-primary" disabled>
        <span className="spinner-border spinner-border-sm"></span>
        Loading..
    </button>)


}
export default AdminUserPage;