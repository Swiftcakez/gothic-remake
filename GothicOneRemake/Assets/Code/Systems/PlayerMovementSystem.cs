using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;


/*
This class updates the players rotation and position based on
the player input.
*/
[UpdateAfter(typeof(TransformSystemGroup))]
public class PlayerMovementSystem : SystemBase {

    protected override void OnUpdate() {

        // Get the input from mouse and keyboard, stored in the Entity PlayerInput
        var playerInput = GetSingleton<PlayerInput>();
        var movementSpeed = 5f;

        // Find the player Entity
        Entities.WithAll<PlayerTag>().ForEach((ref Translation translation, in LocalToWorld localToWorld, in Velocity velocity) => {

            // Calculate the target position for the palyer to move to using the suppied velocity and the 
            // LocalToWorld component
            float3 targetPosition = new float3(0, velocity.Value.y, 0) + (localToWorld.Forward * velocity.Value.z + localToWorld.Right * velocity.Value.x);

            translation.Value += targetPosition * Time.DeltaTime * movementSpeed;
            // TODO: Read up on movement
        }).WithoutBurst().Run();
    }
}