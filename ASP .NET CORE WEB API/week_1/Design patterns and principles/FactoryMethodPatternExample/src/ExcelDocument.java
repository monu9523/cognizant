public class ExcelDocument implements Document {

    public ExcelDocument() {
        System.out.println("ExcelDocument created.");
    }

    @Override
    public void open() {
        System.out.println("Opening Excel document...");
    }

    @Override
    public void save() {
        System.out.println("Saving Excel document as .xlsx");
    }

    @Override
    public void close() {
        System.out.println("Closing Excel document.");
    }
}
