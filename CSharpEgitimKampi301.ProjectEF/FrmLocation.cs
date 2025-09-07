using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace CSharpEgitimKampi301.ProjectEF
{
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }

        EgitimKampiEFTravelDbEntities1 db = new EgitimKampiEFTravelDbEntities1();

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.TblLocation
                .Select(x => new
                {
                    x.LocationId,
                    x.Country,
                    x.Capacity,
                    x.Price,
                    x.DayNight,
                    x.GuideId,
                    GuideFullName = x.TblGuide.GuideName + " " + x.TblGuide.GuideSurname
                })
                .ToList();

            dataGridView1.DataSource = values;
        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = db.TblGuide
                .Select(x => new 
                { 
                    GuideFullName = x.GuideName + " " + x.GuideSurname,
                    x.GuideId
                })
                .ToList(); 
            
            comboGuide.DisplayMember = "GuideFullName";
            comboGuide.ValueMember = "GuideId";
            comboGuide.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TblLocation location = new TblLocation();
            location.Capacity = byte.Parse(nudCapacity.Value.ToString());
            location.Price=decimal.Parse(textPrice.Text.ToString());
            location.Country=textCountry.Text;
            location.DayNight=textDayNight.Text;
            location.GuideId = int.Parse(comboGuide.SelectedValue.ToString());
            db.TblLocation.Add(location);
            db.SaveChanges();
            MessageBox.Show("Ekleme işlemi başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textLocId.Text);
            var deletedValue = db.TblLocation.Find(id);
            db.TblLocation.Remove(deletedValue);
            db.SaveChanges();
            MessageBox.Show("Silme işlemi başarılı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textLocId.Text);
            var updatedValue = db.TblLocation.Find(id);
            updatedValue.DayNight = textDayNight.Text;
            updatedValue.Capacity = byte.Parse(nudCapacity.Text.ToString());
            updatedValue.Country = textCountry.Text;
            updatedValue.Price = decimal.Parse(textPrice.Text.ToString());
            updatedValue.GuideId = int.Parse(comboGuide.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Güncelleme işlemi başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textLocId.Text);
            var result = db.TblLocation
                .Where(x => x.LocationId == id)
                .Select(x => new
                {
                    x.LocationId,
                    x.Country,
                    x.Capacity,
                    x.Price,
                    x.DayNight,
                    x.GuideId,
                    GuideFullName = x.TblGuide.GuideName + " " + x.TblGuide.GuideSurname
                })
                .ToList();

            dataGridView1.DataSource = result;
            MessageBox.Show("İlgili satırdaki bilgiler getirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
