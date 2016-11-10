using UnityEngine;
using System.Collections;

public class MiniGunController : DefaultGunController
{

    [SerializeField]
    public GameObject friezeGauge = null;

    [SerializeField]
    float defaultWaitTimeOfShot = 0.1f;

    [SerializeField]
    float maxWaitTimeOfShot = 65.0f;

    

    void Start()
    {
        setWaitTimeOfShot(defaultWaitTimeOfShot,maxWaitTimeOfShot);
        StartCoroutine(Shot());
    }

    private void MakeBullet()
    {
        GameObject obj = (GameObject)Instantiate(bullet, new Vector3(0, 0, 0), Quaternion.identity);
        Vector3 force;
        force = 1000 * transform.forward * speed;
        obj.GetComponent<VectorMover>().MoveVec = force;
        obj.transform.position = transform.position + transform.forward * 5;
        
    }

    private IEnumerator Shot()
    {
        while (true)
        {
            if (Input.GetMouseButton(0) && friezeGauge.GetComponent<FriezeGaugeController>().CanShot == true)
            {
                MakeBullet();
                friezeGauge.GetComponent<FriezeGaugeController>().IsShoted = true;

                yield return new WaitForSeconds(0.05f);
            }
            
            yield return 0;
        }
    }
}
