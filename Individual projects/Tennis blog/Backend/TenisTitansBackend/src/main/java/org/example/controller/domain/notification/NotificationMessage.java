package org.example.controller.domain.notification;

import lombok.Data;

@Data
public class NotificationMessage {
    private String id;
    private String from;
    private String text;
}
