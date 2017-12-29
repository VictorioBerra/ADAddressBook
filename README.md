# AD Address Book
A sample app targetting netcoreapp2.0 that uses Novell.Directory.Ldap.NETStandard to search LDAP servers.

Works on Windows, Mac and Linux

## Screenshots
![Home](screenshots/home.png?raw=true "Home")

![Search](screenshots/search.png?raw=true "Search")

![Results](screenshots/results.png?raw=true "Results")

## Configuration
- See ADSettings in appsettings.json
- Modify `search()` in src\adaddressbook\services\adsearchservice.cs to change the filter settings
- Have fun!

## Sample LDAP server settings:
```
  "ADSettings": {
    "host": "ldap.forumsys.com",
    "port": 389,
    "ssl": true,
    "username": "cn=read-only-admin,dc=example,dc=com",
    "password": "password",
    "SearchBase": "dc=example,dc=com",
    "ResultAttributes": [
      "cn",
      "mail"
    ]
  }
```
- [Thanks Mamoon Yunus](https://www.forumsys.com/tutorials/integration-how-to/ldap/online-ldap-test-server/)

## License
MIT
