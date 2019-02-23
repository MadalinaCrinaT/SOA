
import * as React from 'react';
import { Redirect } from 'react-router';
import { GroupService } from '../../services/Group.Service';
import { Group } from '../../models/Group';
import { AuthService } from '../../services/Auth.Service';
import { TableRow } from '../Table/TableRow';
import { UpdateGroup } from './UpdateGroup';
import * as Modal from 'react-modal';
import './Group.css';
import { UserDetailsTable } from '../Users/UserDetailsTable';
import { NotificationCenter } from '../Notification/NotificationCenter';

export interface Props {
    groupId: number;
}

interface State {
    member: boolean;
    redirect: boolean;
    groupName: string;
    redirectJoin: boolean;
    showModalGroup: boolean;
    element: TableRow;
}

export class GroupDetails extends React.Component<Props, State> {

    constructor(props: Props) {
        super(props);
        this.state = {
            member: false,
            redirect: false,
            groupName: '',
            redirectJoin: false,
            showModalGroup: false,
            element: {
                id: 0,
                name: '',
            },
        };
        this.handleOpenModalGroup = this.handleOpenModalGroup.bind(this);
        this.checkIsMember = this.checkIsMember.bind(this);
        this.handleCloseModalGroup = this.handleCloseModalGroup.bind(this);
    }

    handleOpenModalGroup() {
        this.setState({ showModalGroup: true });
    }

    handleCloseModalGroup() {
        this.setState({ showModalGroup: false });
        this.getGroupDetailsFromService();
    }

    componentDidMount() {
        this.getGroupDetailsFromService();
    }

    getGroupDetailsFromService() {
        GroupService.getGroupDetails(this.props.groupId).then((result: Group) => {
            this.setState({
                groupName: result.name
            });
            this.checkIsMember(this.props.groupId);
        })
            .catch((err: any) => {
                NotificationCenter.addNotificationError(err);
            });
    }

    deleteGroup() {
        GroupService.deleteGroup(this.props.groupId, AuthService.getUserId())
            .then((result: Group) => {
                this.setState({
                    redirect: true
                });
                NotificationCenter.addNotificationSuccess('group deleted succesfully ' + result.name);

            })
            .catch((err: any) => {
                NotificationCenter.addNotificationError(err);
            });
    }

    joinGroup() {
        GroupService.joinGroup(this.props.groupId, AuthService.getUserId()).then(() => {
            this.setState({
                redirectJoin: true
            });
            NotificationCenter.addNotificationSuccess('Group joined succesfully ');

        })
            .catch((err: any) => {
                NotificationCenter.addNotificationError(err);
            });
    }

    getGroupName() {
        GroupService.getGroupName(this.props.groupId)
            .then((result: string) => {
                this.setState({
                    groupName: result
                });
            })
            .catch((err: any) => {
                NotificationCenter.addNotificationError(err);
            });
    }
    checkIsMember(groupId: number) {
        /*GroupService.getMyGroups().then((result: Group[]) => {

            let a = result.filter(
                (g: Group) => {
                    let b = (g.id === Number(groupId));
                    return b;

                }
            );
            if (a.length === 0) {
                this.setState({
                    member: false
                });
            } else {*/
        this.setState({
            member: true
        });
        // }
        /*})
            .catch((err: any) => {
                NotificationCenter.addNotificationError(err);
            });*/
    }
    getElements() {
        var checkIsMember = this.state.member;
        if (checkIsMember === true) {
            return (
                <div>

                    <div className="block__button">
                        <button
                            className="block__groupDetails__button"
                            onClick={() => this.deleteGroup()}
                        > Unjoin group
                        </button>
                        <button
                            className="block__groupDetails__button"
                            onClick={this.handleOpenModalGroup}
                        > Update group
                        </button>
                    </div>
                </div>
            );
        } else {
            return (
                <div className="block__button">
                    <button
                        className="block__groupDetails__button"
                        onClick={() => this.joinGroup()}
                    > Join
                    </button>
                </div>
            );
        }
    }

    render() {
        if (this.state.redirect) {
            return <Redirect to="/myGroups" />;
        } else if (this.state.redirectJoin) {
            return <Redirect to="/groups" />;
        }
        return (
            <div className="div__body block__groupDetails">
                <div className="block__group">
                    <span className="block__groupNameLabel"> Group: </span>
                    <span className="block__groupName">
                        {this.state.groupName}
                    </span>
                </div>
                <UserDetailsTable
                    groupId={this.props.groupId}
                />
                {this.getElements()}
                <Modal
                    isOpen={this.state.showModalGroup}
                    contentLabel="Minimal Modal Example"
                >
                    <UpdateGroup
                        groupId={this.props.groupId}
                        onClick={() => this.handleCloseModalGroup()}
                        onCancel={() => this.handleCloseModalGroup()}
                    />
                </Modal>
            </div>
        );
    }
}
