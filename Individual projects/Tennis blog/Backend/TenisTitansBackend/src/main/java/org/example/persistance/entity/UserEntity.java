package org.example.persistance.entity;

import lombok.*;

import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;
import javax.persistence.*;
import javax.validation.constraints.Email;
import javax.validation.constraints.NotBlank;
import javax.validation.constraints.NotNull;

@Entity
@Table(name = "user")
@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class UserEntity {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private Long id;

    @NotBlank
    @Email
    @Column(name = "user_email")
    private String email;

    @NotNull
    @Column(name = "user_role")
    private int userRole;

    @NotBlank
    @Column(name = "user_password")
    private String password;

    @NotBlank
    @Column(name = "is_active")
    private String isUserActive;
}
