using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using BookStorePro.Context;
using DevExpress.AspNetCore;
using DevExpress.AspNetCore.Reporting;
using DevExpress.Security.Resources;
using DevExpress.XtraReports.Security;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BookStorePro
{
    public class Startup
    {


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

            });



            services.AddControllers();

            services.AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme).AddCertificate();

            services.AddDbContext<ESQ13M55Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<DLE44M07Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ESQ14D56Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<DLE46A09Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ESR15M57Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<DMO57S20Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ESR16D58Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<DMS58D21Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ESRB0T52Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<DPA50H13Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EST23P65Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<DSA51P14Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ESV04M46Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<DSA53D16Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ESV05D47Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<DSC42005Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ETAX2466Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<DSP52D15Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ETX25D67Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<DWS54M17Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EVT27T69Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<DWS55D18Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<FMEN2902Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EAC59G01Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EAC60L02Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<FPER3003Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EAD62C04Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ESO11M53Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EAD63P05Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<FUS28I01Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EBN64R06Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<FUS31P04Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ECN65M07Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ECN66D08Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ECR67M09Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ECR68D10Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EVC26T68Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ECUR6911Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ABAR1616Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EDB72M14Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ABCH1717Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EDB73D15Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ABOM1515Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EDL74M16Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ABR02002Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EDL75D17Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ACT01001Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EDSV7D13Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<AFI04M04Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EDSV7M12Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<AFI05V05Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EEX76R18Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<AGE06006Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EFN77Y19Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<AMNF0303Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EJR78M20Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<APF09V09Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EJR79D21Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<APR08F08Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ELG61P03Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<APR12L12Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EMR80M22Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<APR13R13Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EMR81D23Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ASKU0707Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<AST14R14Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EPA83M25Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EPA84D26Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<AUN10010Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EPB90T32Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<AUN11C11Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EPC85C27Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<BAG30R13Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EPC86P28Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<BCLM3114Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EPC87R29Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<BCN22S05Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EPC92M34Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<BDA28T11Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EPC93D35Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<BDL29A12Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EPO94M36Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<BDMR2710Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EPO95D37Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<BSA26C09Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EPR91T33Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<BSM25D08Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EPR96M38Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<BSR21D04Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EPR97D39Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<BST18001Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EPS88M30Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<BST19P02Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EPS89D31Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<BST20R03Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<EPT82B24Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<BST23S06Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ERE98M40Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<BST24M07Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ERE99D41Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<CCUS3201Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ERI00M42Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<CNO34D03Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ERI01D43Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<CNOT3302Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ERO02M44Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<COF35T04Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ERO03D45Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<COF36M05Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ESA06M48Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<COF37D06Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<CSCH3807Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ESA07D49Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<DBO56D19Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ESB09T51Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<DDG39002Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ESE18C60Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<DDP40003Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ESE19M61Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<DEM38T01Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ESE20D62Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<DEM41I04Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ESER1759Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<DEM43S06Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ESF08P50Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<DEM45L08Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ESJ21M63Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<DEM49A12Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ESJ22D64Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<DHO47D10Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ESO12D54Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<DHO48S11Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<BOR33015Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<BOR35T17Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<BOT36A18Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ABK40D23Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ABK39L22Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<ECR43L72Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));

            services.AddDbContext<vwCtlContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));

            services.AddDevExpressControls();
            ScriptPermissionManager.GlobalInstance = new ScriptPermissionManager(ExecutionMode.Unrestricted);
            services
                .AddMvc()
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
            services.ConfigureReportingServices(configurator => {
                configurator.ConfigureWebDocumentViewer(viewerConfigurator => {
                    viewerConfigurator.UseCachedReportSourceBuilder();
                });
            });

            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                DevExpress.Printing.CrossPlatform.CustomEngineHelper.RegisterCustomDrawingEngine(
                    typeof(
                        DevExpress.CrossPlatform.Printing.DrawingEngine.PangoCrossPlatformEngine
                    ));
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            app.UseDevExpressControls();
            System.Net.ServicePointManager.SecurityProtocol |= System.Net.SecurityProtocolType.Tls12;


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseCors("CorsPolicy");
            //app.UseCors(x => x
            //   .AllowAnyOrigin()
            //   .AllowAnyMethod()
            //   .AllowAnyHeader());
            app.UseHttpsRedirection();

            app.UseStaticFiles();
      
            //app.UseSession();
            //app.UseMiddleware<BasicAuthMiddleware>();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToController(action: "Index", controller: "Home");
               // endpoints.RequireAuthorization();

            });
            
        }
    }
}
