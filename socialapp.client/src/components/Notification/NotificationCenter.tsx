import * as React from 'react';
import * as NotificationSystem from 'react-notification-system';
interface Props {
}
export class NotificationCenter extends React.Component<Props> {
    static notificationSystem: any;

    static addNotificationSuccess(msg: string) {
        this.notificationSystem.addNotification({
            message: msg,
            level: 'success'
        });
    }

    static addNotificationError(msg: string) {
        // alert(msg);
    }

    static addNotificationWarning(msg: string) {
        this.notificationSystem.addNotification({
            message: msg,
            level: 'warning'
        });
    }

    static addNotificationInfo(msg: string) {
        this.notificationSystem.addNotification({
            message: msg,
            level: 'info'
        });
    }

    constructor(props: Props) {
        super(props);
        this.state = {
        };
    }

    render() {
        return (
            <div>
                <NotificationSystem ref={(ref: any) => { NotificationCenter.notificationSystem = ref; }} />
            </div>
        );
    }
}
