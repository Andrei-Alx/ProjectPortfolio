package org.example.controller.domain.user;

import lombok.*;
import org.example.domain.User;
import java.util.*;

@Data
@Builder
public class ReadAllUsersResponse {
    private List<User> users;
}
