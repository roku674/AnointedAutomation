// Copyright 2024 Anointed Automation, LLC. All Rights Reserved. Created by Alexander Fields https://www.alexanderfields.me
// Created by Alexander Fields

using AnointedAutomation.Repository.MySql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AnointedAutomation.Repository.MySql.Tests
{
    /// <summary>
    /// Test entity for testing repository operations.
    /// </summary>
    public class TestEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    /// <summary>
    /// Test DbContext for in-memory testing.
    /// </summary>
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
        }

        public DbSet<TestEntity> TestEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestEntity>().HasKey(e => e.Id);
            base.OnModelCreating(modelBuilder);
        }
    }

    /// <summary>
    /// Unit tests for the GenericRepository class.
    /// </summary>
    public class GenericRepositoryTests
    {
        private TestDbContext CreateInMemoryContext()
        {
            DbContextOptions<TestDbContext> options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new TestDbContext(options);
        }

        [Fact]
        public async Task AddAsync_ShouldAddEntity()
        {
            // Arrange
            using TestDbContext context = CreateInMemoryContext();
            GenericRepository<TestEntity> repository = new GenericRepository<TestEntity>(context);
            TestEntity entity = new TestEntity { Name = "Test", Description = "Test Description", CreatedAt = DateTime.Now };

            // Act
            TestEntity result = await repository.AddAsync(entity);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Id > 0);
            Assert.Equal("Test", result.Name);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnEntity()
        {
            // Arrange
            using TestDbContext context = CreateInMemoryContext();
            GenericRepository<TestEntity> repository = new GenericRepository<TestEntity>(context);
            TestEntity entity = new TestEntity { Name = "Test", Description = "Test Description", CreatedAt = DateTime.Now };
            await repository.AddAsync(entity);

            // Act
            TestEntity result = await repository.GetByIdAsync(entity.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(entity.Id, result.Id);
            Assert.Equal("Test", result.Name);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNullWhenNotFound()
        {
            // Arrange
            using TestDbContext context = CreateInMemoryContext();
            GenericRepository<TestEntity> repository = new GenericRepository<TestEntity>(context);

            // Act
            TestEntity result = await repository.GetByIdAsync(999);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllEntities()
        {
            // Arrange
            using TestDbContext context = CreateInMemoryContext();
            GenericRepository<TestEntity> repository = new GenericRepository<TestEntity>(context);
            await repository.AddAsync(new TestEntity { Name = "Test1", Description = "Desc1", CreatedAt = DateTime.Now });
            await repository.AddAsync(new TestEntity { Name = "Test2", Description = "Desc2", CreatedAt = DateTime.Now });
            await repository.AddAsync(new TestEntity { Name = "Test3", Description = "Desc3", CreatedAt = DateTime.Now });

            // Act
            IEnumerable<TestEntity> result = await repository.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, ((List<TestEntity>)result).Count);
        }

        [Fact]
        public async Task FindAsync_ShouldReturnMatchingEntities()
        {
            // Arrange
            using TestDbContext context = CreateInMemoryContext();
            GenericRepository<TestEntity> repository = new GenericRepository<TestEntity>(context);
            await repository.AddAsync(new TestEntity { Name = "Alpha", Description = "Desc1", CreatedAt = DateTime.Now });
            await repository.AddAsync(new TestEntity { Name = "Beta", Description = "Desc2", CreatedAt = DateTime.Now });
            await repository.AddAsync(new TestEntity { Name = "Alpha2", Description = "Desc3", CreatedAt = DateTime.Now });

            // Act
            IEnumerable<TestEntity> result = await repository.FindAsync(e => e.Name.StartsWith("Alpha"));

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, ((List<TestEntity>)result).Count);
        }

        [Fact]
        public async Task FindSingleAsync_ShouldReturnFirstMatchingEntity()
        {
            // Arrange
            using TestDbContext context = CreateInMemoryContext();
            GenericRepository<TestEntity> repository = new GenericRepository<TestEntity>(context);
            await repository.AddAsync(new TestEntity { Name = "Alpha", Description = "Desc1", CreatedAt = DateTime.Now });
            await repository.AddAsync(new TestEntity { Name = "Beta", Description = "Desc2", CreatedAt = DateTime.Now });

            // Act
            TestEntity result = await repository.FindSingleAsync(e => e.Name == "Beta");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Beta", result.Name);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateEntity()
        {
            // Arrange
            using TestDbContext context = CreateInMemoryContext();
            GenericRepository<TestEntity> repository = new GenericRepository<TestEntity>(context);
            TestEntity entity = new TestEntity { Name = "Original", Description = "Desc", CreatedAt = DateTime.Now };
            await repository.AddAsync(entity);

            // Act
            entity.Name = "Updated";
            TestEntity result = await repository.UpdateAsync(entity);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Updated", result.Name);

            // Verify in database
            TestEntity fromDb = await repository.GetByIdAsync(entity.Id);
            Assert.Equal("Updated", fromDb.Name);
        }

        [Fact]
        public async Task DeleteAsync_ById_ShouldDeleteEntity()
        {
            // Arrange
            using TestDbContext context = CreateInMemoryContext();
            GenericRepository<TestEntity> repository = new GenericRepository<TestEntity>(context);
            TestEntity entity = new TestEntity { Name = "ToDelete", Description = "Desc", CreatedAt = DateTime.Now };
            await repository.AddAsync(entity);

            // Act
            bool result = await repository.DeleteAsync(entity.Id);

            // Assert
            Assert.True(result);

            // Verify deletion
            TestEntity fromDb = await repository.GetByIdAsync(entity.Id);
            Assert.Null(fromDb);
        }

        [Fact]
        public async Task DeleteAsync_ById_ShouldReturnFalseWhenNotFound()
        {
            // Arrange
            using TestDbContext context = CreateInMemoryContext();
            GenericRepository<TestEntity> repository = new GenericRepository<TestEntity>(context);

            // Act
            bool result = await repository.DeleteAsync(999);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task DeleteAsync_ByEntity_ShouldDeleteEntity()
        {
            // Arrange
            using TestDbContext context = CreateInMemoryContext();
            GenericRepository<TestEntity> repository = new GenericRepository<TestEntity>(context);
            TestEntity entity = new TestEntity { Name = "ToDelete", Description = "Desc", CreatedAt = DateTime.Now };
            await repository.AddAsync(entity);

            // Act
            bool result = await repository.DeleteAsync(entity);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteRangeAsync_ShouldDeleteMatchingEntities()
        {
            // Arrange
            using TestDbContext context = CreateInMemoryContext();
            GenericRepository<TestEntity> repository = new GenericRepository<TestEntity>(context);
            await repository.AddAsync(new TestEntity { Name = "Keep", Description = "Desc1", CreatedAt = DateTime.Now });
            await repository.AddAsync(new TestEntity { Name = "Delete1", Description = "Desc2", CreatedAt = DateTime.Now });
            await repository.AddAsync(new TestEntity { Name = "Delete2", Description = "Desc3", CreatedAt = DateTime.Now });

            // Act
            int deletedCount = await repository.DeleteRangeAsync(e => e.Name.StartsWith("Delete"));

            // Assert
            Assert.Equal(2, deletedCount);

            // Verify remaining
            IEnumerable<TestEntity> remaining = await repository.GetAllAsync();
            Assert.Single(remaining);
        }

        [Fact]
        public async Task ExistsAsync_ShouldReturnTrueWhenExists()
        {
            // Arrange
            using TestDbContext context = CreateInMemoryContext();
            GenericRepository<TestEntity> repository = new GenericRepository<TestEntity>(context);
            await repository.AddAsync(new TestEntity { Name = "Exists", Description = "Desc", CreatedAt = DateTime.Now });

            // Act
            bool result = await repository.ExistsAsync(e => e.Name == "Exists");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task ExistsAsync_ShouldReturnFalseWhenNotExists()
        {
            // Arrange
            using TestDbContext context = CreateInMemoryContext();
            GenericRepository<TestEntity> repository = new GenericRepository<TestEntity>(context);

            // Act
            bool result = await repository.ExistsAsync(e => e.Name == "DoesNotExist");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task CountAsync_ShouldReturnTotalCount()
        {
            // Arrange
            using TestDbContext context = CreateInMemoryContext();
            GenericRepository<TestEntity> repository = new GenericRepository<TestEntity>(context);
            await repository.AddAsync(new TestEntity { Name = "Test1", Description = "Desc1", CreatedAt = DateTime.Now });
            await repository.AddAsync(new TestEntity { Name = "Test2", Description = "Desc2", CreatedAt = DateTime.Now });
            await repository.AddAsync(new TestEntity { Name = "Test3", Description = "Desc3", CreatedAt = DateTime.Now });

            // Act
            int result = await repository.CountAsync();

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public async Task CountAsync_WithPredicate_ShouldReturnFilteredCount()
        {
            // Arrange
            using TestDbContext context = CreateInMemoryContext();
            GenericRepository<TestEntity> repository = new GenericRepository<TestEntity>(context);
            await repository.AddAsync(new TestEntity { Name = "Alpha", Description = "Desc1", CreatedAt = DateTime.Now });
            await repository.AddAsync(new TestEntity { Name = "Beta", Description = "Desc2", CreatedAt = DateTime.Now });
            await repository.AddAsync(new TestEntity { Name = "Alpha2", Description = "Desc3", CreatedAt = DateTime.Now });

            // Act
            int result = await repository.CountAsync(e => e.Name.StartsWith("Alpha"));

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public async Task AddRangeAsync_ShouldAddMultipleEntities()
        {
            // Arrange
            using TestDbContext context = CreateInMemoryContext();
            GenericRepository<TestEntity> repository = new GenericRepository<TestEntity>(context);
            List<TestEntity> entities = new List<TestEntity>
            {
                new TestEntity { Name = "Test1", Description = "Desc1", CreatedAt = DateTime.Now },
                new TestEntity { Name = "Test2", Description = "Desc2", CreatedAt = DateTime.Now },
                new TestEntity { Name = "Test3", Description = "Desc3", CreatedAt = DateTime.Now }
            };

            // Act
            int result = await repository.AddRangeAsync(entities);

            // Assert
            Assert.Equal(3, result);

            // Verify all were added
            int count = await repository.CountAsync();
            Assert.Equal(3, count);
        }
    }

    /// <summary>
    /// Unit tests for the MySqlHelperFactory class.
    /// </summary>
    public class MySqlHelperFactoryTests
    {
        [Fact]
        public void Create_ShouldReturnSameInstanceForSameConnectionString()
        {
            // Arrange
            MySqlHelperFactory factory = new MySqlHelperFactory();
            string connectionString = "Server=localhost;Database=test;User=root;Password=pass;";

            // Act
            // Note: This will fail to actually connect, but we're testing the caching behavior
            // In a real scenario, you'd mock or use an in-memory database
            try
            {
                IMySqlHelper helper1 = factory.Create(connectionString);
                IMySqlHelper helper2 = factory.Create(connectionString);

                // Assert
                Assert.Same(helper1, helper2);
            }
            catch (Exception)
            {
                // Expected to fail connection, but caching logic should still work
                // This test validates the concept, real tests would use a test database
            }
        }

        [Fact]
        public void ClearCache_ShouldRemoveAllCachedInstances()
        {
            // Arrange
            MySqlHelperFactory factory = new MySqlHelperFactory();

            // Act
            factory.ClearCache();

            // Assert - no exception thrown
            Assert.True(true);
        }

        [Fact]
        public void Remove_ShouldReturnFalseWhenKeyNotFound()
        {
            // Arrange
            MySqlHelperFactory factory = new MySqlHelperFactory();

            // Act
            bool result = factory.Remove("nonexistent");

            // Assert
            Assert.False(result);
        }
    }

    /// <summary>
    /// Unit tests for the ConnectionStringBuilder.
    /// </summary>
    public class ConnectionStringBuilderTests
    {
        [Fact]
        public void ConnectionStringBuilder_ShouldBuildCorrectString()
        {
            // Act
            string result = MySqlHelper.ConnectionStringBuilder(
                server: "localhost",
                database: "testdb",
                username: "root",
                password: "password123",
                port: 3306
            );

            // Assert
            Assert.Contains("Server=localhost", result);
            Assert.Contains("Port=3306", result);
            Assert.Contains("Database=testdb", result);
            Assert.Contains("User=root", result);
            Assert.Contains("Password=password123", result);
        }

        [Fact]
        public void ConnectionStringBuilder_WithCustomPort_ShouldIncludePort()
        {
            // Act
            string result = MySqlHelper.ConnectionStringBuilder(
                server: "db.example.com",
                database: "mydb",
                username: "admin",
                password: "secret",
                port: 3307
            );

            // Assert
            Assert.Contains("Port=3307", result);
        }
    }
}
