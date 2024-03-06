using System.Collections.Generic;
using ilunnie.Utils;
using MazeAI;

namespace ilunnie.Search;

public static partial class Search
{
    public static bool Dijkstra(Space start, Space goal)
    {
        Dictionary<Space, Space?> parents = new();
        parents.Add(start, null);

        Queue<Space> queue = new();
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            var currNode = queue.Dequeue();
            
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
                if (space is not null && !space.Visited)
                {
                    queue.Enqueue(space);
                    if (!parents.ContainsKey(space))
                        parents.Add(space, currNode);
                    else
                        if (parents.CountBy(currNode) < parents.CountBy(parents[space]!))
                            parents[space] = currNode;
                }
        }

        return false;
    }

    private static int CountBy(this Dictionary<Space, Space?> parents, Space key)
    {
        if (!parents.ContainsKey(key))
            return -1;

        int count = 0;
        Space? space = key;

        while (space is not null)
        {
            space = parents[space!];
            count++;
        };

        return count;
    }
}