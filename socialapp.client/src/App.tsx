import * as React from 'react';
import './App.css';
import './Modal.css';
import { Login } from './components/Login/Login';
import { Page } from './components/Page';
import { Switch, Route } from 'react-router-dom';
import { Redirect } from 'react-router';

class App extends React.Component {

  render() {
    return (
      <div className="app">
        <Switch >
          <Route exact={true} path="/auth" component={Login} />
          <Route exact={true} path="/home" component={Page} />
          <Route exact={true} path="/groups" component={Page} />
          <Route exact={true} path="/groups/:groupId" component={Page} />
          <Route exact={true} path="/myGroups" component={Page} />
          <Redirect to="/auth" />
        </Switch>
      </div>
    );
  }
}

export default App;
