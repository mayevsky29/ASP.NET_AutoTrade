import './App.css';
import React, {Suspense} from 'react';
import {
  Switch,
  Route
} from "react-router";
const DefaultLayout = React.lazy(()=>import('./components/containers/DefaultLayout'));
const AdminLayout = React.lazy(()=>import('./components/containers/AdminLayout'));

class App extends React.Component {

  render() {
    return (
      <>
        <Suspense fallback={<div>Загрузка ...</div>}>
          <Switch>
            <Route path="/admin" name="Admin" render={props=> <AdminLayout {...props}/>} />
            <Route path="/" name="Default" render={props=> <DefaultLayout {...props}/>} />
          </Switch>
        </Suspense>
        </>
      
    );
  }
}

export default App;
