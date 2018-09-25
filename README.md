[![NuGet Package](https://img.shields.io/nuget/v/ByteDev.PwnedPasswords.svg)](https://www.nuget.org/packages/ByteDev.PwnedPasswords)

# ByteDev.PwnedPasswords

Provides client functionality to talk to the pwnedpasswords API and check whether a particular password has been pwned and if so how many occurrences there have been.

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

The `PwnedPasswordsClient` class has (since v1.1) only one public method:

- **GetHasBeenPwnedAsync(HashedPassword hashedPassword)**

This methods will return a `PwnedPasswordResponse` object containing details of whether the password has been pwned and a count of how many times.

If the `PwnedPasswordsClient` class has any problems getting the details for a password it will throw an `PwnedPasswordsClientException`.

### Example

```c#
var hashedPassword = new HashedPassword("12345");

var client = new PwnedPasswordsClient();

var result = await client.GetHasBeenPwnedAsync(hashedPassword);

Console.WriteLine($"Has Password been pwned: {result.IsPwned}");
Console.WriteLine($"Password has been pwned {result.Count} times.");
```

## Changes in v1.1

There used to be 3 different ways you could call the API:

1. Search with clear text password
2. Search with SHA1 hash of password
3. Search with partial SHA1 hash of password

However, as of 1st June 2018 the API will be changed to only support option 3 (partial hash).  Version 1.1 of this project now only supports partial hash searches.

## Further information

See the following for more general information:

- [PwnedPasswords API details](https://haveibeenpwned.com/API/v2#PwnedPasswords)
- [Troy Hunt blog post - Pwned Passwords v2](https://www.troyhunt.com/ive-just-launched-pwned-passwords-version-2/)

See the following to changes to the API to only support partial hash (range) only searches:

- [Enhancing Pwned Passwords Privacy by Exclusively Supporting Anonymity](https://www.troyhunt.com/enhancing-pwned-passwords-privacy-by-exclusively-supporting-anonymity/)
 