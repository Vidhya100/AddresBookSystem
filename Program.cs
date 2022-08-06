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
                num = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Total number of contact in address book:"+contactList.Count);

            //print contacts
            Console.WriteLine("Current contacts in adress book:");

            foreach (Contact contact in contactList)
            {
                Console.WriteLine(contact.firstName);
            }

            Console.WriteLine("Do you want to edit contact details then press 1 or pres 2 for continue: ");
            num = Convert.ToInt32( Console.ReadLine());

            while (num == 1)
            {
                Console.WriteLine("Enter first name to edit details: ");
                string firstName = Console.ReadLine();
                bool found = false;
                for (int i = 0; i < contactList.Count; i++)
                {

                    if (contactList[i].firstName == firstName)
                    {
                        found = true;  //found the contact

                        //now editing...
                        Console.WriteLine("Enter first name: ");
                        contactList[i].firstName = Console.ReadLine();

                        Console.WriteLine("Enter last name: ");
                        contactList[i].lastName = Console.ReadLine();

                        Console.WriteLine("Enter address: ");
                        contactList[i].address = Console.ReadLine();

                        Console.WriteLine("Enter city: ");
                        contactList[i].city = Console.ReadLine();

                        Console.WriteLine("Enter state: ");
                        contactList[i].state = Console.ReadLine();

                        Console.WriteLine("Enter phone: ");
                        contactList[i].phone = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter email: ");
                        contactList[i].email = Console.ReadLine();

                        Console.WriteLine("Enter zipcode: ");
                        contactList[i].zipcode = Convert.ToInt32(Console.ReadLine());
                        break;

                    }
                } //end of for loop
                if (!found)
                    Console.WriteLine("the contact with given person {0} is not in address book", firstName);
                //print contacts
                Console.WriteLine("Current contacts in adress book");
                foreach (Contact contact in contactList)
                {
                    Console.WriteLine(contact.firstName);
                }
                Console.WriteLine("Do you want to edit contact press 1 to edit or press 2 to cancle.");
                 num = Convert.ToInt32(Console.ReadLine());
            }//while loop end
        }
    }
}