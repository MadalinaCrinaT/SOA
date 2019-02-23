import axios from 'axios';
import { User } from '../models/User';
import { UserMapper } from '../mapper/UserMapper';
import { AppConfig } from '../AppConfig';
export class UserService {

    public static getUserDetails(userId: number): Promise<User> {

        return new Promise((resolve, reject) => {
            axios.get(AppConfig.getUrl() + 'users/' + userId).then(
                ({ data }) => {
                    resolve(UserMapper.mapUser(data));
                },
                (error) => {
                    reject(error.response.data);
                });
        });
    }
}
