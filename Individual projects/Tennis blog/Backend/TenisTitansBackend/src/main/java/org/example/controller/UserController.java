package org.example.controller;

import lombok.AllArgsConstructor;
import org.example.business.impl.UserManager;
import org.example.configuration.security.isauthenticated.IsAuthenticated;
import org.example.controller.domain.post.UpdatePostVisibilityRequest;
import org.example.controller.domain.user.*;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.annotation.security.RolesAllowed;
import javax.validation.Valid;

@RestController
@RequestMapping("/users")
@AllArgsConstructor
@CrossOrigin(origins = "http://localhost:3000/", allowedHeaders = "*", methods = {RequestMethod.GET, RequestMethod.POST, RequestMethod.DELETE, RequestMethod.PATCH})
public class UserController {
    private final UserManager userManager;

    @PostMapping
    public ResponseEntity<CreateUserResponse> createUser(@RequestBody @Valid CreateUserRequest request){
        CreateUserResponse response = userManager.createUser(request);
        return ResponseEntity.status(HttpStatus.CREATED).body(response);
    }

    @GetMapping("/players")
    public ResponseEntity<ReadAllUsersResponse> getPlayers() {
        return ResponseEntity.ok(userManager.getPlayers());
    }

    @GetMapping
    public ResponseEntity<ReadAllUsersResponse> getUsers() {
        return ResponseEntity.ok(userManager.getUsers());
    }

    @DeleteMapping("{userId}")
    public ResponseEntity<Void> deleteUser(@PathVariable int userId) {
        userManager.deleteUser(userId);
        return ResponseEntity.noContent().build();
    }

    @IsAuthenticated
    @RolesAllowed({"ROLE_Admin"})
    @GetMapping("/count")
    public ResponseEntity<ReadUserCountResponse> getUserCount() {
        ReadUserCountResponse response = userManager.getUserCount();
        return ResponseEntity.ok(response);
    }

    @IsAuthenticated
    @RolesAllowed({"ROLE_Admin"})
    @PatchMapping
    public ResponseEntity<Void> updatePostVisibility(@RequestBody @Valid UpdateUserAccountStatus request) {
        userManager.updateAccountStatus(request);
        return ResponseEntity.ok().build();
    }
}
