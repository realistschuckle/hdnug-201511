using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using Npgsql;
using Dapper;

namespace Componentpalooza
{
		public class User
		{
				public int Id { get; set; }
				public string FirstName { get; set; }
				public string LastName { get; set; }
				public string Email { get; set; }
				public DateTime InsertedAt { get; set; }

				public override string ToString()
				{
						return LastName + ", " + FirstName;
				}
		}

    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
            // Add the platform handler to the request pipeline.
            app.UseIISPlatformHandler();

            app.Run(async (context) =>
            {
								using (var conn = new NpgsqlConnection("Host=localhost;Username=postgres;Password=postgres;Database=polyvox_dev"))
								{
										var people = conn.Query<User>("select id as Id, first_name as FirstName, last_name as LastName from users");
										await context.Response.WriteAsync(string.Format("Hello {0}!!!", string.Join("\n\t", people)));
								}
            });
        }
    }
}
