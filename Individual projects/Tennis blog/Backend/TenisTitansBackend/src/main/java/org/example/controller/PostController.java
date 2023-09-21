package org.example.controller;

import lombok.AllArgsConstructor;
import org.example.business.impl.PostManager;
import org.example.configuration.security.isauthenticated.IsAuthenticated;
import org.example.controller.domain.post.*;
import org.example.domain.Post;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.annotation.security.RolesAllowed;
import javax.validation.Valid;

@RestController
@RequestMapping("/posts")
@AllArgsConstructor
@CrossOrigin(origins = "http://localhost:3000/", allowedHeaders = "*", methods = {RequestMethod.GET, RequestMethod.POST, RequestMethod.PUT, RequestMethod.DELETE, RequestMethod.PATCH})
public class PostController {
    private final PostManager postManager;

    @IsAuthenticated
    @RolesAllowed({"ROLE_Player"})
    @PostMapping
    public ResponseEntity<CreatePostResponse> createPost(@RequestBody @Valid CreatePostRequest request){
        CreatePostResponse response = postManager.createPost(request);
        return ResponseEntity.status(HttpStatus.CREATED).body(response);
    }

    @IsAuthenticated
    @RolesAllowed({"ROLE_Admin"})
    @GetMapping("/adminposts")
    public ResponseEntity<ReadAllPostsResponse> getPosts() {
        return ResponseEntity.ok(postManager.getPosts());
    }

    @GetMapping
    public ResponseEntity<ReadAllPostsResponse> getVisiblePosts() {
        return ResponseEntity.ok(postManager.getVisiblePosts());
    }

    @GetMapping("/{id}")
    public ResponseEntity<Post> getPost(@PathVariable(value = "id") final long id) {
        final Post post = postManager.getPostById(id);
        if (post != null) {
            return ResponseEntity.ok().body(post);
        } else {
            return ResponseEntity.notFound().build();
        }
    }

    @IsAuthenticated
    @RolesAllowed({"ROLE_Admin"})
    @GetMapping("/count")
    public ResponseEntity<ReadPostCountResponse> getPostCount() {
        ReadPostCountResponse response = postManager.getPostCount();
        return ResponseEntity.ok(response);
    }

    @IsAuthenticated
    @RolesAllowed({"ROLE_Player"})
    @PutMapping("{id}")
    public ResponseEntity<Void> updatePost(@PathVariable("id") long id,
                                           @RequestBody @Valid UpdatePostRequest request) {
        request.setId(id);
        postManager.updatePost(request);
        return ResponseEntity.ok().build();
    }

    @IsAuthenticated
    @RolesAllowed({"ROLE_Admin"})
    @PatchMapping
    public ResponseEntity<Void> updatePostVisibility(@RequestBody @Valid UpdatePostVisibilityRequest request) {
        postManager.updateVisibility(request);
        return ResponseEntity.ok().build();
    }

    @IsAuthenticated
    @RolesAllowed({"ROLE_Player"})
    @DeleteMapping("{postId}")
    public ResponseEntity<Void> deletePost(@PathVariable int postId) {
        postManager.deletePost(postId);
        return ResponseEntity.noContent().build();
    }

    @IsAuthenticated
    @RolesAllowed({"ROLE_Player"})
    @GetMapping("/search/{winner}")
    public ResponseEntity<SearchPostsByWinnerResponse> getPostsByWinner(@PathVariable String winner) {
        SearchPostsByWinnerResponse response = postManager.getPostsByWinner(winner);
        return ResponseEntity.ok(response);
    }

    @IsAuthenticated
    @RolesAllowed({"ROLE_Player"})
    @GetMapping("/searchAuthor/{author}")
    public ResponseEntity<SearchPostsByAuthorResponse> getPostsByAuthor(@PathVariable String author) {
        SearchPostsByAuthorResponse response = postManager.getPostsByAuthor(author);
        return ResponseEntity.ok(response);
    }
    @IsAuthenticated
    @RolesAllowed({"ROLE_Player"})
    @GetMapping("/myposts")
    public ResponseEntity<ReadAllPostsResponse> getUserPosts() {
        ReadAllPostsResponse response = postManager.getAllPostsByUser();
        return ResponseEntity.ok(response);
    }
    @IsAuthenticated
    @RolesAllowed({"ROLE_Admin"})
    @GetMapping("/userPostCount/{email}")
    public ResponseEntity<ReadPostCountResponse> getUserPosts(@PathVariable String email) {
        ReadPostCountResponse response = postManager.getPostCountPerUser(email);
        return ResponseEntity.ok(response);
    }
}
