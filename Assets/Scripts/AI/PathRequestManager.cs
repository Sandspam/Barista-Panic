/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathRequestManager : MonoBehaviour
{
    Queue<PathRequest> pathRequestQueue = new Queue<PathRequest>();
    PathRequest currentPathRequest;

    static PathRequestManager instance;

    private void Awake()
    {
        instance = this;
    }

    public static void RequestPath (Vector3 pathStart, Vector3 pathEnd)
    {
        PathRequest newRequest = new PathRequest(pathStart, pathEnd);
        instance.pathRequestQueue.Enqueue(newRequest);
    }

    struct PathRequest
    {
        public Vector3 pathStart;
        public Vector3 pathEnd;

        public PathRequest(Vector3 _start, Vector3 _end)
        {
            pathStart = _start;
            pathEnd = _end;
        }
    }
}*/
