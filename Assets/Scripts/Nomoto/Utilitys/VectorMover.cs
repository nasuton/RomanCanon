using UnityEngine;
using System.Collections;

public class VectorMover : MonoBehaviour
{
    private Vector3 moveVec = new Vector3(0, 0, 0);

    public Vector3 MoveVec
    {
        get { return moveVec; }
        set { moveVec = value; }
    }
    void Start()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (true)
        {
            transform.position += new Vector3(moveVec.x * Time.deltaTime, moveVec.y * Time.deltaTime, moveVec.z * Time.deltaTime);
            yield return 0;
        }
    }
}
