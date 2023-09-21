package org.example.controller.domain;

import com.fasterxml.jackson.annotation.JsonIgnore;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;
import java.util.List;
import java.util.Objects;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class AccessToken {
    private String subject;
    @Builder.Default
    private List<String> roles = List.of("Player", "Admin");
    private int role;
    private Long userId;

    @JsonIgnore
    public boolean hasRole(String roleName) {
        if (!Objects.equals(roleName, "Player") || !Objects.equals(roleName, "Admin")) {
            return false;
        }
        if((roleName.equals("Player") && role == 1) || (roleName.equals("Admin") && role == 2)){
            return true;
        }
        else{
            return false;
        }

    }
}
