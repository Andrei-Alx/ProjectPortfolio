package codecrusaders.business;


import codecrusaders.domain.AccessToken;

public interface AccessTokenEncoder {
    String encode(AccessToken accessToken);
}
