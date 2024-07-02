using creditflow.services.client.api.Filters;
using creditflow.services.client.application;
using creditflow.services.client.application.Consumers;
using creditflow.services.client.application.Validators;
using creditflow.services.client.infrastructure;
using creditflow.services.client.infrastructure.MessageBus;
using FluentValidation;
using FluentValidation.AspNetCore;
using MassTransit;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)));

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CriarClienteValidator>();

builder.Services.AddInfrastructure(configuration).AddApplication();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura Masstransit
builder.Services.Configure<RabbitMQConfig>(opt => configuration.GetSection("RabbitMQConfig"));

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<PropostaAceitaConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        RabbitMQConfig rabbitMqConfig = context.GetRequiredService<IOptions<RabbitMQConfig>>().Value;
        cfg.Host(rabbitMqConfig.HostName, h =>
        {
            h.Username(rabbitMqConfig.Username);
            h.Password(rabbitMqConfig.Password);
        });

        cfg.ReceiveEndpoint(rabbitMqConfig.NotificarPropostaAceitaQueue, ep =>
        {
            ep.ConfigureConsumer<PropostaAceitaConsumer>(context);
            ep.UseDelayedRedelivery(r => r.Intervals(TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(15), TimeSpan.FromMinutes(30)));
            ep.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(5)));
            ep.BindDeadLetterQueue("", rabbitMqConfig.NotificarPropostaAceitaQueueDeadLetter);
        });

    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();