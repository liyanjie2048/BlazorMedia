var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddTransient<MediaController>();

await builder.Build().RunAsync();
