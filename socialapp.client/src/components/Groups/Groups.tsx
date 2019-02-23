import * as React from 'react';
import { Group } from '../../models/Group';
import { GroupService } from '../../services/Group.Service';
import { DropdownDataOption } from '../../models/DropdownDataOption';
import { GroupsProps } from './Groups.Props';
import { Table } from '../Table/Table';
import { TableRow } from '../Table/TableRow';
import { NotificationCenter } from '../Notification/NotificationCenter';

interface GroupsState {
    groupsArray: Array<Group>;
    dropdownDataOptionsArray: Array<DropdownDataOption>;
    tableOptionsArray: Array<TableRow>;
}

export class Groups extends React.Component<GroupsProps, GroupsState> {
    constructor(props: GroupsProps) {
        super(props);
        this.state = {
            groupsArray: [],
            dropdownDataOptionsArray: [],
            tableOptionsArray: [],
        };
    }
    componentDidMount() {
        this.getGroupsFromService();
    }

    getGroupsFromService() {
        GroupService.getGroupsIAmNotPartIn().then((result: Group[]) => {
            this.setState({
                groupsArray: result
            });
            this.makeTableArrayFromGroupArray(this.state.groupsArray);
        })
        .catch((err: any) => {
            NotificationCenter.addNotificationError(err);
        });
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

    linkMaker = (id: number): string => {
        let a = 'groups/' + id;
        return a;
    }

    render() {
        return (
            <div className="div div__body div__groups">
                <Table
                    tableName="Groups"
                    link={this.linkMaker}
                    data={this.state.tableOptionsArray}
                />
            </div>
        );
    }
}
