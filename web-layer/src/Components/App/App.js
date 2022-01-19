import './App.css';
import {NavLink, Route, Switch, BrowserRouter, Redirect} from "react-router-dom";
import Authorization from "../Authorization/Authorization"
import Registration from "../Registration/Registration"
import SingleCard from "../LoggedUserPage/UsersCards/SingleCard/SingleCard";
import AdminUserPage from "../LoggedAdminPage/AdminUsersPage/AdminUserPage";

function App() {
    const signOut = () => {
        localStorage.clear()
        window.location.href = "http://localhost:3000/signin";
    }
    return (
        <BrowserRouter>
            <div className="App contrainer">
                <Route exact path="/">
                    <Redirect to="/signin"/>
                </Route>
                <nav className="navbar navbar-expand-sm bg-light navbar-dark">
                    <ul className="navbar-nav">
                        {localStorage.hasOwnProperty('authUserID') ? (
                            <li className="nav-item- m-1">
                                <NavLink className="btn btn-light btn-outline-primary" to="/books">
                                    Books
                                </NavLink>
                            </li>
                        ) : (
                            <li className="nav-item- m-1">
                                <NavLink className="btn btn-light btn-outline-primary" to="/signin">
                                    Sign in
                                </NavLink>
                            </li>
                        )}
                        {localStorage.hasOwnProperty('role') ? (

                            <li className="nav-item- m-1">
                                <NavLink className="btn btn-light btn-outline-primary" to="/admin-user-control">
                                    User Control
                                </NavLink>
                            </li>

                        ) : (
                            console.log('user')
                        )}
                        {!localStorage.hasOwnProperty('authUserID') ?
                            <li className="nav-item- m-1">
                                <NavLink className="btn btn-light btn-outline-primary" to="/signup">
                                    Sign up
                                </NavLink>
                            </li> :
                            console.log('user')}

                        {localStorage.hasOwnProperty('authUserID') ?
                            <li className="nav-item- m-1">
                                <NavLink className="btn btn-light btn-outline-primary" to="/signin" onClick={signOut}>
                                    Sign out
                                </NavLink>
                            </li> :
                            console.log('')}

                    < /ul>
                </nav>
                <Switch>
                    <Route path="/signin" component={Authorization}/>
                    <Route path="/signup" component={Registration}/>
                    <Route path="/books" component={SingleCard}/>
                    <Route path="/admin-user-control" component={AdminUserPage}/>
                </Switch>

            </div>
        </BrowserRouter>
    );
}

export default App;

