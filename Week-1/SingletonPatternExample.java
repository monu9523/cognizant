public class SingletonPatternExample {

    public static void main(String[] args) {

        // Both variables point to the same object
        Logger logger1 = Logger.getInstance();
        Logger logger2 = Logger.getInstance();
        Logger logger3 = Logger.getInstance();

        // Test 1: Use the logger
        logger1.log("Application started");
        logger2.log("User logged in");
        logger3.log("Data fetched successfully");

        // Test 2: Verify same instance using == (compares object references)
        System.out.println("\n--- Identity Check ---");
        System.out.println("logger1 == logger2 : " + (logger1 == logger2));  // true
        System.out.println("logger2 == logger3 : " + (logger2 == logger3));  // true

        // Test 3: Verify using hashCode (same object = same hash)
        System.out.println("\n--- Hash Code Check ---");
        System.out.println("logger1 hashCode: " + logger1.hashCode());
        System.out.println("logger2 hashCode: " + logger2.hashCode());
        System.out.println("logger3 hashCode: " + logger3.hashCode());
    }
}