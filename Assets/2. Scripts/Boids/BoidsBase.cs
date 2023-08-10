using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsBase : MonoBehaviour
{
    //TYPE
    public enum EBOIDTYPE
    {
        one,two,three,four,
    }
    public EBOIDTYPE type = EBOIDTYPE.one;

    protected float speed;
    protected float accelSpeed;
    protected float FOV;


    //추격
    protected Vector3 alignmentVec;
    protected float alignmentWeight;

    //중심점 이동
    protected Vector3 cohesionVec;
    protected float cohesionWeight;

    //회피
    protected Vector3 separationVec;
    protected float separationWeight;

    //장애물 회피
    protected Vector3 obstacleVec;
    protected float obstacleWeight;

    //지역이동
    protected Vector3 boundaryVec;
    protected float boundaryWeight;

    //AI 이동
    protected Vector3 aiVec;
    protected float aiWeight;


}