package org.example.persistance.entity;


import lombok.*;

import javax.persistence.*;

@Entity
@Table(name = "favorite")
@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class FavoriteEntity {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private Long id;

    @ManyToOne
    @JoinColumn(name = "logged_user_id")
    private UserEntity loggedUser;

    @ManyToOne
    @JoinColumn(name = "post_id")
    private PostEntity postId;

}
