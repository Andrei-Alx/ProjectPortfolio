package org.example.controller;

import org.example.business.impl.PostManager;
import org.example.controller.domain.post.CreatePostRequest;
import org.example.controller.domain.post.CreatePostResponse;
import org.example.controller.domain.post.ReadAllPostsResponse;
import org.example.controller.domain.post.UpdatePostRequest;
import org.example.domain.Post;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.MockitoAnnotations;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;

import java.util.List;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.ArgumentMatchers.any;
import static org.mockito.Mockito.*;

public class PostControllerTest {

    @Mock
    private PostManager postManager;

    @InjectMocks
    private PostController postController;

    @BeforeEach
    public void setUp() {
        MockitoAnnotations.openMocks(this);
    }

    @Test
    public void testCreatePost() {
        CreatePostRequest request = new CreatePostRequest();
        CreatePostResponse expectedResponse = new CreatePostResponse();
        when(postManager.createPost(any(CreatePostRequest.class))).thenReturn(expectedResponse);
        ResponseEntity<CreatePostResponse> actualResponse = postController.createPost(request);
        assertEquals(HttpStatus.CREATED, actualResponse.getStatusCode());
        assertEquals(expectedResponse, actualResponse.getBody());
    }

    @Test
    public void testGetPosts() {
        String expectedVideoLink = "https://www.youtube.com/watch?v=ChYELwk19v8&ab_channel=TennisTV";
        String expectedImageLink = "https://i.imgur.com/ei5HSML.png";
        Post expectedPost = Post.builder().id(1L).title("firstTitle").videoLink(expectedVideoLink).imageLink(expectedImageLink).likes(1)
                .winnerPlayer("Some player").description("Random description").userEmail("test@mail.com").build();
        Post expectedPost2 = Post.builder().id(1L).title("firstTitle").videoLink(expectedVideoLink).imageLink(expectedImageLink).likes(1)
                .winnerPlayer("Some player").description("Random description").userEmail("test@mail.com").build();
        ReadAllPostsResponse expectedResponse = new ReadAllPostsResponse(List.of(expectedPost,expectedPost2));
        when(postManager.getPosts()).thenReturn(expectedResponse);
        ResponseEntity<ReadAllPostsResponse> actualResponse = postController.getPosts();
        assertEquals(HttpStatus.OK, actualResponse.getStatusCode());
        assertEquals(expectedResponse, actualResponse.getBody());
    }

    @Test
    public void testGetPost() {
        long postId = 123L;
        Post expectedPost = new Post();
        when(postManager.getPostById(postId)).thenReturn(expectedPost);
        ResponseEntity<Post> actualResponse = postController.getPost(postId);
        assertEquals(HttpStatus.OK, actualResponse.getStatusCode());
        assertEquals(expectedPost, actualResponse.getBody());
    }

    @Test
    public void testGetNonExistingPost() {
        long postId = 123L;
        when(postManager.getPostById(postId)).thenReturn(null);
        ResponseEntity<Post> actualResponse = postController.getPost(postId);
        assertEquals(HttpStatus.NOT_FOUND, actualResponse.getStatusCode());
    }

    @Test
    public void testUpdatePost() {
        long postId = 123L;
        UpdatePostRequest request = new UpdatePostRequest();
        request.setId(postId);
        doNothing().when(postManager).updatePost(request);
        ResponseEntity<Void> actualResponse = postController.updatePost(postId, request);
        assertEquals(HttpStatus.OK, actualResponse.getStatusCode());
        verify(postManager).updatePost(request);
    }

    @Test
    public void testDeletePost() {
        int postId = 123;
        doNothing().when(postManager).deletePost(postId);
        ResponseEntity<Void> actualResponse = postController.deletePost(postId);
        assertEquals(HttpStatus.NO_CONTENT, actualResponse.getStatusCode());
        verify(postManager).deletePost(postId);
    }
}
