# WordCounter

![.NET Core](https://github.com/backsapc/WordCounter/workflows/.NET%20Core/badge.svg)

A word counter console program that supports 3 kind of input sources and output sinks.

This program supports 3 input types: 
1. Console
2. File
3. Database

First 2 are quite simple to use, the third one requires a bit of configuration.

You can choose from 3 types of databases:
1. MSSQL
2. PostgreSQL,
3. In-Memory.

The connection string will not be tested before saving the results, so it depends on you how to verify it.
The data will be read from ProcessTexts table of database. The schema must be:

| Column        | Type          |
| ------------- |:-------------:|
| Id            | int           |
| Text          | varchar       |

Same restriction apply to output database sink.

Thanks for your interest.
