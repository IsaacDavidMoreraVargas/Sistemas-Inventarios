using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SISTEMA_DE_INVENTARIOS
{
    public partial class GUI_REGISTRAR_INVENTARIO : Form
    {
        public GUI_REGISTRAR_INVENTARIO()
        {
            InitializeComponent();
        }

        string globalOrderMaterial;
        string globalPathReadAndWrite;
        int widthPanel;
        int heigthPanel;
        int originalSizePanel;
        int originalSizeSecondBigPanel;
        string threeLine = "---";
        paths_Basements referenceToPaths;
        string[] globalMenu = {"SALIR","+ IMPORTAR"};
        string[] globalSecondMenu = {"GUARDAR","IMPORTAR","AÑADIR VENTA"};
        List<string> lisfOfMaterialFiles = new List<string>();
        private void GUI_REGISTRAR_INVENTARIO_Load(object sender, EventArgs e)
        {
            this.Text = "SISTEMA DE INVENTARIOS";
            panel1.BackColor = Color.Black;
            originalSizePanel = this.Width;
            widthPanel = panel1.Width;
            heigthPanel = panel1.Height / 3;
            heigthPanel /= 2;
            heigthPanel -= 2;
            originalSizeSecondBigPanel=panel7.Width;
            panel7.Visible = false;
            this.Width= originalSizePanel-originalSizeSecondBigPanel;
            chargeDataStart();
        }
        Label label;

        private void chargeDataStart()
        {
            panel1.Controls.Clear();

            comboBoxSize.Text = threeLine;
            comboBoxListMaterial.Text = threeLine;

            panel5.Visible = false;
            textBoxPrice.Enabled = false;

            labelSave.BackColor = Color.LightSteelBlue;
            labelErase.BackColor = Color.LightSteelBlue;

            int Xposition = 1;
            for (int labelNumber = 0; labelNumber < globalMenu.Length; labelNumber++)
            {
                label = new Label();
                label.Text = globalMenu[labelNumber];
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.BackColor = Color.LightSteelBlue;
                label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                label.Visible = true;
                label.Name = "label" + labelNumber;
                label.Location = new System.Drawing.Point(0, Xposition);
                label.Size = new System.Drawing.Size(widthPanel, heigthPanel);
                label.Click += new EventHandler(labelClickFirst);
                panel1.Controls.Add(label);
                Xposition += heigthPanel + 2;
            }

            string[] storageFiles = Directory.GetFiles(globalPathReadAndWrite);
  
            for (int numberFile = 0; numberFile < storageFiles.Length; numberFile++)
            {
                string name = storageFiles[numberFile];
                name = name.Replace(globalPathReadAndWrite, "");
                name = name.Replace(".txt", "");
                label = new Label();
                label.Text = name;
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.BackColor = Color.LightSteelBlue;
                label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                label.Visible = true;
                label.Name = "label" + numberFile;
                label.Location = new System.Drawing.Point(0, Xposition);
                label.Size = new System.Drawing.Size(widthPanel, heigthPanel);
                label.Click += new EventHandler(labelClickFirst);
                panel1.Controls.Add(label);
                Xposition += heigthPanel + 2;
            }
            
        }

        
        private void labelClickFirst(object sender, EventArgs e)
        {
            string text = ((System.Windows.Forms.Label)sender).Text;
            if(text==globalMenu[0])
            {
                this.Dispose();
            }
            else if (text == globalMenu[1])
            {
                panel7.Visible = false;
                this.Width = originalSizePanel - originalSizeSecondBigPanel;
                componentsRestart();

                for (int numberToColor = 0; numberToColor < panel1.Controls.Count; numberToColor++)
                {
                    if (text == panel1.Controls[numberToColor].Text)
                    {
                        panel1.Controls[numberToColor].BackColor = Color.LightGray;
                    }
                    else
                    {
                        panel1.Controls[numberToColor].BackColor = Color.LightSteelBlue;
                    }
                }

                labelMaterial.Visible = true;
                comboBoxListMaterial.Visible = true;
                panel5.Visible = true;
                labelSave.Text = globalSecondMenu[1];
                labelErase.Visible = false;
                string[] storageFolders = Directory.GetDirectories(referenceToPaths.pathFolderDocumentandRegisterMaterials);
                foreach (string folder in storageFolders)
                {
                    string[] storagePaths = Directory.GetFiles(folder);
                    foreach (string path in storagePaths)
                    {
                        lisfOfMaterialFiles.Add(path);
                        string changeString = path;
                        changeString = changeString.Replace(folder, "");
                        changeString = changeString.Replace(".txt", "");
                        changeString = changeString.Replace("\\", "");
                        string[] storageData = File.ReadAllLines(path);
                        changeString += ": L[" + storageData[1] + "] X A[" + storageData[2] + "] x PULGADA-PRECIO[" + storageData[3] + "]";
                        comboBoxListMaterial.Items.Add(changeString);
                    }
                }
                MessageBox.Show("INFORMACION IMPORTADA A CASILLA MATERIALES");
                //System.IO.File.Copy(sourceFile, destFile, true);
            }else
            {
                panel7.Visible = true;
                this.Width = originalSizePanel;// + originalSizeSecondBigPanel;
                labelSave.Text = globalSecondMenu[2];
                panel5.Visible = true;
                labelErase.Visible = true;
                labelMaterial.Visible = false;
                comboBoxListMaterial.Visible = false;
                enableTextBox();
                //code here
                componentsRestart();
                labelMaterial.Visible = false;
                string[] storageData = File.ReadAllLines(globalPathReadAndWrite + text + ".txt");
                textBoxName.Text = text;
                textBoxHeight.Text= storageData[1];
                labelHeight.Text = storageData[1] +" METROS";
                textBoxWidth.Text = storageData[2];
                labelWidth.Text = storageData[2] + " METROS";
                comboBoxSize.Text = storageData[3];
                string []number = storageData[3].Split(" ");
                labelInches.Text = number[0] + " PULGADAS";
                textBoxPrice.Text= number[1];
                comboBoxListMaterial.Visible = false;
                //
                disableTextBox();
            }
        }

        private void enableTextBox()
        {
            textBoxHeight.Enabled = true;
            textBoxWidth.Enabled = true;
            textBoxPrice.Enabled = true;
            textBoxName.Enabled = true;
            comboBoxSize.Enabled = true;
        }
        private void disableTextBox()
        {
            textBoxHeight.Enabled = false;
            textBoxWidth.Enabled = false;
            textBoxPrice.Enabled = false;
            textBoxName.Enabled = false;
            comboBoxSize.Enabled = false;
        }
        private void componentsRestart()
        {
            textBoxHeight.Text = "";
            textBoxWidth.Text = "";
            textBoxPrice.Enabled = true;
            textBoxPrice.Text = "";
            textBoxPrice.Enabled = false;
            textBoxName.Text = "";
            comboBoxSize.Text = threeLine;
            labelInches.Text = "PULGADAS";
            labelWidth.Text = "ANCHO";
            labelHeight.Text = "LARGO";
            comboBoxListMaterial.Items.Clear();
            comboBoxListMaterial.Text = threeLine;
        }

        private void componentsRestartWithoutComboxList()
        {
            textBoxHeight.Text = "";
            textBoxWidth.Text = "";
            textBoxPrice.Enabled = true;
            textBoxPrice.Text = "";
            textBoxPrice.Enabled = false;
            textBoxName.Text = "";
            comboBoxSize.Text = threeLine;
            labelInches.Text = "PULGADAS";
            labelWidth.Text = "ANCHO";
            labelHeight.Text = "LARGO";
            comboBoxListMaterial.Text = threeLine;
        }

        public void orderMaterial(string materialReceived, string pathReadAndWrite, paths_Basements referencedReceived)
        {
            globalOrderMaterial = materialReceived;
            globalPathReadAndWrite = pathReadAndWrite;
            referenceToPaths = referencedReceived;
        }

        private void comboBoxListMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableTextBox();
            string value = comboBoxListMaterial.Text;
            value = value.Replace(": L[","?");
            value = value.Replace("] X A[", "?");
            value = value.Replace("] x PULGADA-PRECIO[", "?");
            value = value.Replace("]", "");
            string[] splitValues = value.Split("?");
            string[] price = splitValues[splitValues.Length-1].Split(" ");
            textBoxPrice.Enabled = true;
            labelInches.Text= price[0] + " PULGADAS";
            textBoxPrice.Enabled = false;
            string number = price[1];
            number = number.Replace("(","");
            number = number.Replace(")", "");
            textBoxName.Text = splitValues[0];
            textBoxHeight.Text = splitValues[1];
            labelHeight.Text = splitValues[1] + " METROS";
            textBoxWidth.Text = splitValues[2];
            labelWidth.Text = splitValues[2] + " METROS";
            comboBoxSize.Text = splitValues[3];
            textBoxPrice.Text = number;
            disableTextBox();
        }

        private void labelSave_Click(object sender, EventArgs e)
        {
            string text = ((System.Windows.Forms.Label)sender).Text;
            if (text==globalSecondMenu[0])
            {

            }else if (text == globalSecondMenu[1])
            {
                if(comboBoxListMaterial.Text==threeLine)
                {
                    MessageBox.Show("IMPOSIBLE IMPORTAR MATERIAL, ELIJE UNO PRIMERO");
                }
                else
                {
                    string pathOrigin = "";
                    string pathTarget = "";
                    foreach(string path in lisfOfMaterialFiles)
                    {
                        if(path.Contains(textBoxName.Text))
                        {
                            pathOrigin = path;
                            break;
                        }
                    }
                    pathTarget = globalPathReadAndWrite + textBoxName.Text + ".txt";
                    if(!File.Exists(pathTarget))
                    { 
                        File.Copy(pathOrigin, pathTarget, true);
                        componentsRestartWithoutComboxList();
                        chargeDataStart();
                        panel5.Visible = true;
                        MessageBox.Show("IMPORTADO CORRECTAMENTE");
                    }else
                    {
                        MessageBox.Show("ESTE MATERIAL YA EXISTE, NO SE PUEDE IMPORTAR");
                    }
                }
            }

        }

        private void labelErase_Click(object sender, EventArgs e)
        {
            string pathErase = globalPathReadAndWrite + textBoxName.Text + ".txt";
            DialogResult answer = MessageBox.Show("¿SEGURO QUE DESEA ELIMINAR " + textBoxName.Text + "?", "OPCIÓN RAPIDA", MessageBoxButtons.YesNo);
            switch (answer)
            {
                case DialogResult.Yes:
                    if (File.Exists(pathErase))
                    {
                        File.Delete(pathErase);
                        panel5.Visible = false;
                        componentsRestart();
                        chargeDataStart();

                        MessageBox.Show("ELIMINADO EXITOSAMENTE");
                    }
                    break;
                case DialogResult.No:

                    break;
            }
            
        }
    }
}
