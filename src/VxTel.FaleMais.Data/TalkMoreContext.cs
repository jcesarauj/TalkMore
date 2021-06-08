using Microsoft.EntityFrameworkCore;
using System.Linq;
using VxTel.TalkMore.Domain.Models;

namespace VxTel.TalkMore.Data
{
	public class TalkMoreContext : DbContext
	{
		public TalkMoreContext(DbContextOptions<TalkMoreContext> options) : base(options)
		{
			if (Plan.FirstOrDefault(x => x.Id == 1) == null)
			{
				Plan.Add(new Plan(1, "FaleMais 30", 30, 10));
				Plan.Add(new Plan(2, "FaleMais 60", 60, 10));
				Plan.Add(new Plan(3, "FaleMais 120", 120, 10));

				CallFee.Add(new CallFee(1, 11, 16, 1.90));
				CallFee.Add(new CallFee(2, 16, 11, 2.90));
				CallFee.Add(new CallFee(3, 11, 17, 1.70));
				CallFee.Add(new CallFee(4, 17, 11, 2.70));
				CallFee.Add(new CallFee(5, 11, 18, 0.90));
				CallFee.Add(new CallFee(6, 18, 11, 1.90));

				base.SaveChanges();
			}
		}

		public DbSet<Plan> Plan { get; set; }
		public DbSet<CallFee> CallFee { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(TalkMoreContext).Assembly);
		}
	}
}