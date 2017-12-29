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
        private readonly IOptions<ADSettings> _ADSettings;

        public SearchController(ADSearchService ADSearchService, IOptions<ADSettings> ADSettings)
        {
            this._ADSearchService = ADSearchService;
            this._ADSettings = ADSettings;
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

            if (entries.Count > 0)
            {
                foreach (var entry in entries)
                {
                    var entryVm = new EntryViewModel();

                    foreach (var attribute in _ADSettings.Value.ResultAttributes)
                    {
                        entryVm.entryAttrbiuteViewModel.Add(new EntryAttrbiuteViewModel()
                        {
                            AttributeName = attribute,
                            AttributeValue = entry.getAttribute(attribute).StringValue
                        });
                    }

                    vm.Entries.Add(entryVm);
                }
            }

            return View(nameof(SearchController.Results), vm);
        }

        public IActionResult Results()
        {
            return View();
        }
    }
}
