using System;
using System.Collections.Generic;
using System.Text;

namespace Formulaires.Models
{
    public class Contact : IComparable
    {
        private static int Count = 0;
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Pseudo { get; set; }
        public int PhoneNumber { get; set; }
        public int AdditionalPhoneNumber { get; set; }
        public string Mail { get; set; }
        public string ImageUrl { get; set; }

        public Contact()
        {
            Count++;
            this.Id = Count;
        }

        public int CompareTo(object obj)
        {
            if(obj == null)
                return 1;
            Contact otherContact = obj as Contact;
            if (otherContact != null)
                return this.Name.CompareTo(otherContact.Name);
            else
                throw new ArgumentException("The argument is not a Contact");
        }
    }
}
