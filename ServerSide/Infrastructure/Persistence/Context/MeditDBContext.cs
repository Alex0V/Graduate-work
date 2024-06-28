using Infrastructure.Persistence.Configurations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context;

public class MeditDBContext : DbContext
{
    public MeditDBContext(DbContextOptions<MeditDBContext> options) : base(options)
    {
    }

    #region DbSet Properties
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<MeditationCategory> MeditationCategories { get; set; }
    public DbSet<Meditation> Meditations { get; set; }
    public DbSet<MeditationProgram> MeditationPrograms { get; set; }
    public DbSet<ProgramContent> ProgramContents { get; set; }
    public DbSet<MeditationSession> MeditationSessions { get; set; }
    public DbSet<Music> Musics { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    //public DbSet<Role> Roles { get; set; }
    #endregion 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfig());
        modelBuilder.ApplyConfiguration(new CategoryConfig());
        modelBuilder.ApplyConfiguration(new MeditationCategoryConfig());
        modelBuilder.ApplyConfiguration(new MeditationConfig());
        modelBuilder.ApplyConfiguration(new MeditationProgramConfig());
        modelBuilder.ApplyConfiguration(new MeditationSessionConfig());
        modelBuilder.ApplyConfiguration(new MusicConfig());
        modelBuilder.ApplyConfiguration(new ProgramContentConfig());
        modelBuilder.ApplyConfiguration(new RatingConfig());
        //modelBuilder.ApplyConfiguration(new RoleConfig());
        base.OnModelCreating(modelBuilder);
    }
}
