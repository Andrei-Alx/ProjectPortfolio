const MessageReceived = (props) => {
    return (
        <div>
            <b>Tennis Titans</b>: {props.text}
        </div>
    );
};

const NotificationsList = (props) => {
    return (
        <>
            <h2>Notifications:</h2>
            {/* {props.onUsernameInformed()} */}
            {props.messagesReceived
                .map(message => <MessageReceived from={message.from} text={message.text} />)}
        </>
    );
}

export default NotificationsList;