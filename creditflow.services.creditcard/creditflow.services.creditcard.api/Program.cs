using creditflow.services.creditcard.api.Filters;
using creditflow.services.creditcard.application.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using creditflow.services.creditcard.infrastructure;
using creditflow.services.creditcard.application;
using MassTransit;
using creditflow.services.creditcard.application.Consumers;
using creditflow.services.creditcard.infrastructure.Persistence.RabbitMQ;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)));

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<AtualizarCartaoValidator>();

builder.Services.AddInfrastructure(configuration).AddApplication();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura Masstransit
builder.Services.Configure<RabbitMQConfig>(configuration.GetSection("RabbitMQConfig"));

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<CriarCartaoConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        var rabbitMqConfig = context.GetRequiredService<IOptions<RabbitMQConfig>>().Value;

        cfg.Host(rabbitMqConfig.HostName, h =>
        {
            h.Username(rabbitMqConfig.Username);
            h.Password(rabbitMqConfig.Password);
        });

        cfg.ReceiveEndpoint(rabbitMqConfig.SolicitarCartaoQueue, ep =>
        {
            ep.ConfigureConsumer<CriarCartaoConsumer>(context);

            ep.UseDelayedRedelivery(r => r.Intervals(TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(15), TimeSpan.FromMinutes(30)));
            ep.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(5)));

            // Configuração da Dead Letter Queue (DLQ)
            ep.BindDeadLetterQueue(rabbitMqConfig.SolicitarCartaoQueueDeadLetter, rabbitMqConfig.SolicitarCartaoQueueDeadLetter);
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