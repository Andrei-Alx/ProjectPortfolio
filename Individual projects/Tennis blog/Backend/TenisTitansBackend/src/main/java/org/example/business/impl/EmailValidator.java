package org.example.business.impl;

import lombok.AllArgsConstructor;
import org.example.business.IEmailValidator;
import org.example.persistance.UserRepository;
import org.springframework.stereotype.Repository;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

@Repository
@AllArgsConstructor
public class EmailValidator implements IEmailValidator {
    private final UserRepository realUserRepository;


    @Override
    public boolean isValidEmail(String email) {
        if(email == null)
        {
            return false;
        }
        else
        {
            String regex = "^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$";
            Pattern pattern = Pattern.compile(regex);
            Matcher matcher = pattern.matcher(email);
            return matcher.matches();
        }
    }

    @Override
    public boolean isEmailTaken(String email) {
        return realUserRepository.findUserEntityByEmail(email).isPresent();
    }
}
