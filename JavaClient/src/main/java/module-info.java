module com.example.client {
    requires javafx.controls;
    requires javafx.fxml;
    requires com.gluonhq.maps;
    requires com.fasterxml.jackson.core;
    requires com.fasterxml.jackson.databind;


    opens com.example.client to javafx.fxml;
    exports com.example.client;
}