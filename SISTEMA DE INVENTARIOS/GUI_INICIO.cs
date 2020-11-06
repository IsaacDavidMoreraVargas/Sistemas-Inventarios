using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_DE_INVENTARIOS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            startPaths();
            InitializeComponent();
        }

        int widthPanel;
        int heigthPanel;
        int originalSizePanel;
        string[] menuComponentsOne = { "REGISTRAR MATERIALES", "REGISTRAR VENTAS", "REGISTRAR INSTRUMENTOS" };
        string[] messageWrong = { "NO SE PUEDE PROCEDER, ELIGE ADECUADAMENTE" };
        string[] corePaths = { "MATERIALES", "VENTAS", "INSTRUMENTOS" };
        string[] menuComponentsRegisterMaterials = { "LAMINA" };
        string[] menuComponentsMonth = { "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE" };
        string[] menuComponentsRegisterInstruments = { "PULGADAS-PRECIO", "REGISTRO METRICO", "REGISTRO MATERIALES" };
        string[] menuAdd = { "" };
        string firstOrder = "";
        string secondOrder = "";
        string metricas = "METRIC";
        string materiales = "MATERIAL";
        string pulgadas = "INCHES";
        Label label;
        paths_Basements callToSetPaths = new paths_Basements();

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "SISTEMA INVENTARIOS";
            panel1.BackColor = Color.Black;
            
            panel3.AutoScroll = false;
            originalSizePanel = panel1.Width;
            panel3.HorizontalScroll.Enabled = false;
            panel3.HorizontalScroll.Visible = false;
            panel3.AutoScroll = true;
            label2.Visible = false;
            labelClose.BackColor = Color.LightSteelBlue;
            labelClose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            addComponents();
        }

        private void startPaths()
        {

            string corePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "SISTEMA DE INSTRUMENTOS" + "\\";
            callToSetPaths.pathFolderDocument = corePath;
            createPaths(callToSetPaths.pathFolderDocument);
            for (int numberPath=0; numberPath<corePath.Length; numberPath++)
            {
                switch(numberPath)
                {
                    case 0:
                        callToSetPaths.pathFolderDocumentandRegisterMaterials = corePath + corePaths[0] + "\\";
                        createPaths(callToSetPaths.pathFolderDocumentandRegisterMaterials);
                        break;
                    case 1:
                        callToSetPaths.pathFolderDocumentandRegisterSells = corePath + corePaths[1] + "\\";
                        createPaths(callToSetPaths.pathFolderDocumentandRegisterSells);
                        break;       
                    case 2:
                        callToSetPaths.pathFolderDocumentandRegisterInstruments = corePath + corePaths[2] + "\\";
                        createPaths(callToSetPaths.pathFolderDocumentandRegisterInstruments);
                        break;
                }
            }

            
            string pathInstruments = callToSetPaths.pathFolderDocumentandRegisterInstruments;
            for (int numberPath = 0; numberPath < menuComponentsRegisterInstruments.Length; numberPath++)
            {
                switch (numberPath)
                {
                    case 0:
                        callToSetPaths.pathFolderInstrumentsAndInches = pathInstruments + pulgadas + ".txt";
                        //createPaths(callToSetPaths.pathFolderInstrumentsAndInches);
                        break;
                    case 1:
                        callToSetPaths.pathFolderInstrumentsAndMetrics = pathInstruments  + metricas + ".txt";
                        //createPaths(callToSetPaths.pathFolderInstrumentsAndMetrics);
                        break;
                    case 2:
                        callToSetPaths.pathFolderInstrumentsAndMaterial = pathInstruments + materiales + ".txt";
                        //createPaths(callToSetPaths.pathFolderInstrumentsAndMaterial);
                        break;
                }
            }
            
        }

        private void createPaths(string create)
        {
            if (!Directory.Exists(create))
            {
                Directory.CreateDirectory(create);
            }
            
        }

        private void addComponents()
        {
            //panel1.BackColor = Color.LightSeaGreen;
            widthPanel = panel1.Width;
            heigthPanel = panel1.Height / 3;
            heigthPanel -=2;
            int Xposition = 1;    
            for (int labelNumber = 0; labelNumber < menuComponentsOne.Length; labelNumber++)
            {
                label = new Label();
                label.Text = menuComponentsOne[labelNumber];
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.BackColor = Color.LightSlateGray;
                label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                label.Visible = true;
                label.Name = "label" + labelNumber;
                label.Location = new System.Drawing.Point(0, Xposition);
                label.Size = new System.Drawing.Size(widthPanel, heigthPanel);
                label.Click += new EventHandler(labelClickFirst);
                panel1.Controls.Add(label);
                Xposition += heigthPanel+2;
            }
            
        }

        
        private void labelClickFirst(object sender, EventArgs e)
        {
            label2.Visible = false;
            string text = ((System.Windows.Forms.Label)sender).Text;
            firstOrder = text;
            panel3.Controls.Clear();

            if (text == menuComponentsOne[0])
            {
                if (File.Exists(callToSetPaths.pathFolderInstrumentsAndMaterial))
                {
                    menuAdd = File.ReadAllLines(callToSetPaths.pathFolderInstrumentsAndMaterial);
                    //menuAdd = menuComponentsRegisterMaterials;
                }
                panel3.Width = originalSizePanel;
                label2.Text = text;
            }
            else if (text == menuComponentsOne[1])
            {
                menuAdd = menuComponentsMonth;
                panel3.Width = originalSizePanel + 17;
                label2.Text = text;
            }
            else if (text == menuComponentsOne[2])
            {
                menuAdd = menuComponentsRegisterInstruments;
                panel3.Width = originalSizePanel;
                label2.Text = text;
            }

            for (int numberToColor = 0; numberToColor < menuComponentsOne.Length; numberToColor++)
            {
                if (firstOrder == menuComponentsOne[numberToColor])
                {
                    panel1.Controls[numberToColor].BackColor = Color.LightGray;
                }
                else
                {
                    panel1.Controls[numberToColor].BackColor = Color.LightSlateGray;
                }
            }

            int Xposition = 1;
            for (int labelNumber = 0; labelNumber < menuAdd.Length; labelNumber++)
            {
                label = new Label();
                label.Text = menuAdd[labelNumber];
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.BackColor = Color.LightSteelBlue;
                label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                label.Visible = true;
                label.Name = "label" + labelNumber;
                label.Location = new System.Drawing.Point(0, Xposition);
                label.Size = new System.Drawing.Size(widthPanel, heigthPanel);
                label.Click += new EventHandler(labelClickSecond);
                panel3.Controls.Add(label);
                Xposition += heigthPanel+2;
            }
            panel3.BackColor = Color.Black;
        }

        private void labelClickSecond(object sender, EventArgs e)
        {
            label2.Visible = true;
            label2.BackColor = Color.LightSteelBlue;
            label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            string text = ((System.Windows.Forms.Label)sender).Text;
            secondOrder = text;
            for(int numberToColor=0; numberToColor < menuAdd.Length; numberToColor++)
            {
                if(secondOrder== menuAdd[numberToColor])
                {
                    panel3.Controls[numberToColor].BackColor = Color.LightGray;
                }else
                {
                    panel3.Controls[numberToColor].BackColor = Color.LightSteelBlue;
                }
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //string[] menuComponentsRegisterInstruments = { "PULGADAS-PRECIO", "REGISTRO METRICO", "REGISTRO MATERIALES" };
            //string[] menuComponentsOne = { "REGISTRAR MATERIALES", "REGISTRAR VENTAS", "REGISTRAR INSTRUMENTOS" };

            if (firstOrder!=""&&secondOrder!="")
            {
                if (firstOrder == menuComponentsOne[0])
                {
                    string pathMaterial = callToSetPaths.pathFolderDocumentandRegisterMaterials + secondOrder + "\\";
                    createPaths(pathMaterial);
                    if (secondOrder == "LAMINA")
                    {
                        GUI_REGISTRAR_MATERIALES callToGui = new GUI_REGISTRAR_MATERIALES();
                        callToGui.orderMaterial(secondOrder, pathMaterial, callToSetPaths);
                        callToGui.ShowDialog();
                    }
                    else if (secondOrder == "GANCHO")
                    {

                    }
                }
                else if (firstOrder == menuComponentsOne[1])
                {
                    string pathMaterial = callToSetPaths.pathFolderDocumentandRegisterSells + secondOrder + "\\";
                    createPaths(pathMaterial);
                    GUI_REGISTRAR_INVENTARIO callToGui = new GUI_REGISTRAR_INVENTARIO();
                    callToGui.orderMaterial(secondOrder, pathMaterial, callToSetPaths);
                    callToGui.ShowDialog();
                }
                else if (firstOrder == menuComponentsOne[2])
                {
                    if (secondOrder == menuComponentsRegisterInstruments[0])
                    {
                        GUI_REGISTRAR_INSTRUMENTOS callToGui = new GUI_REGISTRAR_INSTRUMENTOS();
                        callToGui.receivedGlobalOrder("INCHES");
                        callToGui.referenceAsemblerToMetrics(callToSetPaths);
                        callToGui.Show();
                    }
                    else if (secondOrder == menuComponentsRegisterInstruments[1])
                    {
                        GUI_REGISTRAR_INSTRUMENTOS callToGui = new GUI_REGISTRAR_INSTRUMENTOS();
                        callToGui.receivedGlobalOrder("METRIC");
                        callToGui.referenceAsemblerToMetrics(callToSetPaths);
                        callToGui.Show();
                    }
                    else if (secondOrder == menuComponentsRegisterInstruments[2])
                    {
                        GUI_REGISTRAR_INSTRUMENTOS callToGui = new GUI_REGISTRAR_INSTRUMENTOS();
                        callToGui.receivedGlobalOrder("MATERIAL");
                        callToGui.referenceAsemblerToMetrics(callToSetPaths);
                        callToGui.Show();
                    }
                    
                }
            }
            else
            {
                MessageBox.Show(messageWrong[0]);
            }
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
