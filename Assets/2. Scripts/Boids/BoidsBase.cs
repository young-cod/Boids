using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsBase : MonoBehaviour
{
    //TYPE
    public enum EBOIDTYPE
    {
        Fish,
        Fish2,
        Fish3,
        Fish4,
        Shark
    }
    public EBOIDTYPE type = EBOIDTYPE.Shark;

    public Vector3 velocity;
    //[SerializeField]
    protected float speed = 10f;
    protected float rotSpeed = 10f;
    protected float accelSpeed;
    protected float findDis = 10f;
    protected int maxNeighbour=25;
    protected float FOV=120;

    //추격
    protected Vector3 alignmentVec;
    [SerializeField] protected float alignmentWeight = 1f;

    //중심점 이동
    protected Vector3 cohesionVec;
    [SerializeField] protected float cohesionWeight = 1f;

    //회피
    protected Vector3 separationVec;
    [SerializeField] protected float separationWeight = 1f;

    //장애물 회피
    protected Vector3 obstacleVec;
    [SerializeField] protected float obstacleWeight = 1f;

    //지역이동
    protected Vector3 boundaryVec;
    [SerializeField] protected float boundaryWeight = 1f;

    //AI 이동
    protected Vector3 aiVec;
    [SerializeField] protected float aiWeight = 3f;

    protected Coroutine FindNeighbourCoroutine;
    protected Coroutine aiMoveCoroutine;

    [SerializeField] protected List<BoidsBase> neighbours = new List<BoidsBase>();
    public BoidsSpawner spawner;

    public void ControlVectorWeight(float alignment, float cohesion, float separation, float boundary) {
        alignmentWeight = alignment;
        cohesionWeight = cohesion;
        separationWeight = separation;
        boundaryWeight = boundary;
    }
}