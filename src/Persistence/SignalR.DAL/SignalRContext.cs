using System;
using SignalR.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using SignalR.Helpers;

namespace SignalR.DAL
{
    public class SignalRContext : DbContext
    {
        #region Propiedades
        public DbSet<RequestType> RequestTypes { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentType> CommentType { get; set; }
        public DbSet<User> Users { get; set; }
        #endregion
        
        // Propiedad para log solo mostrara mensajes segun lo indicado
        public static readonly ILoggerFactory loggerFactory =
            new ServiceCollection().AddLogging(builder =>
                builder.AddEventLog().AddFilter(
                    (Category, Level) => Level == LogLevel.Information && Category == DbLoggerCategory.Database.Command.Name
                )
            ).BuildServiceProvider().GetService<ILoggerFactory>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = HelperConfiguration.GetAppConfiguration().ConnectionString;

            // configuracion base de datos
            optionsBuilder
                // .UseSqlServer(connectionString)
                .UseInMemoryDatabase("DBPrueba")
                .UseLoggerFactory(loggerFactory)
                // .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll)
                .EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Configuracion Llaves Primarias
            modelBuilder.Entity<User>().HasKey(c => c.UserID);
            modelBuilder.Entity<CommentType>().HasKey(p => p.CommentTypeID);
            modelBuilder.Entity<Comment>().HasKey(p => p.CommentID);
            modelBuilder.Entity<Area>().HasKey(p => p.AreaID);
            modelBuilder.Entity<File>().HasKey(p => p.FileID);
            modelBuilder.Entity<Request>().HasKey(p => p.RequestID);
            modelBuilder.Entity<RequestType>().HasKey(p => p.RequestTypeID);
            #endregion

            #region Configuracion propiedades 
            modelBuilder.Entity<Request>().Property(p => p.Title).HasMaxLength(120).IsRequired();
            modelBuilder.Entity<Request>().Property(p => p.Description).HasMaxLength(8000).IsRequired();
            modelBuilder.Entity<Request>().Property(c => c.CreationDate).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Request>().Property(p => p.InternalCode).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<Comment>().Property(p => p.Description).HasMaxLength(8000).IsRequired();
            modelBuilder.Entity<Comment>().Property(c => c.CreationDate).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Comment>().Property(c => c.ModifDate).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<CommentType>().Property(c => c.Name).HasMaxLength(120).IsRequired();
            modelBuilder.Entity<CommentType>().Property(c => c.Description).HasMaxLength(400).IsRequired();
            modelBuilder.Entity<CommentType>().Property(c => c.Description).HasMaxLength(400).IsRequired();

            modelBuilder.Entity<File>().Property(f => f.Name).HasMaxLength(120).IsRequired();
            modelBuilder.Entity<File>().Property(f => f.Path).HasMaxLength(600).IsRequired();
            modelBuilder.Entity<File>().Property(f => f.Extension).HasMaxLength(3).IsRequired();
            modelBuilder.Entity<File>().Property(f => f.UploadDate).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<RequestType>().Property(r => r.Name).HasMaxLength(120).IsRequired();
            modelBuilder.Entity<RequestType>().Property(r => r.Description).HasMaxLength(8000).IsRequired();

            modelBuilder.Entity<User>().Property(u => u.FirstName).HasMaxLength(60).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.LastName).HasMaxLength(60).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Code).HasMaxLength(30).IsRequired();

            modelBuilder.Entity<Area>().Property(u => u.Name).HasMaxLength(60).IsRequired();
            modelBuilder.Entity<Area>().Property(u => u.Description).HasMaxLength(8000).IsRequired();
            modelBuilder.Entity<Area>().Property(u => u.Code).HasMaxLength(30).IsRequired();
            #endregion

            #region Configuracion Llaves Foraneas
            modelBuilder.Entity<Request>()
                .HasOne(p => p.RequestType)
                .WithMany(c => c.Requests)
                .HasForeignKey(c => c.RequestTypeID)
                .HasConstraintName("FK_REQUEST_REQUESTTYPE_01");

            modelBuilder.Entity<Request>()
                .HasOne(p => p.Area)
                .WithMany(c => c.Requests)
                .HasForeignKey(c => c.AreaID)
                .HasConstraintName("FK_REQUEST_AREA_01");

            modelBuilder.Entity<Request>()
                .HasOne(p => p.User)
                .WithMany(c => c.Requests)
                .HasForeignKey(c => c.UserID)
                .HasConstraintName("FK_REQUEST_USER_01");

            modelBuilder.Entity<File>()
                .HasOne(f => f.Request)
                .WithMany(p => p.Files)
                .HasForeignKey(p => p.RequestID)
                .HasConstraintName("FK_REQUEST_FILE_01");

            modelBuilder.Entity<Comment>()
                .HasOne(f => f.CommentType)
                .WithMany(p => p.Comments)
                .HasForeignKey(p => p.CommentTypeID)
                .HasConstraintName("FK_COMMENT_COMMENTTYPE_01");

            modelBuilder.Entity<Comment>()
                .HasOne(f => f.User)
                .WithMany(p => p.Comments)
                .HasForeignKey(p => p.UserID)
                .HasConstraintName("FK_COMMENT_USER_01");

            modelBuilder.Entity<Comment>()
                .HasOne(f => f.Request)
                .WithMany(p => p.Comments)
                .HasForeignKey(p => p.RequestID)
                .HasConstraintName("FK_COMMENT_REQUEST_01");
            #endregion
        }
    }
}