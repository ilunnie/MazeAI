using System.Linq;
using ilunnie.Utils;
using MazeAI;

namespace ilunnie.Search;

public static partial class Search
{
    public static bool DFSearch(Space start, Space goal)
    {
        if (start.Visited)
            return false;
        start.Visited = true;

        Space?[] neighbours = start.Neighbours();
        bool isGoal = start == goal;
        bool neighbourIsGoal = neighbours
                                    .Any(space => space is not null
                                                    && DFSearch(space, goal));
        if (isGoal || neighbourIsGoal)
        {
            start.IsSolution = true;
            return true;
        }

        return false;
    }
}