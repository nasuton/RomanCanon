using UnityEngine;
using System.Collections;

public class DeadCounter : MonoBehaviour
{
    [SerializeField]
    private float activeTime = 5.0f;

    void Start()
    {
        StartCoroutine(CountActiveTime());
    }

    private IEnumerator CountActiveTime()
    {
        while (true)
        {
            activeTime -= Time.deltaTime;

            if (activeTime < 0.0f)
            {
                Destroy(this.gameObject);
            }
            yield return 0;
        }
    }
}
