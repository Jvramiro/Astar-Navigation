using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding{
    public class AStarPathfinding{

        public static List<Vector2Int> FindPath(Vector2Int start, Vector2Int end, List<Vector2Int> ignore, bool allowDiagonal = false){

            List<AStarNode> open = new List<AStarNode>();
            HashSet<Vector2Int> closed = new HashSet<Vector2Int>();

            AStarNode firstNode = new AStarNode(start, null, 0, Vector2Int.Distance(start, end));
            open.Add(firstNode);

            while(open.Count > 0){
                AStarNode currentNode = GetLowestFCost(open);

                if(currentNode.Position == end){
                    return RetracePath(currentNode);
                }

                open.Remove(currentNode);
                closed.Add(currentNode.Position);

                foreach(Vector2Int neighbor in GetNeighbors(currentNode.Position, allowDiagonal)){
                    if(closed.Contains(neighbor) || ignore.Contains(neighbor)){
                        continue;
                    }

                    float GCost = currentNode.GCost + Vector2Int.Distance(currentNode.Position, neighbor);
                    AStarNode neighborNode = open.Find(n => n.Position == neighbor);

                    if(neighborNode == null || GCost < neighborNode.GCost){
                        if(neighborNode == null){
                            neighborNode = new AStarNode(neighbor, currentNode, GCost, Vector2Int.Distance(neighbor, end));
                            open.Add(neighborNode);
                        }
                        else{
                            neighborNode.Parent = currentNode;
                            neighborNode.GCost = GCost;
                        }
                    }
                }
            }

            return new List<Vector2Int>();
        }

        private static AStarNode GetLowestFCost(List<AStarNode> nodes){
            AStarNode lowestFCostNode = nodes[0];
            for(int i = 1; i < nodes.Count; i++){
                if(nodes[i].FCost < lowestFCostNode.FCost){
                    lowestFCostNode = nodes[i];
                }
            }
            return lowestFCostNode;
        }

        private static List<Vector2Int> RetracePath(AStarNode lastNode){
            List<Vector2Int> path = new List<Vector2Int>();
            AStarNode currentNode = lastNode;

            while(currentNode != null){
                path.Add(currentNode.Position);
                currentNode = currentNode.Parent;
            }

            path.Reverse();
            return path;
        }

        private static List<Vector2Int> GetNeighbors(Vector2Int position, bool allowDiagonal = false){
            List<Vector2Int> neighbors = new List<Vector2Int>{
                position + Vector2Int.right,
                position + Vector2Int.left,
                position + Vector2Int.up,
                position + Vector2Int.down
            };

            if(allowDiagonal){
                neighbors.Add(position + Vector2Int.right + Vector2Int.up);
                neighbors.Add(position + Vector2Int.right + Vector2Int.down);
                neighbors.Add(position + Vector2Int.left + Vector2Int.up);
                neighbors.Add(position + Vector2Int.left + Vector2Int.down);
            }
            
            return neighbors;
        }

    }
}