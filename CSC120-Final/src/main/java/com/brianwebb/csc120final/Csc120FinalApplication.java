package com.brianwebb.csc120final;

import com.brianwebb.csc120final.ui.LoginView;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.core.userdetails.User;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.provisioning.InMemoryUserDetailsManager;

@SpringBootApplication
public class Csc120FinalApplication {

    public static void main(String[] args) {
        SpringApplication.run(Csc120FinalApplication.class, args);
    }

}
