using System;
using System.Collections.Generic;

namespace ADAddressBook.Models
{
    public class SearchResultsViewModel
    {
        public SearchResultsViewModel()
        {
            Entries = new List<EntryViewModel>();
        }

        public List<EntryViewModel> Entries { get; set; }
    }

    public class EntryViewModel
    {
        public EntryViewModel()
        {
            entryAttrbiuteViewModel = new List<EntryAttrbiuteViewModel>();
        }

        public List<EntryAttrbiuteViewModel> entryAttrbiuteViewModel { get; set; }
    }

    public class EntryAttrbiuteViewModel
    {
        public string AttributeName { get; set; }

        public string AttributeValue { get; set; }
    }
}