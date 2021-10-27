import React from 'react'
import './App.css';
import RegisterPage from './components/auth/Register';
import LoginPage from './components/auth/Login';
import Header from './components/header';
import HomePage from './components/home';
import {
  BrowserRouter as Router,
  Switch,
  Route
} from 'react-router-dom';

class App extends React.Component {
  render() {
    return (
      <Router>
      <Header />
      <div className="container">
      <Switch>
            <Route exact path="/">
              <HomePage />
            </Route>

            <Route exact path="/register">
              <RegisterPage />
            </Route>

            <Route exact path="/login">
              <LoginPage />
            </Route>
          </Switch>
        </div>
        </Router>
    );
  }
}
export default App
