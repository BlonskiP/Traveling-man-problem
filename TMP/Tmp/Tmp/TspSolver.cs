using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsp;

namespace Tmp
{
    abstract class TspSolver
    {
        public AdjacencyMatrix costMatrix;

        public abstract void Solve();
        public abstract void setVariables(AdjacencyMatrix matrix);
    }
}
