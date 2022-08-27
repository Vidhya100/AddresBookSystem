using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class Contact
    {
        public string firstName;
        public string lastName;
        public string address;
        public int phone;
        public string city;
        public string state;
        public int zipcode;
        public string email;
        public override string ToString()
        {
            return String.Format("First Name: {0}, Last Name {1}, Adress: {2}, phone: {3}, city: {4}, state: {5}, zipcode: {6}, email: {7}",
                                              firstName, lastName, address, phone, city, state, zipcode, email);
        }
    }
}
