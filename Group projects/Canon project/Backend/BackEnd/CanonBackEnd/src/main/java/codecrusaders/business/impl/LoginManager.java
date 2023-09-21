package codecrusaders.business.impl;

import codecrusaders.business.AccessTokenEncoder;
import codecrusaders.business.ILoginManager;
import codecrusaders.business.exception.InvalidCredentialsException;
import codecrusaders.domain.AccessToken;
import codecrusaders.domain.LoginRequest;
import codecrusaders.domain.LoginResponse;
import codecrusaders.repository.UserRepository;
import codecrusaders.repository.entity.UserEntity;
import lombok.RequiredArgsConstructor;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@RequiredArgsConstructor
public class LoginManager implements ILoginManager {
    private final UserRepository userRepository;
    private final PasswordEncoder passwordEncoder;
    private final AccessTokenEncoder accessTokenEncoder;

    @Override
    public LoginResponse login(LoginRequest loginRequest) {
        UserEntity user = userRepository.findByUserName(loginRequest.getUsername());
        if (user == null) {
            throw new InvalidCredentialsException();
        }

        if (!matchesPassword(loginRequest.getPassword(), user.getPassword())) {
            throw new InvalidCredentialsException();
        }

        String accessToken = generateAccessToken(user);
        return LoginResponse.builder().accessToken(accessToken).build();
    }

    private boolean matchesPassword(String rawPassword, String encodedPassword) {
        return passwordEncoder.matches(rawPassword, encodedPassword);
    }

    private String generateAccessToken(UserEntity user) {
        Long userId = user.getId() >= 0 ? user.getId() : null;

        return accessTokenEncoder.encode(
                AccessToken.builder()
                        .subject(user.getUserName())
                        .userId(userId)
                        .build());
    }
}
