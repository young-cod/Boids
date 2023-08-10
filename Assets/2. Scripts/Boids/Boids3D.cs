using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Boids3D : BoidsBase
{
    private void Start()
    {
        FindNeighbourCoroutine = StartCoroutine("FindNeighbourCo", 3f);
        aiMoveCoroutine = StartCoroutine("AIMoveCo");
    }

    WaitForSeconds wait = new WaitForSeconds(20f);
    IEnumerator FindNeighbourCo(float val)
    {
        neighbours.Clear();



        foreach (var boid in spawner.neighbours.Where(x => x != this &&
        Vector3.Angle(-transform.right, x.transform.position - transform.position) <= FOV &&
        (x.transform.position - transform.position).magnitude <= findDis &&
        x.type == type))
        {
            if (neighbours.Count > maxNeighbour) break;
            neighbours.Add(boid);
        }


        yield return wait;
        if (FindNeighbourCoroutine != null) FindNeighbourCoroutine = null;
        FindNeighbourCoroutine = StartCoroutine("FindNeighbourCo", 3f);
    }

    private void Update()
    {
        alignmentVec = CalcAlignmentVec() * alignmentWeight;
        cohesionVec = CalcCohesionVec() * cohesionWeight;
        separationVec = CalcSeparationVec() * separationWeight;
        boundaryVec = CalcBoundaryVec() * boundaryWeight;
        obstacleVec = CalcObstacleVec() * obstacleWeight;
        aiVec *= aiWeight;

        velocity = alignmentVec + cohesionVec + separationVec + boundaryVec + aiVec;
        velocity = Vector3.Lerp(transform.forward, velocity, Time.deltaTime);

        velocity.Normalize();

        transform.rotation = Quaternion.LookRotation(velocity);

        transform.position += velocity * speed * Time.deltaTime;
    }


    #region Calculation

    IEnumerator AIMoveCo()
    {
        speed = Random.Range(3, 10);
        aiVec = Random.insideUnitSphere;

        yield return new WaitForSeconds(10f);

        if (aiMoveCoroutine != null) aiMoveCoroutine = null;
        aiMoveCoroutine = StartCoroutine("AIMoveCo");
    }

    Vector3 CalcAlignmentVec()
    {
        Vector3 vec = Vector3.forward;

        if (neighbours.Count > 0)
        {
            foreach (var neighbour in neighbours)
            {
                vec += neighbour.velocity;
            }
        }
        else return vec;

        vec /= neighbours.Count;

        return vec;
    }
    Vector3 CalcCohesionVec()
    {
        Vector3 vec = Vector3.zero;

        if (neighbours.Count > 0)
        {
            foreach (var neighbour in neighbours)
            {
                vec += neighbour.transform.position;
            }
        }
        else return vec;

        vec /= neighbours.Count;
        vec -= transform.position;

        return vec;
    }

    Vector3 CalcSeparationVec()
    {
        Vector3 vec = Vector3.zero;

        if (neighbours.Count > 0)
        {
            foreach (var neighbour in neighbours)
            {
                vec += (transform.position - neighbour.transform.position);
            }
        }
        else return vec;

        vec /= neighbours.Count;

        return vec;
    }

    Vector3 CalcBoundaryVec()
    {
        Vector3 vec = (spawner.transform.position - transform.position);

        if (vec.magnitude >= spawner.radius)
        {
            return vec;
        }
        else return Vector3.zero;
    }

    Vector3 CalcObstacleVec()
    {
        Vector3 vec = Vector3.zero;
        return vec;
    }


    #endregion

}
