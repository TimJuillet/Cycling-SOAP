package com.example.client;

import com.example.serverside.ArrayOfArrayOfPosition;
import com.example.serverside.Service1;
import com.gluonhq.maps.MapPoint;
import com.gluonhq.maps.MapView;
import javafx.scene.input.KeyEvent;
import javafx.application.Application;
import javafx.collections.FXCollections;
import javafx.scene.Scene;
import javafx.scene.control.ListView;
import javafx.scene.input.KeyCode;
import javafx.scene.control.TextField;
import javafx.scene.layout.HBox;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;
import javafx.scene.paint.Color;


import java.io.IOException;
import java.util.ArrayList;
import java.util.List;


public class GluonMapExample extends Application {
    String start;
    String end;
    private final ListView<String> directions = new ListView<>();
    private final VBox controls = new VBox();
    private final Service1 service1 = new Service1();
    private final TextField searchField = new TextField();
    private final List<RouteLayer> routeLayers = List.of(new RouteLayer(List.of(), Color.RED), new RouteLayer(List.of(), Color.BLUE), new RouteLayer(List.of(), Color.RED));
    private MapView mapView;


    public static void main(String[] args) {
        launch();
    }

    @Override
    public void start(Stage stage) throws IOException {/*
    _______AAAA____j_o_a_n____AAAA________
           VVVV               VVVV
           (__)               (__)
            \ \               / /
             \ \   \\|||//   / /
              > \   _   _   / <
     hang      > \ / \ / \ / <
      in        > \\_o_o_// <
      there...   > ( (_) ) <
                  >|     |<
                 / |\___/| \
                 / (_____) \
                 /         \
                  /   o   \
                   ) ___ (
                  / /   \ \
                 ( /     \ )
                 ><       ><
                ///\     /\\\
                '''       '''
 */

        System.setProperty("javafx.platform", "desktop");
        System.setProperty("http.agent", "Gluon Mobile/1.0.3");

        HBox root = new HBox();

        mapView = new MapView();

        //List<String> instructions = or.getRouteInstructions(new MapPoint(43.61524, 7.07188), new MapPoint(43.58807, 7.05226));

        /* Création et ajoute une couche à la carte */

        //mapView.addLayer(routeLayer);
        routeLayers.forEach(mapView::addLayer);

        mapView.setZoom(10);
        mapView.flyTo(0, new MapPoint(43.61551, 7.07170), 0.1);

        // Create a VBox to hold the controls with minimal width of 200px and taking all the available height
        controls.setMinWidth(200);
        controls.setMaxHeight(Double.MAX_VALUE);

        // Add the controls to the VBox
        // List of directions that takes all the available height
        directions.setMaxHeight(Double.MAX_VALUE);

        // on key pressed, search for the text in the search field
        searchField.setOnKeyPressed(this::onSearchUpdate);

        //directions.setItems(FXCollections.observableArrayList(instructions));

        controls.getChildren().add(searchField);
        controls.getChildren().add(directions);
        root.getChildren().add(controls);
        root.getChildren().add(mapView);

        Scene scene = new Scene(root, 640, 480);
        stage.setScene(scene);
        stage.show();
    }

    private void onSearchUpdate(KeyEvent e) {
        if (e.getCode().equals(KeyCode.ENTER)) {
            if (start != null && end != null) {
                start = null;
                end = null;
            }

            if (start == null) {
                start = searchField.getText();
                searchField.setText("");
            } else if (end == null) {
                end = searchField.getText();
                searchField.setText("");
            }

            if (start != null && end != null) {
                ArrayOfArrayOfPosition points = new ArrayOfArrayOfPosition();
                points = service1.getBasicHttpBindingIService1().getBestTrajet(start, end);

                if(points.getArrayOfPosition().size() == 0){
                    System.out.println("Aucun trajet trouvé");
                }

                if (points.getArrayOfPosition().size() == 1) {
                    routeLayers.get(0).setPoints(List.of());
                    mapView.removeLayer(routeLayers.get(0));
                    routeLayers.get(2).setPoints(List.of());
                    mapView.removeLayer(routeLayers.get(2));
                    routeLayers.get(1).setPoints(points.getArrayOfPosition().get(0).getPosition().stream().map(position -> new MapPoint(position.getLatitude(), position.getLongitude())).toList());
                }

                if (points.getArrayOfPosition().size() == 3) {
                    routeLayers.get(0).setPoints(points.getArrayOfPosition().get(0).getPosition().stream().map(position -> new MapPoint(position.getLatitude(), position.getLongitude())).toList());
                    mapView.addLayer(routeLayers.get(0));
                    routeLayers.get(1).setPoints(points.getArrayOfPosition().get(1).getPosition().stream().map(position -> new MapPoint(position.getLatitude(), position.getLongitude())).toList());
                    routeLayers.get(2).setPoints(points.getArrayOfPosition().get(2).getPosition().stream().map(position -> new MapPoint(position.getLatitude(), position.getLongitude())).toList());
                    mapView.addLayer(routeLayers.get(2));
                }
            }
        }
    }

}










































































/*

`;-.          ___,
  `.`\_...._/`.-"`
    \        /      ,
    /()   () \    .' `-._
   |)  .    ()\  /   _.'
   \  -'-     ,; '. <
    ;.__     ,;|   > \
   / ,    / ,  |.-'.-'
  (_/    (_/ ,;|.<`
    \    ,     ;-`
     >   \    /
    (_,-'`> .'
         (_,'
 */