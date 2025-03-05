using UnityEngine;
using UnityEngine.UI;

public class UnitMenu : MonoBehaviour
{
  private const string Female = "Female";
  private const string Male = "Male";

  [SerializeField] private Image _currentSkin;
  [SerializeField] private Sprite[] _skins;
  [SerializeField] private Animator _animator;
  [SerializeField] private RuntimeAnimatorController[] _animatorControllers;

  [Space(10)] [SerializeField] private Gender _gender;
  [SerializeField] private string _actualGender;

  private Sprite _currentUnit;

  public string ActualGender => _actualGender;

  private void OnValidate()
  {
    _animator.runtimeAnimatorController = _animatorControllers[(int) _gender];
    _currentUnit = _skins[(int) _gender];
    _actualGender = _gender.ToString();
    _currentSkin.sprite = _currentUnit;
  }

  private void Start()
  {
        CheckUnit();
  }

    public void CheckUnit()
    {
        if (_actualGender == Gender.Female.ToString())
        {
            _currentSkin.sprite = _skins[SkinSaver.LoadFemaleSkin()];
            _animator.runtimeAnimatorController = _animatorControllers[SkinSaver.LoadFemaleSkin()];
        }
        else
        {
            _currentSkin.sprite = _skins[SkinSaver.LoadMaleSkin()];
            _animator.runtimeAnimatorController = _animatorControllers[SkinSaver.LoadMaleSkin()];
        }
    }
        
}
