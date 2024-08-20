using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding{
    public class AStarAgent2D : AStarAgent{
        private List<Vector2Int> path = new List<Vector2Int>();

        public void Setup(Vector2Int destination, List<Vector2Int> ignore = null){
            Setup(Vector2Int.RoundToInt(transform.position), destination, ignore);
        }

        public void Setup(Vector2Int start, Vector2Int destination, List<Vector2Int> ignore = null){
            List<Vector2Int> _ignore = ignore ?? new List<Vector2Int>();
            path = AStarPathfinding.FindPath(start, destination, _ignore, allowDiagonal);

            if(path != null && path.Count > 0){
                StartMovement();
            }
        }

        void FixedUpdate(){
            if(isMoving){
                Move();
            }
        }

        void Move(){
            if(path.Count > 0){
                if(Vector2.Distance(transform.position, path[0]) > 0.01f){
                    Vector2 newPosition = Vector2.MoveTowards(transform.position, path[0], speed * Time.fixedDeltaTime);
                    transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
                }
                else{
                    transform.position = new Vector3(path[0].x, path[0].y, transform.position.z);
                    path.RemoveAt(0);
                }

                if(path.Count == 0){
                    OnAgentReached?.Invoke();
                    StopMovement();
                }
            }
        }

    }
}
