/* UserInterface.cs
 * Author: Rod Howell
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ksu.Cis300.MazeLibrary;
using Ksu.Cis300.Graphs;

namespace Ksu.Cis300.MazeSolver
{
    /// <summary>
    /// A user interface for a maze solver.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles a New event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxNew_Click(object sender, EventArgs e)
        {
            uxMaze.Generate();
        }

        /// <summary>
        /// Finds the shortest exit path within the maze.
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="u"></param>
        /// <param name="maze"></param>
        /// <param name="paths"></param>
        /// <returns></returns>
        private static Cell FindPath(DirectedGraph<Cell, Direction> graph, Cell u, Maze maze, out Dictionary<Cell, Cell> paths)
        {
            paths = new Dictionary<Cell, Cell>();
            Queue<Edge<Cell, Direction>> queue = new Queue<Edge<Cell, Direction>>();
            paths.Add(u, u);

            foreach (Edge<Cell, Direction> i in graph.OutgoingEdges(u))
            {
                queue.Enqueue(i);
            }
            while (queue.Count > 0)
            {
                Edge<Cell, Direction> edge = queue.Dequeue();

                if (!paths.ContainsKey(edge.Destination))
                {
                    paths.Add(edge.Destination, edge.Source);
                    if (!maze.IsInMaze(edge.Destination)) return edge.Destination;

                    foreach(Edge< Cell, Direction > i in graph.OutgoingEdges(edge.Destination))
                    {
                        queue.Enqueue(i);
                    }
                }
            }
            return new Cell();
        }

        /// <summary>
        /// Displays the shortest exit path on the graph.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <param name="maze"></param>
        /// <param name="paths"></param>
        /// <param name="graph"></param>
        private static void DisplayPath(Cell u, Cell v, Maze maze, Dictionary<Cell, Cell> paths, DirectedGraph<Cell, Direction> graph)
        { 
            while (v != u)
            { 
                Cell temp = paths[v];
                Direction x;
                graph.TryGetEdge(temp, v, out x);
                maze.DrawPath(temp, x);
                v = temp;
            }
        }

        /// <summary>
        /// Gets a graph representing the given maze. The Direction associated with each edge
        /// is the direction from the source to the destination.
        /// </summary>
        /// <param name="maze">The maze to be represented.</param>
        /// <returns>The graph representation.</returns>
        private DirectedGraph<Cell, Direction> GetGraph(Maze maze)
        {
            DirectedGraph<Cell, Direction> graph = new DirectedGraph<Cell, Direction>();
            for (int i = 0; i < maze.MazeHeight; i++)
            {
                for (int j = 0; j < maze.MazeWidth; j++)
                {
                    Cell cell = new Cell(i, j);
                    if (!graph.ContainsNode(cell))
                    {
                        graph.AddNode(cell);
                    }
                    for (Direction d = Direction.North; d <= Direction.West; d++)
                    {
                        if (maze.IsClear(cell, d))
                        {
                            graph.AddEdge(cell, maze.Step(cell, d), d);
                        }
                    }
                }
            }
            return graph;
        }

        /// <summary>
        /// Generates maaze direction.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxMaze_MouseClick(object sender, MouseEventArgs e)
        {
            Cell cell = uxMaze.GetCellFromPixel(e.Location);
            if (uxMaze.IsInMaze(cell))
            {
                uxMaze.EraseAllPaths();
                DirectedGraph<Cell, Direction> graph = GetGraph(uxMaze);
                Dictionary<Cell, Cell> paths;
                Cell exit = FindPath(graph, cell, uxMaze, out paths);
                if (exit == new Cell(0, 0))
                {
                    MessageBox.Show("There is no path from this cell.");
                }
                else
                {
                    DisplayPath(cell, exit, uxMaze, paths, graph);
                }
                uxMaze.Invalidate();
            }
        }
    }
}
