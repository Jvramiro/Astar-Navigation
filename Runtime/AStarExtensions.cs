using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding{
    public static class AStarExtensions{
        
        public static AStarNode LowestFCost(this List<AStarNode> nodes){
            AStarNode lowestFCostNode = nodes[0];
            for(int i = 1; i < nodes.Count; i++){
                if(nodes[i].FCost < lowestFCostNode.FCost){
                    lowestFCostNode = nodes[i];
                }
            }
            return lowestFCostNode;
        }

        public static List<Vector2Int> RetracePath(this AStarNode lastNode){
            List<Vector2Int> path = new List<Vector2Int>();
            AStarNode currentNode = lastNode;

            while(currentNode != null){
                path.Add(currentNode.Position);
                currentNode = currentNode.Parent;
            }

            path.Reverse();
            return path;
        }

        public static List<Vector2Int> Neighbors(this Vector2Int position){
            List<Vector2Int> neighbors = new List<Vector2Int>{
                position + Vector2Int.right,
                position - Vector2Int.right,
                position + Vector2Int.up,
                position - Vector2Int.down
            };
            return neighbors;
        }

    }
}