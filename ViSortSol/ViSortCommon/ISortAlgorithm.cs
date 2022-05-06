using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViSortCommon
{
    public interface ISortAlgorithm
    {
        // Basic methods.
        void SetInputData(List<int> unsorted);
        void Sort();
        List<int> GetOutputData();
        int GetTotalNumberOfComparisons();
       // int GetTotalNumberOfMoves();

        // Advanced methods.
        //void StartSorting();
        bool HasSortingCompleted();
        void ProceedOneStep();
        int GetLastStepComplexityInComparisons();
        //int GetLastStepComplexityInMoves();
        List<int> GetInterimData();
    }
}
