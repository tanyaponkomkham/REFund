using Microsoft.EntityFrameworkCore;
using REFund.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REFund.Data
{
	public class CoreContext : DbContext
	{
		public CoreContext(DbContextOptions<CoreContext> options) 
			: base(options)
		{
		}

		public  DbSet<Status> Status { get; set; }
		public  DbSet<Whom> Whom { get; set; }
		public  DbSet<Category> Category { get; set; }
		public  DbSet<SubCategory> SubCategory { get; set; }
		public  DbSet<Document> Document { get; set; }
		public  DbSet<DocumentDetail> DocumentDetail { get; set; }
		public  DbSet<Attachment> Attachment { get; set; }
		public  DbSet<Communication> Communication { get; set; }
		public  DbSet<Workflow> Workflow { get; set; }
		public  DbSet<Request> Request { get; set; }
		public  DbSet<History> History { get; set; }

		public virtual DbSet<EmpInfo> EmpInfo { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.Entity<Request>().ToTable("Request");
			//View Data
			modelBuilder.Entity<EmpInfo>(entity =>
			{
				entity.HasKey(e => e.empID);
				entity.ToView("EmpInfo");
			});

		}
	}
}
