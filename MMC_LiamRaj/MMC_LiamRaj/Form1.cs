// Project : Linq Assignment - Molecular Mass Calculator(MMC)
// Feb 3 2021
// By Rajeshwar Singh , Liam Hailey
//
// Submission Code : 1202_CMPE2800_MMC
// ///////////////////////////////////////////////////////////////////////////
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
using System.Text.RegularExpressions;

namespace MMC_LiamRaj
{
    public partial class Form1 : Form
    {
        IEnumerable<Elements> elementsList; //list containing all of the elements from the periodic table
        BindingSource bindingSource = new BindingSource(); //binding source used to display info to the dataGridView

        public Form1() 
        {
            InitializeComponent();
            
            //dataGridView settings
            _dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dgv.RowHeadersVisible = false;
            _dgv.AllowUserToAddRows = false;
            _dgv.DataSource = bindingSource;

            //event bindings
            Shown += Form1_Shown;
            button_Sort_Name.Click += Button_Click;
            button_Sort_Atomic.Click += Button_Click;
            button_Char_Symb.Click += Button_Click; 
        }

        /// <summary>
        /// on form shown, read the periodic table file to the Element collection and display it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Shown(object sender, EventArgs e)
        {
            //create a streamreader to read from the Periodic Table.csv file
            StreamReader streamReader = new StreamReader(Path.GetFullPath(@"..\..\Periodic Table.csv"));

            //Getting all the values from the file
            var whole = from s in streamReader.ReadToEnd().Split('\n', '\r') where !String.IsNullOrEmpty(s.Trim()) select s.Trim();

            //Spliting data into lines for each element
            var line = from z in whole select z.Split(',');

            //Adding each element to our list
            elementsList = from x in line select (new Elements(Convert.ToInt32(x[0]), x[2], x[1], Math.Round(Convert.ToDouble(x[3]), 4)));

            //display all the elements
            bindingSource.DataSource = elementsList;
        }

        /// <summary>
        /// event handler for the sorting buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, EventArgs e)
        {
            //If no button was clicked get out
            if (!(sender is Button))
                return;

            //Sorting by Element Name
            if(ReferenceEquals(sender,button_Sort_Name))
            {
                var List = from s in elementsList orderby s.Name select s;
                bindingSource.DataSource = List;
            }

            //Sorting by Element Atomic Number
            if(ReferenceEquals(sender,button_Sort_Atomic))
            {
                var sortList = from s in elementsList orderby s.AtomicNumber select s;
                bindingSource.DataSource = sortList;
            }

            //Sorting by Element Symbol
            if(ReferenceEquals(sender,button_Char_Symb))
            {
                //List of Single Character Elements ordered by character Symbol
                var singleSymList = from s in elementsList where s.Symbol.Length == 1 orderby s.Symbol select s;

                //List of Double Character Elements ordered by Character Symbol
                var doubleSymList = from s in elementsList where s.Symbol.Length == 2 orderby s.Symbol select s;

                //List of Double Character Elements ordered by Character Symbol
                var tripleSymList = from s in elementsList where s.Symbol.Length == 3 orderby s.Symbol select s;

                //Concatenating two Collection to make a bigger collection
                var whole = (singleSymList.Concat(doubleSymList)).Concat(tripleSymList);
                bindingSource.DataSource = whole;
            }
        }

        /// <summary>
        /// event handler for user textbox input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //if the textbox is empty, display elementsList and exit
            if (textBoxChemFormula.Text == "")
            {
                bindingSource.DataSource = elementsList;
                return;
            }

            try
            {
                //regex expression to look for chemical formulas
                Regex regex = new Regex("[A-Z][a-z]?[0-9]*");

                //remove all valid elements from textbox and 
                //throw error if there is any leftover bad input
                if (Regex.Replace(textBoxChemFormula.Text, regex.ToString(), "").Length > 0)
                    throw new ArgumentException("invalid input in textbox");
                
                //match collection of all the element symbols from the textbox
                MatchCollection matches = regex.Matches(textBoxChemFormula.Text);

                //list of element symbols derived from matches
                List<string> symbols = (from n in matches.Cast<Match>().ToArray() select n.Value).ToList();

                //group duplicates together
                var groupedDuplicates = new List<string>(symbols).GroupBy(item => Regex.Match(item, "[A-z]+").ToString());

                //clear the list
                symbols.Clear();

                //variable for try parsing element quantity
                int quantity;

                //refill the list with duplicates now combined into 1 symbol with their quantities summed
                foreach (var item in groupedDuplicates)
                    symbols.Add(item.Key + item.Sum(item2 => int.TryParse(Regex.Match(item2, "[0-9]+").ToString(), out quantity) ? quantity : 1));

                //dictionary containing user's elements and their quantity
                Dictionary<Elements, int> userElementsList;

                //generate the user list by joining on the symbols
                userElementsList = (from n in elementsList
                                   join m in symbols on n.Symbol equals Regex.Match(m, "[A-z]+").ToString()
                                   select new { element = n, quantity = int.TryParse(Regex.Match(m, "[0-9]+").ToString(), out quantity) ? quantity : 1 })
                                   .ToDictionary(item => item.element, item => item.quantity);
                
                //throw error if any symbols were not processed correctly
                if (userElementsList.Count < symbols.Count())
                    throw new ArgumentException("symbol not found in periodic table");
                
                //display the user elements
                bindingSource.DataSource = from item in userElementsList
                                           select new { Element = item.Key.Name, Count = item.Value, Mass = item.Key.Mass, TotalMass = item.Key.Mass*item.Value};

                //Molar Mass
                double molarMass = userElementsList.Sum(item => item.Key.Mass * item.Value);
                labelMolarMass.Text = Math.Round(molarMass, 4).ToString()+" g/mol";

                //change textbox color to green to show that the input is valid
                textBoxChemFormula.ForeColor = Color.Green;
                labelMolarMass.ForeColor = Color.Green;
            }
            catch
            {
                //change text color to red to show that the input is invalid
                textBoxChemFormula.ForeColor = Color.Red;
                labelMolarMass.ForeColor = Color.Red;
            }
        }
    }
}
