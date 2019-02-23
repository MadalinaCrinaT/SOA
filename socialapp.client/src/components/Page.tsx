import * as React from 'react';
import { Switch, Route } from 'react-router-dom';
import { Header } from './Header/Header';
import { Home } from './Home';
import { Groups } from './Groups/Groups';
import { MyGroups } from './Groups/MyGroups';
import { GroupDetails } from './Groups/GroupDetails';
import { NotificationCenter } from './Notification/NotificationCenter';
import './Page.css';
import { AuthService } from '../services/Auth.Service';
import { Redirect } from 'react-router';
export class Page extends React.Component {
    render() {
        if (AuthService.getUserId() === 0) {
            return <Redirect to="../auth" />;
        } else {
            return (
                <div className="div div__page">
                    <NotificationCenter />
                    <Header />
                    <Switch >
                        <Route exact={true} path="/home" component={Home} />
                        <Route exact={true} path="/groups" component={Groups} />
                        <Route
                            exact={true}
                            path="/groups/:groupId"
                            component={({ match }: any) => <GroupDetails
                                groupId={match.params.groupId}
                            />}
                        />

                        <Route exact={true} path="/myGroups" component={MyGroups} />
                    </Switch>
                </div>
            );
        }
    }
}
