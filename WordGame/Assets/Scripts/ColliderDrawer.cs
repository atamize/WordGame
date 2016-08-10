using UnityEngine;
using System.Collections.Generic;
using Vectrosity;

[RequireComponent(typeof(EdgeCollider2D))]
public class ColliderDrawer : MonoBehaviour
{
    VectorLine line;

	void Start()
	{
        var edgeCollider = GetComponent<EdgeCollider2D>();
        List<Vector3> points = new List<Vector3>();
        for (int i = 0; i < edgeCollider.pointCount - 1; ++i)
        {
            Vector3 p1 = transform.position + new Vector3(edgeCollider.points[i].x, edgeCollider.points[i].y);
            Vector3 p2 = transform.position + new Vector3(edgeCollider.points[i + 1].x, edgeCollider.points[i + 1].y);
            points.Add(p1);
            points.Add(p2);
        }

        line = new VectorLine("Line", points, 2f);
        line.color = Color.green;
        line.Draw3DAuto();

    }
}
