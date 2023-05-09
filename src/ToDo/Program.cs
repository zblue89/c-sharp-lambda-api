using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using ToDo.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var options = builder.Configuration.GetAWSOptions();
builder.Services.AddDefaultAWSOptions(options)
  .AddAWSService<IAmazonDynamoDB>()
  .AddSingleton<IDynamoDBContext, DynamoDBContext>()
  .AddSingleton<IToDoRepository, ToDoRepository>();

// Add AWS Lambda support. When application is run in Lambda Kestrel is swapped out as the web server with Amazon.Lambda.AspNetCoreServer. This
// package will act as the webserver translating request and responses between the Lambda event source and ASP.NET Core.
builder.Services.AddAWSLambdaHosting(LambdaEventSource.RestApi);

var app = builder.Build();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => "Welcome to running ASP.NET Core Minimal API on AWS Lambda");

app.Run();
