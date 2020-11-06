using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SISTEMA_DE_INVENTARIOS
{
    class generalMethods
    {
        public void writeInFiles(string pathToWrite, string lineToRead)
        {
            string[] storageSplitData = lineToRead.Split('?');
            FileStream fstream = new FileStream(pathToWrite, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fstream);
            foreach (string line in storageSplitData)
            {
                writer.WriteLine(line);
            }
            writer.Close();
        }

        public bool parseRightFormatNumbers(string data1, string data2)
        {
            bool answer = false;
            try
            {
                int number1 = Convert.ToInt32(data1);
                double number2 = Convert.ToDouble(data2);
                answer = true;
            }
            catch (Exception)
            {

                try
                {
                    int number1 = Convert.ToInt32(data1);
                    int number2 = Convert.ToInt32(data2);
                    answer = true;
                }
                catch (Exception)
                {
                    try
                    {
                        double number1 = Convert.ToDouble(data1);
                        double number2 = Convert.ToDouble(data2);
                        answer = true;
                    }
                    catch (Exception)
                    {
                        try 
                        {
                            int number1 = Convert.ToInt32(data2);
                            double number2 = Convert.ToDouble(data1);
                            answer = true;
                        }
                        catch(Exception)
                        {

                        }
                    }
                }

            }
            return answer;
        }
    }
}
