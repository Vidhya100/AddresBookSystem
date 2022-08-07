namespace AddressBookSystem
{
    class Program
    {
        public static void FillingDetails(Contact contact)
        {
            Console.WriteLine("Enter first name: ");
            contact.firstName = Console.ReadLine();

            Console.WriteLine("Enter last name: ");
            contact.lastName = Console.ReadLine();

            Console.WriteLine("Enter address: ");
            contact.address = Console.ReadLine();

            Console.WriteLine("Enter city: ");
            contact.city = Console.ReadLine();

            Console.WriteLine("Enter state: ");
            contact.state = Console.ReadLine();

            Console.WriteLine("Enter phone: ");
            contact.phone = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter email: ");
            contact.email = Console.ReadLine();

            Console.WriteLine("Enter zipcode: ");
            contact.zipcode = Convert.ToInt32(Console.ReadLine());
        }

        public static void CreatingContacts()
        {
            Console.WriteLine("Do you want to add new contact press 1 or press 2 to cancle.");
            int num = Convert.ToInt32(Console.ReadLine());


            while (num == 1)
            {
                Contact contact = new Contact();
                FillingDetails(contact);
                contactList.Add(contact);

                Console.WriteLine("Do you want to add anoter contact then press 1 or press 2 for exit ");
                num = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("=============================================================");
            Console.WriteLine("Total number of contact in address book:" + contactList.Count);
        }

        public static void DisplayContacts()
        {
            //print contacts

            Console.WriteLine("=============================================================");
            Console.WriteLine("Current contacts in adress book:");

            foreach (Contact contact in contactList)
            {
                Console.WriteLine(contact.firstName);
            }
            Console.WriteLine("=============================================================");

        }

        public static void EditContacts()
        {
            Console.WriteLine("Do you want to edit contact details then press 1 or pres 2 for continue: ");
            int num = Convert.ToInt32(Console.ReadLine());
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
                        FillingDetails(contactList[i]);
                        break;

                    }
                } //end of for loop
                if (!found)
                    Console.WriteLine("the contact with given person {0} is not in address book", firstName);
                //print contacts
                DisplayContacts();
                Console.WriteLine("Do you want to edit contact press 1 to edit or press 2 to cancle.");
                num = Convert.ToInt32(Console.ReadLine());
            }//while loop end

        }

        public static void DeleteContacts()
        {
            //deleting contact
            Console.WriteLine("Do you want to delete contact press 1 to delete or press 2 to cancle.");
            int num = Convert.ToInt32(Console.ReadLine());

            while (num == 1 && contactList.Count > 0)
            {
                Console.WriteLine("Enter contact First name");
                string firstName = Console.ReadLine();

                bool found = false;
                for (int i = 0; i < contactList.Count; i++)
                {

                    if (contactList[i].firstName == firstName)
                    {
                        found = true;  //found the contact

                        contactList.RemoveAt(i);
                        break;

                    }
                }

                if (found)
                {
                    if (contactList.Count == 0) //if size 0 nothing to delete further
                        break;
                }
                else
                    Console.WriteLine("the contact with given person '{0}' is not in address book", firstName);
                //displaying contacts
                DisplayContacts();
                Console.WriteLine("Do you want to delete contact press 1 to delete or press 2 to cancle.");
                num = Convert.ToInt32(Console.ReadLine());

            }//while end
        }

        //creating list of contact
        public static List<Contact> contactList = new List<Contact>();
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Sytem.");

            CreatingContacts();
            DisplayContacts();
            EditContacts();
            DeleteContacts();            
        }
    }
}