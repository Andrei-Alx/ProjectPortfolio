import React, { useState, useEffect } from "react"
import "./Search.css";
import PostAPI from "../../apis/postsApi";
import CardList from "../CardList/CardList";

function Search() {
    const [searchTerm, setSearchTerm] = useState("");
    const [searchCriteria, setSearchCriteria] = useState("Winner");
    const [searchedPosts, setSearchedPosts] = useState(null);

    const handleSearchTermChange = (event) => {
        setSearchTerm(event.target.value);
    };

    const handleSearchCriteriaChange = (event) => {
        setSearchCriteria(event.target.value);
    };

    const getPosts = () => {
        PostAPI.getVisiblePosts()
            .then((response) => setSearchedPosts(response.data.posts))
            .catch()
    };

    useEffect(() => {
        getPosts();
    }, []);

    const handleSearchSubmit = (event) => {
        event.preventDefault();
        if(searchCriteria === "Winner"){
            PostAPI.getPostsByWinner(searchTerm)
                .then((response) => setSearchedPosts(response.data.posts))
                .catch()
        }
        else if(searchCriteria === "Author"){
            PostAPI.getPostsByAuthor(searchTerm)
                .then((response) => setSearchedPosts(response.data.posts))
                .catch()
        }
        else{
            alert("No search criteria found!");
        }
        
    };

    if(searchTerm != "")
    {
        return (
            <div>
                <form onSubmit={handleSearchSubmit} className="search-container">
                    <label className="search-label">
                        Search:
                        <input
                            type="text"
                            value={searchTerm}
                            onChange={handleSearchTermChange}
                            className="search-input"
                        />
                    </label>
                    <label className="search-label">
                        Search criteria:
                        <select
                            value={searchCriteria}
                            onChange={handleSearchCriteriaChange}
                            className="search-select"
                        >
                            <option value="Winner">Winner</option>
                            <option value="Author">Author</option>
                        </select>
                    </label>
                    <button type="submit" className="search-button">Search</button>
                </form>
                <CardList posts={searchedPosts}/>
            </div>
        );
    }
    else{
        return (
            <div>
                <form onSubmit={handleSearchSubmit} className="search-container">
                    <label className="search-label">
                        Search:
                        <input
                            type="text"
                            value={searchTerm}
                            onChange={handleSearchTermChange}
                            className="search-input"
                        />
                    </label>
                    <label className="search-label">
                        Search criteria:
                        <select
                            value={searchCriteria}
                            onChange={handleSearchCriteriaChange}
                            className="search-select"
                        >
                            <option value="Winner">Winner</option>
                            <option value="Author">Author</option>
                        </select>
                    </label>
                    <button type="submit" className="search-button">Search</button>
                </form>
                <CardList posts={searchedPosts}/>
            </div>
        );
    }
}

export default Search;
