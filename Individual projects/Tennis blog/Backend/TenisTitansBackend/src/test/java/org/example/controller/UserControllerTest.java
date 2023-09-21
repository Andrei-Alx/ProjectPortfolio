package org.example.controller;

import org.example.business.AccessTokenDecoder;
import org.example.business.impl.UserManager;
import org.example.controller.domain.user.CreateUserRequest;
import org.example.controller.domain.user.CreateUserResponse;
import org.example.controller.domain.user.ReadAllUsersResponse;
import org.example.domain.User;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
import org.springframework.boot.test.mock.mockito.MockBean;
import org.springframework.http.MediaType;
import org.springframework.test.context.junit.jupiter.SpringExtension;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.MvcResult;
import org.springframework.test.web.servlet.ResultActions;
import org.springframework.test.web.servlet.request.MockMvcRequestBuilders;

import java.util.Collections;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.verify;
import static org.mockito.Mockito.when;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.result.MockMvcResultHandlers.print;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.content;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;


@ExtendWith(SpringExtension.class)
@WebMvcTest(UserController.class)
class UserControllerTest {
    @Autowired
    private MockMvc mockMvc;
    @MockBean
    private UserManager userManager;
    @MockBean
    private AccessTokenDecoder accessTokenDecoder;

    @Test
    void testCreateUser() throws Exception {
        final CreateUserRequest createUserRequest = CreateUserRequest.builder().email("test@mail.com").role(1).password("123").build();
        final CreateUserResponse response = CreateUserResponse.builder().userId(1L).build();
        when(userManager.createUser(createUserRequest)).thenReturn(response);

        // when
        MvcResult result = mockMvc.perform(MockMvcRequestBuilders.post("/users")
                        .contentType(MediaType.APPLICATION_JSON)
                        .content("{\"id\":1,\"email\":\"test@mail.com\",\"role\":\"1\",\"password\":\"123\"}"))
                .andExpect(status().isCreated())
                .andReturn();
        verify(userManager).createUser(createUserRequest);
    }

    @Test
    void getUsers_ShouldReturnStatus200WithUsersArray() throws Exception{
        //Arrange
        final User user = User.builder().id(1L).email("test@mail.com").password("12").build();
        final User user1 = User.builder().id(2L).email("test1@mail.com").password("123").build();
        final ReadAllUsersResponse response = ReadAllUsersResponse.builder().users(List.of(user, user1)).build();
        final String expectedJSON = "{\"users\":[{\"id\":1,\"email\":\"test@mail.com\",\"password\":\"12\"},{\"id\":2,\"email\":\"test1@mail.com\",\"password\":\"123\"}]}";
        when(userManager.getUsers()).thenReturn(response);

        //Act
        ResultActions resultActions = mockMvc.perform(get("/users"));

        //Assert
        resultActions.andDo(print())
                .andExpect(status().isOk())
                .andExpect(content().json(expectedJSON));
        verify(userManager).getUsers();
    }

    @Test
    void testDeleteUser() throws Exception {
        // given
        int userId = 1;

        // when
        mockMvc.perform(MockMvcRequestBuilders.delete("/users/" + userId))
                .andExpect(status().isNoContent());

        // then
        verify(userManager).deleteUser(userId);
    }
}