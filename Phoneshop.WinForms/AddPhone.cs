using Phoneshop.Business.Extensions;
using Phoneshop.Domain;
using Phoneshop.Domain.Interfaces;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Phoneshop.WinForms
{
    public partial class AddPhone : Form
    {
        private readonly PhoneOverview phoneOverview;
        private readonly IPhoneService phoneService;
        private readonly IBrandService brandService;

        public AddPhone(PhoneOverview phoneOverview, IPhoneService phoneService, IBrandService brandService)
        {
            this.phoneOverview = phoneOverview;
            this.phoneService = phoneService;
            this.brandService = brandService;

            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.phoneOverview.Show();
            this.Close();
        }

        private async void btnApply_Click(object sender, EventArgs e)
        {
            if (txbBrand.Text != String.Empty
                && txbType.Text != String.Empty
                && txbDescription.Text != String.Empty
                && txbPrice.Text != String.Empty
                && txbStock.Text != String.Empty
                )
            {
                string brandName = txbBrand.Text;
                string type = txbType.Text;
                string description = txbDescription.Text;
                double price = Convert.ToDouble(txbPrice.Text);
                int stock = Convert.ToInt32(txbStock.Text);

                try
                {
                    Brand brand = brandService.GetAll().Result.FirstOrDefault(x => x.Name.ToLower() == brandName.ToLower()) ?? await brandService.Create(new Brand(brandName));

                    await phoneService.Create(new Phone(brand.Id,
                        brand,
                        type,
                        description,
                        price.PriceWithVAT(),
                        stock
                        ));

                    this.phoneOverview.GetAll();
                    this.phoneOverview.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vul alle vereiste data in");
            }
        }

        private void txbStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsNumber(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }

        private void txbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            bool isDigit = Char.IsDigit(ch);
            int backspace = 8;
            if (isDigit == false && ch != backspace && ch.ToString() != ",")
            {
                e.Handled = true;
            }

            int alreadyHasComma = txbPrice.Text.IndexOf(',');
            if (ch == ',' && alreadyHasComma > -1)
            {
                e.Handled = true;
            }
        }
    }
}