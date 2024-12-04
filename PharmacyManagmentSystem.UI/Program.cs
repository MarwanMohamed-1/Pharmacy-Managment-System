using PharmacyManagmentSystem.UI.Forms;
using Microsoft.Extensions.DependencyInjection;
using PharmacyManagementSystem.BLL.Services;
using PharmacyManagementSystem.DAL.DataContext;
using PharmacyManagementSystem.DAL.Repository.IRepository;

namespace PharmacyManagmentSystem.UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Initialize application settings before creating any forms
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();

            // Set up dependency injection
            var services = new ServiceCollection();
            ConfigureServices(services);

            // Build the service provider and run the main form
            using (var serviceProvider = services.BuildServiceProvider())
            {
                //var mainform = serviceProvider.GetRequiredService<Landing>();
                //Application.Run(mainform);

                var mainForm = serviceProvider.GetRequiredService<PMSWindow>();
                Application.Run(mainForm);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            // Register the ApplicationDbContext
            services.AddScoped<ApplicationDbContext>();

            // Register the Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Register services
            services.AddScoped<ProductService>();
            services.AddScoped<CategoryService>();
            services.AddScoped<CustomerService>();
            services.AddScoped<SaleService>();
            services.AddScoped<PurchaseService>();
            services.AddScoped<SupplierService>();
            services.AddScoped<SaleItemService>();
            services.AddScoped<PurchaseItemService>();
            services.AddScoped<UsersService>();

            // Register the forms
            services.AddTransient<PMSWindow>(); // Assuming Form1 is the main form
            services.AddTransient<Landing>();
            services.AddTransient<Drug>();
            services.AddTransient<Purchase_Report>();
            services.AddTransient<Sales_Report>();


            // You can add other forms here as needed
            // services.AddTransient<OtherForm>();

           
        }
    }
}
