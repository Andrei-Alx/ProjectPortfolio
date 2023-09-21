package codecrusaders.business.impl;

import codecrusaders.business.AccessTokenDecoder;
import codecrusaders.business.AccessTokenEncoder;
import codecrusaders.domain.AccessToken;
import org.junit.Rule;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.Mock;
import org.mockito.MockitoAnnotations;
import org.mockito.junit.MockitoJUnit;
import org.mockito.junit.MockitoRule;
import org.mockito.junit.jupiter.MockitoExtension;
import org.testcontainers.shaded.org.apache.commons.lang3.StringUtils;

import java.util.List;

import static org.junit.jupiter.api.Assertions.assertFalse;
import static org.junit.jupiter.api.Assertions.assertNotNull;
import static org.mockito.Mockito.verifyNoInteractions;

@ExtendWith(MockitoExtension.class)
public class AccessTokenTest {


    @Rule
    public MockitoRule mockitoRule = MockitoJUnit.rule();
    @Mock
    private AccessTokenEncoder accessTokenEncoder;

    @Mock
    private AccessTokenDecoder accessTokenDecoder;

    private AccessTokenEncoderDecoderImpl accessTokenManager;

    @BeforeEach
    public void setup() {
        MockitoAnnotations.openMocks(this);
        accessTokenManager = new AccessTokenEncoderDecoderImpl("E91E158E4C6656F68B1B5D1C316766DE98D2AD6EF3BFB44F78E9CFCDF5");
    }
    @Test
    public void testEncode() {
        // Arrange
        AccessToken accessToken = AccessToken.builder()
                .subject("username")
                .role("PROGRAMMER")
                .userId(123L)
                .build();

        // Act
        String encodedToken = accessTokenManager.encode(accessToken);

        // Assert
        assertNotNull(encodedToken);
        assertFalse(StringUtils.isEmpty(encodedToken));

        verifyNoInteractions(accessTokenEncoder);
        verifyNoInteractions(accessTokenDecoder);
    }

}
