using Lesson27Task;
using Microsoft.EntityFrameworkCore;
using PostsComments.Data;
using PostsComments.Services.Abstractions;
using PostsComments.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);
var config = builder.Configuration.GetConnectionString("ApplicationDbContext");
builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(config).UseLazyLoadingProxies()); ;
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
