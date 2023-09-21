package org.example.controller.domain.user;

import lombok.*;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class UpdateUserAccountStatus {
    private long id;
    private String newStatus;
}
