import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.control.Label;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.Scanner;

public class APIClientApp extends Application {

    public static void main(String[] args) {
        launch(args);
    }

    @Override
    public void start(Stage primaryStage) {
        primaryStage.setTitle("API Client Example");

        // Create a label to display the API response
        Label responseLabel = new Label("API Response Will Appear Here");
   
        // Create a VBox layout to hold the label
        VBox vbox = new VBox(responseLabel);
      

        // Create a scene
        Scene scene = new Scene(vbox, 300, 200);

        // Set the scene
        primaryStage.setScene(scene);

        // Make an API request and set the response as the label text
        try {
            String apiResponse = makeAPIRequest("https://jsonplaceholder.typicode.com/posts/1");
            responseLabel.setText(apiResponse);
        } catch (Exception e) {
            e.printStackTrace();
            responseLabel.setText("Error: Unable to fetch data from the API");
        }

        // Show the stage
        primaryStage.show();
    }

    private String makeAPIRequest(String apiUrl) throws Exception {
        URL url = new URL(apiUrl);
        HttpURLConnection conn = (HttpURLConnection) url.openConnection();
        conn.setRequestMethod("GET");
        conn.connect();

        int responseCode = conn.getResponseCode();
        if (responseCode == 200) {
            Scanner scanner = new Scanner(url.openStream());
            StringBuilder response = new StringBuilder();
            while (scanner.hasNext()) {
                response.append(scanner.nextLine());
            }
            scanner.close();
            return response.toString();
        } else {
            throw new Exception("API request failed with response code: " + responseCode);
        }
    }
}
