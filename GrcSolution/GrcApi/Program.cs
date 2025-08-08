using Arm.GrcApi.Models;
using Arm.GrcApi.Modules.Shared;
using Arm.GrcApi.SetupConfigurations;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Text.Json;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;
using GrcApi;

var builder = WebApplication.CreateBuilder(args);


//Setup Serilog for Dependency injection
builder.Host.UseSerilog((context, services, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.File(
       System.IO.Path.Combine(builder.Configuration["LogPath"], "grctoolapi_logs.txt"),
       rollingInterval: RollingInterval.Hour,
       fileSizeLimitBytes: 10 * 1024 * 1024,
       retainedFileCountLimit: 24,
       rollOnFileSizeLimit: true,
       shared: true,
       flushToDiskInterval: TimeSpan.FromSeconds(1))
        );

builder.Services.AddJwtConfigurations(builder.Configuration);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RiskManagmentEmployeeOnly", policy => policy.RequireClaim("department", "Risk Management"));
    //options.AddPolicy("RiskChampion", policy => policy.RequireClaim("department", "Risk Management"));
    options.AddPolicy("RiskChampionOnly", policy => policy.RequireRole(GRCUserRole.RiskChampion));
    options.AddPolicy("UnitHeadOnly", policy => policy.RequireRole(GRCUserRole.UnitHead));
    options.AddPolicy("OtherComplianceUserOnly", policy => policy.RequireRole(GRCUserRole.OtherComplianceUser));
    options.AddPolicy("ComplianceOfficerOnly", policy => policy.RequireRole(GRCUserRole.ComplianceOfficer));
    options.AddPolicy("HROfficerOnly", policy => policy.RequireRole(GRCUserRole.HROfficer));
    options.AddPolicy("FINCONOnly", policy => policy.RequireRole(GRCUserRole.FINCON));
    options.AddPolicy("TREASURYOnly", policy => policy.RequireRole(GRCUserRole.Treasury));
    options.AddPolicy("InternalAuditOfficerOnly", policy => policy.RequireRole(GRCUserRole.InternalAuditOfficer));
    options.AddPolicy("InternalAuditSupervisorOnly", policy => policy.RequireRole(GRCUserRole.InternalAuditSupervisor));
    options.AddPolicy("InternalControlOfficerOnly", policy => policy.RequireRole(GRCUserRole.InternalControlOfficer));
    options.AddPolicy("InternalControlSupervisorOnly", policy => policy.RequireRole(GRCUserRole.InternalControlSupervisor));
    options.AddPolicy("InternalAuditManagerConcern", policy => policy.RequireRole(GRCUserRole.InternalAuditManagerConcern));
    options.AddPolicy("InternalAuditExecutiveManagerConcern", policy => policy.RequireRole(GRCUserRole.InternalAuditExecutiveManagerConcern));
    options.AddPolicy("InternalControlCallOverOfficerOnly", policy => policy.RequireRole(GRCUserRole.InternalControlCallOverOfficer));
    options.AddPolicy("InternalControlCallOverSupervisorOnly", policy => policy.RequireRole(GRCUserRole.InternalControlCallOverSupervisor));
    options.AddPolicy("OperationControlOfficerOnly", policy => policy.RequireRole(GRCUserRole.OperationControlOfficer));
    options.AddPolicy("OperationControlSupervisorOnly", policy => policy.RequireRole(GRCUserRole.OperationControlSupervisor));   
    options.AddPolicy("InternalAuditeeOnly", policy => policy.RequireRole(GRCUserRole.InternalAuditee));
    options.AddPolicy("SuperAdminOnly", policy => policy.RequireRole(GRCUserRole.SuperAdmin));
    options.AddPolicy("AdminOnly", policy => policy.RequireRole(GRCUserRole.Admin));
    options.AddPolicy("InfoSecOfficerOnly", policy => policy.RequireRole(GRCUserRole.InfoSecOfficer));
    options.AddPolicy("InfoSecISORiskChampionOnly", policy => policy.RequireRole(GRCUserRole.InfoSecISORiskChampion));
    options.AddPolicy("InfoSecISOUnitHeadOnly", policy => policy.RequireRole(GRCUserRole.InfoSecISOUnitHead));
});

//Rate limiter
builder.Services.AddRateLimiter(rateLimiterOption =>
{
    rateLimiterOption.RejectionStatusCode = StatusCodes.Status423Locked;
    rateLimiterOption.AddFixedWindowLimiter(policyName: "fixed", options =>
    {
        options.Window = TimeSpan.FromMinutes(5);
        options.PermitLimit = 5;
        options.QueueLimit = 0;
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    });
});

//set up Graylog
//builder.RegisterSerilog();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddHttpClient();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<GrcToolDbContext>(
opts => opts.UseSqlServer("name=GrcToolDbConnection", options => options.MigrationsAssembly("GrcApi"))
    );
builder.Services
   .AddHealthChecks()
   .AddDbContextCheck<Arm.GrcApi.Models.GrcToolDbContext>();
builder.Services.AddCors();

builder.Services.AddHttpClient("emailMessageClient", client =>
{
    client.Timeout = TimeSpan.FromMinutes(1);
    client.DefaultRequestHeaders.Clear();
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

// register all the modules in the modules directory
builder.Services.RegisterModules(builder.Configuration);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.SerializerOptions.WriteIndented = true;

});

builder.Services.AddSwagggerConfigurations();

//#region new swag gen

//builder.Services.AddSwaggerGen(c =>
//{
//    //c.SwaggerDoc("v1", new OpenApiInfo { Title = "ParallexBank.Solution.PanGeneration.API", Version = "v1" });
//    c.SwaggerDoc("v1", new OpenApiInfo
//    {
//        Title = "GRC Tool API",
//        Version = "v1",
//        Description = "An API for GRC",
//        TermsOfService = new Uri("https://www.arm.com.ng/"),
//        Contact = new OpenApiContact
//        {
//            Name = "Asset & Resource Management Holding Company (ARM) Limited.",
//            Email = "enquiries@arm.com.ng",
//            Url = new Uri("https://arminvestmentcenter.com/"),
//        },
//        License = new OpenApiLicense
//        {
//            Name = "ARM Open Api License Agreement",
//            Url = new Uri("https://www.arm.com.ng")
//        }
//    });

//    c.CustomSchemaIds(type => type.ToString());
//    c.AddServer(new OpenApiServer()
//    {
//        Url = builder.Configuration["EmailConfiguration:AddServer"],//   "https://localhost:7089/"
//                                                                    // Url = "https://stag-api.arm.com.ng/grctoolapi/" // test
//    });
//    c.DescribeAllParametersInCamelCase();
//    //c.EnableAnnotations();

//    // add JWT Authentication
//    var securityScheme = new OpenApiSecurityScheme
//    {
//        Name = "JWT Authentication",
//        Description = "Enter JWT Bearer token *only*",
//        In = ParameterLocation.Header,
//        Type = SecuritySchemeType.Http,
//        Scheme = "bearer", // must be lower case
//        BearerFormat = "JWT",
//        Reference = new OpenApiReference
//        {
//            Id = JwtBearerDefaults.AuthenticationScheme,
//            Type = ReferenceType.SecurityScheme
//        }

//    };
//    c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);

//    c.OperationFilter<AuthFilter>();
//    c.AddSecurityRequirement(new OpenApiSecurityRequirement
//        {
//        {securityScheme, new string[] { }}
//        });

//});

//#endregion




var app = builder.Build();

app.UseCors(builder => builder
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader());

app.MigrateDatabase();

app.UsePathBase("/grctool/api");

app.UseRouting();

app.UseStatusCodePages(async statusCodeContext
    => await Results.Problem(statusCode: statusCodeContext.HttpContext.Response.StatusCode)
                 .ExecuteAsync(statusCodeContext.HttpContext));

app.UseExceptionHandler(exceptionHandlerApp
    => exceptionHandlerApp.Run(async context
        => await Results.Problem()
                     .ExecuteAsync(context)));

app.UseRateLimiter();

app.Use(async (ctx, next) =>
{
    // Get a starting time
    var start = DateTime.Now;

    //string body = await new StreamReader(ctx.Request.Body).ReadToEndAsync();
    //app.Logger.LogInformation($"Body: {body}");
    //app.Logger.LogInformation($"Body.Length: {body.Length}");
    // Call the next piece of middleware
    await next.Invoke(ctx);

    //Execute code as the chain returns back up the list of middleware.
    var totalMs = (DateTime.Now - start).TotalMilliseconds;
    app.Logger.LogInformation(@$"Request {ctx.Request.Path}: {totalMs}ms");
});
app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();


app.MapEndpoints(builder.Configuration);
app.MapHealthChecks("/health");

app.Run();

