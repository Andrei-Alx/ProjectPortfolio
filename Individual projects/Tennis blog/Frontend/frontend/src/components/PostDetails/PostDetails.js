/* eslint-disable no-useless-escape */
import React, { useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import PostAPI from "../../apis/postsApi";
import "./PostDetails.css";

function PostDetails(props) {
    const [isEditing, setIsEditing] = useState(false);
    const [editedWinner, setEditedWinner] = useState(props.post.winnerPlayer);
    const [editedTitle, setEditedTitle] = useState(props.post.title);
    const [editedDescription, setEditedDescription] = useState(props.post.description);
    const navigate = useNavigate();
    const { id } = useParams();

    const videoId = extractVideoId(props.post.videoLink);

    const redirector = (path) =>{
        navigate(path);
    }

    const handleWinnerChange = (event) => {
        setEditedWinner(event.target.value);
    };

    const handleTitleChange = (event) => {
        setEditedTitle(event.target.value);
    };

    const handleDescriptionChange = (event) => {
        setEditedDescription(event.target.value);
    };

    const handleEditClick = () => {
        const token = sessionStorage.getItem("token");
        if (token === null) {
            alert("You are not logged in!")
        }
        else {
            const parts = token.split('.');
            const payload = parts[1];
            const decodedPayload = atob(payload);
            const parsedPayload = JSON.parse(decodedPayload);
            const sub = parsedPayload.sub;

            if (props.post.userEmail === sub) {
                setIsEditing(true);
            }
            else {
                alert("You can't edit another user's post!")
            }
        }
    };

    const handleDeleteClick = () => {
        PostAPI.deletePost(id)
            .then((response) => {
            })
            .catch((error) => {
                alert("You are not logged in!");
                redirector("/login");
            });
    };

    const handleCancelClick = () => {
        setIsEditing(false);
        setEditedWinner(props.post.winnerPlayer);
        setEditedTitle(props.post.title);
        setEditedDescription(props.post.description);
    };

    const handleSaveClick = () => {
        const updateRequest = {
            id:id,
            title: editedTitle,
            winnerPlayer: editedWinner,
            description: editedDescription
        }
        PostAPI.updatePost(id, updateRequest)
            .then((response) => {
                setIsEditing(false);
                redirector("/highlights");
            })
            .catch((error) => {
                alert(error.response.data);
            });
    };

    return (
        <div className="post-details">
            <div className="post-info">
                {isEditing ? (
                    <div className="editable-field">
                        <label htmlFor="winner-input">Winner</label>
                        <input
                            type="text"
                            id="winner-input"
                            value={editedWinner}
                            onChange={handleWinnerChange}
                        />
                        <label htmlFor="title-input">Title</label>
                        <input
                            type="text"
                            id="title-input"
                            value={editedTitle}
                            onChange={handleTitleChange}
                        />
                        <label htmlFor="description-input">Description</label>
                        <input
                            type="text"
                            id="likes-input"
                            value={editedDescription}
                            onChange={handleDescriptionChange}
                        />
                        <button onClick={handleSaveClick}>Save</button>
                        <button className="cancel-button" onClick={handleCancelClick}>Cancel</button>
                    </div>
                ) : (
                    <>
                        <h2>Title: {props.post.title}</h2>
                        <h2>Winner: {props.post.winnerPlayer}</h2>
                        <p>Description: {props.post.description}</p>
                        <p>Posted by: {props.post.userEmail}</p>
                        <button className="cancel-button" onClick={handleEditClick}>Edit</button>
                        <button className="cancel-button" onClick={handleDeleteClick}>Delete post</button>
                    </>
                )}
            </div>
            <div className="video-wrapper">
                <iframe
                    title="post video"
                    src={`https://www.youtube.com/embed/${videoId}`}
                    allowFullScreen
                ></iframe>
            </div>
        </div>
    );
}

function extractVideoId(videoLink) {
    const regex =
        /(?:youtube\.com\/(?:[^\/]+\/.+\/|(?:v|e(?:mbed)?)\/|.*[?&]v=)|youtu\.be\/)([^"&?\/\s]{20})/;
    const match = videoLink.match(regex);
    return match ? match[1] : "";
}

export default PostDetails;