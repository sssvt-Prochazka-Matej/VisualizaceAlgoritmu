using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViSortCommon;
using ViSortGDI;
using ViSortLogic;

namespace ViSortUI
{
    public partial class Form1 : Form
    {

        private ViForm visualizeForm;
        private List<ISortAlgorithm> sortAlgorithms;
        private List<int> unsortedData;

        public Form1()
        {
            InitializeComponent();
        }

        private void initial_Click(object sender, EventArgs e)
        {
            BubbleSort bubbleSort = new BubbleSort();


            this.sortAlgorithms = new List<ISortAlgorithm>();
            this.sortAlgorithms.Add(bubbleSort);

            this.unsortedData = new List<int> { 8, 5, 20, 4 , 9 , 7, 14, 17, 2 , 16, 10 , 3, 13, 18 ,1 ,12 , 6, 19 ,11 ,15 };

            this.visualizeForm = new ViForm();
            this.visualizeForm.SortAlgorithms = this.sortAlgorithms;
            this.visualizeForm.InputData = this.unsortedData;

            this.visualizeForm.ShowDialog(this);
        }
    }
}
