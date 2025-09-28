using Assets.Scripts.Interfaces;
using Assets.Scripts.Managers;
using UnityEngine;
using static ObjectEquip;

public class Goal : MonoBehaviour, IInteractable
{
    [SerializeField] public string target;
    [SerializeField] public GameObject InteractionUI;

    public void onPlayerEnter()
    {
        InteractionUI.SetActive(true);
    }

    public void onPlayerExit()
    {
        InteractionUI.SetActive(false);
    }

    public void Interact()
    {
        NameSprite ns = ObjectEquip.Instance.CurrentlySelected;
        if (ns == null) return;

        string currName = ns.name;
        Debug.Log($"{currName}, {target}");
        if (currName == target)
        {
            onGoalAchieved();
        }
        else
        {
            onGoalFailed();
        }
    }

    public void onGoalAchieved()
    {
        Inventory.Instance.removeItem(ObjectEquip.Instance.CurrentlySelected.name);
        UIManager.Instance.WinScreen();
    }

    public void onGoalFailed()
    {
        LivesManager.Instance.IncrementLives(-1);
    }
}
