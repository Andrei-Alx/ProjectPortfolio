import React, { useState, useEffect } from 'react';
import './UserList.css';
import PostAPI from '../../apis/postsApi';
import UserAPI from '../../apis/usersApi';

function UserList(props) {
    const [status, setStatus] = useState('');
    const [postCounts, setPostCounts] = useState({});

    useEffect(() => {
        if (props.users) {
            fetchPostCounts();
        }
    }, [props.users]);

    const fetchPostCounts = () => {
        const updatedPostCounts = {};

        props.users.forEach((user) => {
            PostAPI.getPostCountPerUser(user.email)
                .then((response) => {
                    const postCount = response.data.postCount;
                    updatedPostCounts[user.email] = postCount;
                    setPostCounts(updatedPostCounts);
                })
                .catch();
        });
    };

    const handleStatusChange = (event, userId) => {
        const newStatus = event.target.value;

        if (status !== newStatus) {
            const confirmed = window.confirm(`Are you sure you want to mark this account as ${newStatus}?`);
            if (confirmed) {
                const request = {
                    id:userId,
                    newStatus:newStatus
                }
                UserAPI.updateAccountStatus(request)
                    .then((response)=>{
                    })
                    .catch()
            }
            else{
            }
        }
    };

    return (
        <table className="user-table">
            <thead>
                <tr>
                    <th>Username</th>
                    <th>Number of Posts</th>
                    <th>Status</th>
                </tr>
            </thead>
            <tbody>
                {props.users &&
                    props.users.map((user) => (
                        <tr key={user.id}>
                            <td>{user.email}</td>
                            <td>{postCounts[user.email]}</td>
                            <td>
                                <select id="status" value={user.isActive} onChange={(e) => handleStatusChange(e, user.id)}>
                                    <option value="Active">Active</option>
                                    <option value="Inactive">Inactive</option>
                                </select>
                            </td>
                        </tr>
                    ))}
            </tbody>
        </table>
    );
}

export default UserList;
