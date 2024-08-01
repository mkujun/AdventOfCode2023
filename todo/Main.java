import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.List;

public class Main {
    public static void main(String[] args) {
        Path filePath = Paths.get("src/input.txt");
        List<String> lines = Utils.readFile(filePath);
        List<Hand> handList = new ArrayList<>();

        for (String line : lines) {
            Hand hand = readHand(line);
            if (handList.isEmpty()) {
                handList.add(hand);
            }
            else {
                // todo: read and compare with others in the list and set to appropriate index
                insertHandIntoList(hand, handList);
            }
        }
    }

    private static Hand readHand(String line) {
        String[] parts = line.split(" ");
        String value = parts[0];
        String bid = parts[1];

        return new Hand(value, bid);
    }

    private static void insertHandIntoList(Hand hand, List<Hand> handList) {
        for (int i = 0; i <handList.size() ; i++) {
            int indexToInsert = findIndexToInsert(hand, handList.get(i));
        }
    }

    // todo: compare hand which is being inserted with the ones from the list
    // left element in array needs to be smaller and the right element should be bigger
    private static int findIndexToInsert(Hand hand, Hand handInList) {
        return 0;
    }
}

class Hand {
    private String value;
    private String bid;

    public Hand(String value, String bid) {
        this.value = value;
        this.bid = bid;
    }
}