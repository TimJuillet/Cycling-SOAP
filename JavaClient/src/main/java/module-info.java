module com.example.client {
    requires javafx.controls;
    requires javafx.fxml;
    requires com.gluonhq.maps;
    requires com.fasterxml.jackson.core;
    requires com.fasterxml.jackson.databind;
    requires jakarta.xml.bind;
    requires jakarta.xml.ws;
    opens com.example.client to javafx.fxml;
    opens com.example.serverside to org.eclipse.persistence.core;
    exports com.example.client;
    exports com.example.serverside;/*
         ||
         ||
        _;|
       /__3
      / /||
     / / // .--.
     \ \// / (OO)
      \//  |( _ )
      // \__/`-'\__
     // \__      _ \
 _.-'/    | ._._.|\ \
(_.-'     |      \ \ \
   .-._   /    o ) / /
  /_ \ \ /   \__/ / /
    \ \_/   / /  E_/
     \     / /
      `-._/-'

 */
}