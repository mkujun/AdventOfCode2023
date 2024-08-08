import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

public class Main {
    public static void main(String[] args) {
        Path filePath = Paths.get("src/input.txt");
        List<String> lines = Utils.readFile(filePath);
        List<Hand> handList = new ArrayList<>();

        for (String line : lines) {
            Hand hand = new Hand(line);
            System.out.println(hand);
            if (handList.isEmpty()) {
                handList.add(hand);
            } else {
                // todo: read and compare with others in the list and set to appropriate index
                insertHandIntoList(hand, handList);
            }
        }
    }

    private static void insertHandIntoList(Hand hand, List<Hand> handList) {
        for (int i = 0; i < handList.size(); i++) {
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
    private String type;

    public Hand(String value, String bid) {
        this.value = value;
        this.bid = bid;

        parseType(value);
    }

    public Hand(String line) {
        String[] parts = line.split(" ");

        this.value = parts[0];
        this.bid = parts[1];

        parseType(value);
    }

    private void parseType(String str) {
        HashMap<Character, Integer> charCountMap = new HashMap<>();
        char[] charArray = str.toCharArray();

        for (char c : charArray) {
            if (charCountMap.containsKey(c)) {
                charCountMap.put(c, charCountMap.get(c) + 1);
            } else {
                charCountMap.put(c, 1);
            }
        }

        this.type = defineType(charCountMap);
    }

    private String defineType(HashMap<Character, Integer> charMap) {
        if (charMap.containsValue(5)) {
            return "Five";
        }
        if (charMap.containsValue(4)) {
            return "Four";
        }
        if (charMap.containsValue(3) && charMap.containsValue(2)) {
            return "FullHouse";
        }
        if (charMap.containsValue(3) && !charMap.containsValue(2)) {
            return "Three";
        }

        if (charMap.containsValue(2)) {
            int size = charMap.size();

            if (size == 4) {
                return "OnePair";
            }
            if (size == 3) {
                return "TwoPair";
            }
        } else if (charMap.containsValue(1)) {
            return "HighCard";
        }

        return "UndefinedType";
    }

    public String toString() {
        return "Value " + this.value + " Bid " + this.bid + " Type " + this.type;
    }
}