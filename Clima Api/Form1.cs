using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.Entities;

namespace Clima_Api
{
    public partial class Form1 : Form
    {
        string APIKey = "3b1e07da90d4fc52eeadc2a8588ef6dc";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public double temp(double temperatura)
        {
            double temp = temperatura - 273.15;
            return temp;
        }
        void Busqueda()
        {
            using (WebClient web = new WebClient())
            {

                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", txtCiudad.Text, APIKey);

                var json = web.DownloadString(url);
                Clima info = JsonConvert.DeserializeObject<Clima>(json);

                lbpuestadelsol.Text = convertdatetime(info.sys.sunset).ToShortTimeString();
                lbamanecer.Text = convertdatetime(info.sys.sunrise).ToShortTimeString();
                lbviento.Text = (info.wind.speed * 3.6).ToString();
                lbpresion.Text = info.main.pressure.ToString();
                double temperatura = Convert.ToDouble(info.main.temp.ToString());

                double temperaturamin = Convert.ToDouble(info.main.temp_min.ToString());

                double temperaturamax = Convert.ToDouble(info.main.temp_max.ToString());

                lbtemperatura.Text = Convert.ToString(temp(temperatura));
                lbtempmin.Text = Convert.ToString(temp(temperaturamin));
                lbtempmax.Text = Convert.ToString(temp(temperaturamax));
                lbhumidity.Text = info.main.humidity.ToString();
            }
        }
        DateTime convertdatetime(long sec)
        {
            DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(sec).ToLocalTime();
            return day;
        }
       
        private void btnbuscar_Click(object sender, EventArgs e)
        {
            Busqueda();
           
        }

        private void lbamanecer_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

