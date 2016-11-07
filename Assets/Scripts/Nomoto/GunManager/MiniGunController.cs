using UnityEngine;
using System.Collections;

public class MiniGunController : DefaultGunController
{
    [SerializeField]
    GameObject friezeGauge = null;

    [SerializeField]
    float defaultWaitTimeOfShot = 0.5f;

    [SerializeField]
    float maxWaitTimeOfShot = 65.0f;

    void Start()
    {
        setWaitTimeOfShot(defaultWaitTimeOfShot,maxWaitTimeOfShot);
        friezeGauge = GameObject.Find("FriezeGauge");
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
            if (Input.GetKey(KeyCode.Space) && friezeGauge.GetComponent<FriezeGaugeController>().CanShot == true)
            {
                MakeBullet();
                friezeGauge.GetComponent<FriezeGaugeController>().IsShoted = true;

                Debug.Log(waitTimeOfShot);

                yield return new WaitForSeconds(waitTimeOfShot);
            }
            yield return 0;
        }
    }
}
