import * as React from 'react';
import { Group } from '../../models/Group';
import { GroupService } from '../../services/Group.Service';
import { GroupsProps } from './Groups.Props';
import { Table } from '../Table/Table';
import { TableRow } from '../Table/TableRow';
import * as Modal from 'react-modal';
import { CreateGroup } from './CreateGroup';
import { NotificationCenter } from '../Notification/NotificationCenter';
interface GroupsState {
    groupsArray: Array<Group>;
    tableOptionsArray: Array<TableRow>;
    showModal: boolean;
}

export class MyGroups extends React.Component<GroupsProps, GroupsState> {
    constructor(props: GroupsProps) {
        super(props);
        this.state = {
            groupsArray: [],
            tableOptionsArray: [],
            showModal: false,
        };
        this.handleOpenModal = this.handleOpenModal.bind(this);
        this.handleCloseModal = this.handleCloseModal.bind(this);
    }

    handleOpenModal() {
        this.setState({ showModal: true });
    }

    handleCloseModal() {
        this.setState({ showModal: false });
    }

    handleAddGroup(group: Group) {
        this.setState({ showModal: false });

        let tableArray = this.state.tableOptionsArray;
        tableArray.push(this.makeTableFromGroup(group));
        this.setState({
            tableOptionsArray: tableArray
        });
    }

    componentDidMount() {
        this.getGroupsFromService();
    }

    getGroupsFromService() {
        GroupService.getMyGroups().then((result: Group[]) => {
            this.setState({
                groupsArray: result
            });
            this.makeTableArrayFromGroupArray(this.state.groupsArray);
        })
            .catch((err: any) => {
                NotificationCenter.addNotificationError(err);
            });
    }

    linkMaker = (id: number): string => {
        let a = 'groups/' + id ;
        return a;
    }

    makeTableArrayFromGroupArray(data: Group[]) {
        this.setState({
            tableOptionsArray: data.map(this.makeTableFromGroup)
        });
    }

    makeTableFromGroup(group: Group): TableRow {
        let tableEntity: TableRow = {
            id: group.id,
            name: group.name
        };

        return tableEntity;
    }

    render() {

        return (
            <div className="div__body div__myGroups">
                <Table
                    tableName="Groups"
                    link={this.linkMaker}
                    data={this.state.tableOptionsArray}
                />
                <div className="block__button">
                    <button onClick={this.handleOpenModal}>Create a new group</button>

                    <Modal
                        isOpen={this.state.showModal}
                        contentLabel="Minimal Modal Example"
                    >
                        <CreateGroup
                            onClick={(group) => this.handleAddGroup(group)}
                            onCancel={this.handleCloseModal}
                        />

                    </Modal>
                </div>
            </div>
        );
    }

}