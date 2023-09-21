import React, { useEffect } from 'react';
import { Card } from "react-bootstrap";
import CardHeader from 'react-bootstrap/esm/CardHeader';

function NotificationsPage(props) {
    useEffect(() => {
        props.onUsernameInformed();
    }, []);

    const MessageReceived = (props) => {
        return (
            <p><b>From {props.from}</b>: {props.text}</p>
        );
    };

    return (
        <div>
            <Card>
                <CardHeader className="notifications-header" title="Messages:" />
                {props.messagesReceived
                    .map(message => <MessageReceived key={message.id} from={message.from} direct={message.to === props.username} text={message.text} />)}
            </Card>
        </div>
    );
}

export default NotificationsPage;