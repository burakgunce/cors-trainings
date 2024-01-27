namespace CORS_Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /* browserlar �c�n farkl� doma�n olmas�
             * protokol : protokol�n farkl� olmas�
             * host : hostun farkl� olmas�
             * port : portun farkl� olmas�
             */

            // ana domain : https:// www.contoso.com
            /* Origin                                        sonuc           neden�
             * https:// www.contoso.com/page/1               basr�l�         protocol host ve port ayn�
             * https:// www.contoso.com/images/upld.png      basr�l�         protocol host ve port ayn�
             * https:// www.contoso.com:88                  basr�s�z         protocol host ayn� ancak port farkl�
             * http:// www.contoso.com:88                   basr�s�z         protocol farkl� host ve port ayn�
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
            //ikisinide birden tan�mlaman laz�m hem serviste hem burda ayn� sek�lde tan�mlamal�s�n
            
            //app.UseCors("ClientDomains");
            
            //app.UseCors("SubDomainClient");


            app.MapControllers();

            app.Run();
        }
    }
}