using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sorting_alg_visualizer
{
    public partial class MainWindow : Form
    {
        private int[] array;
        private int amount;
        private string algChosen;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void StartButton_Click(object sender, EventArgs e)
        {
            // gets input from user for type of alg
            if(sortingAlgComboBox.SelectedItem.ToString().Split(' ')[0]==null)
            {
                MessageBox.Show("Choose an algorithm!");
                return;
            }
            algChosen = sortingAlgComboBox.SelectedItem.ToString().Split(' ')[0];

            //if array is empty, display and don't run the rest
            if (array == null)
            {
                MessageBox.Show("The array is empty :(");
                return;
            }



            // sorts the array 
            Sort sort = new Sort();
            int[] sortedArray = sort.Sorting(array, algChosen, displayBox);

            // draw to screen
            displayBox.Invalidate();
        }

        private int[] createRandomArray(int amount)
        {
            Random rand = new Random();
            int[] arr = new int[amount];
            for(int i = 0; i < amount; i++)
            {
                arr[i] = rand.Next(10000-1)+1;
            }
            return arr;
        }

        private void RandomizeButton_Click(object sender, EventArgs e)
        {
            //get input from user for amount of items in array
            amount = int.Parse(AmountComboBox.SelectedItem.ToString());

            // creates random array
            array = createRandomArray(amount);
            displayBox.Invalidate();
        }

        private void displayBox_Paint(object sender, PaintEventArgs e)
        { 
            e.Graphics.Clear(Color.Black);

            Font font = new Font("Cascadia Code", 12);
            Brush textBrush = Brushes.White;

            // draw comparison and swap counters
            e.Graphics.DrawString("Comparisons: " + SortingStats.Comparisons.ToString(), font, textBrush, new PointF(10, 10));
            e.Graphics.DrawString("Swaps: " + SortingStats.Swaps.ToString(), font, textBrush, new PointF(displayBox.Width - 100, 10));

            // draws the array when valid
            if (array != null && array.Length > 0)
            {
                // calculate width of each bar
                float barWidth = (float)displayBox.Width / (float)array.Length;

                if (isSorted(array))
                {
                    // draw the array in order, from left to right
                    for (int i = 0; i < array.Length; i++)
                    {
                        float barHeight = (float)array[i] / (float)displayBox.Height * 10 + 10;
                        e.Graphics.FillRectangle(Brushes.Green, i * barWidth, displayBox.Height - barHeight, barWidth - 1, barHeight);
                    }
                }
                else
                {
                    // draw the array
                    for (int i = 0; i < array.Length; i++)
                    {
                        float barHeight = (float)array[i] / (float)displayBox.Height * 10 + 10;
                        e.Graphics.FillRectangle(Brushes.Cyan, i * barWidth, displayBox.Height - barHeight, barWidth - 1, barHeight);
                    }
                }
            }

        }

        private bool isSorted(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
