package codecrusaders.business;


import codecrusaders.domain.LoginRequest;
import codecrusaders.domain.LoginResponse;

public interface ILoginManager {
    LoginResponse login(LoginRequest loginRequest);
}
