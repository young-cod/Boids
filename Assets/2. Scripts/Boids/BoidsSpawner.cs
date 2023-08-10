using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsSpawner : MonoBehaviour
{
    public GameObject[] prefab;

    public List<BoidsBase> neighbours = new List<BoidsBase>();
    public int createCount = 0;
    public float radius = 0;

    [SerializeField] float alignmentWeight = 1;
    [SerializeField] float cohesionWeight = 1;
    [SerializeField] float separationWeight = 1;
    [SerializeField] float boundaryWeight = 3;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < createCount; i++)
        {
            var randType = Random.Range(0, 5);
            var randPos = Random.insideUnitSphere;
            randPos *= radius;

            var go = Instantiate(prefab[randType], transform.position + randPos, Quaternion.Euler(RandomRoatationInY()));
            if (go.TryGetComponent(out BoidsBase bb))
            {
                neighbours.Add(bb);
                bb.spawner = this;
                bb.type = (BoidsBase.EBOIDTYPE)randType;
            }
            go.transform.SetParent(transform);
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ControlVectorWeight(alignmentWeight, cohesionWeight, separationWeight, boundaryWeight);
        }
    }

    void ControlVectorWeight(float alignment = 1, float cohesion = 1, float separation = 1, float boundary = 1)
    {
        foreach (var boid in neighbours)
        {
            boid.ControlVectorWeight(alignment, cohesion, separation, boundary);
        }
    }

    Vector3 RandomRoatationInY()
    {
        float y = Random.Range(0, 360f);
        Vector3 random = new Vector3(0, y, 0);
        return random;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
