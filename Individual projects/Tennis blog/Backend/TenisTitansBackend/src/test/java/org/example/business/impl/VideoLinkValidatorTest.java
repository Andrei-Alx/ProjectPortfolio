package org.example.business.impl;

import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.junit.jupiter.MockitoExtension;

import static org.junit.jupiter.api.Assertions.assertFalse;
import static org.junit.jupiter.api.Assertions.assertTrue;

@ExtendWith(MockitoExtension.class)
class VideoLinkValidatorTest {
    VideoLinkValidator linkValidator = new VideoLinkValidator();

    @Test
    public void testIsValidLink_NullLink() {
        assertFalse(linkValidator.isValidLink(null));
    }

    @Test
    public void testIsValidLink_ValidYouTubeLink() {
        assertTrue(linkValidator.isValidLink("https://www.youtube.com/watch?v=dQw4w9WgXcQ"));
    }

    @Test
    public void testIsValidLink_InvalidYouTubeLink() {
        assertFalse(linkValidator.isValidLink("https://www.yhjj.com/watch?v=invalid"));
    }
}