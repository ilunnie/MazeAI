using System.Collections.Generic;
using ilunnie.Utils;
using MazeAI;

namespace ilunnie.Search;

public static partial class Search
{
    public static bool AStar(Space start, Space goal)
    {
        var queue = new PriorityQueue<Space, float>();
        var dist = new Dictionary<Space, float>();
        var prev = new Dictionary<Space, Space>();

        queue.Enqueue(start, 0);
        dist[start] = .0f;

        while (queue.Count > 0)
        {
            var currNode = queue.Dequeue();

            if (currNode.Visited)
                continue;
            currNode.Visited = true;

            if (currNode == goal)
            {
                currNode.IsSolution = true;
                break;
            }

            Space?[] neighbours = currNode.Neighbours();

            foreach (var space in neighbours)
            {
                if (space is not null)
                {
                    var x = goal.X - space.X;
                    var y = goal.Y - space.Y;
                    var penalty = x * x + y * y;
                    var newWeight = dist[currNode] + penalty;

                    if (!dist.ContainsKey(space))
                    {
                        dist[space] = float.PositiveInfinity;
                        prev[space] = null!;
                    }

                    if (newWeight < dist[space])
                    {
                        dist[space] = newWeight;
                        prev[space] = currNode;
                        queue.Enqueue(space, newWeight);
                    }
                }
            }
        }

        var attempt = goal;
        while (attempt != start)
        {
            if (!prev.ContainsKey(attempt))
                return false;

            attempt = prev[attempt];
            attempt.IsSolution = true;
        }

        return true;
    }
}