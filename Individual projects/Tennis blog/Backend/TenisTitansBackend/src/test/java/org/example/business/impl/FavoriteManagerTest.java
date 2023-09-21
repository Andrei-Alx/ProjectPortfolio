package org.example.business.impl;

import org.example.business.IFavoriteManager;
import org.example.controller.domain.AccessToken;
import org.example.controller.domain.favorite.CreateFavoriteRequest;
import org.example.controller.domain.favorite.CreateFavoriteResponse;
import org.example.controller.domain.favorite.ReadAllFavoritesResponse;
import org.example.domain.Post;
import org.example.persistance.FavoriteRepository;
import org.example.persistance.PostRepository;
import org.example.persistance.UserRepository;
import org.example.persistance.entity.FavoriteEntity;
import org.example.persistance.entity.PostEntity;
import org.example.persistance.entity.UserEntity;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.Mock;
import org.mockito.MockitoAnnotations;
import org.mockito.junit.jupiter.MockitoExtension;

import java.util.List;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.Mockito.*;

@ExtendWith(MockitoExtension.class)
public class FavoriteManagerTest {
    private IFavoriteManager favoriteManager;

    @Mock
    private FavoriteRepository favoriteRepository;

    @Mock
    private UserRepository userRepository;

    @Mock
    private PostRepository postRepository;

    @Mock
    private AccessToken accessToken;

    @BeforeEach
    public void setUp() {
        MockitoAnnotations.initMocks(this);
        favoriteManager = new FavoriteManager(favoriteRepository, userRepository, postRepository, accessToken);
    }

    @Test
    public void createFavoriteTest() {
        // Arrange
        CreateFavoriteRequest request = new CreateFavoriteRequest();
        request.setPostId(1);
        UserEntity user = new UserEntity();
        user.setEmail("test@example.com");
        when(accessToken.getSubject()).thenReturn(user.getEmail());
        when(userRepository.findByEmail(user.getEmail())).thenReturn(user);
        PostEntity post = new PostEntity();
        when(postRepository.findById(request.getPostId())).thenReturn(post);
        FavoriteEntity favorite = new FavoriteEntity();
        favorite.setId(1L);
        favorite.setLoggedUser(user);
        favorite.setPostId(post);
        when(favoriteRepository.save(any())).thenReturn(favorite);

        // Act
        CreateFavoriteResponse response = favoriteManager.createFavorite(request);

        // Assert
        assertEquals(1L, (long)response.getId());
        verify(userRepository, times(1)).findByEmail(user.getEmail());
        verify(postRepository, times(1)).findById(request.getPostId());
        verify(favoriteRepository, times(1)).save(any(FavoriteEntity.class));
    }

    @Test
    public void getFavoritesTest() {
        // Arrange
        String videoLink = "https://www.youtube.com/watch?v=ChYELwk19v8&ab_channel=TennisTV";
        String imageLink = "https://i.imgur.com/ei5HSML.png";
        PostEntity postEntity = PostEntity.builder().id(1L).title("firstTitle").videoLink(videoLink).imageLink(imageLink).likes(1)
                .winnerPlayer("Some player").description("Random description").userEmail("test@mail.com").build();
        PostEntity postEntity2 = PostEntity.builder().id(1L).title("firstTitle").videoLink(videoLink).imageLink(imageLink).likes(1)
                .winnerPlayer("Some player").description("Random description").userEmail("test@mail.com").build();

        when(favoriteRepository.findPostIdsByUserId(accessToken.getUserId(), "Visible")).thenReturn(List.of(postEntity,postEntity2));

        // Act
        ReadAllFavoritesResponse actualResult = favoriteManager.getFavorites();
        Post expectedPost = Post.builder().id(1L).title("firstTitle").videoLink(videoLink).imageLink(imageLink).likes(1)
                .winnerPlayer("Some player").description("Random description").userEmail("test@mail.com").build();
        Post expectedPost2 = Post.builder().id(1L).title("firstTitle").videoLink(videoLink).imageLink(imageLink).likes(1)
                .winnerPlayer("Some player").description("Random description").userEmail("test@mail.com").build();
        ReadAllFavoritesResponse expectedResult = ReadAllFavoritesResponse.builder().favorites(List.of(expectedPost,expectedPost2)).build();
        // Assert
        assertEquals(expectedResult, actualResult);
        verify(favoriteRepository).findPostIdsByUserId(accessToken.getUserId(), "Visible");
    }

    @Test
    public void testGetFavorites() {
        // given
        String videoLink = "https://www.youtube.com/watch?v=ChYELwk19v8&ab_channel=TennisTV";
        String imageLink = "https://i.imgur.com/ei5HSML.png";
        PostEntity postEntity = PostEntity.builder()
                .id(1L)
                .title("firstTitle")
                .videoLink(videoLink)
                .imageLink(imageLink)
                .likes(1)
                .winnerPlayer("Some player")
                .description("Random description")
                .userEmail("test@mail.com")
                .build();
        PostEntity postEntity2 = PostEntity.builder()
                .id(2L) // Changed id to be different from the first postEntity
                .title("secondTitle") // Changed title to be different from the first postEntity
                .videoLink(videoLink)
                .imageLink(imageLink)
                .likes(1)
                .winnerPlayer("Some player")
                .description("Random description")
                .userEmail("test@mail.com")
                .build();

        List<PostEntity> postEntities = List.of(postEntity, postEntity2);
        when(favoriteRepository.findPostIdsByUserId(anyLong(), anyString())).thenReturn(postEntities);

        // when
        ReadAllFavoritesResponse response = favoriteManager.getFavorites();

        // then
        assertEquals(2, response.getFavorites().size());
        verify(favoriteRepository).findPostIdsByUserId(anyLong(), eq("Visible"));
    }


    @Test
    public void deleteFavoriteTest() {
        // Arrange
        long favoriteId = 1L;

        // Act
        favoriteManager.deleteFavorite(favoriteId);

        // Assert
        verify(favoriteRepository, times(1)).deleteById(favoriteId);
    }
}
