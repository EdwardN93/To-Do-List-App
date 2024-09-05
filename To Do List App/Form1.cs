using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace To_Do_List_App
{
    public partial class ToDoList : Form
    {
        public ToDoList()
        {
            InitializeComponent();

            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Sample.txt");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    Console.WriteLine(line);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        DataTable toDoList = new DataTable();
        bool isEditing = false;
        string line = "";



        private void Form1_Load(object sender, EventArgs e)
        {
            // Create Columns

            toDoList.Columns.Add("Title");
            toDoList.Columns.Add("Description");

            // Point our data grid view to data Source

            toDoListView.DataSource = toDoList;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            
            
            isEditing = true;
            // Fill text fields with data from table
            titleTextBox.Text = toDoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[0].ToString();
            descriptionTextBox.Text = toDoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[1].ToString();
            

        }

        private void deleteButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                if(toDoList.Rows.Count <= 0) { return; }
                else
                {
                toDoList.Rows[toDoListView.CurrentCell.RowIndex].Delete();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(isEditing)
            {
              
                toDoList.Rows[toDoListView.CurrentCell.RowIndex]["Title"] = titleTextBox.Text;
                toDoList.Rows[toDoListView.CurrentCell.RowIndex]["Description"] = descriptionTextBox.Text;
                

            }
            else
            {
               
                    toDoList.Rows.Add(titleTextBox.Text, descriptionTextBox.Text);
               
            }
            // Clear Fields
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
            isEditing = false;

        }

        
    }

}
