
import * as React from 'react';
import { AuthService } from '../../services/Auth.Service';
import { User } from '../../models/User';
import { Redirect } from 'react-router';
import { NotificationCenter } from '../Notification/NotificationCenter';

export interface Props {
}

interface State {
    inputValue: string;
    redirect: boolean;
}

export class Login extends React.Component<Props, State> {
    constructor(props: Props) {
        super(props);
        this.state = {
            inputValue: '',
            redirect: false,
        };
    }

    getUser(id: string) {
        AuthService.auth(id)
            .then((result: User) => {
                AuthService.storeUser(result);
                this.setState({
                    redirect: true
                });
                NotificationCenter.addNotificationSuccess('Welcome!');
            })
            .catch((err: any) => {
                NotificationCenter.addNotificationError(err);
            });
    }

    updateInputValue = (evt: any) => {
        this.setState({
            inputValue: evt.target.value
        });
    }

    render() {
        if (this.state.redirect) {
            return <Redirect to="/home" />;
        }
        return (
            <div className="div__body">
                User name:<br />
                <input value={this.state.inputValue} onChange={this.updateInputValue} /><br />
                <button onClick={() => this.getUser(this.state.inputValue)}> Login </button>
            </div>
        );
    }
}
