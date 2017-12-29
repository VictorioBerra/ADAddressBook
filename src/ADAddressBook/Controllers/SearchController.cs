using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ADAddressBook.Models;
using Microsoft.Extensions.Options;
using ADAddressBook.Services;

namespace ADAddressBook.Controllers
{
    public class SearchController : Controller
    {
        private readonly ADSearchService _ADSearchService;

        public SearchController(ADSearchService ADSearchService)
        {
            this._ADSearchService = ADSearchService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username)
        {
            //var results = _ADSearchService.Search(username);

            var entries = _ADSearchService.Search(username);

            SearchResultsViewModel vm = new SearchResultsViewModel();
            vm.Entries = entries.Select(x => new EntryResultViewModel()
            {
                cn = x.getAttribute("cn").StringValue,
                mail = x.getAttribute("mail").StringValue
            }).ToList();

            return View(nameof(SearchController.Results), vm);
        }

        public IActionResult Results()
        {
            return View();
        }
    }
}
