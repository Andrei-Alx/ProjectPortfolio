package org.example.business;

import org.example.controller.domain.post.UpdatePostVisibilityRequest;
import org.example.controller.domain.user.*;

public interface IUserManager {
    CreateUserResponse createUser(CreateUserRequest request);
    ReadAllUsersResponse getUsers();
    ReadAllUsersResponse getPlayers();
    void deleteUser(long userId);
    ReadUserCountResponse getUserCount();
    void updateAccountStatus(UpdateUserAccountStatus request);
}
