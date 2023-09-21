package org.example.controller;

import lombok.AllArgsConstructor;
import org.example.business.impl.FavoriteManager;
import org.example.configuration.security.isauthenticated.IsAuthenticated;
import org.example.controller.domain.favorite.CreateFavoriteRequest;
import org.example.controller.domain.favorite.CreateFavoriteResponse;
import org.example.controller.domain.favorite.ReadAllFavoritesResponse;
import org.example.domain.Favorite;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.annotation.security.RolesAllowed;
import javax.validation.Valid;

@RestController
@RequestMapping("/favorites")
@AllArgsConstructor
@CrossOrigin(origins = "http://localhost:3000/", allowedHeaders = "*", methods = {RequestMethod.GET, RequestMethod.POST, RequestMethod.PUT, RequestMethod.DELETE, RequestMethod.PATCH})
public class FavoriteController {
    private final FavoriteManager favoriteManager;

    @IsAuthenticated
    @RolesAllowed({"ROLE_Player"})
    @PostMapping
    public ResponseEntity<CreateFavoriteResponse> createPost(@RequestBody @Valid CreateFavoriteRequest request){
        CreateFavoriteResponse response = favoriteManager.createFavorite(request);
        return ResponseEntity.status(HttpStatus.CREATED).body(response);
    }

    @IsAuthenticated
    @RolesAllowed({"ROLE_Player"})
    @GetMapping
    public ResponseEntity<ReadAllFavoritesResponse> getFavorites() {
        return ResponseEntity.ok(favoriteManager.getFavorites());
    }

    @IsAuthenticated
    @RolesAllowed({"ROLE_Player"})
    @DeleteMapping("{favoriteId}")
    public ResponseEntity<Void> deleteFavorite(@PathVariable long favoriteId) {
        favoriteManager.deleteFavorite(favoriteId);
        return ResponseEntity.noContent().build();
    }
}
