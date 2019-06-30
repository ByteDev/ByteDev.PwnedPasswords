[![Build status](https://ci.appveyor.com/api/projects/status/github/bytedev/ByteDev.PwnedPasswords?branch=master&svg=true)](https://ci.appveyor.com/project/bytedev/ByteDev-PwnedPasswords/branch/master)
[![NuGet Package](https://img.shields.io/nuget/v/ByteDev.PwnedPasswords.svg)](https://www.nuget.org/packages/ByteDev.PwnedPasswords)

![Logo](https://raw.githubusercontent.com/bytedev/ByteDev.PwnedPasswords/master/images/icon.png)

# ByteDev.PwnedPasswords

Provides client functionality to talk to Troy Hunt's Pwnedpasswords API and check whether a particular password has been pwned and if so how many occurrences there have been.

## Installation

ByteDev.PwnedPasswords has been written as a .NET Standard 2.0 library, so you can consume it from a .NET Core or .NET Framework 4.6.1 (or greater) application.

ByteDev.PwnedPasswords is hosted as a package on nuget.org.  To install from the Package Manager Console in Visual Studio run:

`Install-Package ByteDev.PwnedPasswords`

Further details can be found on the [nuget page](https://www.nuget.org/packages/ByteDev.PwnedPasswords/).

## Code

The repo can be cloned from git bash:

`git clone https://github.com/ByteDev/ByteDev.PwnedPasswords`

Unit tests and integration tests are also provided in the solution.

## Usage

The `PwnedPasswordsClient` class has two public methods:

- **GetHasBeenPwnedAsync(string password)**
- **GetHasBeenPwnedAsync(string password, CancellationToken cancellationToken)**

This methods will return a `PwnedPasswordResponse` object containing details of whether the password has been pwned and a count of how many times.

If the `PwnedPasswordsClient` class has any problems getting the details for a password it will throw an `PwnedPasswordsClientException`.

### Example

```c#
var client = new PwnedPasswordsClient(new HttpClient());

var result = await client.GetHasBeenPwnedAsync("Password1");

Console.WriteLine($"Has Password been pwned: {result.IsPwned}");
Console.WriteLine($"Password has been pwned {result.Count} times.");
```

### Version 2.0 changes

A number of breaking changes were made from version 1.1. to 2.0:

- PwnedPasswordsClient now takes a simple string for the password (as the API only takes a hash of the password theres no need for the consumer to supply a HashedPassword object)
- IPwnedPasswordsClient interface now provided
- PwnedPasswordsClient needs to be provided with an implementation of HttpClient on construction
- PwnedPasswordsClient.GetHasBeenPwnedAsync method now takes optional CancellationToken

## Further information

See the following for more general information:

- [PwnedPasswords API details](https://haveibeenpwned.com/API/v2#PwnedPasswords)
- [Troy Hunt blog post - Pwned Passwords v2](https://www.troyhunt.com/ive-just-launched-pwned-passwords-version-2/)

See the following to changes to the API to only support partial hash (range) only searches:

- [Enhancing Pwned Passwords Privacy by Exclusively Supporting Anonymity](https://www.troyhunt.com/enhancing-pwned-passwords-privacy-by-exclusively-supporting-anonymity/)
 