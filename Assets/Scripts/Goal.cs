using Assets.Scripts.Interfaces;
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
        Debug.Log("Goal cleared!");
    }

    public void onGoalFailed()
    {
        Debug.Log("Goal Failed :(");
    }
}
