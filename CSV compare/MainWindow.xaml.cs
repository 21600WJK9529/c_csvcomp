using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSV_compare
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //Buttons
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog selectedCSV = new OpenFileDialog();

            selectedCSV.Filter = "CSV files (*.csv)|*.csv";
            selectedCSV.FilterIndex = 0;
            selectedCSV.RestoreDirectory = true;
            selectedCSV.CheckFileExists = true;
            selectedCSV.ShowDialog();
            String csvPath = selectedCSV.FileName;

            lblCsv1.Content = csvPath;
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog selectedCSV2 = new OpenFileDialog();

            selectedCSV2.Filter = "CSV files (*.csv)|*.csv";
            selectedCSV2.FilterIndex = 0;
            selectedCSV2.RestoreDirectory = true;
            selectedCSV2.CheckFileExists = true;
            selectedCSV2.ShowDialog();
            String csvPath2 = selectedCSV2.FileName;

            lblCsv2.Content = csvPath2;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            String csv1= lblCsv1.Content.ToString();
            rtCsv1.AppendText(csv1);//testing if path returns correctly from label text
            String csv2 = lblCsv2.Content.ToString();
            rtCsv1.AppendText(csv2);//testing if path returns correctly from label text
            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            using (StreamReader sr = new StreamReader(csv1))
                using (StreamReader sr2 = new StreamReader(csv2))
                {
                var csv1Line = "";
                var csv2Line = "";
                while (!sr.EndOfStream && !sr2.EndOfStream)
                    {
                    int lineNo = 1;
                    csv1Line = sr.ReadLine();
                    csv2Line = sr2.ReadLine();
                    if (csv1Line.Equals(csv2Line))
                        {
                        rtCsv1.AppendText(sr.ToString());
                        rtCsv2.AppendText(sr2.ToString());
                        }
                    else
                    {
                        rtCsv1.AppendText("Error line: "+lineNo);
                        rtCsv2.AppendText("Error line: "+lineNo);
                    }
                    lineNo++;
                    }

                }
            }
            
                
                
            
        }
    }
 
