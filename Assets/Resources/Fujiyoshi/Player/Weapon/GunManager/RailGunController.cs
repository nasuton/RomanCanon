using UnityEngine;
using System.Collections;

public class RailGunController : MonoBehaviour
{
    [SerializeField]
    GameObject bullet = null;

    [SerializeField, Tooltip("BulletSpeed")]
    private float speed = 100.0f;

    [SerializeField, Tooltip("1発撃った後の待機時間")]
    private float waitTimeOfShot = 0.05f;

    private bool isCharge = false;

    private bool isShoted = false;

    private float chargePower = 0.0f;

    [SerializeField, Tooltip("Chargeを貯める速度")]
    private float chargeSpeed = 0.5f;

    public float ChargePower
    {
        get { return chargePower; }
    }

    enum ChargeCount
    {
        MAX = 100,
        MIN = 0
    }

    void Start()
    {
        isCharge = false;
        isShoted = false;
        bullet.SetActive(false);
    }

    private void MakeBullet()
    {
        Vector3 force;
        force = transform.forward * speed;
        bullet.GetComponent<BulletOfRailGun>().MoveVec = force;
    }

    void Update()
    {
        Shot();
        Charge();
        DevideChargePower();
    }

    private void Shot()
    {
        if (isShoted == true) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isCharge == false)
                isCharge = true;
        }

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            if (isCharge == true)
            {
                isCharge = false;
                isShoted = true;
                bullet.GetComponent<BulletOfRailGun>().Reset();
                bullet.SetActive(true);
                MakeBullet();
            }
        }
    }

    private void Charge()
    {
        if (isCharge == false) return;

        chargePower += chargeSpeed * Time.deltaTime;

        Debug.Log(chargePower);

        if (chargePower > (float)ChargeCount.MAX)
            chargePower = (float)ChargeCount.MAX;
    }


    private void DevideChargePower()
    {
        if (isShoted == false) return;

        chargePower -= chargeSpeed * Time.deltaTime;

        if (chargePower < (float)ChargeCount.MIN)
        {
            chargePower = (float)ChargeCount.MIN;
            isShoted = false;
            bullet.SetActive(false);
        }
    }

}
