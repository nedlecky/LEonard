using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEonard
{
    public partial class MainForm : Form
    {

        private void DefaultDevicesBtn_Click(object sender, EventArgs e)
        {
            DevicesFilenameLbl.Text = "Untitled";

            devices = new DataTable("Devices");

            DataColumn nameColumn = devices.Columns.Add("Name", typeof(System.String));
            devices.Columns.Add("Enabled", typeof(System.Boolean));
            devices.Columns.Add("Running", typeof(System.Boolean));
            devices.Columns.Add("DeviceType", typeof(System.String));
            devices.Columns.Add("Address", typeof(System.String));

            //devices.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //devices.Columns[0].

            devices.PrimaryKey = new DataColumn[] { nameColumn };

            devices.Rows.Add(new object[] { "UR-5e", true, false, "Socket", "192.168.0.2:30000" });
            devices.Rows.Add(new object[] { "Sherlock", true, false, "TCPserver", "192.168.0.2:20000" });
            devices.Rows.Add(new object[] { "HALCON", true, false, "TCPclient", "192.168.0.2:21000" });
            devices.Rows.Add(new object[] { "Command", true, false, "TCPserver", "192.168.0.2:1000" });
            devices.Rows.Add(new object[] { "Dataman 1", true, false, "Serial", "COM3" });
            devices.Rows.Add(new object[] { "Dataman 2", true, false, "Serial", "COM4" });

            DeviceGrid.DataSource = devices;

            DefaultDevicesBtn.Enabled = false;
            LoadDevicesBtn.Enabled = true;
            SaveDevicesBtn.Enabled = false;
            SaveAsDevicesBtn.Enabled = true;
        }

        int LoadDevicesFile(string name)
        {
            Crawl("LoadDevices from " + name);
            devices = new DataTable("Devices");
            devices.ReadXml(name);
            DeviceGrid.DataSource = devices;
            DevicesFilenameLbl.Text = name;

            return 0;
        }
        private void LoadDevicesBtn_Click(object sender, EventArgs e)
        {
            // TODO: Need to close everyone down!

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open a LEonard Devices File";
            dialog.Filter = "Device files|*.dev";
            dialog.InitialDirectory = LEonardRoot;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadDevicesFile(dialog.FileName);

                DefaultDevicesBtn.Enabled = true;
                LoadDevicesBtn.Enabled = true;
                SaveDevicesBtn.Enabled = false;
                SaveAsDevicesBtn.Enabled = true;
            }
        }
        private void SaveDevicesBtn_Click(object sender, EventArgs e)
        {
            devices.AcceptChanges();

            if (DevicesFilenameLbl.Text == "Untitled" || DevicesFilenameLbl.Text == "")
                SaveAsDevicesBtn_Click(null, null);
            else
            {
                Crawl("SaveDevices to " + DevicesFilenameLbl.Text);
                devices.WriteXml(DevicesFilenameLbl.Text, XmlWriteMode.WriteSchema, true);

                DefaultDevicesBtn.Enabled = true;
                LoadDevicesBtn.Enabled = true;
                SaveDevicesBtn.Enabled = false;
                SaveAsDevicesBtn.Enabled = true;
            }
        }
        private void SaveAsDevicesBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "LEonard Devices|*.dev";
            dialog.Title = "Save a LEonard devices File";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.FileName != "")
                {
                    DevicesFilenameLbl.Text = dialog.FileName;
                    SaveDevicesBtn_Click(null, null);
                }
            }
        }

        private void DeviceGrid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Crawl("Deleting Row");

            DefaultDevicesBtn.Enabled = true;
            LoadDevicesBtn.Enabled = true;
            SaveDevicesBtn.Enabled = true;
            SaveAsDevicesBtn.Enabled = true;

        }


    }
}
