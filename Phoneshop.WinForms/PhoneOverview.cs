using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Phoneshop.Business;
using Phoneshop.Domain;
using Phoneshop.Domain.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Phoneshop.WinForms
{
    public partial class PhoneOverview : Form
    {
        private AddPhone? addPhone;
        private readonly IPhoneService phoneService;
        private readonly IBrandService brandService;

        public PhoneOverview()
        {
            InitializeComponent();

            IConfiguration configuration;
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory)?.FullName)
                .AddJsonFile(@"C:\Users\daand\source\repos\Phoneshop\Phoneshop.WinForms\appsettings.json")
                .Build();

            ServiceCollection service = new();
            service.AddScoped<DataContext>();
            service.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            service.AddScoped<IPhoneService, PhoneService>();
            service.AddScoped<IBrandService, BrandService>();
            service.AddScoped<ILogger, DatabaseLogger>();
            service.AddSingleton<ICache, Cache>();
            service.AddSingleton(configuration);
            ServiceProvider serviceProvider = service.BuildServiceProvider();

            this.phoneService = (PhoneService)serviceProvider.GetService<IPhoneService>();
            this.brandService = (BrandService)serviceProvider.GetService<IBrandService>();

            this.GetAll();
        }

        public void GetAll()
        {
            lbAllPhones.DataSource = this.phoneService.GetAll().ToList();
            lbAllPhones.DisplayMember = "FullName";
        }

        private void lbAllPhones_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lbAllPhones.SelectedIndex >= 0)
            {
                Phone phone = (Phone)lbAllPhones.SelectedItem;
                lblBrand.Text = phone.Brand.Name;
                lblType.Text = phone.Type;
                lblPrice.Text = $"€{phone.Price:0.00}";
                lblStock.Text = phone.Stock.ToString();
                lblDescription.Text = phone.Description;
            }
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void txbSearch_TextChanged(object sender, System.EventArgs e)
        {
            if (txbSearch.Text.Length >= 3)
            {
                lbAllPhones.DataSource = phoneService.Search(txbSearch.Text).ToList();
            }
            else
            {
                this.GetAll();
            }
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            var instance = Application.OpenForms.OfType<AddPhone>().FirstOrDefault();
            if (instance == null)
            {
                this.addPhone = new AddPhone(this, phoneService, brandService);
                this.addPhone.Show();
                this.Hide();
            }
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            if (lbAllPhones.SelectedIndex >= 0)
            {
                Phone phone = (Phone)lbAllPhones.SelectedItem;
                this.phoneService.Delete(phone.Id);

                if (!phoneService.GetAll().Any(x => x.BrandId == phone.BrandId))
                {
                    brandService.Delete(phone.BrandId);
                }

                this.GetAll();
            }
            else
            {
                MessageBox.Show("Selecteer astublieft een telefoon om te verwijderen");
            }
        }
    }
}