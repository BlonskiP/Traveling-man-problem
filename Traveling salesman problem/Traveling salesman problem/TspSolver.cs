using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveling_salesman_problem;

namespace Traveling_salesman_problem
{
    abstract class TspSolver
    {
        public AdjacencyMatrix costMatrix;

        public abstract void Solve();
        public abstract void SetVariables(AdjacencyMatrix matrix);
    }
}
