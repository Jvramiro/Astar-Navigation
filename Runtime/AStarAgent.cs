using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding{
    public abstract class AStarAgent : MonoBehaviour{
       
        public float speed;
        public bool allowDiagonal;
        public Action OnMovementStart;
        public Action OnMovementStop;
        public Action OnAgentReached;
        public bool IsMoving { get{ return isMoving; }}
        protected bool isMoving;

        public virtual void StartMovement(){
            isMoving = true;
            OnMovementStart?.Invoke();
        }

        public virtual void StopMovement(){
            isMoving = false;
            OnMovementStop?.Invoke();
        }

    }
}
