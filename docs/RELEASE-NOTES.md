# Release Notes

## 2.0.2 - 02 July 2020

Breaking changes:
- (None)

New features:
- (None)

Bug fixes:
- Build/package related fixes

## 2.0.1 - 02 July 2019

Breaking changes:
- (None)

New features:
- (None)

Bug fixes:
- Added public xml documentation

## 2.0.0 - 30 June 2019

Breaking changes:
- `PwnedPasswordsClient` now takes a simple string for the password (as the API only takes a hash of the password theres no need for the consumer to supply a HashedPassword object)
- `PwnedPasswordsClient` requires an implementation of `HttpClient` on construction

New features:
- Added `IPwnedPasswordsClient` interface
- `GetHasBeenPwnedAsync` method now takes optional CancellationToken

Bug fixes:
- (None)

## 1.0.1 - 19 April 2018

Initial version.
