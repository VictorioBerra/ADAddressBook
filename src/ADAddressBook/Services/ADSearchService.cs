using Microsoft.Extensions.Options;
using Novell.Directory.Ldap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADAddressBook.Services
{
    public class ADSearchService : IDisposable
    {
        private LdapConnection _cn;
        private IOptions<ADSettings> _ADSettings;

        public ADSearchService(IOptions<ADSettings> ADSettings, LdapConnection ldapConnection)
        {
            this._cn = ldapConnection;
            this._ADSettings = ADSettings;

            _cn.Connect(ADSettings.Value.host, ADSettings.Value.port);

            _cn.SecureSocketLayer = ADSettings.Value.ssl;

            _cn.Bind(ADSettings.Value.username, ADSettings.Value.password);
        }
        

        public LdapSearchResults Search(string username)
        {
            var @base = _ADSettings.Value.SearchBase;
            var filter = $"(|(uid=*{username}*)(displayName=*{username}*)(cn=*{username}*)(sn=*{username}*))";

            return _cn.Search(@base, LdapConnection.SCOPE_SUB, filter, new string[] { "cn", "mail" }, false);
        }

        public void Dispose()
        {
            _cn.Dispose();
        }
    }
}
