using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class DummyEnemyBT : EnemyBT
{
    protected override Node SetupTree()
    {
        Node root = new Sequence(new List<Node>
        {
            new TaskEnemyIsNotLocked(enemyController),
            new Selector(new List<Node>
            {
                new TaskIsCloseToPlayer(enemyController, enemyController.enemyData.normalDistanceFromPlayer),
                new TaskMoveToPlayer(enemyController, enemyController.enemyData.movementSpeed)
            }),
            new TaskAttackPlayer(enemyController)
        });
        return root;

    }
}
