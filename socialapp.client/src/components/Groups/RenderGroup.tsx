
import * as React from 'react';
import { GroupService } from '../../services/Group.Service';
import { NotificationCenter } from '../Notification/NotificationCenter';

export interface Props {
    onClick: (input: string) => void;
    onCancel: () => void;
    buttonName: string;
    componentIdForUpdate?: number;
}

interface State {
    inputValue: string;
}

export class RenderGroup extends React.Component<Props, State> {
    constructor(props: Props) {
        super(props);
        this.state = {
            inputValue: ''
        };
    }
    updateInputValue = (evt: any) => {
        this.setState({
            inputValue: evt.target.value
        });
    }

    componentDidMount() {
        let id = this.props.componentIdForUpdate;
        if (id !== undefined) {
            GroupService.getGroupName(id)
                .then((result: string) => {
                    this.setState({
                        inputValue: result
                    });
                })
                .catch((err: any) => {
                    NotificationCenter.addNotificationError(err);
                });
        }
    }

    render() {
        return (
            <div className="block__modal block__create">
                Group name:<br />
                <input
                    className="block__create__input"
                    value={this.state.inputValue}
                    onChange={this.updateInputValue}
                /><br />
                <div className="block__create__block">
                    <button
                        className="block__create__block__button"
                        onClick={() => this.props.onClick(this.state.inputValue)}
                    > {this.props.buttonName}
                    </button>
                </div>
                <div className="block__create__block">
                    <button
                        className="block__create__block__button"
                        onClick={() => this.props.onCancel()}
                    >Cancel
                    </button>
                </div>
            </div>
        );
    }
}
