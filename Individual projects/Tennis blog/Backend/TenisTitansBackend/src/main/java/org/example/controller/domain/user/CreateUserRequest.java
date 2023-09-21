package org.example.controller.domain.user;

import lombok.*;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class CreateUserRequest {
    private String email;
    private int role; //1 = player, 2 = admin
    private String password;
}
