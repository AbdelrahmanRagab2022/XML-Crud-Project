using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;


namespace XmlProject
{
    public partial class Form1 : Form
    {
        XmlDocument xmlfile;
        string fileName;
        int index;
        int indexPhone;
        int indexAddress;
        int indexName;
        int indexEmail;
        XmlNode root;
        XmlNodeList Employee;
        XmlNodeList Fields;
        XmlNodeList Phones;
        XmlNodeList Addresses;
        string[] AddressDetails;
        XmlNode node;
        XslCompiledTransform Xsl;

        public Form1()
        {
            InitializeComponent();
            index = 0;
            indexName = 0;
            indexPhone = 1;
            indexAddress = 2;
            indexEmail = 3;
            xmlfile = new XmlDocument();
            fileName = "Employee.xml";
            xmlfile.Load(fileName);
            root = xmlfile.DocumentElement;
            Employee = xmlfile.DocumentElement.ChildNodes;
            Fields = Employee.Item(index).ChildNodes;
            Phones = Fields.Item(indexPhone).ChildNodes;
            Addresses = Fields.Item(indexAddress).ChildNodes;
            node = root.FirstChild.CloneNode(true);
            Xsl = new XslCompiledTransform();
            Xsl.Load("Employee.xsl");

        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Next_Click(object sender, EventArgs e)
        {
            Employee = xmlfile.DocumentElement.ChildNodes;
            if (index < (Employee.Count - 1))
            {
                index++;
                this.SetNode();
                this.FillForm();

            }

            else
            {
                MessageBox.Show("This is Last Employee");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FillForm();

        }
        private void FillForm()
        {
            this.name.Text = Fields.Item(0).InnerText;
            this.Phone.Text = Phones.Item(0).InnerText;
            this.Address.Text = "";
            for (int i = 0; i < Addresses.Count; i++)
            {
                this.Address.Text += this.Addresses.Item(i).InnerText + ",";
            }
            this.Email.Text = Fields.Item(indexEmail).InnerText;
        }

        private void Prev_Click(object sender, EventArgs e)
        {
            Employee = xmlfile.DocumentElement.ChildNodes;

            if (index >= 1)
            {
                index--;
                this.SetNode();
                this.FillForm();

            }

            else
            {
                MessageBox.Show("This is First Employee");
            }
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            if (this.name.Text == "" || this.Email.Text == "" || this.Phone.Text == "" || this.Address.Text == "")
            {
                MessageBox.Show("Must Enter All Fields");
            }
            else
            {
                root.AppendChild(node);
                Employee = xmlfile.DocumentElement.ChildNodes;
                InsertNewNode();
                xmlfile.Save(fileName);
            }
        }
        private void InsertNewNode()
        {
            index = Employee.Count - 1;
            AddressDetails = this.Address.Text.Split(',');
            Fields = Employee.Item(index).ChildNodes;
            Phones = Fields.Item(indexPhone).ChildNodes;
            Addresses = Fields.Item(indexAddress).ChildNodes;
            this.UpdateNode();

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            root.RemoveChild(Employee.Item(index));
            xmlfile.Save(fileName);
            index--;
            Employee = xmlfile.DocumentElement.ChildNodes;
            this.SetNode();
            this.FillForm();

        }
        private void SetNode()
        {
            Fields = Employee.Item(index).ChildNodes;
            Phones = Fields.Item(indexPhone).ChildNodes;
            Addresses = Fields.Item(indexAddress).ChildNodes;
        }

        private void Search_Click(object sender, EventArgs e)
        {
            string name = this.searchBox.Text;
            XmlNode NameNode;
            bool flag = false;
            if (name != "")
            {
                for (int i = 0; i < Employee.Count && !flag; i++)
                {
                    NameNode = Employee.Item(i).FirstChild;
                    if (NameNode.InnerText == name)
                    {
                        this.index = i;
                        flag = true;
                    }
                }
                this.searchBox.Text = "";
                if (flag)
                {
                    this.SetNode();
                    this.FillForm();
                }
                else
                {
                    MessageBox.Show($"{name} is Not Found");
                }
            }
            else
            {
                MessageBox.Show("Empty input please Enter Name in Search input");
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (this.name.Text == "" || this.Email.Text == "" || this.Phone.Text == "" || this.Address.Text == "")
            {
                MessageBox.Show("Must Enter All Fields");
            }
            else
            {
                this.UpdateNode();
                xmlfile.Save(fileName);
            }
        }
        private void UpdateNode()
        {
            AddressDetails = this.Address.Text.Split(',');
            Fields.Item(indexName).InnerText = this.name.Text;
            Phones.Item(0).InnerText = this.Phone.Text;
            for (int i = 0; i < AddressDetails.Length - 1; i++)
            {
                Addresses.Item(i).InnerText = AddressDetails[i];

            }
            Fields.Item(indexEmail).InnerText = this.Email.Text;
        }

        private void Display_Click(object sender, EventArgs e)
        {
            Xsl.Transform("Employee.xml", "Employee.html");
            webForm web = new webForm();
            web.Show();
        }
    }

}
