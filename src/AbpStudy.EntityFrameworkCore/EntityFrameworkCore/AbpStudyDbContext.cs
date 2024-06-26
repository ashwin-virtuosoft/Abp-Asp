﻿using AbpStudy.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace AbpStudy.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class AbpStudyDbContext :
    AbpDbContext<AbpStudyDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<Client> clients {get;set;}
    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }   
    public DbSet<JobportalDetails> JobportalDetails { get; set; }
    public DbSet<JobDetails> Jobdetails { get; set; }
    public DbSet<JobAllDetails> JobAllDetails { get; set; }
    public DbSet<JobSeeker>JobSeekers { get; set; }

    public AbpStudyDbContext(DbContextOptions<AbpStudyDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(AbpStudyConsts.DbTablePrefix + "YourEntities", AbpStudyConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});

        builder.Entity<JobportalDetails>().HasNoKey();
        builder.Entity<Student>().HasNoKey();
        builder.Entity<JobDetails>().HasNoKey();
        builder.Entity<JobAllDetails>().HasNoKey();
        builder.Entity<JobSeeker>().HasNoKey();

        builder.Entity<Teacher>(t =>
        {
            t.ToTable(nameof(Teacher));
        });

        builder.Entity<Client>(b =>
        {
            b.ToTable(nameof(Client));
        });

        builder.Entity<Student>(s =>
        {
            s.ToTable(nameof(Student));
            s.HasKey(e => e.StudId);
        });

        builder.Entity<JobportalDetails>(j =>
        {
            j.ToTable(nameof(JobportalDetails));
        });

        builder.Entity<JobAllDetails>(h =>
        {
            h.ToTable(nameof(JobAllDetails));
        });
    }
}
