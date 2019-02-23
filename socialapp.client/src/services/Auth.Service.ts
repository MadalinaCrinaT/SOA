import axios from 'axios';
import { User } from '../models/User';
import { UserMapper } from '../mapper/UserMapper';
import { AppConfig } from '../AppConfig';
export class AuthService {

    public static storeUser(user: User) {
        sessionStorage.setItem('userName', user.name);
        sessionStorage.setItem('userId', user.id.toString());
    }

    public static getUserId(): number {
        let id = sessionStorage.getItem('userId');
        if (id != null) {
            return Number(id);
        }
        return 0;
    }

    public static getUserName(): string {
        let name = sessionStorage.getItem('userName');
        if (name != null) {
            return name;
        }
        return '';
    }

    public static auth(userName: string): Promise<User> {

        return new Promise((resolve, reject) => {
            axios.post(AppConfig.getUrl() + 'auth', { userName }, {
                headers: {
                    'Content-Type': 'application/json'
                }
            }).then(
                    ({ data }) => {
                        if (typeof data === 'string' || data instanceof String) {
                            reject(data);
                        } else {
                            resolve(UserMapper.mapUser(data));
                        }
                    },
                    (error) => {
                        alert(error.response.data);
                    });
        });
    }
}
