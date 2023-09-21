package org.example.business.impl;

import org.example.business.IVideoLinkValidator;
import org.springframework.stereotype.Repository;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

@Repository
public class VideoLinkValidator implements IVideoLinkValidator {

    @Override
    public boolean isValidLink(String link) {
        if(link == null)
        {
            return false;
        }
        else
        {
            String regex = "^(?:https?:\\/\\/)?(?:www\\.)?(?:youtube\\.com\\/watch\\?v=)([a-zA-Z0-9_-]{11})(?:\\&\\S+)?$";
            Pattern pattern = Pattern.compile(regex);
            Matcher matcher = pattern.matcher(link);
            return matcher.matches();
        }
    }
}
