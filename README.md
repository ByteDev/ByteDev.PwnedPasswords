[![Build status](https://ci.appveyor.com/api/projects/status/github/bytedev/ByteDev.PwnedPasswords?branch=master&svg=true)](https://ci.appveyor.com/project/bytedev/ByteDev-PwnedPasswords/branch/master)
[![NuGet Package](https://img.shields.io/nuget/v/ByteDev.PwnedPasswords.svg)](https://www.nuget.org/packages/ByteDev.PwnedPasswords)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/ByteDev/ByteDev.PwndedPasswords/blob/master/LICENSE)

# ByteDev.PwnedPasswords

.NET Standard library that provides client SDK functionality to talk to Troy Hunt's Pwnedpasswords API and check whether a particular password has been pwned and if so how many occurrences there have been.

## Installation

ByteDev.PwnedPasswords has been written as a .NET Standard 2.0 library, so you can consume it from a .NET Core or .NET Framework 4.6.1 (or greater) application.

ByteDev.PwnedPasswords is hosted as a package on nuget.org.  To install from the Package Manager Console in Visual Studio run:

`Install-Package ByteDev.PwnedPasswords`

Further details can be found on the [nuget page](https://www.nuget.org/packages/ByteDev.PwnedPasswords/).

## Release Notes

Releases follow semantic versioning.

Full details of the release notes can be viewed on [GitHub](https://github.com/ByteDev/ByteDev.PwnedPasswords/blob/master/docs/RELEASE-NOTES.md).

## Usage

The `PwnedPasswordsClient` class has two public methods:

- **GetHasBeenPwnedAsync(string password)**
- **GetHasBeenPwnedAsync(string password, CancellationToken cancellationToken)**

These methods will return a `PwnedPasswordResponse` object containing details of whether the password has been pwned and a count of how many times.

If the `PwnedPasswordsClient` class has any problems getting the details for a password it will throw an `PwnedPasswordsClientException`.

```csharp
IPwnedPasswordsClient client = new PwnedPasswordsClient(new HttpClient());

PwnedPasswordResponse response = await client.GetHasBeenPwnedAsync("Password1");

Console.WriteLine($"Has Password been pwned: {response.IsPwned}.");
Console.WriteLine($"Password has been pwned {response.Count} times.");
```

## Further information

See the following for more general information:

- [PwnedPasswords API details](https://haveibeenpwned.com/API/v2#PwnedPasswords)
- [Troy Hunt blog post - Pwned Passwords v2](https://www.troyhunt.com/ive-just-launched-pwned-passwords-version-2/)

See the following to changes to the API to only support partial hash (range) only searches:

- [Enhancing Pwned Passwords Privacy by Exclusively Supporting Anonymity](https://www.troyhunt.com/enhancing-pwned-passwords-privacy-by-exclusively-supporting-anonymity/)
 