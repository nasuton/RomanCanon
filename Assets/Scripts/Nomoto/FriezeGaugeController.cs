using UnityEngine;
using System.Collections;

public class FriezeGaugeController : MonoBehaviour
{
    [SerializeField, Tooltip("冷却ゲージのDefault値です これでゲージの大きさを決めて下さい")]
    private float _defaultValue = 70;

    [SerializeField, Tooltip("上限値 冷却ゲージの最大値をいれてください")]
    private float _maxCoolValue = 110;

    [SerializeField, Tooltip("現在のステータスの冷却ゲージの最大値")]
    private float _nowMaxCoolValue = 0;

    [SerializeField, Tooltip("ゲージがだんだん減る量")]
    private float _minusValue = 10;

    [SerializeField, Tooltip("MiniGunを打つたびに増える量")]
    private float _plusValue = 100;

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

    [SerializeField]
    private float MaxCoolTimeSpeedRate = 55.0f;

    private float coolTimeSpeedRate = 0.0f;

    bool _isShoted = false;

    public bool IsShoted
    {
        get { return _isShoted; }
        set { _isShoted = value; }
    }

    void Start()
    {
        coolTimeSpeedRate = GameObject.Find("WeaponType").GetComponent<NormalPartsStatus>().Status[4] / MaxCoolTimeSpeedRate;
        _nowMaxCoolValue = (GameObject.Find("WeaponType").GetComponent<NormalPartsStatus>().Status[3] / _maxCoolValue) * _defaultValue;
    }

    void ChangeValue()
    {
        if (true != _canShot) return;

        if (_value > 0)
            _value -= coolTimeSpeed * coolTimeSpeedRate * Time.deltaTime;
        if (_value < 0)
            _value = 0;

        if (true != _isShoted) return;
            _value += _plusValue * Time.deltaTime;
            _isShoted = false;
        if (_value <= _nowMaxCoolValue) return;
        _value = _nowMaxCoolValue;
        _canShot = false;
    }

    void Cool()
    {
        if (false != _canShot) return;

        _value -= coolTimeSpeed * coolTimeSpeedRate * 3 * Time.deltaTime;

        if (_value > 0) return;
        _value = 0.0f;
        _canShot = true;
    }

    void ChangeSize()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2((_value / _nowMaxCoolValue) * 700, 120);
    }

    void Update()
    {
        ChangeValue();
        Cool();
        ChangeSize();
    }
}
