using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Formulaires.Models
{
    public class ContactsGroup : List<Contact>, IComparable
    {
        public string Title { get; set; }
        public string ShortTitle { get; set; }
        public ContactsGroup(string title, string shortTitle)
        {
            Title = title;
            ShortTitle = shortTitle;
        }

        public int CompareTo(object obj)
        {
            if(obj == null)
                return 1;
            ContactsGroup other = obj as ContactsGroup;
            if (other != null)
                return this.Title.CompareTo(other.Title);
            else
                throw new ArgumentException("The object passed as parameter is not of type ContactGroup");
        }
    }
}
