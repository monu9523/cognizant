public class FactoryMethodPatternTest {

    public static void main(String[] args) {

        System.out.println("=== Creating a Word Document ===");
        DocumentFactory wordFactory = new WordDocumentFactory();
        wordFactory.processDocument();

        System.out.println("\n=== Creating a PDF Document ===");
        DocumentFactory pdfFactory = new PdfDocumentFactory();
        pdfFactory.processDocument();

        System.out.println("\n=== Creating an Excel Document ===");
        DocumentFactory excelFactory = new ExcelDocumentFactory();
        excelFactory.processDocument();

        System.out.println("\n=== Demonstrating Direct Creation ===");
        Document doc = getDocumentFromFactory("pdf");
        doc.open();
        doc.close();
    }

    private static Document getDocumentFromFactory(String type) {
        DocumentFactory factory = switch (type.toLowerCase()) {
            case "word" -> new WordDocumentFactory();
            case "pdf" -> new PdfDocumentFactory();
            case "excel" -> new ExcelDocumentFactory();
            default -> throw new IllegalArgumentException("Unknown document type: " + type);
        };
        return factory.createDocument();
    }
}
