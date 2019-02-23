import * as React from 'react';
import { ActivitiesProps } from './Home.Props';
import { NotificationCenter } from './Notification/NotificationCenter';
import { UserService } from '../services/User.Service';
import { AuthService } from '../services/Auth.Service';
import { User } from '../models/User';
interface HomeState {
    userName: string;
}
export class Home extends React.Component<ActivitiesProps, HomeState> {

    constructor(props: ActivitiesProps) {
        super(props);
        this.state = {
            userName: '',
        };
    }

    componentDidMount() {
        this.getUserName();
    }

    getUserName() {
        UserService.getUserDetails(AuthService.getUserId()).then((result: User) => {
            this.setState({
                userName: result.name
            });
        })
            .catch((err: any) => {
                NotificationCenter.addNotificationError(err);
            });
    }
    render() {
        return (
            <div className="div__body">
                <span> Welcome: </span>
                <span> {this.state.userName} </span>

            </div>
        );
    }
}
