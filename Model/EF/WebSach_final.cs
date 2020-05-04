namespace Model.EF
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class WebSach_final : DbContext
	{
		public WebSach_final()
			: base("name=WebSach_final")
		{
		}

		public virtual DbSet<Account> Accounts { get; set; }
		public virtual DbSet<Author> Authors { get; set; }
		public virtual DbSet<Book> Books { get; set; }
		public virtual DbSet<Category> Categories { get; set; }
		public virtual DbSet<Customer> Customers { get; set; }
		public virtual DbSet<Father_category> Father_category { get; set; }
		public virtual DbSet<File> Files { get; set; }
		public virtual DbSet<NXB> NXBs { get; set; }
		public virtual DbSet<Order> Orders { get; set; }
		public virtual DbSet<Order_detail> Order_detail { get; set; }
		public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
		public virtual DbSet<Worker> Workers { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Account>()
				.HasMany(e => e.Customers)
				.WithOptional(e => e.Account)
				.HasForeignKey(e => e.Id_account);

			modelBuilder.Entity<Account>()
				.HasMany(e => e.Workers)
				.WithOptional(e => e.Account)
				.HasForeignKey(e => e.Id_account);

			modelBuilder.Entity<Author>()
				.Property(e => e.Information)
				.IsUnicode(false);

			modelBuilder.Entity<Author>()
				.HasMany(e => e.Books)
				.WithOptional(e => e.Author)
				.HasForeignKey(e => e.Id_author);

			modelBuilder.Entity<Book>()
				.Property(e => e.Description)
				.IsUnicode(false);

			modelBuilder.Entity<Book>()
				.HasMany(e => e.Order_detail)
				.WithOptional(e => e.Book)
				.HasForeignKey(e => e.Id_book);

			modelBuilder.Entity<Category>()
				.HasMany(e => e.Books)
				.WithOptional(e => e.Category)
				.HasForeignKey(e => e.Id_category);

			modelBuilder.Entity<Customer>()
				.HasMany(e => e.Orders)
				.WithOptional(e => e.Customer)
				.HasForeignKey(e => e.Id_customer);

			modelBuilder.Entity<Father_category>()
				.HasMany(e => e.Categories)
				.WithOptional(e => e.Father_category)
				.HasForeignKey(e => e.Id_father);

			modelBuilder.Entity<File>()
				.HasMany(e => e.Books)
				.WithOptional(e => e.File)
				.HasForeignKey(e => e.file_id_image);

			modelBuilder.Entity<File>()
				.HasMany(e => e.Books1)
				.WithOptional(e => e.File1)
				.HasForeignKey(e => e.file_id_pdf);

			modelBuilder.Entity<NXB>()
				.Property(e => e.Information)
				.IsUnicode(false);

			modelBuilder.Entity<NXB>()
				.HasMany(e => e.Books)
				.WithOptional(e => e.NXB)
				.HasForeignKey(e => e.Id_NXB);

			modelBuilder.Entity<Order>()
				.HasMany(e => e.Order_detail)
				.WithOptional(e => e.Order)
				.HasForeignKey(e => e.Id_order);

			modelBuilder.Entity<Worker>()
				.HasMany(e => e.Orders)
				.WithOptional(e => e.Worker)
				.HasForeignKey(e => e.Id_Shipper);
		}
	}
}
