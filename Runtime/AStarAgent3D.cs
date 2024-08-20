using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

namespace Pathfinding{
    public class AStarAgent3D : AStarAgent{
        public float rotation;
        enum Layout {XYZ, XZY, YXZ, YZX, ZXY, ZYX}
        [SerializeField] Layout layout = Layout.XZY;

        private List<Vector3> path = new List<Vector3>();

        public void Setup(Vector3Int destination, List<Vector3> ignore = null){
            Setup(Vector3Int.RoundToInt(transform.position), destination, ignore);
        }

        public void Setup(Vector3Int start, Vector3Int destination, List<Vector3> ignore = null){
            Vector2Int _start = GetVector2Int(start);
            Vector2Int _destination = GetVector2Int(destination);

            List<Vector2Int> _ignore = new List<Vector2Int>();
            if(ignore != null && ignore.Count > 0){
                foreach(Vector3 vector in ignore){
                    _ignore.Add(GetVector2Int(Vector3Int.RoundToInt(vector)));
                }
            }

            List<Vector2Int> _path = AStarPathfinding.FindPath(_start, _destination, _ignore, allowDiagonal);
            foreach(Vector2Int vector in _path){
                path.Add(GetVector3(vector));
            }

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
                if(Vector3.Distance(transform.position, path[0]) > 0.01f){
                    transform.position = Vector3.MoveTowards(transform.position, path[0], speed * Time.fixedDeltaTime);
                    Vector3 direction = (path[0] - transform.position).normalized;
                    
                    if (direction != Vector3.zero){
                        Quaternion targetRotation = Quaternion.LookRotation(direction);
                        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotation * Time.fixedDeltaTime);
                    }
                }
                else{
                    transform.position = path[0];
                    transform.eulerAngles = Vector3Int.RoundToInt(transform.eulerAngles);
                    path.RemoveAt(0);
                }

                if(path.Count == 0){
                    OnAgentReached?.Invoke();
                    StopMovement();
                }
            }
        }



        Vector2Int GetVector2Int(Vector3Int vector){
            switch(layout){
                case Layout.XYZ : return new Vector2Int(vector.x, vector.y);
                case Layout.XZY: return new Vector2Int(vector.x, vector.z);
                case Layout.YXZ: return new Vector2Int(vector.y, vector.x);
                case Layout.YZX: return new Vector2Int(vector.y, vector.z);
                case Layout.ZXY: return new Vector2Int(vector.z, vector.x);
                case Layout.ZYX: return new Vector2Int(vector.z, vector.y);
                default : throw new System.ArgumentOutOfRangeException();
            }
        }

        Vector3 GetVector3(Vector2Int vector) {
            float x = transform.position.x;
            float y = transform.position.y;
            float z = transform.position.z;

            switch(layout) {
                case Layout.XYZ: return new Vector3(vector.x, vector.y, z);
                case Layout.XZY: return new Vector3(vector.x, y, vector.y);
                case Layout.YXZ: return new Vector3(vector.y, vector.x, z);
                case Layout.YZX: return new Vector3(x, vector.x, vector.y);
                case Layout.ZXY: return new Vector3(vector.y, y, vector.x);
                case Layout.ZYX: return new Vector3(x, vector.y, vector.x);
                default: throw new System.ArgumentOutOfRangeException();
            }
        }
    }
}
