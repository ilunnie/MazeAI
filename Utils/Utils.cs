using System.Collections.Generic;
using MazeAI;

namespace ilunnie.Utils;

public static partial class Utils
{
    public static Space?[] Neighbours(this Space space)
        => new Space?[]
        {
            space.Top,
            space.Left,
            space.Right,
            space.Bottom
        };
}