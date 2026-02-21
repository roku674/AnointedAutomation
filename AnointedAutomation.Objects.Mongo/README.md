# AnointedAutomation.Objects.Mongo

A .NET library providing MongoDB-specific data models with BSON serialization attributes, extending the base AnointedAutomation.Objects classes.

## Overview

AnointedAutomation.Objects.Mongo provides MongoDB-specific versions of the core data models from AnointedAutomation.Objects. These classes add BSON attributes and MongoDB-specific serialization support while maintaining full compatibility with the base objects through inheritance.

## Installation

Install via NuGet:

```bash
dotnet add package AnointedAutomation.Objects.Mongo
```

## Features

- **MongoDB-Specific Models**: Classes with `[BsonId]` and `[BsonIgnoreExtraElements]` attributes
- **BSON Serialization**: Native MongoDB BSON serialization support
- **JObject Serialization**: Custom serializer for Newtonsoft.Json JObjects to BSON
- **Inheritance Pattern**: Extends base Objects classes, allowing seamless casting
- **Clean Separation**: Keeps MongoDB dependencies separate from base models

## Key Differences from AnointedAutomation.Objects

- Adds `[BsonId]` attribute to ID properties
- Adds `[BsonIgnoreExtraElements]` for flexible schema evolution
- Includes JObjectSerializer for JObject to BSON conversion
- Designed specifically for MongoDB persistence

## Core Models

### Account Namespace
- `MongoUser` - MongoDB-specific user with `[BsonId]` on UserId

### Utilities
- `JObjectSerializer` - Custom serializer for JObject to BSON conversion
- `BsonClassMapRegistrar` - Registers BSON class maps and global serializers (call once at startup)

## Usage Example

```csharp
using AnointedAutomation.Objects.Mongo.Account;
using MongoDB.Driver;

// Create a MongoDB-specific user
var mongoUser = new MongoUser
{
    UserId = Guid.NewGuid().ToString(),
    Email = "user@example.com",
    Username = "johndoe",
    createdDate = DateTime.UtcNow
};

// The MongoUser can be stored directly in MongoDB
// The UserId property is automatically used as the _id field
var collection = database.GetCollection<MongoUser>("users");
await collection.InsertOneAsync(mongoUser);

// Can also be used as base User type
User baseUser = mongoUser;
```

## Dependencies

- .NET 8.0
- MongoDB.Bson (3.6.0)
- Newtonsoft.Json (13.0.4)
- AnointedAutomation.Objects (project reference)

## License

Copyright © 2023 Anointed Automation, LLC. All rights reserved.

## Author

Created by Alexander Fields
