package com.example.client;

import com.example.serverside.ArrayOfArrayOfPosition;
import com.example.serverside.Service1;
import com.gluonhq.maps.MapPoint;
import com.gluonhq.maps.MapView;

import javafx.application.Application;
import javafx.collections.FXCollections;
import javafx.scene.Scene;
import javafx.scene.control.ListView;
import javafx.scene.control.TextField;
import javafx.scene.input.KeyCode;
import javafx.scene.input.KeyEvent;
import javafx.scene.layout.HBox;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;
import javafx.scene.paint.Color;


import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import static javafx.scene.paint.Color.RED;

public class GluonMapExample extends Application {
    String start;
    String end;
    private final ListView<String> directions = new ListView<>();
    private final  VBox controls = new VBox();
    private final Service1 service1 = new Service1();
    private final TextField searchField = new TextField();
    private final ArrayList<RouteLayer> routeLayers = new ArrayList<RouteLayer>();
    private MapView mapView;


    public static void main(String[] args) {
        launch();
    }

    @Override
    public void start(Stage stage) throws IOException {


        System.setProperty("javafx.platform", "desktop");
        System.setProperty("http.agent", "Gluon Mobile/1.0.3");

        HBox root = new HBox();

        mapView = new MapView();

        //List<String> instructions = or.getRouteInstructions(new MapPoint(43.61524, 7.07188), new MapPoint(43.58807, 7.05226));

        /* Création et ajoute une couche à la carte */

        //mapView.addLayer(routeLayer);

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
                    //transformer points en liste de MapPoint
                    System.out.println(points.getArrayOfPosition().size());
                    points.getArrayOfPosition().forEach(arrayOfPosition -> {
                        List<MapPoint> pointsList = new ArrayList<>();
                        // add a routeLayer for each route, with a different color
                        RouteLayer routeLayer = new RouteLayer(new ArrayList<>(), Color.rgb((int) (Math.random() * 255), (int) (Math.random() * 255), (int) (Math.random() * 255)));
                        arrayOfPosition.getPosition().forEach(position -> {
                            pointsList.add(new MapPoint(position.getLatitude(), position.getLongitude()));
                        });
                        routeLayer.setPoints(pointsList);
                        routeLayers.add(routeLayer);
                    });
                   // directions.setItems(FXCollections.observableArrayList(or.getRouteInstructions(start, end)));
                for(RouteLayer routeLayer : routeLayers){
                    mapView.addLayer(routeLayer);
                }
            }
        }
    }

}