using UnityEngine;

public class MobileUI : MonoBehaviour
{
    [SerializeField] private Player player;

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
