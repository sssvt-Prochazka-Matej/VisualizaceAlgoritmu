using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViSortCommon;

namespace ViSortLogic
{
    public class BubbleSort : ISortAlgorithm
    {
        private List<int> inputData = new List<int>();
        private int TotalComparisons = 0;
        private int LastStepMoves = 0;

        public void SetInputData(List<int> unsorted)
        {
            TotalComparisons = 0;
            LastStepMoves = 0;
            inputData.Clear();
            foreach (var item in unsorted)
            {
                inputData.Add(item);
            }
        }

        public void Sort()
        {
            while (true)
            {
                bool sorted = true;

                for (int i = 0; i < inputData.Count - 1; i++)
                {
                    if (inputData[i] > inputData[i + 1])
                    {
                        int temp = inputData[i + 1];
                        inputData[i + 1] = inputData[i];
                        inputData[i] = temp;

                        this.TotalComparisons += i + 1;

                        sorted = false;
                    }
                }

                if (sorted)
                {
                    break;
                }
            }
            //bubble sort
        }

        public List<int> GetInterimData()
        {
            return inputData;
        }

        public void ProceedOneStep()
        {
            for (int i = 0; i < inputData.Count - 1; i++)
            {
                if (inputData[i] > inputData[i + 1])
                {
                    int temp = inputData[i + 1];
                    inputData[i + 1] = inputData[i];
                    inputData[i] = temp;

                    this.LastStepMoves = i + 1;
                    break;
                }
            }
        }

        public bool HasSortingCompleted()
        {
            for(int i = 0; i < inputData.Count - 1; i++)
            {
                if(inputData[i] > inputData[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        public List<int> GetOutputData()
        {
            if (HasSortingCompleted())
            {
                return inputData;
            }
            return null;
        }

        public int GetTotalNumberOfComparisons()
        {
            return this.TotalComparisons;
        }

        public int GetLastStepComplexityInComparisons()
        {
            return this.LastStepMoves;
        }
    }
}
