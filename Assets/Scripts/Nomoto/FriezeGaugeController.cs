using UnityEngine;
using System.Collections;

public class FriezeGaugeController : MonoBehaviour
{

    [SerializeField, Tooltip("上限値 (最低値は0です)")]
    private float maxValue = 100;

    [SerializeField, Tooltip("ゲージがだんだん減る量")]
    private float minusValue = 10;

    [SerializeField, Tooltip("MiniGunを打つたびに増える量")]
    private float plusValue = 100;

    private float _value = 0;

    public float Value
    {
        get { return _value; }
        set { _value = value; }
    }

    bool _canShot = true;

    public bool CanShot
    {
        get { return _canShot; }
    }

    [SerializeField, Tooltip("冷却を進める速度")]
    private float coolTimeSpeed = 25.0f;

    bool _isShoted = false;

    public bool IsShoted
    {
        get { return _isShoted; }
        set { _isShoted = value; }
    }

    void Start()
    {

    }

    void ChangeValue()
    {
        if (true != _canShot) return;

        if (_value > 0)
            _value -= minusValue * Time.deltaTime;
        if (_value < 0)
            _value = 0;

        if (true != _isShoted) return;
            _value += plusValue * Time.deltaTime;
            _isShoted = false;
        if (_value <= maxValue) return;
        _value = maxValue;
        _canShot = false;
    }

    void Cool()
    {
        if (false != _canShot) return;

        _value -= coolTimeSpeed * Time.deltaTime;

        if (_value > 0) return;
        _value = 0.0f;
        _canShot = true;
    }

    void ChangeSize()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(7 * _value, 120);
    }

    void Update()
    {
        ChangeValue();
        Cool();
        ChangeSize();
    }
}
