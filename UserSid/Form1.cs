using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using System.DirectoryServices.AccountManagement;
using System.Management;

namespace UserSid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT UserName FROM Win32_ComputerSystem");
            ManagementObjectCollection collection = searcher.Get();
            string username = (string)collection.Cast<ManagementBaseObject>().First()["UserName"];

            NTAccount f = new NTAccount(username);
            SecurityIdentifier s = (SecurityIdentifier)f.Translate(typeof(SecurityIdentifier));
            String sid = s.ToString();

            MessageBox.Show(sid);
        }
    }
}
