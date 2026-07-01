public abstract class DocumentFactory {

    // The Factory Method - subclasses decide which Document to instantiate.
    public abstract Document createDocument();

    // A template method that uses the factory method.
    public void processDocument() {
        Document document = createDocument();
        document.open();
        document.save();
        document.close();
    }
}
