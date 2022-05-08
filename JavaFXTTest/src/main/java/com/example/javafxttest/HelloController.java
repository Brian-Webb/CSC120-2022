package com.example.javafxttest;

import javafx.fxml.FXML;
import javafx.scene.control.Label;
import javafx.scene.text.Text;
import javafx.scene.text.TextFlow;

public class HelloController {
    @FXML
    private TextFlow welcomeTextAlert;

    @FXML
    private Text welcomeText;

    @FXML
    protected void onHelloButtonClick() {
        welcomeTextAlert.getStyleClass().setAll("alert","alert-success");

        welcomeText.setText("Thank you for clicking the button.");
    }
}