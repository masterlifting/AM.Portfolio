using AM.Portfolio.Core.Persistence.Entities.Sql;
using AM.Portfolio.Core.Persistence.Entities.Sql.Catalogs;
using AM.Portfolio.Infrastructure.Settings;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Net.Shared.Persistence.Contexts;

using CoreEnums = AM.Portfolio.Core.Constants.Enums;
using SharedEnums = AM.Shared.Models.Constants.Enums;
using PersistenceEnums = Net.Shared.Persistence.Models.Constants.Enums;

namespace AM.Portfolio.Infrastructure.Persistence.Contexts;

public sealed class PostgrePortfolioContext : PostgreContext
{
    #region Catalogs
    public DbSet<AssetType> AssetTypes { get; set; } = null!;
    public DbSet<EventType> EventTypes { get; set; } = null!;
    public DbSet<OperationType> OperationTypes { get; set; } = null!;
    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<Exchange> Exchanges { get; set; } = null!;
    public DbSet<Provider> Providers { get; set; } = null!;
    public DbSet<ProcessStatus> ProcessStatuses { get; set; } = null!;
    public DbSet<ProcessStep> ProcessSteps { get; set; } = null!;
    #endregion

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Account> Accounts { get; set; } = null!;
    public DbSet<Asset> Assets { get; set; } = null!;
    public DbSet<Derivative> Derivatives { get; set; } = null!;
    public DbSet<Deal> Deals { get; set; } = null!;
    public DbSet<Event> Events { get; set; } = null!;
    public DbSet<Income> Incomes { get; set; } = null!;
    public DbSet<Expense> Expenses { get; set; } = null!;

    public PostgrePortfolioContext(ILoggerFactory loggerFactory, IOptions<DatabaseConnectionSection> options) : base(loggerFactory, options.Value.PostgreSQL)
    {
        //Database.EnsureDeleted();
        //Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.UseSerialColumns();

        builder.Entity<User>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired().HasMaxLength(100);
            e.Property(x => x.Description).HasMaxLength(500);
            e.Property(x => x.Created).HasDefaultValue(DateTime.UtcNow);
        });
        builder.Entity<Account>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired().HasMaxLength(200);
            e.Property(x => x.Description).HasMaxLength(500);
            e.Property(x => x.Created).HasDefaultValue(DateTime.UtcNow);

            e.HasIndex(x => new { x.Name, x.UserId, x.ProviderId }).IsUnique();
        });
        builder.Entity<Event>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Value).HasPrecision(18, 10);
            e.Property(x => x.Error).HasMaxLength(500);
            e.Property(x => x.Description).HasMaxLength(500);
            e.Property(x => x.Created).HasDefaultValue(DateTime.UtcNow);
            e.Property(x => x.Updated).HasDefaultValue(DateTime.UtcNow);
        });
        builder.Entity<Deal>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Cost).HasPrecision(18, 10);
            e.Property(x => x.Error).HasMaxLength(500);
            e.Property(x => x.Description).HasMaxLength(500);
            e.Property(x => x.Created).HasDefaultValue(DateTime.UtcNow);
            e.Property(x => x.Updated).HasDefaultValue(DateTime.UtcNow);
        });
        builder.Entity<Asset>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired().HasMaxLength(100);
            e.Property(x => x.BalanceValue).HasPrecision(18, 10);
            e.Property(x => x.BalanceCost).HasPrecision(18, 10);
            e.Property(x => x.LastDealCost).HasPrecision(18, 10);
            e.Property(x => x.Error).HasMaxLength(500);
            e.Property(x => x.Description).HasMaxLength(500);
            e.Property(x => x.Created).HasDefaultValue(DateTime.UtcNow);
            e.Property(x => x.Updated).HasDefaultValue(DateTime.UtcNow);

            e.HasIndex(x => new { x.Name, x.TypeId }).IsUnique();
        });
        builder.Entity<Derivative>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired().HasMaxLength(50);
            e.Property(x => x.Code).IsRequired().HasMaxLength(50);
            e.Property(x => x.BalanceValue).HasPrecision(18, 10);
            e.Property(x => x.BalanceCost).HasPrecision(18, 10);
            e.Property(x => x.LastDealCost).HasPrecision(18, 10);
            e.Property(x => x.Error).HasMaxLength(500);
            e.Property(x => x.Description).HasMaxLength(500);
            e.Property(x => x.Created).HasDefaultValue(DateTime.UtcNow);
            e.Property(x => x.Updated).HasDefaultValue(DateTime.UtcNow);

            e.HasIndex(x => new { x.Code, x.Name }).IsUnique();
        });
        builder.Entity<Income>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Value).HasPrecision(18, 10);
            e.Property(x => x.Description).HasMaxLength(500);
            e.Property(x => x.Created).HasDefaultValue(DateTime.UtcNow);
        });
        builder.Entity<Expense>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Value).HasPrecision(18, 10);
            e.Property(x => x.Description).HasMaxLength(500);
            e.Property(x => x.Created).HasDefaultValue(DateTime.UtcNow);
        });

        builder.Entity<ProcessStatus>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired().HasMaxLength(50);
            e.HasIndex(x => x.Name).IsUnique();
        });
        builder.Entity<ProcessStep>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired().HasMaxLength(50);
            e.HasIndex(x => x.Name).IsUnique();
        });
        builder.Entity<AssetType>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired().HasMaxLength(50);
            e.HasIndex(x => x.Name).IsUnique();
        });
        builder.Entity<Country>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired().HasMaxLength(50);
            e.HasIndex(x => x.Name).IsUnique();
        });
        builder.Entity<Exchange>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired().HasMaxLength(50);
            e.HasIndex(x => x.Name).IsUnique();
        });
        builder.Entity<Provider>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired().HasMaxLength(50);
            e.HasIndex(x => x.Name).IsUnique();
        });
        builder.Entity<OperationType>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired().HasMaxLength(50);
            e.HasIndex(x => x.Name).IsUnique();
        });
        builder.Entity<EventType>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired().HasMaxLength(50);
            e.HasIndex(x => x.Name).IsUnique();
        });

        #region Catalogs
        //builder.Entity<Country>().HasData(new Country[]
        //{
        //    new() {Id = (int) AM.Services.Common.Contracts.SharedEnums.Currencies.Rub, Name = nameof(AM.Services.Common.Contracts.SharedEnums.Currencies.Rub), Info = "₽"},
        //    new() {Id = (int) AM.Services.Common.Contracts.SharedEnums.Currencies.Usd, Name = nameof(AM.Services.Common.Contracts.SharedEnums.Currencies.Usd), Info = "$"},
        //    new() {Id = (int) AM.Services.Common.Contracts.SharedEnums.Currencies.Eur, Name = nameof(AM.Services.Common.Contracts.SharedEnums.Currencies.Eur), Info = "€"},
        //    new() {Id = (int) AM.Services.Common.Contracts.SharedEnums.Currencies.Gbp, Name = nameof(AM.Services.Common.Contracts.SharedEnums.Currencies.Gbp), Info = "£"},
        //    new() {Id = (int) AM.Services.Common.Contracts.SharedEnums.Currencies.Chy, Name = nameof(AM.Services.Common.Contracts.SharedEnums.Currencies.Chy), Info = "¥"}
        //});
        builder.Entity<ProcessStatus>().HasData(new ProcessStatus[]
        {
        new(){Id = (int)PersistenceEnums.ProcessStatuses.Draft, Name = nameof(PersistenceEnums.ProcessStatuses.Draft), Description = "Draft" },
        new(){Id = (int)PersistenceEnums.ProcessStatuses.Ready, Name = nameof(PersistenceEnums.ProcessStatuses.Ready), Description = "Ready to processing data" },
        new(){Id = (int)PersistenceEnums.ProcessStatuses.Processing, Name = nameof(PersistenceEnums.ProcessStatuses.Processing), Description = "Processing data" },
        new(){Id = (int)PersistenceEnums.ProcessStatuses.Processed, Name = nameof(PersistenceEnums.ProcessStatuses.Processed), Description = "Processed data" },
        new(){Id = (int)PersistenceEnums.ProcessStatuses.Error, Name = nameof(PersistenceEnums.ProcessStatuses.Error), Description = "Error of processing" }
        });
        builder.Entity<ProcessStep>().HasData(new ProcessStep[]
        {
        new(){Id = (int)CoreEnums.ProcessSteps.ParseBcsReport, Name = nameof(CoreEnums.ProcessSteps.ParseBcsReport)}
        });
        builder.Entity<AssetType>().HasData(new AssetType[]
        {
        new() {Id = (int) SharedEnums.AssetTypes.Valuable, Name = nameof(SharedEnums.AssetTypes.Valuable), Description = "Valuable" },
        new() {Id = (int) SharedEnums.AssetTypes.Stock, Name = nameof(SharedEnums.AssetTypes.Stock), Description = "Stocks" },
        new() {Id = (int) SharedEnums.AssetTypes.Bond, Name = nameof(SharedEnums.AssetTypes.Bond), Description = "Bonds" },
        new() {Id = (int) SharedEnums.AssetTypes.Fund, Name = nameof(SharedEnums.AssetTypes.Fund), Description = "Founds" },
        new() {Id = (int) SharedEnums.AssetTypes.CurrencyFiat, Name = nameof(SharedEnums.AssetTypes.CurrencyFiat), Description = "Fiat currencies" },
        new() {Id = (int) SharedEnums.AssetTypes.CurrencyToken, Name = nameof(SharedEnums.AssetTypes.CurrencyToken), Description = "Crypto currencies" },
        new() {Id = (int) SharedEnums.AssetTypes.NftToken, Name = nameof(SharedEnums.AssetTypes.NftToken), Description = "NFT tokens"},
        new() {Id = (int) SharedEnums.AssetTypes.RealEstate, Name = nameof(SharedEnums.AssetTypes.RealEstate), Description = "Real estates"},
        new() {Id = (int) SharedEnums.AssetTypes.PersonalEstate, Name = nameof(SharedEnums.AssetTypes.PersonalEstate), Description = "Personal estates"}
        });
        builder.Entity<Country>().HasData(new Country[]
        {
        new() { Id = (int) SharedEnums.Countries.Rus, Name = nameof(SharedEnums.Countries.Rus), Description = "Russia" },
        new() { Id = (int) SharedEnums.Countries.Usa, Name = nameof(SharedEnums.Countries.Usa), Description = "USA" },
        new() { Id = (int) SharedEnums.Countries.Chn, Name = nameof(SharedEnums.Countries.Chn), Description = "China" },
        new() { Id = (int) SharedEnums.Countries.Deu, Name = nameof(SharedEnums.Countries.Deu), Description = "Deutschland" },
        new() { Id = (int) SharedEnums.Countries.Gbr, Name = nameof(SharedEnums.Countries.Gbr), Description = "Great Britain" },
        new() { Id = (int) SharedEnums.Countries.Che, Name = nameof(SharedEnums.Countries.Che), Description = "Switzerland" },
        new() { Id = (int) SharedEnums.Countries.Jpn, Name = nameof(SharedEnums.Countries.Jpn), Description = "Japan" }
        });
        builder.Entity<Exchange>().HasData(new Exchange[]
        {
        new() {Id = (int) SharedEnums.Exchanges.Nasdaq, Name = nameof(SharedEnums.Exchanges.Nasdaq) },
        new() {Id = (int) SharedEnums.Exchanges.Nyse, Name = nameof(SharedEnums.Exchanges.Nyse)},
        new() {Id = (int) SharedEnums.Exchanges.Fwb, Name = nameof(SharedEnums.Exchanges.Fwb)},
        new() {Id = (int) SharedEnums.Exchanges.Hkse, Name = nameof(SharedEnums.Exchanges.Hkse)},
        new() {Id = (int) SharedEnums.Exchanges.Lse, Name = nameof(SharedEnums.Exchanges.Lse)},
        new() {Id = (int) SharedEnums.Exchanges.Sse, Name = nameof(SharedEnums.Exchanges.Sse)},
        new() {Id = (int) SharedEnums.Exchanges.Spbex, Name = nameof(SharedEnums.Exchanges.Spbex)},
        new() {Id = (int) SharedEnums.Exchanges.Moex, Name = nameof(SharedEnums.Exchanges.Moex)},
        new() {Id = (int) SharedEnums.Exchanges.Binance, Name = nameof(SharedEnums.Exchanges.Binance)},
        new() {Id = (int) SharedEnums.Exchanges.Ftx2, Name = nameof(SharedEnums.Exchanges.Ftx2)},
        new() {Id = (int) SharedEnums.Exchanges.Coinbase, Name = nameof(SharedEnums.Exchanges.Coinbase)}
        });
        builder.Entity<OperationType>().HasData(new OperationType[]
        {
        new() {Id = (int)CoreEnums.OperationTypes.Income, Name = nameof(CoreEnums.OperationTypes.Income) },
        new() {Id = (int)CoreEnums.OperationTypes.Expense, Name = nameof(CoreEnums.OperationTypes.Expense) }
        });
        builder.Entity<Provider>().HasData(new Provider[]
        {
        new() {Id = (int)CoreEnums.Providers.Safe, Name = nameof(CoreEnums.Providers.Safe), Description = "Private storage" },
        new() {Id = (int)CoreEnums.Providers.Bcs, Name = nameof(CoreEnums.Providers.Bcs), Description = "Broker/Bank" },
        new() {Id = (int)CoreEnums.Providers.Tinkoff, Name = nameof(CoreEnums.Providers.Tinkoff), Description = "Broker/Bank" },
        new() {Id = (int)CoreEnums.Providers.Vtb, Name = nameof(CoreEnums.Providers.Vtb), Description = "Broker/Bank" },
        new() {Id = (int)CoreEnums.Providers.Bitokk, Name = nameof(CoreEnums.Providers.Bitokk), Description = "Сrypto exchange https://bitokk.biz/" },
        new() {Id = (int)CoreEnums.Providers.XChange, Name = nameof(CoreEnums.Providers.XChange), Description = "Сrypto exchange https://xchange.cash/" },
        new() {Id = (int)CoreEnums.Providers.JetLend, Name = nameof(CoreEnums.Providers.JetLend), Description = "Crowdlending platform https://jetlend.ru/" }
        });
        builder.Entity<EventType>().HasData(new EventType[]
        {
        new()
        {
            Id = (int)CoreEnums.EventTypes.Adding,
            Name = nameof(CoreEnums.EventTypes.Adding),
            OperationTypeId = (int)CoreEnums.OperationTypes.Income,
            Description = "Increasing the asset balance"
        },
        new()
        {
            Id= (int)CoreEnums.EventTypes.Withdrawing,
            Name = nameof(CoreEnums.EventTypes.Withdrawing),
            OperationTypeId = (int)CoreEnums.OperationTypes.Expense,
            Description = "Decreasing the asset balance"
        },

        new()
        {
            Id= (int)CoreEnums.EventTypes.BankInvestments,
            Name= nameof(CoreEnums.EventTypes.BankInvestments),
            OperationTypeId = (int)CoreEnums.OperationTypes.Expense,
            Description = "Investing in bank products"
        },
        new()
        {
            Id= (int)CoreEnums.EventTypes.CrowdfundingInvestments,
            Name= nameof(CoreEnums.EventTypes.CrowdfundingInvestments),
            OperationTypeId = (int)CoreEnums.OperationTypes.Expense,
            Description = "Investing in crowdfunding"
        },
        new()
        {
            Id= (int)CoreEnums.EventTypes.CrowdlendingInvestments,
            Name= nameof(CoreEnums.EventTypes.CrowdlendingInvestments),
            OperationTypeId = (int)CoreEnums.OperationTypes.Expense,
            Description = "Investing in crowdlending"
        },
        new()
        {
            Id= (int)CoreEnums.EventTypes.VentureInvestments,
            Name= nameof(CoreEnums.EventTypes.VentureInvestments),
            OperationTypeId = (int)CoreEnums.OperationTypes.Expense,
            Description = "Venture investments"
        },

        new()
        {
            Id= (int)CoreEnums.EventTypes.InterestProfit,
            Name= nameof(CoreEnums.EventTypes.InterestProfit),
            OperationTypeId = (int)CoreEnums.OperationTypes.Income,
            Description = "Interest profit"
        },
        new()
        {
            Id= (int)CoreEnums.EventTypes.InvestmentProfit,
            Name= nameof(CoreEnums.EventTypes.InvestmentProfit),
            OperationTypeId = (int)CoreEnums.OperationTypes.Income,
            Description = "Investment profit"
        },
        new()
        {
            Id= (int)CoreEnums.EventTypes.InvestmentBody,
            Name= nameof(CoreEnums.EventTypes.InvestmentBody),
            OperationTypeId = (int)CoreEnums.OperationTypes.Income,
            Description = "Returning of investment body"
        },

        new()
        {
            Id= (int)CoreEnums.EventTypes.Splitting,
            Name= nameof(CoreEnums.EventTypes.Splitting),
            OperationTypeId = (int)CoreEnums.OperationTypes.Income,
            Description = "Increasing an asset by dividing it"
        },

        new()
        {
            Id= (int)CoreEnums.EventTypes.Donation,
            Name= nameof(CoreEnums.EventTypes.Donation),
            OperationTypeId = (int)CoreEnums.OperationTypes.Income,
            Description = "Increasing an asset by donation it"
        },

        new()
        {
            Id= (int)CoreEnums.EventTypes.Coupon,
            Name= nameof(CoreEnums.EventTypes.Coupon),
            OperationTypeId = (int)CoreEnums.OperationTypes.Income,
            Description = "Coupons from assets"
        },
        new()
        {
            Id= (int)CoreEnums.EventTypes.Dividend,
            Name= nameof(CoreEnums.EventTypes.Dividend),
            OperationTypeId = (int)CoreEnums.OperationTypes.Income,
            Description = "Dividends from assets"
        },

        new()
        {
            Id= (int)CoreEnums.EventTypes.Delisting,
            Name= nameof(CoreEnums.EventTypes.Delisting),
            OperationTypeId = (int)CoreEnums.OperationTypes.Expense,
            Description = "Excluding an asset from lists"
        },
        new()
        {
            Id= (int)CoreEnums.EventTypes.Loss,
            Name= nameof(CoreEnums.EventTypes.Loss),
            OperationTypeId = (int)CoreEnums.OperationTypes.Expense,
            Description = "Loss registration"
        },
        new()
        {
            Id= (int)CoreEnums.EventTypes.TaxIncome,
            Name= nameof(CoreEnums.EventTypes.TaxIncome),
            OperationTypeId = (int)CoreEnums.OperationTypes.Expense,
            Description = "Tax on profit by an asset"
        },
        new()
        {
            Id= (int)CoreEnums.EventTypes.TaxCountry,
            Name= nameof(CoreEnums.EventTypes.TaxCountry),
            OperationTypeId = (int)CoreEnums.OperationTypes.Expense,
            Description = "Internal tax of country"
        },
        new()
        {
            Id= (int)CoreEnums.EventTypes.TaxDeal,
            Name= nameof(CoreEnums.EventTypes.TaxDeal),
            OperationTypeId = (int)CoreEnums.OperationTypes.Expense,
            Description = "Tax for a deal"
        },
        new()
        {
            Id= (int)CoreEnums.EventTypes.TaxProvider,
            Name= nameof(CoreEnums.EventTypes.TaxProvider),
            OperationTypeId = (int)CoreEnums.OperationTypes.Expense,
            Description = "Tax to provider"
        },
        new()
        {
            Id= (int)CoreEnums.EventTypes.TaxDepositary,
            Name= nameof(CoreEnums.EventTypes.TaxDepositary),
            OperationTypeId = (int)CoreEnums.OperationTypes.Expense,
            Description = "Tax to depositary of an asset"
        },
        new()
        {
            Id= (int)CoreEnums.EventTypes.ComissionDeal,
            Name= nameof(CoreEnums.EventTypes.ComissionDeal),
            OperationTypeId = (int)CoreEnums.OperationTypes.Expense,
            Description = "Commission for a deal"
        },
        new()
        {
            Id= (int)CoreEnums.EventTypes.ComissionProvider,
            Name= nameof(CoreEnums.EventTypes.ComissionProvider),
            OperationTypeId = (int)CoreEnums.OperationTypes.Expense,
            Description = "Commission to provider"
        },
        new()
        {
            Id= (int)CoreEnums.EventTypes.ComissionDepositary,
            Name= nameof(CoreEnums.EventTypes.ComissionDepositary),
            OperationTypeId = (int)CoreEnums.OperationTypes.Expense,
            Description = "Commission to depositary of an asset"
        } });
        #endregion
    }
}
