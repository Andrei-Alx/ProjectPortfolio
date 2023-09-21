package org.example.business;

import org.example.controller.domain.post.*;
import org.example.domain.Post;

public interface IPostManager {
    CreatePostResponse createPost(CreatePostRequest request);
    ReadAllPostsResponse getPosts();
    ReadAllPostsResponse getVisiblePosts();
    void updatePost(UpdatePostRequest request);
    void updateVisibility(UpdatePostVisibilityRequest request);
    void deletePost(long postId);
    Post getPostById(long postId);
    ReadPostCountResponse getPostCount();
    ReadPostCountResponse getPostCountPerUser(String email);
    SearchPostsByWinnerResponse getPostsByWinner(String winner);
    SearchPostsByAuthorResponse getPostsByAuthor(String author);
    ReadAllPostsResponse getAllPostsByUser();
}
