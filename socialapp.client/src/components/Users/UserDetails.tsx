import * as React from 'react';
import { User } from '../../models/User';
import { UserService } from '../../services/User.Service';
import { NotificationCenter } from '../Notification/NotificationCenter';
import { UserDetailsProps } from './UserDetails.Props';
import './User.css';

interface UserDetailsState {
    userName: string;
}

export class UserDetails extends React.Component<UserDetailsProps, UserDetailsState> {
    constructor(props: UserDetailsProps) {
        super(props);
        this.state = {
            userName: '',
        };
    }

    componentDidMount() {
        this.getUserDetailsFromService();
    }

    getUserDetailsFromService() {
        UserService.getUserDetails(this.props.userId).then((result: User) => {
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
            <div className="block__modal block__user">
                <span className="block__userNameLabel">
                    User name:
            </span>
                <span className="block__userName">
                    {this.state.userName}
                </span>
                <div className="block__modal__button">
                    <button
                        onClick={this.props.onClose}
                    >Close
                    </button>
                </div>
            </div>
        );
    }
}
