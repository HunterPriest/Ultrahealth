using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlayerMenu : UIToolkitElementWithExitOnButton
{
    [SerializeField] private VisualTreeAsset _playerMenuAsset;
    [SerializeField] private LevelChoice _levelChoice;
    [SerializeField] private levelUp _levelUp;
    [SerializeField] private DictionaryUI _directoryUI;
}