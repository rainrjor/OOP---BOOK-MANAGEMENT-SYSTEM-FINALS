using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using static System.Collections.Specialized.BitVector32;

namespace oop_finals_draft
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {

        //private List<Book> books = new List<Book>();

        public MainWindow()
        {
            InitializeComponent();

            cbFilter1.SelectedIndex = -1;
            cbFilter2.SelectedIndex = -1;
            //   cbFilter1.Items.Add("Genre");
            //cbFilter2.Items.Add("Title");


            Genre();


        }



        private void Genre()
        {
            string filepath = "C:\\Users\\ramas\\OneDrive\\Desktop\\GENRE.txt";

            using (StreamReader reader = new StreamReader(filepath))
            {

                string content;

                while ((content = reader.ReadLine()) != null)
                {
                    cbFilter1.Items.Add(content);
                }


            }
        }




        private void cbFilter1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string sel1;
            //cbFilter1.SelectedItem = sel1;
            //cbFilter2.Items.Add(sel1);


            if (cbFilter1.SelectedItem != null)
            {

                cbFilter2.Items.Clear();


                string sel1 = cbFilter1.SelectedItem.ToString();



                string filepath = "C:\\Users\\ramas\\OneDrive\\Desktop\\" + sel1 + ".txt";

                using (StreamReader reader = new StreamReader(filepath))
                {

                    string content;

                    while ((content = reader.ReadLine()) != null)
                    {
                        cbFilter2.Items.Add(content);
                    }

                }


            }


        }

        private void cbFilter2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            if (cbFilter2.SelectedItem != null)
            {
                string sel1 = cbFilter2.SelectedItem.ToString();

                //string filepath = "C:\\Users\\ramas\\OneDrive\\Desktop\\" + sel1 + ".txt";


                string filepath = "C:\\Users\\ramas\\OneDrive\\Desktop\\BOOK TITLES\\" + sel1 + ".txt";
                using (StreamReader reader = new StreamReader(filepath))
                {

                    string content;
                    while ((content = reader.ReadLine()) != null)
                    {

                        string[] Book = content.Split('/'); // Split content and assign to Book array
                                                            //content.Split('/');



                        if (Book.Length > 4)
                        {
                            string Title = Book[0];
                            string Author = Book[1];
                            string PublishedDate = Book[2];
                            string Genre = Book[3];
                            string Price = Book[4];

                            txtbTITLE.Text = Title;
                            txtbAUTHOR.Text = Author;
                            txtbPUBLISHED_DATE.Text = PublishedDate;
                            txtbGENRE.Text = Genre;
                            txtbPRICE.Text = Price;



                        }



                    }


                }




            }

        }






        private void BTN_UPDATE_Click(object sender, RoutedEventArgs e)
        {

            if (cbFilter2.SelectedItem != null)
            {
                string sel1 = cbFilter2.SelectedItem.ToString();
                string filepath = "C:\\Users\\ramas\\OneDrive\\Desktop\\BOOK TITLES\\" + sel1 + ".txt";

                // Build the content to save
                string Title = txtbTITLE.Text;
                string Author = txtbAUTHOR.Text;
                string PublishedDate = txtbPUBLISHED_DATE.Text;
                string Genre = txtbGENRE.Text;
                string Price = txtbPRICE.Text;

                string newContent = $"{Title}/{Author}/{PublishedDate}/{Genre}/{Price}";

                if (File.Exists(filepath))
                {
                    // Update the existing file by overwriting it
                    using (StreamWriter writer = new StreamWriter(filepath))
                    {
                        writer.WriteLine(newContent);
                    }
                }

                MessageBox.Show("Information saved successfully!");
            }
            else
            {
                MessageBox.Show("Please select an item from the filters to update or save.");
            }



        }




        private void BTN_ADD_Click(object sender, RoutedEventArgs e)
        {
            if (txtbTITLE.Text.Length > 0 &&
                txtbAUTHOR.Text.Length > 0 &&
                txtbPUBLISHED_DATE.Text.Length > 0 &&
                txtbGENRE.Text.Length > 0 &&
                txtbPRICE.Text.Length > 0)
            {
                if (cbFilter1.SelectedItem != null)
                {


                    string sel1 = cbFilter1.SelectedItem.ToString();
                    string filepath = $"C:\\Users\\ramas\\OneDrive\\Desktop\\{sel1}.txt";

                    if (File.Exists(filepath))
                    {
                        using (StreamWriter writer = new StreamWriter(filepath, true)) // true to append text to the file
                        {
                            string BookTitle = txtbTITLE.Text;
                            writer.WriteLine(BookTitle);
                        }
                    }


                    string sel2 = txtbTITLE.Text;
                    string newFilepath = $"C:\\Users\\ramas\\OneDrive\\Desktop\\BOOK TITLES\\{sel2}.txt";

                    string Title = txtbTITLE.Text;
                    string Author = txtbAUTHOR.Text;
                    string PublishedDate = txtbPUBLISHED_DATE.Text;
                    string Genre = txtbGENRE.Text;
                    string Price = txtbPRICE.Text;

                    string newContent = $"{Title}/{Author}/{PublishedDate}/{Genre}/{Price}";


                    //
                    using (StreamWriter writer = new StreamWriter(newFilepath))
                    {
                        writer.WriteLine(newContent);
                    }


                    MessageBox.Show("Information saved successfully!");
                }
                else
                {
                    MessageBox.Show("Please select an item from the filter 1 to add or create.");
                }

            }
            else
            {
                MessageBox.Show("INCOMPLETE REQUIREMENTS TO RUN");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }




        private void clear()
        {

            txtbTITLE.Text = "";
            txtbAUTHOR.Text = "";
            txtbPUBLISHED_DATE.Text = "";
            txtbGENRE.Text = "";
            txtbPRICE.Text = "";

            cbFilter1.SelectedIndex = -1;
            cbFilter2.SelectedIndex = -1;



        }
    }
}
