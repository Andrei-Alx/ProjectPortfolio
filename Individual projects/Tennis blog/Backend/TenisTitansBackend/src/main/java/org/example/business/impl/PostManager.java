package org.example.business.impl;

import lombok.AllArgsConstructor;
import org.example.business.IPostManager;
import org.example.business.IVideoLinkValidator;
import org.example.business.exception.InvalidLinkException;
import org.example.business.exception.InvalidPostParametersException;
import org.example.business.exception.UnauthorizedAccessException;
import org.example.controller.domain.AccessToken;
import org.example.controller.domain.post.*;
import org.example.controller.domain.user.ReadUserCountResponse;
import org.example.domain.Post;
import org.example.persistance.PostRepository;
import org.example.persistance.entity.PostEntity;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Objects;
import java.util.Optional;

@Service
@AllArgsConstructor
public class PostManager implements IPostManager {

    private final PostRepository realPostRepository;
    private final IVideoLinkValidator videoLinkValidator;
    private AccessToken accessToken;

    @Override
    public CreatePostResponse createPost(CreatePostRequest request) {

        if (!videoLinkValidator.isValidLink(request.getVideoLink())) {
            throw new InvalidLinkException();
        }

        PostEntity newPost = PostEntity.builder()
                .title(request.getTitle())
                .videoLink(request.getVideoLink())
                .imageLink(request.getImageLink())
                .likes(request.getLikes())
                .winnerPlayer(request.getWinnerPlayer())
                .description(request.getDescription())
                .userEmail(accessToken.getSubject())
                .isPostVisible("Visible")
                .build();

        PostEntity savedPost = saveNewPost(newPost);

        return CreatePostResponse.builder()
                .postId(savedPost.getId())
                .build();
    }
    private PostEntity saveNewPost(PostEntity post) {

        return realPostRepository.save(post);
    }

    @Override
    public ReadAllPostsResponse getPosts() {
        List<Post> posts = realPostRepository.findAll()
                .stream()
                .map(PostConvertor::convert)
                .toList();

        return ReadAllPostsResponse.builder()
                .posts(posts)
                .build();
    }

    @Override
    public ReadAllPostsResponse getVisiblePosts() {
        List<Post> posts = realPostRepository.getPostEntitiesByIsPostVisibleIsLike("Visible")
                .stream()
                .map(PostConvertor::convert)
                .toList();

        return ReadAllPostsResponse.builder()
                .posts(posts)
                .build();
    }

    @Override
    public void updatePost(UpdatePostRequest request) {
        Optional<PostEntity> postOptional = Optional.ofNullable(realPostRepository.findById(request.getId()));
        if (postOptional.isEmpty()) {
            throw new InvalidPostParametersException("Invalid parameters");
        }

        PostEntity post = postOptional.get();
        if(!accessToken.getSubject().equals(post.getUserEmail())){
            throw new UnauthorizedAccessException("You are trying to update another user's post!");
        }
        else{
            post.setTitle(request.getTitle());
            post.setWinnerPlayer(request.getWinnerPlayer());
            post.setDescription(request.getDescription());
            realPostRepository.save(post);
        }
    }

    @Override
    public void updateVisibility(UpdatePostVisibilityRequest request) {
        Optional<PostEntity> postOptional = Optional.ofNullable(realPostRepository.findById(request.getId()));
        if (postOptional.isEmpty()) {
            throw new InvalidPostParametersException("Invalid parameters");
        }
        PostEntity post = postOptional.get();
        post.setIsPostVisible(request.getNewVisibility());
        realPostRepository.save(post);
    }

    @Override
    public void deletePost(long postId) {
        Post postToDelete = getPostById(postId);
        String postAuthor = postToDelete.getUserEmail();
        if(!accessToken.getSubject().equals(postAuthor)) {
            throw new UnauthorizedAccessException("You are trying to delete another user's post!");
        }
        else{
            this.realPostRepository.deleteById(postId);
        }
    }

    @Override
    public Post getPostById(long postId) {
        Post post = PostConvertor.convert(realPostRepository.findById(postId));
        if(Objects.equals(post.getIsPostVisible(), "Visible")){
            return post;
        }
        else{
            return null;
        }
    }

    @Override
    public ReadPostCountResponse getPostCount() {
        return ReadPostCountResponse.builder()
                .postCount(realPostRepository.getAllPostsCount())
                .build();
    }

    @Override
    public ReadPostCountResponse getPostCountPerUser(String email) {
        return ReadPostCountResponse.builder()
                .postCount(realPostRepository.getPostsCountPerUser(email))
                .build();
    }

    @Override
    public SearchPostsByWinnerResponse getPostsByWinner(String winner) {
        List<Post> resultedPosts = realPostRepository.searchPostEntitiesByWinnerPlayerContainingAndIsPostVisible(winner, "Visible")
                .stream()
                .map(PostConvertor::convert)
                .toList();
        return SearchPostsByWinnerResponse.builder().posts(resultedPosts).build();
    }

    @Override
    public SearchPostsByAuthorResponse getPostsByAuthor(String author) {
        List<Post> resultedPosts = realPostRepository.searchPostEntitiesByUserEmailContainingAndIsPostVisible(author, "Visible")
                .stream()
                .map(PostConvertor::convert)
                .toList();
        return SearchPostsByAuthorResponse.builder().posts(resultedPosts).build();
    }

    @Override
    public ReadAllPostsResponse getAllPostsByUser() {
        List<Post> resultedPosts = realPostRepository.getVisiblePostsByUserEmail("Visible", accessToken.getSubject())
                .stream()
                .map(PostConvertor::convert)
                .toList();
        return ReadAllPostsResponse.builder().posts(resultedPosts).build();
    }
}
