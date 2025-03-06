using System;
using MPUIKIT;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class SkinPanel : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private SkinType _skinType;
    [SerializeField] private Color _usedColor;
    [SerializeField] private Color _unusedColor;
    [SerializeField] private Color _inactiveColor;
    [SerializeField] private Image _color;
    [SerializeField] private State _state;
    [SerializeField] private Buyed _buyed;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private String _activeName;
    [SerializeField] private String _buyedName;
    [SerializeField] private RewardAdvertising _rewardAdvertising;
    [SerializeField] private Image _adsLogo;
    [SerializeField] private string _used;
    [SerializeField] private string _use;

    private RectTransform _rectTransform;
    public SkinType SkinType => _skinType;

    public event Action<SkinType> OnClick;
    public event Action ClickedButton;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
        CheckPanelState();
    }

    private void OnDisable() => _button.onClick.RemoveListener(OnButtonClick);

    private void Start()
    {
        _used = "USED";
        _use = "SELECT";

        CheckPanelState();
    }

    public void SetStatesByPlayerPrefs()
    {
        if (ES3.Load(_activeName, 0) == 1)
            _state = State.Active;
        else
            _state = State.Inactive;

        if (ES3.Load(_buyedName, 0) == 1)
        {
            _buyed = Buyed.Buy;

            if (_adsLogo != null)
                _adsLogo.enabled = false;
        }
        else
            _buyed = Buyed.Sell;
    }

    public void Deactivate()
    {
        ES3.Save(_activeName, 0);
        _state = State.Inactive;
        _color.color = _inactiveColor;
        CheckPanelState();
    }

    public void Activate()
    {
        ES3.Save(_activeName, 1);
        ES3.Save(_buyedName, 1);
        _buyed = Buyed.Buy;
        _state = State.Active;
        CheckPanelState();
    }

    public void CheckPanelState()
    {
        if (_buyed == Buyed.Buy)
        {
            ES3.Save(_buyedName, 1);
            _text.text = _use;
        }
        else
            _text.text = "GET IT";

        if (_state == State.Active)
        {
            ES3.Save(_activeName, 1);
            _color.color = _usedColor;
            _text.text = _used;
        }
        else
            _color.color = _unusedColor;
    }

    public void OnRewardCallback()
    {
        _state = State.Active;
        _buyed = Buyed.Buy;
        CheckPanelState();
        OnClick?.Invoke(SkinType);
    }

    public void OnButtonClick()
    {
        if (_buyed == Buyed.Buy)
            OnRewardCallback();
        else
        {
         
            //Advertisements.Instance.ShowRewardedVideo(CompleteMethod);
            //if (_adsLogo != null)
            //    _adsLogo.enabled = false;

            //_rewardAdvertising.TryShowAD(OnRewardCallback);
        }

        ClickedButton?.Invoke();
    }

    private void CompleteMethod(bool completed, string advertiser)
    {
        Debug.Log("Closed rewarded from: " + advertiser + " -> Completed " + completed);
        if (completed == true)
        {
            //give the reward
            if (_adsLogo != null)
                _adsLogo.enabled = false;

            OnRewardCallback();
        }
        else
        {
            //no reward
        }
    }

    public void Init(RewardAdvertising rewardAdvertising)
    {
        _rewardAdvertising = rewardAdvertising;
        _rectTransform.localScale = Vector3.one;
        _rectTransform.localPosition = new Vector3(_rectTransform.localPosition.x, _rectTransform.localPosition.y, 0.0f);
    }

    public void SetButtonPosition()
    {
        _button.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(
          _button.gameObject.GetComponent<RectTransform>().localPosition.x, -250.0f,
          _button.gameObject.GetComponent<RectTransform>().localPosition.z);
    }
}

enum State
{
    Active = 0,
    Inactive
}

enum Buyed
{
    Buy = 0,
    Sell
}