
import * as React from 'react';
import { GroupService } from '../../services/Group.Service';
import { Group } from '../../models/Group';
import { RenderGroup } from './RenderGroup';
import { AuthService } from '../../services/Auth.Service';
import '../Create.css';
import { NotificationCenter } from '../Notification/NotificationCenter';
export interface Props {
    onClick: (group: Group) => void;
    onCancel: () => void;
}

export function CreateGroup(props: Props) {

    let addGroup = (groupName: string) => {
        GroupService.addGroup(groupName, AuthService.getUserId())
            .then((result: Group) => {
                NotificationCenter.addNotificationSuccess('Group added succesfully ' + result.name);

                props.onClick(result);
            })
            .catch((err: any) => {
                NotificationCenter.addNotificationError(err);
            });
    };

    return (
        <RenderGroup
            onClick={input => addGroup(input)}
            onCancel={props.onCancel}
            buttonName="Create"
        />
    );
}
