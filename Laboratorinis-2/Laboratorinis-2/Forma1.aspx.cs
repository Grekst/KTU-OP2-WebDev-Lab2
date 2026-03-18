using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Laboratorinis_2
{
    public partial class Forma1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Data_CalculateButton_Click(object sender, EventArgs e)
        {
            LListCity cityList = InOut.ReadCity(Data_TextBox1.Text);
            LListRoad roadList = InOut.ReadRoad(Data_TextBox2.Text);
        }

        protected void Data_UploadFromInternal_Click(object sender, EventArgs e)
        {
            string fileName1 = Server.MapPath("~/Data/U8a.txt");
            string fileName2 = Server.MapPath("~/Data/U8b.txt");

            Data_TextBox1.Text = InOut.ReadFileData(fileName1);
            Data_TextBox2.Text = InOut.ReadFileData(fileName2);
        }
    }
}