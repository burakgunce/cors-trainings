namespace CORS_Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /* browserlar ýcýn farklý domaýn olmasý
             * protokol : protokolün farklý olmasý
             * host : hostun farklý olmasý
             * port : portun farklý olmasý
             */

            // ana domain : https:// www.contoso.com
            /* Origin                                        sonuc           nedený
             * https:// www.contoso.com/page/1               basrýlý         protocol host ve port ayný
             * https:// www.contoso.com/images/upld.png      basrýlý         protocol host ve port ayný
             * https:// www.contoso.com:88                  basrýsýz         protocol host ayný ancak port farklý
             * http:// www.contoso.com:88                   basrýsýz         protocol farklý host ve port ayný
             * 
             */
            
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //builder.Services.AddCors();

            builder.Services.AddCors(x => x.AddDefaultPolicy(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            //builder.Services.AddCors(x => x.AddPolicy("ClientDomains", x => x.WithOrigins("www.contoso.com", "www.test.com").AllowAnyMethod().AllowAnyHeader()));
            //bu domainlerden gelen metodlara ve headerlara izin ver

            //builder.Services.AddCors(x => x.AddPolicy("SubDomainClient", x => x.WithOrigins("www.contoso.com").SetIsOriginAllowedToAllowWildcardSubdomains()));


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            
            //app.UseCors();
            
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            //ikisinide birden tanýmlaman lazým hem serviste hem burda ayný sekýlde tanýmlamalýsýn
            
            //app.UseCors("ClientDomains");
            
            //app.UseCors("SubDomainClient");


            app.MapControllers();

            app.Run();
        }
    }
}