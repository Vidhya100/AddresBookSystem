namespace AddressBookSystem
{
    class Program
    {
        //creating list of contact
        public static List<Contact> contactList = new List<Contact>();
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Sytem.");

            //ability to creating contacts
            Contact contact1 = new Contact();
            contact1.firstName = "Vidhya";
            contact1.lastName = "Mundhe";
            contact1.address = "Jalna Maharashtra";
            contact1.phone = 1234567890;
            contact1.city = "Jalna";
            contact1.state = "Maharashtra";
            contact1.zipcode = 413515;
            contactList.Add(contact1);

        }
    }
}