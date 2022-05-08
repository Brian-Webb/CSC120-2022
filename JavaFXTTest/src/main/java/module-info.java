module com.example.javafxttest {
    requires javafx.controls;
    requires javafx.fxml;

    requires org.kordamp.bootstrapfx.core;

    opens com.example.javafxttest to javafx.fxml;
    exports com.example.javafxttest;
}