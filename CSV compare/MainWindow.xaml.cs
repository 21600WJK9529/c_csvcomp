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
            String csv2 = lblCsv2.Content.ToString();

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
                        var noErr1 = csv1Line;
                        var noErr2 = csv2Line;

                        TextRange tr = new TextRange(rtCsv1.Document.ContentEnd, rtCsv1.Document.ContentEnd);
                        tr.Text=noErr1+"\r";
                        tr.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Green);

                        TextRange tr2 = new TextRange(rtCsv2.Document.ContentEnd, rtCsv2.Document.ContentEnd);
                        tr2.Text=noErr2+"\r";
                        tr2.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Green);
                        }
                    else if(!(csv1Line.Equals(csv2Line)))
                    {
                        var err1 = csv1Line;
                        var err2 = csv2Line;

                        TextRange tr = new TextRange(rtCsv1.Document.ContentEnd, rtCsv1.Document.ContentEnd);
                        tr.Text=err1+"\r";
                        tr.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Red);

                        TextRange tr2 = new TextRange(rtCsv2.Document.ContentEnd, rtCsv2.Document.ContentEnd);
                        tr2.Text=err2+"\r";
                        tr2.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Red);
                    }
                    lineNo++;
                    }

                }

            }

        private void BtnCsvClear_Click(object sender, RoutedEventArgs e)
        {
            rtCsv1.Document.Blocks.Clear();
            rtCsv2.Document.Blocks.Clear();
        }
    }
    }
 
