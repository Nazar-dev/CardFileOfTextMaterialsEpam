import './App.css';
import {NavLink, Route, Switch , BrowserRouter} from "react-router-dom";
import Authorization from "../Authorization/Authorization"
import Registration from "../Registration/Registration"
import HomePage from "../Home/HomePage";
import SingleCard from "../LoggedUserPage/UsersCards/SingleCard/SingleCard";
import AdminUserPage from "../LoggedAdminPage/AdminUsersPage/AdminUserPage";
function App() {
  return (
      <BrowserRouter>
    <div className="App contrainer">

        <nav className="navbar navbar-expand-sm bg-light navbar-dark">
            <ul className="navbar-nav">
                <li className="nav-item- m-1">
                    <NavLink className="btn btn-light btn-outline-primary" to="/signin">
                        Sign in
                    </NavLink>
                </li>
                <li className="nav-item- m-1">
                    <NavLink className="btn btn-light btn-outline-primary" to="/signup">
                        Sign up
                    </NavLink>
                </li>
                <li className="nav-item- m-1">
                    <NavLink className="btn btn-light btn-outline-primary" to="/cards">
                        Cards
                    </NavLink>
                </li>
                <li className="nav-item- m-1">
                    <NavLink className="btn btn-light btn-outline-primary" to="/admin-user-control">
                        User Control
                    </NavLink>
                </li>
            </ul>
        </nav>
        <Switch>
            <Route path="/signin" component={Authorization}/>
            <Route path="/signup" component={Registration}/>
            <Route path="/cards" component={SingleCard}/>
            <Route path="/admin-user-control" component={AdminUserPage}/>
        </Switch>

    </div>
      </BrowserRouter>
  );
}

export default App;
//TODO
/*
*  Three states
*   Authorized
*   Role
*   UserId

* */

