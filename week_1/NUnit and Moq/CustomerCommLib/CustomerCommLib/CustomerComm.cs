namespace CustomerCommLib
{
    public class CustomerComm
    {
        private readonly IMailSender _mailSender;

        public CustomerComm(IMailSender mailSender)
        {
            _mailSender = mailSender;
        }

        public bool SendMailToCustomer()
        {
            // Actual business logic goes here
            string toAddress = "singhroshni3211@gmail.com";
            string message = "this is a test message";

            return _mailSender.SendMail(toAddress, message);
        }
    }
}