import React from "react"

function UnauthorizedPage(){
    return (
        <div>
            <img src="https://i.imgur.com/nF9dzBy.png" alt="The Grand Slam Chronicles logo"></img>
            <h3>Access denied! This might be because you do not have the correct role.</h3>
            <h4>You can also try to log in <a href="/login">here</a>.</h4>
        </div>
    )
}

export default UnauthorizedPage;