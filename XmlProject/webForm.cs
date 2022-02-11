using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace XmlProject
{
    public partial class webForm : Form
    {
        string url;
        public webForm()
        {
            InitializeComponent();
            url = "file:///E:/PD%20and%20Bi%20intake%2042/Technology%20Courses/3-XML/XML%20Project/XML%20Project/XmlProject/bin/Debug/Employee.html";
            webBrowser1.Navigate(url);
        }

    }
}
