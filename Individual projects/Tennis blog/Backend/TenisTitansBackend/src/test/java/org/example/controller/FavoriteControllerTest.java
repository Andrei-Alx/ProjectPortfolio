package org.example.controller;

import com.fasterxml.jackson.databind.ObjectMapper;
import org.example.business.impl.FavoriteManager;
import org.example.controller.domain.favorite.CreateFavoriteRequest;
import org.example.controller.domain.favorite.CreateFavoriteResponse;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;
import org.springframework.http.MediaType;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.setup.MockMvcBuilders;

import static org.mockito.ArgumentMatchers.any;
import static org.mockito.Mockito.when;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.delete;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.jsonPath;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

@ExtendWith(MockitoExtension.class)
public class FavoriteControllerTest {
    String password = "123";
    String validEmail = "test@mail.com";
    String videoLink = "https://www.youtube.com/watch?v=ChYELwk19v8&ab_channel=TennisTV";
    String imageLink = "https://i.imgur.com/ei5HSML.png";
    private MockMvc mockMvc;

    @Mock
    private FavoriteManager favoriteManager;

    private ObjectMapper objectMapper;

    @BeforeEach
    public void setup() {
        FavoriteController favoriteController = new FavoriteController(favoriteManager);
        mockMvc = MockMvcBuilders.standaloneSetup(favoriteController).build();
        objectMapper = new ObjectMapper();
    }

    @Test
    public void testCreateFavorite() throws Exception {
        CreateFavoriteRequest request = new CreateFavoriteRequest(1);
        CreateFavoriteResponse response = new CreateFavoriteResponse(1L);
        when(favoriteManager.createFavorite(any(CreateFavoriteRequest.class))).thenReturn(response);

        mockMvc.perform(post("/favorites")
                        .contentType(MediaType.APPLICATION_JSON)
                        .content(objectMapper.writeValueAsString(request)))
                .andExpect(status().isCreated())
                .andExpect(jsonPath("$.id").value(1));
    }

//    @Test
//    public void testGetFavorites() throws Exception {
//        Post post = Post.builder().id(1L).title("firstTitle").videoLink(videoLink).imageLink(imageLink).likes(1)
//                .winnerPlayer("Some player").description("Random description").userEmail("test@mail.com").build();
//        Post post2 = Post.builder().id(2L).title("firstTitle").videoLink(videoLink).imageLink(imageLink).likes(1)
//                .winnerPlayer("Some player").description("Random description").userEmail("test@mail.com").build();
//        List<Post> posts = List.of(post,post2);
////        User user = new User(1L, validEmail, 1, password);
////        User user2 = new User(2L, validEmail, 1, password);
////        List<Favorite> favorites = new ArrayList<>();
////        favorites.add(new Favorite(1L,user, post));
////        favorites.add(new Favorite(2L, user2, post2));
//
//        ReadAllFavoritesResponse response = new ReadAllFavoritesResponse(posts);
//        when(favoriteManager.getFavorites()).thenReturn(response);
//
//        mockMvc.perform(get("/favorites"))
//                .andExpect(status().isOk())
//                .andExpect(content().json(expectedJSON));
//        verify(favoriteManager).getFavorites();
//
////                .andExpect(jsonPath("$.favorites[0].id").value(1))
////                .andExpect(jsonPath("$.favorites[0].name").value("Favorite 1"))
////                .andExpect(jsonPath("$.favorites[1].id").value(2))
////                .andExpect(jsonPath("$.favorites[1].name").value("Favorite 2"));
//    }

    @Test
    public void testDeleteFavorite() throws Exception {
        long favoriteId = 1L;

        mockMvc.perform(delete("/favorites/" + favoriteId))
                .andExpect(status().isNoContent());
    }
}
