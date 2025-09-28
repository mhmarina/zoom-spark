using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnlockableLevel : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField]
    public LevelData levelData;
    [SerializeField]
    public GameObject lockedImage;
    [SerializeField]
    public Button button;
    [SerializeField] 
    TextMeshProUGUI InfoTarget;

    void Start()
    {
        if (!levelData.locked)
        {
            Unlock();
        }
        if (levelData.locked)
        {
            Lock();
        }
    }

    public void Lock(){
        lockedImage.SetActive(true);
        button.enabled = false;
        levelData.locked = true;
    }

    public void Unlock()
    {
        lockedImage.SetActive(false);
        button.enabled = true;
        levelData.locked = false;
    }

    public void Complete()
    {
        levelData.completed = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (levelData.completed)
        {
            InfoTarget.text = levelData.info;
        }
    }
}
