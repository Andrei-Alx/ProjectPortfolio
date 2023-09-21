import React, { useState, useEffect } from "react";
import "./AddPostForm.css";
import PostAPI from "../../apis/postsApi";

function AddPostForm(props) {
    const [imageLink, setImageLink] = useState("");
    const [videoLink, setVideoLink] = useState("");
    const [winner, setWinner] = useState("");
    const [title, setTitle] = useState("");
    const [description, setDescription] = useState("");

    useEffect(() => {
        props.xeventx.onUsernameInformed();
    }, []);

    const addPost = (post) => {
        PostAPI.createPost(post)
            .then((response) => {
                alert("Post added!");
                props.xeventx.onMessageSend({ 'text': `A new post called ${title} has been added!` });
            })
            .catch(function (error) {
                alert("Couldn't add post!")
            });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        setTitle(title);
        setImageLink(imageLink);
        setVideoLink(videoLink);
        setDescription(description);
        setWinner(winner);
        const post = {
            title: title,
            videoLink: videoLink,
            imageLink: imageLink,
            likes: 0,
            winnerPlayer: winner,
            description: description,
        }
        addPost(post);
    };

    return (
        <form onSubmit={handleSubmit} className="input-form">
            <h1>Here you can add a post</h1>
            <div className="form-grid">
                <div className="form-grid-left">
                    <label className="form-label">
                        Title:
                        <input
                            type="text"
                            value={title}
                            onChange={(e) => setTitle(e.target.value)}
                            className="form-input"
                        />
                    </label>
                    <label className="form-label">
                        Image link:
                        <input
                            type="text"
                            value={imageLink}
                            onChange={(e) => setImageLink(e.target.value)}
                            className="form-input"
                        />
                    </label>
                    <label className="form-label">
                        Video link:
                        <input
                            type="text"
                            value={videoLink}
                            onChange={(e) => setVideoLink(e.target.value)}
                            className="form-input"
                        />
                    </label>
                </div>
                <div className="form-grid-right">
                    <label className="form-label">
                        Winner player:
                        <input
                            type="text"
                            value={winner}
                            onChange={(e) => setWinner(e.target.value)}
                            className="form-input"
                        />
                    </label>
                    <label className="form-label">
                        Description:
                        <input
                            type="text"
                            value={description}
                            onChange={(e) => setDescription(e.target.value)}
                            className="form-input"
                        />
                    </label>
                </div>
                <button type="submit" className="form-button">
                    Submit
                </button>
            </div>
        </form>
    );
}

export default AddPostForm;
