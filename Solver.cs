using System;
using System.Linq;
using ilunnie.Search;

namespace MazeAI;

public class Solver
{
    public int  Option { get; set; }
    public Maze Maze   { get; set; } = null!;

    public string Algorithm
    {
        get
        {
            return (Option % 4) switch
            {
                0 => "DFS",
                1 => "BFS",
                2 => "dijkstra",
                _ => "aStar"
            };
        }
    }

    public void Solve()
    {
        var goal = Maze.Spaces.FirstOrDefault(s => s.Exit);

        if (Maze.Root is null || goal is null)
            return;

        switch (Option % 4)
        {
            case 0:
                DFS(Maze.Root, goal);
                break;
            case 1:
                BFS(Maze.Root, goal);
                break;
            case 2:
                Dijkstra(Maze.Root, goal);
                break;
            case 3:
                AStar(Maze.Root, goal);
                break;
        }
    }

    private static bool DFS(Space start, Space goal)
        => Search.DFSearch(start, goal);

    private static bool BFS(Space start, Space goal)
        => Search.BFSearch(start, goal);

    private static bool Dijkstra(Space start, Space goal)
    {
        throw new NotImplementedException();
    }

    private static bool AStar(Space start, Space goal)
    {
        throw new NotImplementedException();
    }
}