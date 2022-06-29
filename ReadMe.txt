ReadMe - IP4ToGeolocation

This solutions provides code for hosting a Blazor based Server-Side App.

When running the server. The index page should be opened directly in the default browser of the running machine.

The project itself is constructed that way, that a MaxMind GeoLocation database is required (.mmdb-file).

Setup steps:

1. Have .Net6 installed.
2. Check MaxMind.GeoIP2 is installed in the NuGetManager.
3. Please create an account on maxmind.com and download the geolite2 city database. Dont forget to check the download for a valid checksum.
4. Place the db-file in a location of your choice. In my example i got a DB folder.
5. Adjust in the appsettings.json file the attribute "DbLocation" to matchup the correct path.
6. Build the application and run.



