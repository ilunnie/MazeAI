using System.Collections.Generic;
using ilunnie.Utils;
using MazeAI;

namespace ilunnie.Search;

public static partial class Search
{
    public static bool BFSearch(Space start, Space goal)
    {
        Dictionary<Space, Space?> parents = new();
        parents.Add(start, null);

        Queue<Space> queue = new();
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            var currNode = queue.Dequeue();

            if (currNode.Visited)
                continue;
            currNode.Visited = true;
                
            if (currNode == goal)
            {
                Space? space = currNode;
                do
                {
                    space.IsSolution = true;
                    space = parents[space];
                }
                while(space != null);
                return true;
            }

            foreach (var space in currNode.Neighbours())
                if (space is not null)
                {
                    queue.Enqueue(space);
                    if (!parents.ContainsKey(space))
                        parents.Add(space, currNode);
                }
        }

        return false;
    }
}