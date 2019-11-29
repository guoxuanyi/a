using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyBlog.Models
{
    public partial class gxyContext : DbContext
    {
        public gxyContext()
        {
        }

        public gxyContext(DbContextOptions<gxyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<Sort> Sort { get; set; }
        public virtual DbSet<SortBlogRelation> SortBlogRelation { get; set; }
        public virtual DbSet<UserBlogRelation> UserBlogRelation { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DLC0004XTHFD2D\\SQLEXPRESS01;Database=gxy;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(entity =>
            {
                entity.Property(e => e.BlogId)
                    .HasColumnName("blog_id")
                    .HasMaxLength(50);

                entity.Property(e => e.BlogCommentCount).HasColumnName("blog_comment_count");

                entity.Property(e => e.BlogContent)
                    .IsRequired()
                    .HasColumnName("blog_content")
                    .HasColumnType("text");

                entity.Property(e => e.BlogDate)
                    .HasColumnName("blog_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.BlogDeleteFlag).HasColumnName("blog_delete_flag");

                entity.Property(e => e.BlogLikeCount).HasColumnName("blog_like_count");

                entity.Property(e => e.BlogTitle)
                    .IsRequired()
                    .HasColumnName("blog_title")
                    .HasMaxLength(30);

                entity.Property(e => e.BlogViews).HasColumnName("blog_views");
            });

            modelBuilder.Entity<Sort>(entity =>
            {
                entity.Property(e => e.SortId)
                    .HasColumnName("sort_id")
                    .HasMaxLength(50);

                entity.Property(e => e.SortDescription)
                    .HasColumnName("sort_description")
                    .HasColumnType("text");

                entity.Property(e => e.SortName)
                    .IsRequired()
                    .HasColumnName("sort_name")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<SortBlogRelation>(entity =>
            {
                entity.HasKey(e => e.SortId);

                entity.Property(e => e.SortId)
                    .HasColumnName("sort_id")
                    .HasMaxLength(50);

                entity.Property(e => e.BlogId)
                    .HasColumnName("blog_id")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserBlogRelation>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasMaxLength(50);

                entity.Property(e => e.BlogId)
                    .HasColumnName("blog_id")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasMaxLength(50);

                entity.Property(e => e.Admin).HasColumnName("admin");

                entity.Property(e => e.UserDeleteFlag).HasColumnName("user_delete_flag");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasColumnName("user_email")
                    .HasMaxLength(30);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("user_name")
                    .HasMaxLength(20);

                entity.Property(e => e.UserNickname)
                    .IsRequired()
                    .HasColumnName("user_nickname")
                    .HasMaxLength(20);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("user_password")
                    .HasMaxLength(20);

                entity.Property(e => e.UserPhoneNumber)
                    .HasColumnName("user_phone_number")
                    .HasMaxLength(11)
                    .IsFixedLength();

                entity.Property(e => e.UserPhoto)
                    .IsRequired()
                    .HasColumnName("user_photo")
                    .HasMaxLength(255);

                entity.Property(e => e.UserRegisterDate)
                    .HasColumnName("user_register_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
