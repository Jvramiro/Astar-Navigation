using Pathfinding;
using UnityEngine;

public class AStarAgent2DExample : MonoBehaviour
{
    [SerializeField] AStarAgent2D agent;
    [SerializeField] Vector2Int destination;
    Vector2Int startPosition;
    bool waitingReset;

    void Start(){
        startPosition = Vector2Int.RoundToInt(transform.position);
    }
    public void Reset(){
        transform.position = new Vector2(startPosition.x, startPosition.y);
        waitingReset = false;
    }
    public void Setup(){
        if(!waitingReset){
            agent.Setup(destination);
            waitingReset = true;
        }
    }
}
