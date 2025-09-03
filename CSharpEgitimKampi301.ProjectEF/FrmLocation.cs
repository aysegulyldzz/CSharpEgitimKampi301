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
                    GuideId = x.GuideId,
                    GuideName = x.TblGuide.GuideName,
                    GuideSurname = x.TblGuide.GuideSurname
                })
                .ToList();

            dataGridView1.DataSource = values;
        }
    }
}
