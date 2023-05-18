using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    public override void EnterState(EnemyStateMachine enemy)
    {
        enemy.enemyAnimation.PlayAnimation(1);
    }

    public override void ExitState(EnemyStateMachine enemy)
    {

    }

    public override void FixedUpdateState(EnemyStateMachine enemy)
    {
    }

    public override void UpdateState(EnemyStateMachine enemy)
    {
        if (enemy.enemyController.playerColi)
            enemy.enemyController.MoveToTarget(enemy.enemyController.playerColi.transform.position);

        if (enemy.enemyController.playerInRange && enemy.enemyController.canAttack)
            enemy.SwitchState(enemy.attackState);

        if (!enemy.enemyController.playerDetected)
            enemy.SwitchState(enemy.idleState);
    }


}