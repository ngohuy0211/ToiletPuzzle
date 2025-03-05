using UnityEngine;

public class OverlayButton : MonoBehaviour
{
  private RectTransform _rectTransform;

  [Header("Desktop")] [SerializeField] private Vector3 _desktopPosition;
  [SerializeField] private int _desktopSize;

  [Header("Mobile")] [Space(10)] [SerializeField]
  private Vector3 _mobilePosition;

  [SerializeField] private int _mobileSize;

  private void Awake() => _rectTransform = GetComponent<RectTransform>();

  public void CheckPlatform()
  {
      SetMobileSize();
  }


  private void SetDesktopSize()
  {
    _rectTransform.anchoredPosition = _desktopPosition;
    _rectTransform.sizeDelta = new Vector2(_desktopSize, _desktopSize);
  }

  private void SetMobileSize()
  {
    _rectTransform.anchoredPosition = _mobilePosition;
    _rectTransform.sizeDelta = new Vector2(_mobileSize, _mobileSize);
  }
}