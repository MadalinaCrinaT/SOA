
import * as React from 'react';
import { GroupService } from '../../services/Group.Service';
import { Group } from '../../models/Group';
import { RenderGroup } from './RenderGroup';
import { NotificationCenter } from '../Notification/NotificationCenter';

export interface Props {
    groupId: number;
    onCancel: () => void;
    onClick: () => void;
}

export function UpdateGroup(props: Props) {

    let updateGroup = (groupName: string) => {
        GroupService.updateGroup(groupName, props.groupId)
            .then((result: Group) => {
                NotificationCenter.addNotificationSuccess('group updated succesfully ' + result.name);

                props.onClick();
            })
            .catch((err: any) => {
                NotificationCenter.addNotificationError(err);
            });
    };

    return (
        <div>
            <RenderGroup
                onClick={input => updateGroup(input)}
                onCancel={props.onCancel}
                buttonName="Update"
                componentIdForUpdate={props.groupId}
            />
        </div>
    );
}
