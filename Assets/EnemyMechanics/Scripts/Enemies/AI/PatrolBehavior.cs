using System.Collections.Generic;
using EnemyMechanics.Core;
using EnemyMechanics.Movement;
using UnityEngine;

namespace EnemyMechanics.Enemies.AI
{
    public class PatrolBehavior : IBehavior
    {
        private Queue<Vector3> _waypointsQueue = new Queue<Vector3>();
        private Vector3 _currentWaypoint;
        private readonly Transform _self;
        private readonly Mover _mover;

        public PatrolBehavior(Transform self, Mover mover, IReadOnlyList <Transform> patrolPoints)
        {
            _self = self;
            _mover = mover;
            
            foreach (var patrolPoint in patrolPoints)
                _waypointsQueue.Enqueue(patrolPoint.position);    
            
            SwitchWaypoint();
        }
        
        public void Tick(float deltaTime)
        {
            Vector3 toWaypoint = _currentWaypoint - _self.position;
            toWaypoint.y = 0;
            
            if (toWaypoint.magnitude <= ConfigData.WaypointReachDistance)
            {
                SwitchWaypoint();
                toWaypoint = _currentWaypoint - _self.position;
                toWaypoint.y = 0;
            }
            
            toWaypoint.Normalize();
            _mover.MoveTo(toWaypoint);
            _mover.RotateTo(toWaypoint);
        }

        private void SwitchWaypoint()
        {
            _currentWaypoint = _waypointsQueue.Dequeue();
            _waypointsQueue.Enqueue(_currentWaypoint);
        }
    }
}