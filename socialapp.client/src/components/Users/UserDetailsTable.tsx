
import * as React from 'react';
import { GroupService } from '../../services/Group.Service';
import { Table2 } from '../Table/Table2';
import { TableRow } from '../Table/TableRow';
import * as Modal from 'react-modal';
import '../Groups/Group.css';
import { UserDetails } from './UserDetails';
import { User } from '../../models/User';
import { UserDetailsTableProps } from './UserDetailsTable.Props';
import { NotificationCenter } from '../Notification/NotificationCenter';

interface UserDetailsTableState {
    membersArray: Array<User>;
    tableOptionsMembersArray: Array<TableRow>;
    showMemberDetails: boolean;
    element: TableRow;
    owner: User;
}

export class UserDetailsTable extends React.Component<UserDetailsTableProps, UserDetailsTableState> {

    constructor(props: UserDetailsTableProps) {
        super(props);
        this.state = {
            tableOptionsMembersArray: [],
            membersArray: [],
            showMemberDetails: false,
            element: {
                id: 0,
                name: '',
            },
            owner: {
                id: 0,
                name: ''
            },
        };
        this.handleCloseModalUserDetail = this.handleCloseModalUserDetail.bind(this);
    }

    handleCloseModalUserDetail() {
        this.setState({ showMemberDetails: false });
    }

    componentDidMount() {
        this.getGroupOwnerFromService();
    }

    getGroupOwnerFromService() {
        GroupService.getGroupOwner(this.props.groupId).then((result: User) => {
            this.setState({
                owner: result
            });
            this.getGroupMembersFromService();
        })
            .catch((err: any) => {
                NotificationCenter.addNotificationError(err);
            });
    }

    getGroupMembersFromService() {
        GroupService.getGroupMembers(this.props.groupId, this.state.owner).then((result: User[]) => {
            this.setState({
                membersArray: result
            });
            
            if (result.length === 0) {
                NotificationCenter.addNotificationInfo('There aren\'t members which joined your group!');
            }
            this.makeTableArrayFromMembersArray();
        })
            .catch((err: any) => {
                NotificationCenter.addNotificationError(err);
            });
    }

    makeTableArrayFromMembersArray() {
        this.setState({
            tableOptionsMembersArray: this.state.membersArray.map(this.makeTableFromMembers)
        });
    }

    makeTableFromMembers(user: User): TableRow {
        let tableEntity: TableRow = {
            id: user.id,
            name: user.name
        };
        return tableEntity;
    }

    memberClick(element: TableRow) {
        this.setState({
            element: element,
            showMemberDetails: true,
        });
    }
    render() {
        let getModalMembers = () => {
            return (
                <Modal
                    isOpen={this.state.showMemberDetails}
                    contentLabel="Minimal Modal Example"
                >
                    <UserDetails
                        userId={this.state.element.id}
                        onClose={this.handleCloseModalUserDetail}
                    />

                </Modal>
            );
        };

        return (
            <div>
                <div className="block__group">
                    <span className="block__ownerLabel"> Owner: </span>
                    <span className="block__owner">
                        <button
                            className="block__owner__button"
                            onClick={() => { this.memberClick(this.state.owner); }}
                        >{this.state.owner.name}
                        </button>
                    </span>
                </div>
                <Table2
                    tableName="Members"
                    data={this.state.tableOptionsMembersArray}
                    getModal={() => getModalMembers()}
                    elementClick={(element) => this.memberClick(element)}
                />
            </div>
        );
    }
}
