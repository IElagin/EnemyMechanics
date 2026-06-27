using System.Collections.Generic;
using EnemyMechanics.Core;
using UnityEngine;

namespace EnemyMechanics.Enemies.AI
{
    public class PatrolBehavior : IIdleBehavior
    {
        private Queue<Vector3> _waypointsQueue = new Queue<Vector3>();
        private Vector3 _currentWaypoint;
        
        public PatrolBehavior(IReadOnlyList <Transform> patrolPoints)
        {
            foreach (var patrolPoint in patrolPoints)
            {
                _waypointsQueue.Enqueue(patrolPoint.position);    
            }
            
            SwitchWaypoint();
        }

        public Vector3 Tick(IEnemyContext enemy)
        {
            Vector3 toWaypoint = _currentWaypoint - enemy.Position;
            toWaypoint.y = 0;
            
            if (toWaypoint.magnitude <= ConfigData.WaypointReachDistance)
            {
                SwitchWaypoint();
                toWaypoint = _currentWaypoint - enemy.Position;
                toWaypoint.y = 0;
            }
            
            return toWaypoint.normalized;
        }

        private void SwitchWaypoint()
        {
            _currentWaypoint = _waypointsQueue.Dequeue();
            _waypointsQueue.Enqueue(_currentWaypoint);
        }
    }
}