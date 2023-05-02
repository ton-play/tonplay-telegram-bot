using System.Threading;
using efzgamebot.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DotNetEnv;
using System.Reflection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

UpdateHandlers updateHandlers = new UpdateHandlers();

var app = builder.Build();

app.MapGet("/health", () => "OK");

CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

await updateHandlers.StartAsync(cancellationTokenSource.Token);
app.Run();

cancellationTokenSource.Cancel();

await updateHandlers.StopAsync(cancellationTokenSource.Token);