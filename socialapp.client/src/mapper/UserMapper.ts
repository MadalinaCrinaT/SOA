import { User } from '../models/User';

export class UserMapper {

    public static mapUsers(data: any[]): User[] {
        return data.map(this.mapUser);
    }
    public static mapUser(data: any): User {
        let userEntity: User = {
            name: data.userName,
            id: data.userId
        };

        return userEntity;
    }
}
