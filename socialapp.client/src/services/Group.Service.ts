import axios from 'axios';
import { Group } from '../models/Group';
import { GroupMapper } from '../mapper/GroupsMapper';
import { AuthService } from './Auth.Service';
import { AppConfig } from '../AppConfig';
import { User } from '../models/User';
import { UserMapper } from '../mapper/UserMapper';

export class GroupService {

    public static getGroupName(i: number): Promise<string> {

        return new Promise((resolve, reject) => {
            axios.get(AppConfig.getUrl() + 'app/groups/' + i).then(
                ({ data }) => {
                    resolve(GroupMapper.mapGroup(data).name);
                },
                (error) => {
                    reject(error.response.data);
                });
        });
    }

    public static getGroupsIAmNotPartIn(): Promise<Group[]> {
        let promiseAllGroups = GroupService.getAllGroups();
        let promiseMyGroups = promiseAllGroups;
        return Promise.all([promiseAllGroups, promiseMyGroups]).then(function (values: any[]) {
            let allGroups = values[0];
            // let myGroups = values[1];

            return allGroups;
        });
    }
    public static getAllGroups(): Promise<Group[]> {
        return new Promise((resolve, reject) => {
            axios.get(AppConfig.getUrl() + 'groups').then(
                ({ data }) => {
                    resolve(GroupMapper.mapGroups(data));
                },
                (error) => {
                    reject(error.response.data);
                });
        });
    }

    static filter(allGroups: Group[], myGroups: Group[]): any {
        return allGroups.filter(
            (group: Group) => {
                if (myGroups.find(
                    function (g: Group) {
                        return (g.id === group.id);
                    })
                ) {
                    return false;
                }
                return true;
            }
        );
    }

    public static getGroupDetails(i: number): Promise<Group> {

        return new Promise((resolve, reject) => {
            axios.get(AppConfig.getUrl() + 'app/groups/' + i).then(
                ({ data }) => {
                    resolve(GroupMapper.mapGroup(data));
                },
                (error) => {
                    reject(error.response.data);
                    // reject(error);
                });
        });
    }

    static getGroupMembers(i: number, owner: User): Promise<User[]> {
        return new Promise((resolve, reject) => {
            axios.get(AppConfig.getUrl() + 'app/groups/' + i + '/members').then(
                ({ data }) => {
                    resolve(GroupService.filterOwner(UserMapper.mapUsers(data), owner));
                },

                (error) => {
                    reject(error.response.data);
                });
        });
    }

    static filterOwner(allUsers: User[], owner: User): User[] {
        return allUsers.filter(
            (user: User) => {
                return (user.id !== owner.id);

            }
        );
    }
    static getGroupOwner(i: number): Promise<User> {
        return new Promise((resolve, reject) => {
            axios.get(AppConfig.getUrl() + 'app/groups/' + i + '/owner').then(
                ({ data }) => {
                    resolve(UserMapper.mapUser(data));
                },
                (error) => {
                    reject(error.response.data);
                });
        });
    }

    public static getMyGroups(): Promise<Group[]> {

        return new Promise((resolve, reject) => {
            axios.get(AppConfig.getUrl() + 'users/' + AuthService.getUserId() + '/groups').then(
                ({ data }) => {
                    resolve(GroupMapper.mapGroups(data));
                },
                (error) => {
                    reject(error.response.data);
                });
        });
    }

    public static addGroup(groupName: string, userId: number): Promise<Group> {
        return new Promise((resolve, reject) => {
            axios.post(AppConfig.getUrl() + 'app/groups',
                {
                    GroupName: groupName
                },
                {
                    params: {
                        userId: userId
                    }
                }).then(
                    ({ data }) => {
                        resolve(GroupMapper.mapGroup(data));
                    },
                    (error) => {
                        reject(error.response.data);
                    });
        });

    }
    public static joinGroup(groupId: number, userId: number) {
        return new Promise((resolve, reject) => {
            axios.post(AppConfig.getUrl() + 'app/groups/' + groupId + '/' + userId).then(
                () => {
                    resolve('succes');
                },
                (error) => {
                    reject(error.response.data);
                });
        });

    }

    public static updateGroup(groupName: string, id: number): Promise<Group> {
        return new Promise((resolve, reject) => {
            axios.put(AppConfig.getUrl() + 'app/groups',
                {
                    GroupName: groupName
                },
                {
                    params: {
                        groupId: id
                    }
                }
            )
                .then(
                    ({ data }) => {
                        resolve(GroupMapper.mapGroup(data));
                    },
                    (error) => {
                        reject(error.response.data);
                    });
        });
    }

    public static deleteGroup(groupId: number, userId: number): Promise<Group> {
        return new Promise((resolve, reject) => {
            axios.delete(AppConfig.getUrl() + 'app/groups', {
                params: {
                    'groupId': groupId,
                    'userId': userId
                }
            })
                .then(
                    ({ data }) => {
                        resolve(GroupMapper.mapGroup(data));
                    },
                    (error) => {
                        reject(error.response.data);
                    });
        });
    }
}
