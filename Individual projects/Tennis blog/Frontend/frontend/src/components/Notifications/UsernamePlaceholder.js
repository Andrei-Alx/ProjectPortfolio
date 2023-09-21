const UsernamePlaceholder = (props) => {
    return (
      <>
        <label htmlFor='username'>Username:</label>
        <input id='username' type='text' onBlur={(event) => props.onUsernameInformed(event.target.value)} />
      </>
    );
  }

  export default UsernamePlaceholder;