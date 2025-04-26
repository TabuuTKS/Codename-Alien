using UnityEngine;
using UnityEngine.UI;

public class MobileUI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] GameObject DailogueUI;
    [SerializeField] GameObject LeftBTN, RightBTN, JumpBTN, CrouchBTN;

    private void Update()
    {
        if (DailogueUI.activeSelf)
        {
            LeftBTN.GetComponent<Button>().interactable = false;
            RightBTN.GetComponent<Button>().interactable = false;
            JumpBTN.GetComponent<Button>().interactable = false;
            CrouchBTN.GetComponent<Button>().interactable = false;
        }
        else
        {
            LeftBTN.GetComponent<Button>().interactable = true;
            RightBTN.GetComponent<Button>().interactable = true;
            JumpBTN.GetComponent<Button>().interactable = true;
            CrouchBTN.GetComponent<Button>().interactable = true;
        }
    }

    //we nead and object which has new input system.
    //these functions are called using event trigger in buttons. or by onclick event.
    //they are assigned some specific values.
    public void MoveLeftButtonDown() => player.SetXAxis(-1);
    public void MoveRightButtonDown() => player.SetXAxis(1);
    public void MoveButtonUp() => player.SetXAxis(0);

    public void JumpButton() => player.TriggerJump();
    public void CrouchButtonDown() => player.setCrouch(true);
    public void CrouchButtonUP() => player.setCrouch(false);
}
