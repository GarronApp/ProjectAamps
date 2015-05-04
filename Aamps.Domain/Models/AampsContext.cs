using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Aamps.Domain.Models.Mapping;
using AAMPS.Domain.ViewModels.Bonds;
using Aamps.Domain.ViewModels.Sales;

namespace Aamps.Domain.Models
{
    public partial class AampsContext : DbContext
    {
        static AampsContext()
        {
            Database.SetInitializer<AampsContext>(null);
        }

        public AampsContext()
            : base("Name=AampsContext")
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<BondAtt> BondAtts { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentGroup> CommentGroups { get; set; }
        public DbSet<Development> Developments { get; set; }
        public DbSet<DevelopmentType> DevelopmentTypes { get; set; }
        public DbSet<EntityType> EntityTypes { get; set; }
        public DbSet<Estate> Estates { get; set; }
        public DbSet<Individual> Individuals { get; set; }
        public DbSet<PreferedContactMethod> PreferedContactMethods { get; set; }
        public DbSet<Purchaser> Purchasers { get; set; }
        public DbSet<PurchaserIndividualLink> PurchaserIndividualLinks { get; set; }
        public DbSet<SalesCoDevLink> SalesCoDevLinks { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleActiveStatus> SaleActiveStatus { get; set; }
        public DbSet<SaleDepositProof> SaleDepositProofs { get; set; }
        public DbSet<SaleStatus> SaleStatus { get; set; }
        public DbSet<SaleType> SaleTypes { get; set; }
        public DbSet<BondConditionTr> BondConditionTrs { get; set; }
        public DbSet<CommissionTr> CommissionTrs { get; set; }
        public DbSet<CommissionType> CommissionTypes { get; set; }
        public DbSet<FinancialTr> FinancialTrs { get; set; }
        public DbSet<FinancialType> FinancialTypes { get; set; }
        public DbSet<MOStatus> MOStatus { get; set; }
        public DbSet<OriginatorTr> OriginatorTrs { get; set; }
        public DbSet<TransAtt> TransAtts { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<UnitStatus> UnitStatus { get; set; }
        public DbSet<UnitType> UnitTypes { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<FormReport> FormReports { get; set; }
        public DbSet<GroupRight> GroupRights { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserList> UserLists { get; set; }
        public DbSet<UserRight> UserRights { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BondAttMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new BankMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new CommentGroupMap());
            modelBuilder.Configurations.Add(new DevelopmentMap());
            modelBuilder.Configurations.Add(new DevelopmentTypeMap());
            modelBuilder.Configurations.Add(new EntityTypeMap());
            modelBuilder.Configurations.Add(new EstateMap());
            modelBuilder.Configurations.Add(new IndividualMap());
            modelBuilder.Configurations.Add(new PreferedContactMethodMap());
            modelBuilder.Configurations.Add(new PurchaserMap());
            modelBuilder.Configurations.Add(new PurchaserIndividualLinkMap());
            modelBuilder.Configurations.Add(new SalesCoDevLinkMap());
            modelBuilder.Configurations.Add(new SaleMap());
            modelBuilder.Configurations.Add(new SaleActiveStatusMap());
            modelBuilder.Configurations.Add(new SaleDepositProofMap());
            modelBuilder.Configurations.Add(new SaleStatusMap());
            modelBuilder.Configurations.Add(new SaleTypeMap());
            modelBuilder.Configurations.Add(new BondConditionTrMap());
            modelBuilder.Configurations.Add(new CommissionTrMap());
            modelBuilder.Configurations.Add(new CommissionTypeMap());
            modelBuilder.Configurations.Add(new FinancialTrMap());
            modelBuilder.Configurations.Add(new FinancialTypeMap());
            modelBuilder.Configurations.Add(new MOStatusMap());
            modelBuilder.Configurations.Add(new OriginatorTrMap());
            modelBuilder.Configurations.Add(new TransAttMap());
            modelBuilder.Configurations.Add(new UnitMap());
            modelBuilder.Configurations.Add(new UnitStatusMap());
            modelBuilder.Configurations.Add(new UnitTypeMap());
            modelBuilder.Configurations.Add(new CompanyMap());
            modelBuilder.Configurations.Add(new FormReportMap());
            modelBuilder.Configurations.Add(new GroupRightMap());
            modelBuilder.Configurations.Add(new UserGroupMap());
            modelBuilder.Configurations.Add(new UserListMap());
            modelBuilder.Configurations.Add(new UserRightMap());
            modelBuilder.Configurations.Add(new UserTypeMap());
        }
    }
}
