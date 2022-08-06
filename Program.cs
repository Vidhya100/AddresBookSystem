namespace AddressBookSystem
{
    class Program
    {
        //creating list of contact
        public static List<Contact> contactList = new List<Contact>();
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Sytem.");

            Console.WriteLine("Do you want to add new contact press 1 or press 2 to cancle.");
            int num = Convert.ToInt32(Console.ReadLine());

           
            while (num == 1)
            {
                Contact contact1 = new Contact();
                Console.WriteLine("Enter first name: ");
                contact1.firstName = Console.ReadLine();

                Console.WriteLine("Enter last name: ");
                contact1.lastName = Console.ReadLine();

                Console.WriteLine("Enter address: ");
                contact1.address = Console.ReadLine();

                Console.WriteLine("Enter city: ");
                contact1.city = Console.ReadLine();

                Console.WriteLine("Enter state: ");
                contact1.state = Console.ReadLine();

                Console.WriteLine("Enter phone: ");
                contact1.phone = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter email: ");
                contact1.email = Console.ReadLine();

                Console.WriteLine("Enter zipcode: ");
                contact1.zipcode = Convert.ToInt32(Console.ReadLine());


                contactList.Add(contact1);

                Console.WriteLine("Do you want to add anoter contact then press 1 or press 2 for exit ");
                num =Convert.ToInt32( Console.ReadLine());
            }
            Console.WriteLine("Total number of contact in address book:"+contactList.Count);

            foreach (Contact contact in contactList)
            {
                Console.WriteLine(contact.firstName);
            }

        }
    }
}