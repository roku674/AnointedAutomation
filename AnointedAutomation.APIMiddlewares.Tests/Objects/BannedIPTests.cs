// Copyright © Anointed Automation, LLC., 2025. All Rights Reserved. Created by Alexander Fields https://www.alexanderfields.me on 2025-06-08 13:27:40
// Edited by Alexander Fields https://www.alexanderfields.me 2025-07-02 11:48:25
using Xunit;
using AnointedAutomation.APIMiddleware.Objects;

namespace AnointedAutomation.APIMiddlewares.Tests.Objects
{
    public class BannedIPTests
    {
        [Fact]
        public void DefaultConstructor_CreatesInstance()
        {
            // Act
            var bannedIP = new BannedIP();

            // Assert
            Assert.NotNull(bannedIP);
            Assert.Null(bannedIP._id);
            Assert.Null(bannedIP.ipv4);
            Assert.Null(bannedIP.ipv6);
            Assert.Null(bannedIP.reason);
        }

        [Fact]
        public void Constructor_WithIPAddresses_SetsIPAddressesOnly()
        {
            // Arrange
            string ipv4 = "192.168.1.1";
            string ipv6 = "2001:0db8:85a3:0000:0000:8a2e:0370:7334";

            // Act
            var bannedIP = new BannedIP(ipv4, ipv6);

            // Assert
            Assert.Equal(ipv4, bannedIP.ipv4);
            Assert.Equal(ipv6, bannedIP.ipv6);
            Assert.Null(bannedIP._id);
            Assert.Null(bannedIP.reason);
        }

        [Fact]
        public void Constructor_WithAllParameters_SetsAllProperties()
        {
            // Arrange
            string id = "test-id";
            string ipv4 = "192.168.1.1";
            string ipv6 = "2001:0db8:85a3:0000:0000:8a2e:0370:7334";
            string reason = "Test reason";

            // Act
            var bannedIP = new BannedIP(id, ipv4, ipv6, reason);

            // Assert
            Assert.Equal(id, bannedIP._id);
            Assert.Equal(ipv4, bannedIP.ipv4);
            Assert.Equal(ipv6, bannedIP.ipv6);
            Assert.Equal(reason, bannedIP.reason);
        }

        [Fact]
        public void Properties_CanBeModified()
        {
            // Arrange
            var bannedIP = new BannedIP();
            string id = "test-id";
            string ipv4 = "192.168.1.1";
            string ipv6 = "2001:0db8:85a3:0000:0000:8a2e:0370:7334";
            string reason = "Test reason";

            // Act
            bannedIP._id = id;
            bannedIP.ipv4 = ipv4;
            bannedIP.ipv6 = ipv6;
            bannedIP.reason = reason;

            // Assert
            Assert.Equal(id, bannedIP._id);
            Assert.Equal(ipv4, bannedIP.ipv4);
            Assert.Equal(ipv6, bannedIP.ipv6);
            Assert.Equal(reason, bannedIP.reason);
        }

        // EDGE CASE TESTS - Added per CLAUDE_TESTING.md requirements

        [Fact]
        public void Constructor_WithNullIPAddresses_SetsNullValues()
        {
            // Act
            var bannedIP = new BannedIP(null, null);

            // Assert
            Assert.Null(bannedIP.ipv4);
            Assert.Null(bannedIP.ipv6);
        }

        [Fact]
        public void Constructor_WithEmptyIPAddresses_SetsEmptyStrings()
        {
            // Act
            var bannedIP = new BannedIP("", "");

            // Assert
            Assert.Equal("", bannedIP.ipv4);
            Assert.Equal("", bannedIP.ipv6);
        }

        [Fact]
        public void Constructor_WithAllNullParameters_SetsAllNull()
        {
            // Act
            var bannedIP = new BannedIP(null, null, null, null);

            // Assert
            Assert.Null(bannedIP._id);
            Assert.Null(bannedIP.ipv4);
            Assert.Null(bannedIP.ipv6);
            Assert.Null(bannedIP.reason);
        }

        [Fact]
        public void Constructor_WithAllEmptyParameters_SetsAllEmpty()
        {
            // Act
            var bannedIP = new BannedIP("", "", "", "");

            // Assert
            Assert.Equal("", bannedIP._id);
            Assert.Equal("", bannedIP.ipv4);
            Assert.Equal("", bannedIP.ipv6);
            Assert.Equal("", bannedIP.reason);
        }

        [Fact]
        public void Constructor_WithVeryLongStrings_SetsValues()
        {
            // Arrange
            string longString = new string('a', 10000);

            // Act
            var bannedIP = new BannedIP(longString, longString, longString, longString);

            // Assert
            Assert.Equal(longString, bannedIP._id);
            Assert.Equal(longString, bannedIP.ipv4);
            Assert.Equal(longString, bannedIP.ipv6);
            Assert.Equal(longString, bannedIP.reason);
        }

        [Fact]
        public void Properties_CanBeSetToNull()
        {
            // Arrange
            var bannedIP = new BannedIP("id", "ipv4", "ipv6", "reason");

            // Act
            bannedIP._id = null;
            bannedIP.ipv4 = null;
            bannedIP.ipv6 = null;
            bannedIP.reason = null;

            // Assert
            Assert.Null(bannedIP._id);
            Assert.Null(bannedIP.ipv4);
            Assert.Null(bannedIP.ipv6);
            Assert.Null(bannedIP.reason);
        }

        [Fact]
        public void Properties_CanBeSetToEmptyString()
        {
            // Arrange
            var bannedIP = new BannedIP("id", "ipv4", "ipv6", "reason");

            // Act
            bannedIP._id = "";
            bannedIP.ipv4 = "";
            bannedIP.ipv6 = "";
            bannedIP.reason = "";

            // Assert
            Assert.Equal("", bannedIP._id);
            Assert.Equal("", bannedIP.ipv4);
            Assert.Equal("", bannedIP.ipv6);
            Assert.Equal("", bannedIP.reason);
        }

        [Fact]
        public void Constructor_WithSpecialCharacters_SetsValues()
        {
            // Arrange
            string specialChars = "!@#$%^&*()_+-=[]{}|;':\",./<>?";

            // Act
            var bannedIP = new BannedIP(specialChars, specialChars, specialChars, specialChars);

            // Assert
            Assert.Equal(specialChars, bannedIP._id);
            Assert.Equal(specialChars, bannedIP.ipv4);
            Assert.Equal(specialChars, bannedIP.ipv6);
            Assert.Equal(specialChars, bannedIP.reason);
        }
    }
}
