using UnityEngine;

namespace Pathfinding{

    public class AStarNode{
        public Vector2Int Position;
        public AStarNode Parent;
        public float GCost;
        public float HCost;
        public float FCost => GCost + HCost;

        public AStarNode(Vector2Int position, AStarNode parent, float gCost, float hCost){
            Position = position;
            Parent = parent;
            GCost = gCost;
            HCost = hCost;
        }
    }

}