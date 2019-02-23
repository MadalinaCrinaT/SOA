import { Group } from '../models/Group';

export class GroupMapper {

    public static mapGroups(data: any[]): Group[] {
        // data = data.filter((g: any) => g.groupId !== 1);
        return data.map(this.mapGroup);
    }

    public static mapGroup(data: any): Group {
        let groupEntity: Group = {
            name: data.groupName,
            id: data.groupId
        };
        return groupEntity;
    }
}
