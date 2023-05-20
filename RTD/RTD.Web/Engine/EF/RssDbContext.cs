using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RTD.Web.Engine.EF;

public class RssDbContext : DbContext
{
    public DbSet<RssSource> RssSources { get; set; }
    public DbSet<RssEntry> RssEntries { get; set; }
    public DbSet<AdminUser> AdminUsers { get; set; }

    public DbSet<DiscordHook> DiscordHooks { get; set; }
    public RssDbContext(DbContextOptions<RssDbContext> options) : base(options)
    {
    }
}

public class RssSource
{
    [Key] public Guid RssSourceId { get; set; }

    public string RssName { get; set; }
    public bool Active { get; set; }

    public DateTime? DateAdded { get; set; }
    public DateTime? DateChecked { get; set; }

    public ICollection<RssEntry> RssEntries { get; set; }
}

public class DiscordHook
{
    [Key]
    public Guid Id { get; set; }

    public string Name { get; set; }
    public string HookUrl { get; set; }
}

public class RssEntry
{
    [Key] public Guid RssEntryInternalId { get; set; }
    public string Uid { get; set; }
    public string Link { get; set; }
    public string ImageLink { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime? ItemDate { get; set; }
}

public class AdminUser
{
    [Key] public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public bool Active { get; set; }
    public DateTime DateCreated { get; set; }

    public void SetPassword(string modelPassword)
    {
        Salt = Guid.NewGuid().ToString();
        Password = HashPassword(modelPassword);
    }

    private string HashPassword(string modelPassword)
    {
        return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: modelPassword,
            salt: Encoding.UTF8.GetBytes(Salt),
            prf: KeyDerivationPrf.HMACSHA512,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));
    }
}

public class DesignTimeFactory : IDesignTimeDbContextFactory<RssDbContext>
{
    public RssDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<RssDbContext>();
        builder.UseSqlite("Data Source=RTD-DT.db");

        return new RssDbContext(builder.Options);
    }
}