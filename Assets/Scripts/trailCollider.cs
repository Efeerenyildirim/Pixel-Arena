using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class trailCollider : MonoBehaviour
{
    public GameObject trail;
    private TrailRenderer trailRenderer;
    private EdgeCollider2D edgeCollider;

    void Start()
    {
        trailRenderer = trail.GetComponent<TrailRenderer>();
        edgeCollider = GetComponent<EdgeCollider2D>();

        trailRenderer.time = Mathf.Infinity;
    }


    void Update()
    {
        SetColliderPointsFromTrail(trailRenderer, edgeCollider);
    }

    void SetColliderPointsFromTrail(TrailRenderer trail, EdgeCollider2D collider)
    {
        List<Vector2> points = new List<Vector2>();
        for (int position = 0; position < trail.positionCount; position++)
        {
            points.Add(trail.GetPosition(position));
        }

        collider.SetPoints(points);
    }
}
