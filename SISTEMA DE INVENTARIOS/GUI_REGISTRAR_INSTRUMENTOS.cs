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
    public partial class GUI_REGISTRAR_INSTRUMENTOS : Form
    {
        public GUI_REGISTRAR_INSTRUMENTOS()
        {
            InitializeComponent();
        }

        paths_Basements specificPathsOfMetrics;
        bool allowErase = false;
        int indexErase = 0;
        string globalOrder = "";
        string pathReadAnWrite = "";
        private void GUI_REGISTRAR_INSTRUMENTOS_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            int listViewWidth = listView1.Width;
            listView1.Items[0].Remove();
            int newValue = listViewWidth / 2;

            if (globalOrder == "METRIC")
            {
                listView1.Columns[0].Text = "METRICA";
                listView1.Columns[1].Text = "VALOR";
                label1.Text = "NOMBRE";
                label2.Text = "VALOR";
                foreach (ColumnHeader column in listView1.Columns)
                {
                    column.Width = newValue;
                }
            }
            else if (globalOrder == "MATERIAL")
            {
                listView1.Columns[0].Text = "MATERIALES";
                listView1.Columns.RemoveAt(1);
                foreach (ColumnHeader column in listView1.Columns)
                {
                    column.Width = listViewWidth;
                }
                label1.Text = "MATERIAL";
                label2.Dispose();
                textBox2.Dispose();
            }
            else if(globalOrder == "INCHES")
            {
                foreach (ColumnHeader column in listView1.Columns)
                {
                    column.Width = newValue;
                }
            }
            pathReadAnWrite = specificPathsOfMetrics.pathFolderDocumentandRegisterInstruments + globalOrder + ".txt";
            chargeData();
            //MessageBox.Show(pathReadAnWrite);
        }

        private void chargeData()
        {
            if (File.Exists(pathReadAnWrite))
            {
                string[] storageData = File.ReadAllLines(pathReadAnWrite);
                if (storageData.Length >=1)
                {
                    for (int line = 0; line < storageData.Length; line++)
                    {
                        if (globalOrder == "METRIC")
                        {
                            string data1 = storageData[line];
                            ++line;
                            string data2 = storageData[line];
                            string[] data = { data1, data2 };
                            ListViewItem listViewItem = new ListViewItem(data);
                            listView1.Items.Add(listViewItem);
                        }
                        else if (globalOrder == "MATERIAL")
                        {
                            string data1 = storageData[line];
                            string[] data = { data1 };
                            ListViewItem listViewItem = new ListViewItem(data);
                            listView1.Items.Add(listViewItem);
                        }
                        else if (globalOrder == "INCHES")
                        {
                            string data1 = storageData[line];
                            ++line;
                            string data2 = storageData[line];
                            string[] data = { data1, data2 };
                            ListViewItem listViewItem = new ListViewItem(data);
                            listView1.Items.Add(listViewItem);
                        }
                    }
                    paint();
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (globalOrder == "METRIC")
            {
                try
                {
                    int number2 = Convert.ToInt32(textBox2.Text);
                    string[] row = { textBox1.Text, textBox2.Text };
                    ListViewItem listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    paint();
                }
                catch (Exception)
                {
                    MessageBox.Show("NO SE AÑADIRA \n-VALOR: SOLO NUMEROS ENTEROS");
                }
            }
            else if (globalOrder == "MATERIAL")
            {
                string[] row = { textBox1.Text, textBox2.Text };
                ListViewItem listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
                textBox1.Text = "";
                paint();
            }
            else if (globalOrder == "INCHES")
            {
                try
                {
                    int number1 = Convert.ToInt32(textBox1.Text);
                    double number2 = Convert.ToDouble(textBox2.Text);
                    string[] row = { textBox1.Text, textBox2.Text };
                    ListViewItem listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    paint();
                }
                catch (Exception)
                {

                    try
                    {
                        int number1 = Convert.ToInt32(textBox1.Text);
                        int number2 = Convert.ToInt32(textBox2.Text);
                        string[] row = { textBox1.Text, textBox2.Text };
                        ListViewItem listViewItem = new ListViewItem(row);
                        listView1.Items.Add(listViewItem);
                        textBox1.Text = "";
                        textBox2.Text = "";
                        paint();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("NO SE AÑADIRA \n-PULGADAS: SOLO NUMEROS ENTEROS \n-PRECIOS: SOLO NUMEROS ENTEROS O SOLO CON COMA");
                    }

                }
            }
            
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void paint()
        {
            for (int column = 0; column < listView1.Items.Count; column++)
            {
                for (int row = 0; row < listView1.Items[column].SubItems.Count; row++)
                {
                    listView1.Items[column].SubItems[row].BackColor = Color.White;
                }
            }
            int indexColor = 0;
            for(int column=0; column<listView1.Items.Count; column++)
            {
                if ((indexColor % 2) == 0)
                {
                    for (int row = 0; row < listView1.Items[column].SubItems.Count; row++)
                    {
                        listView1.Items[column].SubItems[row].BackColor = Color.LightSlateGray;
                    }
                }
                ++indexColor;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            allowErase = true;
            indexErase = listView1.FocusedItem.Index;
        }

        private void buttonErase_Click(object sender, EventArgs e)
        {
            if (allowErase == true)
            {
                listView1.Items[indexErase].Remove();
                allowErase = false;
            }else
            {
                MessageBox.Show("IMPOSIBLE ELIMINAR, SELECCIONE PRIMERO");
            }
        }

        public void receivedGlobalOrder(string orderReceived)
        {
            globalOrder = orderReceived;
        }

        public void referenceAsemblerToMetrics(paths_Basements pathsReceived)
        {
            specificPathsOfMetrics = pathsReceived;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                if (File.Exists(pathReadAnWrite))
                {
                    File.Delete(pathReadAnWrite);
                }
                string addString = "";
                for (int column = 0; column < listView1.Items.Count; column++)
                {
                    for (int row = 0; row < listView1.Items[column].SubItems.Count; row++)
                    {
                        addString += listView1.Items[column].SubItems[row].Text + "?";
                    }
                }
                addString = addString.TrimEnd('?');
                addString = addString.ToUpper();
                try
                {
                    generalMethods callToMethod = new generalMethods();
                    callToMethod.writeInFiles(pathReadAnWrite, addString);
                    MessageBox.Show("GUARDADDO CORRECTAMENTE");
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR AL GUARDAR");
                }
            }else
            {
                MessageBox.Show("NO SE GUARDARA, NO EXISTEN DATOS");
            }
        }
    }
}
