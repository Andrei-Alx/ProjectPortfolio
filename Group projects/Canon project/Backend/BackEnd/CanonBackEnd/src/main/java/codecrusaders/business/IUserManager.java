package codecrusaders.business;

import codecrusaders.domain.Http.GetAllUsersResponse;
import codecrusaders.domain.Http.RegisterUserRequest;
import codecrusaders.domain.Http.RegisterUserResponse;

public interface IUserManager {
    public RegisterUserResponse registerUser(RegisterUserRequest request);
    public GetAllUsersResponse getAllUsers();

    }
