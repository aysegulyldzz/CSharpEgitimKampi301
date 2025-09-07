using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.ProjectEF
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        EgitimKampiEFTravelDbEntities1 db = new EgitimKampiEFTravelDbEntities1();

        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = db.TblLocation.Count().ToString();
            
            lblTotalCapacity.Text = db.TblLocation.Sum(x => x.Capacity).ToString();
            
            lblGuideCount.Text = db.TblLocation.Count().ToString();
            
            lblAverageCapacity.Text = db.TblLocation.Average(x => x.Capacity)?.ToString("0.00");
            
            lblAveragePrice.Text = db.TblLocation.Average(x => x.Price).Value.ToString("F2") + " ₺";
            
            lblLastCountry.Text = db.TblLocation.Where(x => x.LocationId == db.TblLocation.Max(y => y.LocationId)).Select(z => z.Country).FirstOrDefault();
            
            lblCapacityofKapadokya.Text = db.TblLocation.Where(x => x.Country == "Türkiye - Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();
            
            lblAysegulAvgCapacity.Text = db.TblLocation.Where(x => x.GuideId == 2).Average(x => x.Capacity).Value.ToString("F2");
            
            var franceGuideId = db.TblLocation.Where(x => x.Country == "Fransa - Paris").Select(y => y.GuideId).FirstOrDefault();
            lblGuideofFrance.Text = db.TblGuide.Where(x => x.GuideId == franceGuideId).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault();
            
            var maxCapacity = db.TblLocation.Max(x => x.Capacity);
            lblMaxCapacitiedCity.Text = db.TblLocation.Where(x => x.Capacity == maxCapacity).Select(y => y.Country).FirstOrDefault().ToString();
            
            var maxPrice = db.TblLocation.Max(x => x.Price);
            lblMostExpensiveCity.Text = db.TblLocation.Where(x => x.Price == maxPrice).Select(y =>y.Country).FirstOrDefault().ToString();
            
            var guideAysegulId = db.TblGuide.Where(x => x.GuideName == "Ayşegül" & x.GuideSurname == "Yıldız").Select(y => y.GuideId).FirstOrDefault();
            lblAysegulTourCount.Text = db.TblLocation.Where(x => x.GuideId == guideAysegulId).Count().ToString();
        }
    }
}
