The website begins with a login form containing fixed data (data from the .NET migration) that can be changed. There is a link to register a new user.

Upon login, the token is captured and stored locally for subsequent authentication and authorization requests. The home page displays a list of entries that can be edited, created, or deleted using the provided buttons. Deleting entries requires a user with administrator privileges (via the .NET API).

