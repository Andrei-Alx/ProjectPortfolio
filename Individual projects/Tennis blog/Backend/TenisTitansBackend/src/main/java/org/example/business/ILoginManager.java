package org.example.business;

import org.example.controller.domain.login.LoginRequest;
import org.example.controller.domain.login.LoginResponse;

public interface ILoginManager {
    LoginResponse login(LoginRequest loginRequest);
}
