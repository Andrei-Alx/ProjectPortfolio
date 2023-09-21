package org.example.business.impl;

import org.example.business.AccessTokenDecoder;
import org.example.business.exception.InvalidAccessTokenException;
import org.example.controller.domain.AccessToken;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;
import static org.mockito.ArgumentMatchers.anyString;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

class AccessTokenEncoderDecoderImplTest {

    private static final String SECRET_KEY = "2345678900908978678598jknckndkcwnwlsssssssssssssssssssspiwejofjewofkcpkwemckpwmckpmwcpmwemcomcpwemip";

    private AccessTokenEncoderDecoderImpl accessTokenEncoderDecoderImpl;
    private AccessToken accessToken;

    @BeforeEach
    public void setUp() {
        accessToken = AccessToken.builder()
                .subject("Test Subject")
                .userId(1L)
                .role(2)
                .build();

        accessTokenEncoderDecoderImpl = new AccessTokenEncoderDecoderImpl(SECRET_KEY);
    }

    @Test
    public void testEncode() {
//        accessTokenEncoderDecoderImpl = new AccessTokenEncoderDecoderImpl(SECRET_KEY);
        String encodedAccessToken = accessTokenEncoderDecoderImpl.encode(accessToken);
        AccessToken decodedAccessToken = accessTokenEncoderDecoderImpl.decode(encodedAccessToken);

        assertEquals(accessToken.getSubject(), decodedAccessToken.getSubject());
        assertEquals(accessToken.getUserId(), decodedAccessToken.getUserId());
        //assertEquals(accessToken.getRole(), decodedAccessToken.getRole());
    }

    @Test
    public void testDecodeInvalidToken() {
        AccessTokenDecoder accessTokenDecoder = mock(AccessTokenDecoder.class);
        when(accessTokenDecoder.decode(anyString())).thenThrow(new InvalidAccessTokenException("Error"));

        assertThrows(InvalidAccessTokenException.class, () -> accessTokenDecoder.decode("invalid-token"));
    }
}