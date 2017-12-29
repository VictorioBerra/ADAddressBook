using System;
using System.Collections.Generic;

namespace ADAddressBook.Models
{
    public class SearchResultsViewModel
    {
        public List<EntryResultViewModel> Entries { get; set; }
    }

    public class EntryResultViewModel
    {
        public string cn { get; set; }

        public string mail { get; set; }
    }
}