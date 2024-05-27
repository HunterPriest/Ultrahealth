using System.Collections;
using UnityEngine;

public class ComboCounter
{
    private MonoBehaviour _monoBehaviour;
    private GameUI _gameUI;
    private int _amountCombo = 0;
    private int _currentAmountCombo = 0;
    private GameConfigInstaller.ComboSetting _comboSetting;

    public ComboCounter(MonoBehaviour monoBehaviour, GameUI gameUI, GameConfigInstaller.ComboSetting comboSetting)
    {
        _monoBehaviour = monoBehaviour;
        _gameUI = gameUI;
        _comboSetting = comboSetting;
    }

    public void AddCombo(float health)
    {
        _monoBehaviour.StopAllCoroutines();
        if(_currentAmountCombo == 0)
        {
            _gameUI.gameplayUI.SetComboVisible(true);
            _gameUI.gameplayUI.SetOutlineComboColor(Color.black);
        }
        _currentAmountCombo++;
        _gameUI.gameplayUI.SetCombo(_currentAmountCombo, _comboSetting.GetColorCombo(_currentAmountCombo));
        _monoBehaviour.StartCoroutine(RemoveCombo());
    }

    private IEnumerator RemoveCombo()
    {
        yield return new WaitForSeconds(_comboSetting.timeOfDescreaseCombo);
        _amountCombo++;
        _currentAmountCombo--;
        _gameUI.gameplayUI.SetCombo(_currentAmountCombo, _comboSetting.GetColorCombo(_currentAmountCombo));
        if(_currentAmountCombo == 0)
        {
            _monoBehaviour.StartCoroutine(HideZeroCombo());
        }
        else if(_currentAmountCombo > 0)
        {
            _monoBehaviour.StartCoroutine(RemoveCombo());
        }
    }   

    public void ResetToZero(float damage)
    {
        _monoBehaviour.StopAllCoroutines();
        _currentAmountCombo = 0;
        _monoBehaviour.StartCoroutine(HideZeroCombo());
    }

    private IEnumerator HideZeroCombo()
    {   
        _gameUI.gameplayUI.SetCombo(_currentAmountCombo, Color.black);
        _gameUI.gameplayUI.SetOutlineComboColor(Color.red);
        yield return new WaitForSeconds(_comboSetting.timeOfHideZeroCombo);
        _gameUI.gameplayUI.SetComboVisible(false);
        _gameUI.gameplayUI.SetOutlineComboColor(Color.black);
    }

    public int GetAmountComboInEndLevel()
    {
        return _amountCombo + _currentAmountCombo;
    }
}