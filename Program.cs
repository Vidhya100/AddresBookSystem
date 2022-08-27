using System.Collections;
using System.Globalization;
using CsvHelper;
using Newtonsoft.Json;

namespace AddressBookSystem
{
    class Program
    {

        public static void WriteToJsonFile()
        {
            string path = @"..\..\..\Contact.json";

            foreach (var book in addressBookSystem.Values)
            {
                string jsonData = JsonConvert.SerializeObject(book);
               
                File.WriteAllText(path, jsonData);
            }

            Console.WriteLine("wrote contact jason file");
        }
        public static void ReadJsonFile()
        {
            string path = @"..\..\..\Contact.json";
            string jsonData = File.ReadAllText(path);
            if (jsonData != null || jsonData.Equals(String.Empty))
            {
                var jsonResult = JsonConvert.DeserializeObject<List<Contact>>(jsonData).ToList();
                Console.WriteLine("Reading from Json file");
                foreach (var item in jsonResult)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        public static void WriteToCsvFile()
        {
            string path = @"..\..\..\Contact.csv";
            using (StreamWriter sw = File.CreateText(path))
            {
                CsvWriter cw = new CsvWriter(sw, CultureInfo.InvariantCulture);
                Console.WriteLine("Creating and writing into Contact CSV file");
                //While writing Contact first row is always property Names then all values of list
                foreach (var book in addressBookSystem.Values)
                {
                    cw.WriteRecords<Contact>(book);
                }
                Console.WriteLine("Done writing");
            }
        }

        public static void ReadCsvFile()
        {
            string path = @"..\..\..\Contact.csv";
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    CsvReader cr = new CsvReader(sr, CultureInfo.InvariantCulture);
                    
                    //while reading file first row should be property names rest rows should be values to create objects
                    List<Contact> readResult = cr.GetRecords<Contact>().ToList();
                    Console.WriteLine("Reading from Contact CSV file");

                    //displaying read object
                    foreach (var item in readResult)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
               
            }
            else
                Console.WriteLine("Contact.csv file doenot exists");
        }

        //uc13
        public static void WriteToFile()
        {
            string path = @"..\..\..\Contact.txt";

            using (StreamWriter sw = File.CreateText(path))
            {
                foreach (var kv in addressBookSystem)
                {
                    foreach(var contact in kv.Value)
                        sw.WriteLine(contact.ToString());
                }
            }
        }
        public static void SortByCityAndStateOrZip()
        {
            Console.WriteLine("Do you want to sort contact then press 1 for yes and 2 for no ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            while (num1 == 1)
            {
                Console.WriteLine("Press following keys for sort : ");
                Console.WriteLine("press 1 for City: ");
                Console.WriteLine("press 2 for State");
                Console.WriteLine("press 3 for Zipcode: ");
                Console.WriteLine("press any key for Exit");

                int num = Convert.ToInt32(Console.ReadLine());
                List<Contact> sort = new List<Contact>();
                switch (num)
                {
                    case 1:
                        foreach (var kv in addressBookSystem)
                        {
                            var list = kv.Value.OrderBy(x => x.city).ToList();
                            sort.AddRange(list);
                        }
                        DisplayContactsByName(sort);

                        Console.WriteLine("===============================");
                        break;
                    case 2:
                        foreach (var kv in addressBookSystem)
                        {
                            var list = kv.Value.OrderBy(x => x.state).ToList();
                            sort.AddRange(list);
                        }
                        DisplayContactsByName(sort);

                        Console.WriteLine("===============================");
                        break;
                    case 3:
                        foreach (var kv in addressBookSystem)
                        {
                            var list = kv.Value.OrderBy(x => x.zipcode).ToList();
                            sort.AddRange(list);
                        }
                        DisplayContactsByName(sort);

                        Console.WriteLine("===============================");
                        break;

                }
            }            
        }
        public static void SortByName()
        {
            Console.WriteLine("Do you want to sort contact using firstname then press 1 or press 2 for exit ");
            int num = Convert.ToInt32(Console.ReadLine());

            List<Contact> sort = new List<Contact>();
            foreach (var kv in addressBookSystem)
            {
                var list = kv.Value.OrderBy(x => x.firstName).ToList();
                sort.AddRange(list);
            }
            DisplayContactsByName(sort);

            Console.WriteLine("===============================");
        }
        public static void DisplayContactsByName(List<Contact> sort)
        {
            //print contacts

            
            Console.WriteLine("Current contacts in adress book:");

            foreach (Contact contact in sort)
            {
                Console.WriteLine(contact.firstName);
            }
            Console.WriteLine("=============================================================");

        }
        public static void ShowCountofContactsbyCityandState()
        {
            Console.WriteLine("Enter city name to show counts in that city");
            string icity = Console.ReadLine();

            if (cityDict.ContainsKey(icity))
                Console.WriteLine("number of contacts in city {0} are {1}", icity, cityDict[icity].Count);
            else
                Console.WriteLine("number of contacts in city {0} are zero", icity);


            Console.WriteLine("Enter state name to show counts in that state");
            icity = Console.ReadLine();

            if (stateDict.ContainsKey(icity))
                Console.WriteLine("number of contacts in state {0} are {1}", icity, stateDict[icity].Count);
            else
                Console.WriteLine("number of contacts in state {0} are zero", icity);

        }
        public static void FilterByCityAndState()
        {

            foreach (var kv in addressBookSystem)
            {
                foreach (Contact contact in kv.Value)
                {
                    // City filtering

                    //check city is added into city dictionary?
                    if (cityDict.ContainsKey(contact.city))
                    {
                        //add contact entry into exiting key- value (city-contacts) list
                        cityDict[contact.city].Add(contact);

                    }
                    else
                    {
                        //adding new entery of city  key-value pair
                        cityDict.Add(contact.city, new List<Contact>());
                        //adding contact entry into created key city
                        cityDict[contact.city].Add(contact);
                    }

                    //state filtering

                    //check state is added into state dictionary?
                    if (stateDict.ContainsKey(contact.state))
                    {
                        //add contact entry into exiting key- value (city-contacts) list
                        stateDict[contact.state].Add(contact);

                    }
                    else
                    {
                        //adding new entery of city
                        stateDict.Add(contact.state, new List<Contact>());
                        stateDict[contact.state].Add(contact);
                    }
                }
            }

            DisplayDictionary(cityDict);
            DisplayDictionary(stateDict);

        }

        public static void SearchByCityOrState()
        {

            Console.WriteLine("Do you want to search city or state for contact then press 1 or press 2 for exit ");
            int num = Convert.ToInt32(Console.ReadLine());
            while (num == 1)
            {
                List<Contact> tempcontacts = new List<Contact>();
                Console.WriteLine("Enter the city or state to search :");
                string iCity = Console.ReadLine();

                foreach (var kv in addressBookSystem)
                {
                    var list = kv.Value.Where(x => x.city.Equals(iCity)).ToList();
                    tempcontacts.AddRange(list);
                }
                Console.WriteLine("Here are found persons : ");
                foreach (Contact contact in tempcontacts)
                {
                    Console.WriteLine(contact.firstName);
                }
                Console.WriteLine("Do you want to search city or state for contact then press 1 or press 2 for exit ");
                num = Convert.ToInt32(Console.ReadLine());
            }
        }
        public static bool FillingDetails(Contact contact, List<Contact> contacts)
        {
            Console.WriteLine("Enter first name: ");
            string tempFirstname = Console.ReadLine();


            if (CheckDuplicate(contacts, tempFirstname))
            {
                return false;
            }
            contact.firstName = tempFirstname;

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
            return true;
        }

        public static void CreatingContacts(List<Contact> contacts)
        {
            Console.WriteLine("Do you want to add new contact press 1 or press 2 to cancle.");
            int num = Convert.ToInt32(Console.ReadLine());


            while (num == 1)
            {
                Contact contact = new Contact();

                if (FillingDetails(contact, contacts))
                    contacts.Add(contact);

                Console.WriteLine("Do you want to add anoter contact then press 1 or press 2 for exit ");
                num = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("=============================================================");
            Console.WriteLine("Total number of contact in address book:" + contacts.Count);
        }

        public static bool CheckDuplicate(List<Contact> contacts, string firstName)
        {

            //Any will check for duplicate same firstnamename in database
            if (contacts.Count > 0)
            {

                if (contacts.Any(x => x.firstName.Equals(firstName)))
                {
                    Console.WriteLine("Already exist in database");
                    return true;
                }


            }
            return false;
        }
        public static void DisplayContacts(List<Contact> contacts)
        {
            //print contacts

           
            Console.WriteLine("Current contacts in adress book:");

            foreach (Contact contact in contacts)
            {
                Console.WriteLine(contact.firstName);
            }
            Console.WriteLine("=============================================================");

        }

        public static void EditContacts(List<Contact> contacts)
        {
            Console.WriteLine("Do you want to edit contact details then press 1 or pres 2 for continue: ");
            int num = Convert.ToInt32(Console.ReadLine());
            while (num == 1)
            {
                Console.WriteLine("Enter first name to edit details: ");
                string firstName = Console.ReadLine();
                bool found = false;
                for (int i = 0; i < contacts.Count; i++)
                {

                    if (contacts[i].firstName == firstName)
                    {
                        found = true;  //found the contact

                        //now editing...
                        if (!FillingDetails(contacts[i], contacts)) ;
                        Console.WriteLine("Name is available in database");
                        break;

                    }
                } //end of for loop
                if (!found)
                    Console.WriteLine("the contact with given person {0} is not in address book", firstName);
                //print contacts
                DisplayContacts(contacts);
                Console.WriteLine("Do you want to edit contact press 1 to edit or press 2 to cancle.");
                num = Convert.ToInt32(Console.ReadLine());
            }//while loop end

        }

        public static void DeleteContacts(List<Contact> contacts)
        {
            //deleting contact
            Console.WriteLine("Do you want to delete contact press 1 to delete or press 2 to cancle.");
            int num = Convert.ToInt32(Console.ReadLine());

            while (num == 1 && contacts.Count > 0)
            {
                Console.WriteLine("Enter contact First name");
                string firstName = Console.ReadLine();

                bool found = false;
                for (int i = 0; i < contacts.Count; i++)
                {

                    if (contacts[i].firstName == firstName)
                    {
                        found = true;  //found the contact

                        contacts.RemoveAt(i);
                        break;

                    }
                }

                if (found)
                {
                    if (contacts.Count == 0) //if size 0 nothing to delete further
                        break;
                }
                else
                    Console.WriteLine("the contact with given person '{0}' is not in address book", firstName);
                //displaying contacts
                DisplayContacts(contacts);
                Console.WriteLine("Do you want to delete contact press 1 to delete or press 2 to cancle.");
                num = Convert.ToInt32(Console.ReadLine());

            }//while end
        }

        public static void DisplayDictionary(Dictionary<string, List<Contact>> dict)
        {
            Console.WriteLine("Diplay current data in dictionary: ");
            foreach (KeyValuePair<string, List<Contact>> obj in dict)
            {
                Console.WriteLine("Displaying contacts of {0}", obj.Key);
                DisplayContacts(obj.Value);
                Console.WriteLine("===============================================");
            }
        }
        public static void CreateAddresBook()
        {
            Console.WriteLine("Do you want to create new AddressBook press 1 for yes or 2 for no:");
            int num = Convert.ToInt32(Console.ReadLine());


            while (num == 1)
            {
                Console.WriteLine("Please enter a name of addressbook:");
                string name = Console.ReadLine();
                //creating list of contact
                List<Contact> addressBook = new List<Contact>();
                addressBookSystem.Add(name, addressBook);

                CreatingContacts(addressBook);

                if (addressBook.Count > 0)
                {
                    EditContacts(addressBook);
                    DeleteContacts(addressBook);
                }

                DisplayDictionary(addressBookSystem);

                Console.WriteLine("Do you want to create another addressbook press 1 or press 2 for exit:");
                num = Convert.ToInt32(Console.ReadLine());
            }
        }



        public static Dictionary<string, List<Contact>> addressBookSystem = new Dictionary<string, List<Contact>>();
        public static Dictionary<String, List<Contact>> cityDict = new Dictionary<string, List<Contact>>();
        public static Dictionary<String, List<Contact>> stateDict = new Dictionary<string, List<Contact>>();

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Sytem.");
            try
            {
                CreateAddresBook();
                DisplayDictionary(addressBookSystem);
                //DisplayContacts();
                //SearchByCityOrState();
                //FilterByCityAndState();
                //ShowCountofContactsbyCityandState();
                //SortByName();
                // WriteToFile();
               // WriteToCsvFile();
               // ReadCsvFile();
                WriteToJsonFile();
                ReadJsonFile();

            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message); 
            }
        }
    }
}