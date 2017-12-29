using Microsoft.Extensions.Options;
using Novell.Directory.Ldap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADAddressBook.Services
{
    public class ADSearchService
    {
        private LdapConnection _cn;
        private IOptions<ADSettings> _ADSettings;

        public ADSearchService(IOptions<ADSettings> ADSettings, LdapConnection ldapConnection)
        {
            this._cn = ldapConnection;
            this._ADSettings = ADSettings;
        }
        

        public LdapSearchResults Search(string username)
        {
            _cn.Connect(_ADSettings.Value.host, _ADSettings.Value.port);
            _cn.SecureSocketLayer = _ADSettings.Value.ssl;
            _cn.Bind(_ADSettings.Value.username, _ADSettings.Value.password);

            var @base = _ADSettings.Value.SearchBase;
            var filter = $"(|(uid=*{username}*)(displayName=*{username}*)(cn=*{username}*)(sn=*{username}*))";

            return _cn.Search(@base, LdapConnection.SCOPE_SUB, filter, new string[] { "cn", "mail" }, false);
        }
    }
}
