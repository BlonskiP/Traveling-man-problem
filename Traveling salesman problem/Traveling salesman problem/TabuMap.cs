using System.Collections.Generic;

namespace Traveling_salesman_problem
{
    class TabuMap
    {   int _timeOfLife;
        int _vertices;
        int[,] tabuMap;
        public TabuMap(int timeOfLife, int verticles)
        {
            _vertices = verticles;
            _timeOfLife = timeOfLife;
            tabuMap = new int[verticles, verticles];

        }
        public void makeMoveATabu(int verticleA, int verticleB)
        {
            tabuMap[verticleA, verticleB] += _timeOfLife;
            tabuMap[verticleB, verticleA] += _timeOfLife;
        }
        public void decreseTabuLife()
        {
            for (int i = 0; i < _vertices; i++)
                for (int k = 0; k < _vertices; k++) 
                    if(tabuMap[i,k]>0)
                    tabuMap[i, k] -= 1;
        }
        public void resetTabuMap()
        {
            for (int i = 0; i < _vertices; i++)
                for (int k = 0; k < _vertices; k++)
                    tabuMap[i, k] = 0;
        }
        public bool IsMoveTabu(int verticleA, int verticleB)
        {
            if (tabuMap[verticleA, verticleB] > 0 || tabuMap[verticleB, verticleA] > 0)
                return true;
            else
                return false;
        }
      

    }
}
