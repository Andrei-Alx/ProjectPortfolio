package org.example.controller;

import lombok.RequiredArgsConstructor;
import org.example.business.ILoginManager;
import org.example.business.impl.LoginManager;
import org.example.controller.domain.login.LoginRequest;
import org.example.controller.domain.login.LoginResponse;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;

@RestController
@RequestMapping("/login")
@RequiredArgsConstructor
@CrossOrigin(origins = "http://localhost:3000/", allowedHeaders = "*", methods = {RequestMethod.POST})
public class LoginController {
    private final ILoginManager loginManager;

    @PostMapping
    public ResponseEntity<LoginResponse> login(@RequestBody @Valid LoginRequest loginRequest) {
        LoginResponse loginResponse = loginManager.login(loginRequest);
        return ResponseEntity.ok(loginResponse);
    }
}
