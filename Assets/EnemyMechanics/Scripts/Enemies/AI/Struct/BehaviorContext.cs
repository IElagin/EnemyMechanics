using System.Collections.Generic;
using EnemyMechanics.Movement;
using UnityEngine;

namespace EnemyMechanics.Enemies.AI
{
    public struct BehaviorContext
    {
          public Transform Self { get; }                                                                                                                                                                                                                                                                           
          public Transform Target { get; }                                                                                                                                                                                                                                                                         
          public Mover Mover { get; }                                                                                                                                                                                                                                                                              
          public IKillable Killable { get; }                                                                                                                                                                                                                                                                       
          public IReadOnlyList<Transform> PatrolPoints { get; }                                                                                                                                                                                                                                                    
                                                                                                                                                                                                                                                                                                                   
          public BehaviorContext(Transform self, Transform target, Mover mover,                                                                                                                                                                                                                                    
                                 IKillable killable, IReadOnlyList<Transform> patrolPoints)                                                                                                                                                                                                                        
          {                                                                                                                                                                                                                                                                                                        
              Self = self;                                                                                                                                                                                                                                                                                         
              Target = target;                                                                                                                                                                                                                                                                                     
              Mover = mover;                                                                                                                                                                                                                                                                                       
              Killable = killable;                                                                                                                                                                                                                                                                                 
              PatrolPoints = patrolPoints;                                                                                                                                                                                                                                                                         
          }       
    }
}