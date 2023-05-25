using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : IState
{
    public void EnterState(PlayerStateManager player)
    {
        player.playerAnimation.PlayAnimatorClip("Fall");

        player.soundEffect.PlayAudio(0);
    }

    public void ExitState(PlayerStateManager player)
    {

    }

    public void FixedUpdateState(PlayerStateManager player)
    {
        player.playerController.MoveOnAir();

    }

    public void UpdateState(PlayerStateManager player)
    {
        if (player.playerDatabase.isGrounded)
        {
            player.SwitchState(player.crouchState);
            player.soundEffect.PlayAudio(3);
        }

        // if (player.playerController.isRightEdge || player.playerController.isLeftEdge)
        //     player.SwitchState(player.wallEdge);

        if (player.playerDatabase.isLeftWall || player.playerDatabase.isRightWall)
        {
            player.SwitchState(player.wallSlideState);
        }


        if (player.inputController.isLeftMousePress)
        {
            player.SwitchState(player.airAttackState);
        }

        if (player.inputController.isDashPress)
        {
            player.SwitchState(player.dashState);
        }

        if (player.inputController.isJumpPress)
            player.SwitchState(player.jumpState);
    }
}
