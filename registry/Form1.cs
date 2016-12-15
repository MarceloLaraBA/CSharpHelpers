using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace registry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void save(object sender, EventArgs e)
        {
            Configuration.ConfigurationKeys key;
            Enum.TryParse<Configuration.ConfigurationKeys>(enumItems.SelectedValue.ToString(), out key);
            Configuration.UpdateValue(key, ConfigValue.Text);
        }

        private void readKey(object sender, EventArgs e)
        {
            Configuration.ConfigurationKeys key;
            Enum.TryParse<Configuration.ConfigurationKeys>(enumItems.SelectedValue.ToString(), out key);
            

            ConfigValue.Text = Configuration.GetValue(key);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConfigValue.Text = Configuration.ConfigurationKeys.eventsQueue.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            enumItems.DataSource = Enum.GetValues(typeof(Configuration.ConfigurationKeys));
        }

        private void enumItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            readKey(sender, e);
        }
    }



}
