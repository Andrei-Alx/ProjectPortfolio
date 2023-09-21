package org.example.business.impl;

import org.example.business.exception.InvalidLinkException;
import org.example.business.exception.InvalidPostParametersException;
import org.example.controller.domain.AccessToken;
import org.example.controller.domain.post.*;
import org.example.domain.Post;
import org.example.persistance.PostRepository;
import org.example.persistance.entity.PostEntity;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;

import java.util.List;
import java.util.stream.Stream;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;
import static org.mockito.Mockito.*;

@ExtendWith(MockitoExtension.class)
class PostManagerTest {

    @Mock
    private PostRepository postRepositoryMock;
    @Mock
    private VideoLinkValidator mockVideoLinkValidator;
    @Mock
    private AccessToken accessToken;
    @InjectMocks
    private PostManager postManager;

    @Test
    void createPostValidLink() {
        // Arrange
        String validLink = "https://www.youtube.com/watch?v=ChYELwk19v8&ab_channel=TennisTV";
        CreatePostRequest request = new CreatePostRequest("title", validLink, "image", 0, "winner", "description", "test@mail.com");

        when(mockVideoLinkValidator.isValidLink(validLink)).thenReturn(true);
        when(accessToken.getSubject()).thenReturn("test@mail.com");

        PostEntity savedPost = new PostEntity(1L, "title", validLink, "image", 0, "winner", "description", "test@mail.com", "Visible");
        when(postRepositoryMock.save(any(PostEntity.class))).thenReturn(savedPost);

        // Act
        CreatePostResponse response = postManager.createPost(request);

        // Assert
        assertEquals(1L, (long) response.getPostId());
        verify(postRepositoryMock, times(1)).save(any(PostEntity.class));
    }

    @Test
    public void testCreatePostInvalidLink() {
        // Arrange
        String invalidLink = "invalid-link";
        CreatePostRequest request = new CreatePostRequest("title", invalidLink, "image", 0, "winner", "description", "test@mail.com");

        // Act
        when(mockVideoLinkValidator.isValidLink(invalidLink)).thenReturn(false);

        // Assert
        assertThrows(InvalidLinkException.class, () -> postManager.createPost(request));
        verify(mockVideoLinkValidator, times(1)).isValidLink(invalidLink);
    }

    @Test
    void getPosts() {
        // Arrange
        String videoLink = "https://www.youtube.com/watch?v=ChYELwk19v8&ab_channel=TennisTV";
        String imageLink = "https://i.imgur.com/ei5HSML.png";
        PostEntity postEntity = PostEntity.builder().id(1L).title("firstTitle").videoLink(videoLink).imageLink(imageLink).likes(1)
                .winnerPlayer("Some player").description("Random description").userEmail("test@mail.com").build();
        String videoLink2 = "https://www.youtube.com/watch?v=ChYELwk19v8&ab_channel=TennisTV";
        String imageLink2 = "https://i.imgur.com/ei5HSML.png";
        PostEntity postEntity2 = PostEntity.builder().id(1L).title("firstTitle").videoLink(videoLink2).imageLink(imageLink2).likes(1)
                .winnerPlayer("Some player").description("Random description").userEmail("test@mail.com").build();

        //Act
        when(postRepositoryMock.findAll())
                .thenReturn(List.of(postEntity, postEntity2));

        ReadAllPostsResponse actualResult = postManager.getPosts();
        String expectedVideoLink = "https://www.youtube.com/watch?v=ChYELwk19v8&ab_channel=TennisTV";
        String expectedImageLink = "https://i.imgur.com/ei5HSML.png";
        Post expectedPost = Post.builder().id(1L).title("firstTitle").videoLink(expectedVideoLink).imageLink(expectedImageLink).likes(1)
                .winnerPlayer("Some player").description("Random description").userEmail("test@mail.com").build();
        String expectedVideoLink2 = "https://www.youtube.com/watch?v=ChYELwk19v8&ab_channel=TennisTV";
        String expectedImageLink2 = "https://i.imgur.com/ei5HSML.png";
        Post expectedPost2 = Post.builder().id(1L).title("firstTitle").videoLink(expectedVideoLink2).imageLink(expectedImageLink2).likes(1)
                .winnerPlayer("Some player").description("Random description").userEmail("test@mail.com").build();
        ReadAllPostsResponse expectedResult = ReadAllPostsResponse.builder().posts(List.of(expectedPost, expectedPost2)).build();

        //Assert
        assertEquals(expectedResult, actualResult);
        verify(postRepositoryMock, times(1)).findAll();
    }

    @Test
    void testUpdatePostValid() {
        //Arrange
        UpdatePostRequest request = new UpdatePostRequest();
        request.setId(1L);
        request.setTitle("New title");
        request.setWinnerPlayer("New winner player");
        request.setDescription("New description");

        PostEntity postEntity = new PostEntity();
        postEntity.setId(1L);
        postEntity.setTitle("Old title");
        postEntity.setWinnerPlayer("Old winner player");
        postEntity.setDescription("Old description");
        postEntity.setUserEmail("test@mail.com");

        when(accessToken.getSubject()).thenReturn("test@mail.com");

//Act
        when(postRepositoryMock.findById(1L)).thenReturn(postEntity);

        postManager.updatePost(request);

//Assert
        assertEquals(request.getTitle(), postEntity.getTitle());
        assertEquals(request.getWinnerPlayer(), postEntity.getWinnerPlayer());
        assertEquals(request.getDescription(), postEntity.getDescription());

        verify(postRepositoryMock, times(1)).findById(1L);
        verify(postRepositoryMock, times(1)).save(postEntity);
    }

    @Test
    void testUpdatePostInvalid() {
        UpdatePostRequest request = new UpdatePostRequest();
        request.setId(1L);
        request.setTitle("New title");
        request.setWinnerPlayer("New winner player");
        request.setDescription("New description");

        when(postRepositoryMock.findById(1L)).thenReturn(null);

        assertThrows(InvalidPostParametersException.class, () -> postManager.updatePost(request));

        verify(postRepositoryMock, times(1)).findById(1L);
        verify(postRepositoryMock, never()).save(any(PostEntity.class));
    }

    @Test
    void deletePost() {
        //Arrange
        PostEntity post = new PostEntity();
        post.setId(1L);
        post.setTitle("Old title");
        post.setWinnerPlayer("Old winner player");
        post.setDescription("Old description");
        post.setUserEmail("test@mail.com");
        post.setIsPostVisible("Visible");
        long postId = 1L;
        when(accessToken.getSubject()).thenReturn("test@mail.com");
        when(postRepositoryMock.findById(postId)).thenReturn(post);
        //Act
        postManager.deletePost(postId);

        //Assert
        verify(postRepositoryMock, times(1)).deleteById(postId);
    }

    @Test
    void testGetPostById() {
        PostEntity postEntity = new PostEntity();
        postEntity.setId(1L);
        postEntity.setTitle("Title");
        postEntity.setWinnerPlayer("Winner player");
        postEntity.setDescription("Description");
        postEntity.setUserEmail("test@mail.com");
        postEntity.setIsPostVisible("Visible");

        when(postRepositoryMock.findById(1L)).thenReturn(postEntity);

        Post post = postManager.getPostById(1L);

        assertEquals(postEntity.getId(), post.getId());
        assertEquals(postEntity.getTitle(), post.getTitle());
        assertEquals(postEntity.getWinnerPlayer(), post.getWinnerPlayer());
        assertEquals(postEntity.getDescription(), post.getDescription());
        assertEquals(postEntity.getUserEmail(), post.getUserEmail());
        assertEquals(postEntity.getIsPostVisible(), post.getIsPostVisible());

        verify(postRepositoryMock, times(1)).findById(1L);
    }

    @Test
    void testGetPostByIdNotFound() {
        when(postRepositoryMock.findById(1L)).thenReturn(null);

        assertThrows(NullPointerException.class, () -> postManager.getPostById(1L));

        verify(postRepositoryMock, times(1)).findById(1L);
    }

    @Test
    void testGetPostByWinner() {
        PostEntity postEntity = new PostEntity();
        postEntity.setId(1L);
        postEntity.setTitle("Title");
        postEntity.setWinnerPlayer("Winner player");
        postEntity.setDescription("Description");
        postEntity.setUserEmail("test@mail.com");

        when(postRepositoryMock.searchPostEntitiesByWinnerPlayerContainingAndIsPostVisible("Winner", "Visible"))
                .thenReturn(List.of(postEntity));

        SearchPostsByWinnerResponse posts = postManager.getPostsByWinner("Winner");

        Post searchedPost = posts.getPosts().get(0);

        assertEquals(postEntity.getId(), searchedPost.getId());
        assertEquals(postEntity.getTitle(), searchedPost.getTitle());
        assertEquals(postEntity.getWinnerPlayer(), searchedPost.getWinnerPlayer());
        assertEquals(postEntity.getDescription(), searchedPost.getDescription());
        assertEquals(postEntity.getUserEmail(), searchedPost.getUserEmail());

        verify(postRepositoryMock, times(1)).searchPostEntitiesByWinnerPlayerContainingAndIsPostVisible("Winner", "Visible");
    }

    @Test
    void testGetPostByAuthor() {
        PostEntity postEntity = new PostEntity();
        postEntity.setId(1L);
        postEntity.setTitle("Title");
        postEntity.setWinnerPlayer("Winner player");
        postEntity.setDescription("Description");
        postEntity.setUserEmail("test@mail.com");

        when(postRepositoryMock.searchPostEntitiesByUserEmailContainingAndIsPostVisible("test", "Visible"))
                .thenReturn(List.of(postEntity));

        SearchPostsByAuthorResponse posts = postManager.getPostsByAuthor("test");

        Post searchedPost = posts.getPosts().get(0);

        assertEquals(postEntity.getId(), searchedPost.getId());
        assertEquals(postEntity.getTitle(), searchedPost.getTitle());
        assertEquals(postEntity.getWinnerPlayer(), searchedPost.getWinnerPlayer());
        assertEquals(postEntity.getDescription(), searchedPost.getDescription());
        assertEquals(postEntity.getUserEmail(), searchedPost.getUserEmail());

        verify(postRepositoryMock, times(1)).searchPostEntitiesByUserEmailContainingAndIsPostVisible("test", "Visible");
    }

    @Test
    void getVisiblePosts() {
        // Arrange
        String videoLink = "https://www.youtube.com/watch?v=ChYELwk19v8&ab_channel=TennisTV";
        String imageLink = "https://i.imgur.com/ei5HSML.png";
        PostEntity postEntity = PostEntity.builder().id(1L).title("firstTitle").videoLink(videoLink).imageLink(imageLink).likes(1)
                .winnerPlayer("Some player").description("Random description").userEmail("test@mail.com").isPostVisible("Visible").build();
        String videoLink2 = "https://www.youtube.com/watch?v=ChYELwk19v8&ab_channel=TennisTV";
        String imageLink2 = "https://i.imgur.com/ei5HSML.png";
        PostEntity postEntity2 = PostEntity.builder().id(1L).title("firstTitle").videoLink(videoLink2).imageLink(imageLink2).likes(1)
                .winnerPlayer("Some player").description("Random description").userEmail("test@mail.com").isPostVisible("Visible").build();

        //Act
        when(postRepositoryMock.getPostEntitiesByIsPostVisibleIsLike("Visible"))
                .thenReturn( List.of(postEntity, postEntity2));

        ReadAllPostsResponse actualResult = postManager.getVisiblePosts();
        String expectedVideoLink = "https://www.youtube.com/watch?v=ChYELwk19v8&ab_channel=TennisTV";
        String expectedImageLink = "https://i.imgur.com/ei5HSML.png";
        Post expectedPost = Post.builder().id(1L).title("firstTitle").videoLink(expectedVideoLink).imageLink(expectedImageLink).likes(1)
                .winnerPlayer("Some player").description("Random description").userEmail("test@mail.com").isPostVisible("Visible").build();
        String expectedVideoLink2 = "https://www.youtube.com/watch?v=ChYELwk19v8&ab_channel=TennisTV";
        String expectedImageLink2 = "https://i.imgur.com/ei5HSML.png";
        Post expectedPost2 = Post.builder().id(1L).title("firstTitle").videoLink(expectedVideoLink2).imageLink(expectedImageLink2).likes(1)
                .winnerPlayer("Some player").description("Random description").userEmail("test@mail.com").isPostVisible("Visible").build();
        ReadAllPostsResponse expectedResult = ReadAllPostsResponse.builder().posts(List.of(expectedPost, expectedPost2)).build();

        //Assert
        assertEquals(expectedResult, actualResult);
        verify(postRepositoryMock, times(1)).getPostEntitiesByIsPostVisibleIsLike("Visible");
    }

    @Test
    void getPostCount() {
        // Arrange
        String videoLink = "https://www.youtube.com/watch?v=ChYELwk19v8&ab_channel=TennisTV";
        String imageLink = "https://i.imgur.com/ei5HSML.png";
        PostEntity postEntity = PostEntity.builder().id(1L).title("firstTitle").videoLink(videoLink).imageLink(imageLink).likes(1)
                .winnerPlayer("Some player").description("Random description").userEmail("test@mail.com").isPostVisible("Visible").build();
        String videoLink2 = "https://www.youtube.com/watch?v=ChYELwk19v8&ab_channel=TennisTV";
        String imageLink2 = "https://i.imgur.com/ei5HSML.png";
        PostEntity postEntity2 = PostEntity.builder().id(1L).title("firstTitle").videoLink(videoLink2).imageLink(imageLink2).likes(1)
                .winnerPlayer("Some player").description("Random description").userEmail("test@mail.com").isPostVisible("Visible").build();

        //Act
        when(postRepositoryMock.getAllPostsCount())
                .thenReturn(2);

        ReadPostCountResponse actualResult = postManager.getPostCount();
        String expectedVideoLink = "https://www.youtube.com/watch?v=ChYELwk19v8&ab_channel=TennisTV";
        String expectedImageLink = "https://i.imgur.com/ei5HSML.png";
        Post expectedPost = Post.builder().id(1L).title("firstTitle").videoLink(expectedVideoLink).imageLink(expectedImageLink).likes(1)
                .winnerPlayer("Some player").description("Random description").userEmail("test@mail.com").isPostVisible("Visible").build();
        String expectedVideoLink2 = "https://www.youtube.com/watch?v=ChYELwk19v8&ab_channel=TennisTV";
        String expectedImageLink2 = "https://i.imgur.com/ei5HSML.png";
        Post expectedPost2 = Post.builder().id(1L).title("firstTitle").videoLink(expectedVideoLink2).imageLink(expectedImageLink2).likes(1)
                .winnerPlayer("Some player").description("Random description").userEmail("test@mail.com").isPostVisible("Visible").build();
        ReadPostCountResponse expectedResult = ReadPostCountResponse.builder().postCount((int) Stream.of(expectedPost, expectedPost2).count()).build();

        //Assert
        assertEquals(expectedResult, actualResult);
        verify(postRepositoryMock, times(1)).getAllPostsCount();
    }

    @Test
    void getPostCountPerUser() {
        // Arrange
        String videoLink = "https://www.youtube.com/watch?v=ChYELwk19v8&ab_channel=TennisTV";
        String imageLink = "https://i.imgur.com/ei5HSML.png";
        PostEntity postEntity = PostEntity.builder().id(1L).title("firstTitle").videoLink(videoLink).imageLink(imageLink).likes(1)
                .winnerPlayer("Some player").description("Random description").userEmail("test@mail.com").isPostVisible("Visible").build();
        String videoLink2 = "https://www.youtube.com/watch?v=ChYELwk19v8&ab_channel=TennisTV";
        String imageLink2 = "https://i.imgur.com/ei5HSML.png";
        PostEntity postEntity2 = PostEntity.builder().id(1L).title("firstTitle").videoLink(videoLink2).imageLink(imageLink2).likes(1)
                .winnerPlayer("Some player").description("Random description").userEmail("test@mail.com").isPostVisible("Visible").build();

        //Act
        when(postRepositoryMock.getPostsCountPerUser("test@mail.com"))
                .thenReturn(2);

        ReadPostCountResponse actualResult = postManager.getPostCountPerUser("test@mail.com");
        String expectedVideoLink = "https://www.youtube.com/watch?v=ChYELwk19v8&ab_channel=TennisTV";
        String expectedImageLink = "https://i.imgur.com/ei5HSML.png";
        Post expectedPost = Post.builder().id(1L).title("firstTitle").videoLink(expectedVideoLink).imageLink(expectedImageLink).likes(1)
                .winnerPlayer("Some player").description("Random description").userEmail("test@mail.com").isPostVisible("Visible").build();
        String expectedVideoLink2 = "https://www.youtube.com/watch?v=ChYELwk19v8&ab_channel=TennisTV";
        String expectedImageLink2 = "https://i.imgur.com/ei5HSML.png";
        Post expectedPost2 = Post.builder().id(1L).title("firstTitle").videoLink(expectedVideoLink2).imageLink(expectedImageLink2).likes(1)
                .winnerPlayer("Some player").description("Random description").userEmail("test@mail.com").isPostVisible("Visible").build();
        ReadPostCountResponse expectedResult = ReadPostCountResponse.builder().postCount((int) Stream.of(expectedPost, expectedPost2).count()).build();

        //Assert
        assertEquals(expectedResult, actualResult);
        verify(postRepositoryMock, times(1)).getPostsCountPerUser("test@mail.com");
    }

    @Test
    void getAllPostsByUser() {
        PostEntity postEntity = new PostEntity();
        postEntity.setId(1L);
        postEntity.setTitle("Title");
        postEntity.setWinnerPlayer("Winner player");
        postEntity.setDescription("Description");
        postEntity.setUserEmail("test@mail.com");

        when(postRepositoryMock.getVisiblePostsByUserEmail("Visible", "test@mail.com"))
                .thenReturn(List.of(postEntity));
        when(accessToken.getSubject()).thenReturn("test@mail.com");

        ReadAllPostsResponse posts = postManager.getAllPostsByUser();

        Post searchedPost = posts.getPosts().get(0);

        assertEquals(postEntity.getId(), searchedPost.getId());
        assertEquals(postEntity.getTitle(), searchedPost.getTitle());
        assertEquals(postEntity.getWinnerPlayer(), searchedPost.getWinnerPlayer());
        assertEquals(postEntity.getDescription(), searchedPost.getDescription());
        assertEquals(postEntity.getUserEmail(), searchedPost.getUserEmail());

        verify(postRepositoryMock, times(1)).getVisiblePostsByUserEmail("Visible", "test@mail.com");
    }

    @Test
    void updateVisibility() {
        //Arrange
        UpdatePostVisibilityRequest request = new UpdatePostVisibilityRequest();
        request.setId(1L);
        request.setNewVisibility("Invisible");

        PostEntity postEntity = new PostEntity();
        postEntity.setId(1L);
        postEntity.setTitle("Old title");
        postEntity.setWinnerPlayer("Old winner player");
        postEntity.setDescription("Old description");
        postEntity.setUserEmail("test@mail.com");
        postEntity.setIsPostVisible("Visible");

//Act
        when(postRepositoryMock.findById(1L)).thenReturn(postEntity);

        postManager.updateVisibility(request);

//Assert
        assertEquals(request.getNewVisibility(), postEntity.getIsPostVisible());

        verify(postRepositoryMock, times(1)).findById(1L);
        verify(postRepositoryMock, times(1)).save(postEntity);
    }
}