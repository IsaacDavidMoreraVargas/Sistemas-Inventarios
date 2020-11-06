using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace SISTEMA_DE_INVENTARIOS
{
    public partial class GUI_REGISTRAR_MATERIALES : Form
    {
        public GUI_REGISTRAR_MATERIALES()
        {
            InitializeComponent();
        }

        string globalOrderMaterial;
        string globalPathReadAndWrite;
        string []globalMenu = {"SALIR","+ AÑADIR","BUSCAR"};
        int widthPanel;
        int heigthPanel;
        int originalSizePanel;
        string threeLine = "---";
        paths_Basements referenceToPaths;
        generalMethods callToGeneralMethods = new generalMethods();

        Label label;
        private void GUI_INSTRUMENTOS_UNO_Y_DOS_Load(object sender, EventArgs e)
        {
            this.Text = "SISTEMA DE REGISTRO";
            panel1.BackColor = Color.Black;
            originalSizePanel = panel1.Width;
            widthPanel = panel1.Width;
            heigthPanel = panel1.Height / 3;
            heigthPanel /= 2;
            heigthPanel -= 2;

            labelSave.BackColor = Color.LightSteelBlue;
            labelErase.BackColor = Color.LightSteelBlue;

            chargeDataStart();

            comboBoxSize.Text = threeLine;
            string[] storageInstruments = File.ReadAllLines(referenceToPaths.pathFolderInstrumentsAndInches);
            for (int numberInstrument = 0; numberInstrument < storageInstruments.Length; numberInstrument++)
            {
                string value = storageInstruments[numberInstrument] + "''";
                ++numberInstrument;
                value += " ("+storageInstruments[numberInstrument]+")";
                comboBoxSize.Items.Add(value);
            }

            textBoxPrice.Enabled = false;
            panel4.Visible = false;
            labelErase.Visible=false;
        }

        private void chargeDataStart()
        {

            panel1.Controls.Clear();

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
                Xposition += heigthPanel+2;
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
                Xposition += heigthPanel+2;
            }
        }

        private void chargeDataSearch(string search)
        {

            panel1.Controls.Clear();

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
                Xposition += heigthPanel+2;
            }
            
            string[] storageFiles = Directory.GetFiles(globalPathReadAndWrite);
            for (int numberFile = 0; numberFile < storageFiles.Length; numberFile++)
            {
                string name = storageFiles[numberFile];
                name = name.Replace(globalPathReadAndWrite, "");
                name = name.Replace(".txt", "");
                
                if (name.Contains(search))
                {
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
                    Xposition += heigthPanel+2;
                }
            }
            
        }

        private void labelClickFirst(object sender, EventArgs e)
        {
            string text = ((System.Windows.Forms.Label)sender).Text;

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

            if (text==globalMenu[0])
            {
                //CLOSE
                this.Dispose();
            }else if (text == globalMenu[1])
            {
                componentsRestart();
                //AÑADIR
                panel4.Visible = true;
                labelErase.Visible = false;
                labelSave.Text = "GUARDAR";
            }
            else if (text == globalMenu[2])
            {
                componentsRestart();
                //BUSCAR
                panel4.Visible = false;
                labelErase.Visible = false;
                labelSave.Text = "GUARDAR";
                InputBox callToInput = new InputBox();
                callToInput.ShowDialog();
                string search = callToInput.getOrder();
                search = search.ToUpper();
                string[] splitOrders = search.Split("?");
                if(splitOrders[1]=="ACCEPT")
                { 
                    chargeDataSearch(splitOrders[0]);
                }
                callToInput.Dispose();
            }
            else
            {
                componentsRestart();
                //EDITAR
                labelErase.Visible = true;
                panel4.Visible = true;
                labelSave.Text = "EDITAR";
                string pathRead = globalPathReadAndWrite + text+".txt";
                string []storageLines = File.ReadAllLines(pathRead);
                textBoxName.Text = text;
                textBoxHeight.Text = storageLines[1];
                textBoxWidth.Text = storageLines[2];
                comboBoxSize.Text = storageLines[3];
                splitValuesOSize();
            }
        }

        public void orderMaterial(string materialRceived, string pathReadAndWrite, paths_Basements referencedReceived)
        {
            globalOrderMaterial = materialRceived;
            globalPathReadAndWrite = pathReadAndWrite;
            referenceToPaths = referencedReceived;
        }

        private void comboBoxSize_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void labelSave_Click(object sender, EventArgs e)
        {
            bool allowSave = true;
            string wrongMessage = "NO SE PODRA GUARDAR, PROBLEMAS:";
            if(textBoxName.Text== " " || textBoxName.Text == "")
            {
                wrongMessage += "\n-CASILLA NOMBRE VACIO";
                allowSave = false;
            }
            
            if (textBoxHeight.Text == " " || textBoxHeight.Text == "")
            {
                wrongMessage += "\n-CASILLA ANCHO VACIO";
                allowSave = false;
            }
           
            bool answer=callToGeneralMethods.parseRightFormatNumbers(textBoxWidth.Text, textBoxHeight.Text);
            if (answer == false)
            {
                allowSave = false;
                wrongMessage += "\n-FORMATO NUMEROS INCORRECTO, METROS Y CENTIMENTROS, CENTIMETROS";
            }

            if (textBoxWidth.Text == " " || textBoxWidth.Text == "")
            {
                wrongMessage += "\n-CASILLA LARGO VACIO";
                allowSave = false;
            }
           
            if (comboBoxSize.Text == threeLine)
            {
                wrongMessage += "\n-CASILLA MEDIDA VACIO";
                allowSave = false;
            }
           
            if(allowSave==true)
            {
               int index = panel1.Controls.Count+1;
               index -= 3;
               string name = textBoxName.Text.ToUpper();
               string pathWrite = globalPathReadAndWrite;
               pathWrite += name + ".txt";
               string addString = "";
               addString += globalOrderMaterial+index.ToString() + "?";
               addString += textBoxHeight.Text + "?";
               addString += textBoxWidth.Text + "?";
               addString += comboBoxSize.Text;
               callToGeneralMethods.writeInFiles(pathWrite,addString);
               componentsRestart();
               chargeDataStart();
               MessageBox.Show("GUARDADO EXITOSAMENTE");
            }
            else
            {
                MessageBox.Show(wrongMessage);
            }
        }
        private void componentsRestart()
        {
            textBoxHeight.Text = "";
            textBoxWidth.Text = "";
            textBoxPrice.Enabled = true;
            textBoxPrice.Text = "";
            textBoxPrice.Enabled = false;
            textBoxName.Text="";
            comboBoxSize.Text = threeLine;
            labelInches.Text = "PULGADAS";
            labelWidth.Text = "ANCHO";
            labelHeight.Text = "LARGO";
        }
        
        private void textBoxHeight_TextChanged(object sender, EventArgs e)
        {
            labelHeight.Text = textBoxHeight.Text;
            labelHeight.Text += " METROS";
        }

        private void textBoxWidth_TextChanged(object sender, EventArgs e)
        {
            labelWidth.Text = textBoxWidth.Text;
            labelWidth.Text += " METROS";
        }

        private void comboBoxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            splitValuesOSize();
        }

        private void splitValuesOSize()
        {
            string[] value = comboBoxSize.Text.Split(" ");
            labelInches.Text = value[0] + " PULGADAS";
            string price = value[1];
            price = price.Replace("(", "");
            price = price.Replace(")", "");
            textBoxPrice.Enabled = true;
            textBoxPrice.Text = price;
            textBoxPrice.Enabled = false;
        }
        private void labelErase_Click(object sender, EventArgs e)
        {
            string pathErase = globalPathReadAndWrite + textBoxName.Text + ".txt";
            DialogResult answer = MessageBox.Show("¿SEGURO QUE DESEA ELIMINAR "+ textBoxName.Text+"?", "OPCIÓN RAPIDA", MessageBoxButtons.YesNo);
            switch (answer)
            {
                case DialogResult.Yes:
                    if(File.Exists(pathErase))
                    {
                        File.Delete(pathErase);
                        panel4.Visible = false;
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
