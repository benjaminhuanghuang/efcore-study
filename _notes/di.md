## Ordinary Style
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connString);
        base.OnConfiguring(optionsBuilder);
    }


## Constructor DI
    // MyDbContext.cs 
    public MyDbContext(DbContextOption<MyDbContext> options) : base(option)
    { }

    // Startup.cs
    public void ConfigureService(IServiceCollection services)
    {
        var connString = "...";
        services.AddDbContext<MyDbContext>(options => options.UseSqlServer(connString))
    }