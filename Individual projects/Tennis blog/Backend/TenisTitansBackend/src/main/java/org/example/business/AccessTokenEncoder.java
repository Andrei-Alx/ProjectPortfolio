package org.example.business;

import org.example.controller.domain.AccessToken;

public interface AccessTokenEncoder {
    String encode(AccessToken accessToken);
}
