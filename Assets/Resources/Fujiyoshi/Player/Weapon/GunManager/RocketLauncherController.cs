using UnityEngine;
using System.Collections;

public class RocketLauncherController : DefaultGunController
{
    void Start()
    {
        StartCoroutine(Shot());
    }

    private void MakeBullet()
    {
        GameObject obj = (GameObject)Instantiate(bullet, new Vector3(0, 0, 0), Quaternion.identity);
        Vector3 force;
        force = transform.forward * speed;
        obj.GetComponent<VectorMover>().MoveVec = force;
        obj.transform.position = transform.position + transform.forward * 7;
    }




    private IEnumerator Shot()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                MakeBullet();

                yield return new WaitForSeconds(waitTimeOfShot);
            }
            yield return 0;
        }
    }
}
