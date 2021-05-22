using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/State/Chase")]

public class Chase : State
{
    private Enemy enemy;
    public override void EnterState(StateController controller)
    {
        enemy = controller.GetComponent<Enemy>();
        enemy.agent.updateRotation = false;
        enemy.agent.updateUpAxis = false;
    }

 

    public override void UpdateState(StateController controller)
    {
        Vector2 dir = (enemy.transform.position - enemy.target.position).normalized;
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
        enemy.transform.rotation = Quaternion.RotateTowards(enemy.transform.rotation, rot, enemy.rotSpeed * Time.deltaTime);
        enemy.agent.SetDestination(enemy.target.position);
    }
}
