using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class AStarAgent3DExample : MonoBehaviour
{
    [SerializeField] AStarAgent3D agent;
    [SerializeField] Vector3Int destination;

    [Tooltip("Obstacle points or positions to avoid")]
    [SerializeField] List<Vector3> pointsToIgnore;
    Vector3Int startPosition, startRotation;
    bool waitingReset;

    void Start(){
        startPosition = Vector3Int.RoundToInt(transform.position);
        startRotation = Vector3Int.RoundToInt(transform.eulerAngles);
    }
    public void Reset(){
        transform.position = startPosition;
        transform.eulerAngles = startRotation;
        waitingReset = false;
    }
    public void Setup(){
        if(!waitingReset){
            agent.Setup(destination, pointsToIgnore);
            waitingReset = true;
        }
    }
}
