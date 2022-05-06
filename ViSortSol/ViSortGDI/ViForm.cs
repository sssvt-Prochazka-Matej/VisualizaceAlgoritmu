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
using ViSortCommon;

namespace ViSortGDI
{
    public partial class ViForm : Form
    {

        private const int penaltyForOperationUnit = 10;



        private List<BackgroundWorker> backgroundWorkers;

        private List<Label> progressLabels;
        private List<Panel> dataPanels;



        public List<ISortAlgorithm> SortAlgorithms { get; set; }


        public List<int> InputData { get; set; }

        private List<int> inputForQuick = new List<int>();

        public ViForm()
        {
            InitializeComponent();
        }

        private void ViForm_Load(object sender, EventArgs e)
        {


            // Here:
            // The sort algorithms should already be set.
            // So should be the input data.

            // We will create as many background workers as the number of sort algorithms is.

            this.backgroundWorkers = new List<BackgroundWorker>();

            for (int i = 0; i < this.SortAlgorithms.Count; i++)
            {

                BackgroundWorker backgroundWorker;
                backgroundWorker = new BackgroundWorker();

                backgroundWorker.DoWork += new DoWorkEventHandler(worker_DoWork);
                backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
                backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);

                backgroundWorker.WorkerReportsProgress = true;
                backgroundWorker.WorkerSupportsCancellation = true;

                this.backgroundWorkers.Add(backgroundWorker);

            }

            // Prepare buttons and panels.
            this.progressLabels = new List<Label>();
            this.progressLabels.Add(this.lblCompleteBubble);
            this.dataPanels = new List<Panel>();
            this.dataPanels.Add(this.panelBubble);


        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.backgroundWorkers.Count; i++)
            {
                BackgroundWorker backgroundWorker = this.backgroundWorkers[i];
                if (!backgroundWorker.IsBusy)
                {

                    backgroundWorker.RunWorkerAsync(this.SortAlgorithms[i]);
                }
            }

            if (!this.backgroundWrkrQuick.IsBusy)
            {
                this.backgroundWrkrQuick.RunWorkerAsync();
            }
        }




        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {

            BackgroundWorker worker = sender as BackgroundWorker;
            ISortAlgorithm sortAlgorithm = (ISortAlgorithm)e.Argument;


            int complexity = EstimateAlgorithmComplexity(sortAlgorithm);


            int maxOperations = complexity;
            int operationsCounter = 0;
            sortAlgorithm.SetInputData(this.InputData);
            //sortAlgorithm.StartSorting();
            List<int> unsorted = sortAlgorithm.GetInterimData();
            int progressPercentage = operationsCounter * 100 / maxOperations;
            worker.ReportProgress(progressPercentage, unsorted);

            // Sort data step by step.
            while (!sortAlgorithm.HasSortingCompleted())
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    sortAlgorithm.ProceedOneStep();

                    int numberOfOperationsForLastStep = sortAlgorithm.GetLastStepComplexityInComparisons();
                    // ***
                    // Simulate lots of work...
                    Thread.Sleep(numberOfOperationsForLastStep * penaltyForOperationUnit);
                    // ***
                    operationsCounter += numberOfOperationsForLastStep;

                    List<int> interim = sortAlgorithm.GetInterimData();

                    progressPercentage = (operationsCounter * 100) / maxOperations;
                    worker.ReportProgress(progressPercentage, interim);
                }
            }

            // Let the main thread know we're done.
            List<int> sorted = sortAlgorithm.GetOutputData();
            progressPercentage = 100;
            worker.ReportProgress(progressPercentage, sorted);

        }



        private int EstimateAlgorithmComplexity(ISortAlgorithm algorithm)
        {
          
            // Let the algorithm sort data "quickly" first (without sleep delays).
            algorithm.SetInputData(this.InputData);
            algorithm.Sort();
            // Ignore the resulting sorted list.
            algorithm.GetOutputData();
            int complexity = algorithm.GetTotalNumberOfComparisons();
            return complexity;
        }



        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            BackgroundWorker backgroundWorker = sender as BackgroundWorker;
            int workerIndex = this.backgroundWorkers.FindIndex(wrk => wrk == backgroundWorker);

            Label label = this.progressLabels[workerIndex];
            Panel panel = this.dataPanels[workerIndex];           


            int progressPercentage = e.ProgressPercentage;
            label.Text = progressPercentage.ToString() + " %";

            List<int> interim = (List<int>)e.UserState;

            var g = panel.CreateGraphics();

            Brush blue = new SolidBrush(Color.LightBlue);

            g.Clear(Color.White);

            g.TranslateTransform(0.0F, 140.0F);

            if (interim != null)
            {
                for (int i = 0; i < interim.Count; i++)
                {
                    g.FillRectangle(blue, i * 20, -interim[i] * 7, 20, interim[i] * 7);
                }
            }
            

        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BackgroundWorker backgroundWorker = sender as BackgroundWorker;
            int workerIndex = this.backgroundWorkers.FindIndex(wrk => wrk == backgroundWorker);

            Label label = this.progressLabels[workerIndex];
            if (e.Cancelled)
            {
                label.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                label.Text = "Error: " + e.Error.Message;
            }
            else
            {
                label.Text = "Done!";
            }
        }


        private void btnCancle_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.backgroundWorkers.Count; i++)
            {
                BackgroundWorker backgroundWorker = this.backgroundWorkers[i];
                if (backgroundWorker.WorkerSupportsCancellation)
                {
                    backgroundWorker.CancelAsync();
                }
            }
            if (this.backgroundWrkrQuick.WorkerSupportsCancellation)
            {
                this.backgroundWrkrQuick.CancelAsync();
            }
        }

        private void backgroundWrkrQuick_DoWork(object sender, DoWorkEventArgs e)
        {
            SetDataForQuick(InputData);
            List<int> unsorted = GetDataForQuick(inputForQuick);

            QuickSortAlgorithm(unsorted,e);

                int progressPercentage = 100;
                this.backgroundWrkrQuick.ReportProgress(progressPercentage, unsorted);
  
        }

        private void backgroundWrkrQuick_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Label label = this.lblCompleteQuick;
            Panel panel = this.panelQuick;


            int progressPercentage = e.ProgressPercentage;

            if (progressPercentage == 0)
            {
                label.Text = "In progress...";
            }
            else 
            {
                label.Text = progressPercentage.ToString() + " %";
            }
            

            List<int> interim = (List<int>)e.UserState;

            var g = panel.CreateGraphics();

            Brush blue = new SolidBrush(Color.LightBlue);

            g.Clear(Color.White);

            if (!this.backgroundWrkrQuick.CancellationPending)
            {
                g.TranslateTransform(0.0F, 140.0F);

                if (interim != null)
                {
                    for (int i = 0; i < interim.Count; i++)
                    {
                        g.FillRectangle(blue, i * 20, -interim[i] * 7, 20, interim[i] * 7);
                    }
                }
            }
        }

        private void backgroundWrkrQuick_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                this.lblCompleteQuick.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                this.lblCompleteQuick.Text = "Error: " + e.Error.Message;
            }
            else
            {
                this.lblCompleteQuick.Text = "Done!";
            }
        }

        private void SetDataForQuick(List<int> list)
        {
            if(this.inputForQuick.Count > 0)
            {
                this.inputForQuick.Clear();
            }
            
            foreach(var item in list)
            {
                this.inputForQuick.Add(item);
            }
            
        }

        private List<int> GetDataForQuick(List<int> list)
        {
            List<int> temp = list;
            return temp;
        }

        public int Divide(List<int> list, int left, int right, int pivot, DoWorkEventArgs e)
        {
            int temp = list[pivot]; // prohozeni pivotu s poslednim prvkem
            list[pivot] = list[right];
            list[right] = temp;


            if (!this.backgroundWrkrQuick.CancellationPending)
            {
                List<int> interim3 = GetDataForQuick(list);
                this.backgroundWrkrQuick.ReportProgress(0, interim3);
                Thread.Sleep(100);
            }
            int i = left;
            for (int j = left; j < right; j++)
            {
                if (this.backgroundWrkrQuick.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                if (list[j] < list[right])
                { // prvek je mensi, nez pivot
                    temp = list[i]; // prohozeni pivotu s prvkem na pozici
                    list[i] = list[j];
                    list[j] = temp;
                    i++; // posun pozice
                    List<int> interim2 = GetDataForQuick(list);
                    this.backgroundWrkrQuick.ReportProgress(0, interim2);
                    Thread.Sleep(100);
                }
            }
            temp = list[i]; // prohozeni pivotu zpet
            list[i] = list[right];
            list[right] = temp;

            if (!this.backgroundWrkrQuick.CancellationPending)
            {
                List<int> interim3 = GetDataForQuick(list);
                this.backgroundWrkrQuick.ReportProgress(0, interim3);
                Thread.Sleep(100);
            }
            
            return i; // vrati novy index pivotu
        }

        public void Limited_quicksort(List<int> list, int left, int right, DoWorkEventArgs e)
        {
            if (right >= left)
            { // podminka rekurze
                int pivot = left; // vyber pivotu
                int new_pivot = Divide(list, left, right, pivot,e);
                // rekurzivni zavolani na obe casti pole
                Limited_quicksort(list, left, new_pivot - 1,e);
                Limited_quicksort(list, new_pivot + 1, right,e);
            }
        }

        // zavola omezeny quicksort na cele pole
        public void QuickSortAlgorithm(List<int> list, DoWorkEventArgs e)
        {
            Limited_quicksort(list, 0, list.Count - 1,e);
        }
    }
}
