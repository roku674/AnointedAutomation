// Copyright © Anointed Automation, LLC., 2024. All Rights Reserved. Created by Alexander Fields https://www.alexanderfields.me

using AnointedAutomation.Objects.Account;
using MongoDB.Bson.Serialization;
using Newtonsoft.Json.Linq;

namespace AnointedAutomation.Objects.Mongo
{
    /// <summary>
    /// Registers BSON class maps for proper MongoDB serialization with inheritance.
    /// Call <see cref="RegisterClassMaps"/> once at application startup before any MongoDB operations.
    /// </summary>
    public static class BsonClassMapRegistrar
    {
        private static bool _isRegistered = false;
        private static readonly object _lock = new object();

        /// <summary>
        /// Registers all BSON class maps for the AnointedAutomation.Objects hierarchy.
        /// Thread-safe and idempotent - calling multiple times has no effect.
        /// </summary>
        public static void RegisterClassMaps()
        {
            if (_isRegistered)
            {
                return;
            }

            lock (_lock)
            {
                if (_isRegistered)
                {
                    return;
                }

                RegisterGlobalSerializers();
                RegisterUserClassMaps();

                _isRegistered = true;
            }
        }

        private static void RegisterGlobalSerializers()
        {
            // Register JObjectSerializer globally for all JObject properties
            // This handles Newtonsoft.Json JObject <-> MongoDB BSON conversion
            BsonSerializer.RegisterSerializer(typeof(JObject), new JObjectSerializer());
        }

        private static void RegisterUserClassMaps()
        {
            // Register base User class as root class first
            if (!BsonClassMap.IsClassMapRegistered(typeof(User)))
            {
                BsonClassMap.RegisterClassMap<User>(cm =>
                {
                    cm.AutoMap();
                    cm.SetIsRootClass(true);
                    cm.SetIgnoreExtraElements(true);
                });
            }

            // Register MongoUser - inherits from User
            if (!BsonClassMap.IsClassMapRegistered(typeof(Account.MongoUser)))
            {
                BsonClassMap.RegisterClassMap<Account.MongoUser>(cm =>
                {
                    cm.AutoMap();
                    cm.SetIgnoreExtraElements(true);
                    cm.MapIdMember(x => x.UserId);
                });
            }
        }
    }
}
