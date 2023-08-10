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


    //�߰�
    protected Vector3 alignmentVec;
    protected float alignmentWeight;

    //�߽��� �̵�
    protected Vector3 cohesionVec;
    protected float cohesionWeight;

    //ȸ��
    protected Vector3 separationVec;
    protected float separationWeight;

    //��ֹ� ȸ��
    protected Vector3 obstacleVec;
    protected float obstacleWeight;

    //�����̵�
    protected Vector3 boundaryVec;
    protected float boundaryWeight;

    //AI �̵�
    protected Vector3 aiVec;
    protected float aiWeight;


}