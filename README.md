# README #

### What is this repository for? ###

* A basic C# wrapper for the Gracenote music database web API. Currently supports ALBUM_TOC and ALBUM_FETCH lookups. Does not currently support extended options.
* Version 1.0

### How do I get set up? ###

* This project contains the wrapper itself(API), basic tests(API.Tests), and a basic example client application(Client). 
* Before you can run the tests or example client you must obtain a clientID from developer.gracenote.com/ and insert it into the respective projects
Additionally, to run the test project you must obtain a userID. The easiest way to do this is to run the example client and take the userID from the file
that it generates.