using UnityEngine;
using System.Collections;

public class MiniGunController : DefaultGunController
{

    private GameObject friezeGauge = null;
    public GameObject FriezeGauge { get { return friezeGauge; } set { friezeGauge = value; } }

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
            if (Input.GetMouseButton(0) && friezeGauge.GetComponent<CoolingGauge>().canShot == true)
            {
                MakeBullet();
                if(GameObject.Find("RomanBar").GetComponent<RomanGauge>().roman_mode == false) {
                    friezeGauge.GetComponent<CoolingGauge>().Default();
                }
                else
                {
                    friezeGauge.GetComponent<CoolingGauge>().Cooling();
                }
                
                yield return new WaitForSeconds(friezeGauge.GetComponent<CoolingGauge>().rate);
            }
            else
            {
                friezeGauge.GetComponent<CoolingGauge>().Cooling();
            }
            yield return 0;
        }
    }
}
