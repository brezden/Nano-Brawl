using Godot;
using System;
using System.Transactions;

public partial class Player : Godot.CharacterBody2D {
    int Acceleration = 500;
    int MaxSpeed = 60;
    int Friction = 500;
    
    [Signal]
    public delegate void EnemyHitWithArgumentEventHandler(Detonix detonix);

    public override void _Ready(){

    }

    // AnimationPlayer RobotAnimation;
    // AnimationTree RobotAnimationTree;
    // AnimationNodeStateMachinePlayback StateMachine;

    // public override void _Ready() {
    //     RobotAnimation = (AnimationPlayer)GetNode("RobotAnimation");
    //     RobotAnimationTree = (AnimationTree)GetNode("RobotAnimationTree");
    //     StateMachine = (AnimationNodeStateMachinePlayback)RobotAnimationTree.Get("parameters/playback");
    // }

    public override void _PhysicsProcess(double delta) {

        for(int i = 0; i < GetSlideCollisionCount(); i++){
        KinematicCollision2D collisionObject = GetSlideCollision(i);
        Node collidedNode = collisionObject?.GetCollider() as Node;

        if (collisionObject != null && collidedNode != null && collidedNode.IsInGroup("enemy") && collidedNode is Detonix) {
            EmitSignal(nameof(EnemyHitWithArgument), collidedNode as Detonix);
        }
    }

        Vector2 InputVector = Vector2.Zero;
        InputVector.X = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
        InputVector.Y = Input.GetActionStrength("move_down") - Input.GetActionStrength("move_up");
        InputVector = InputVector.Normalized();

        if (InputVector != Vector2.Zero) {
            // RobotAnimationTree.Set("parameters/Idle/blend_position", InputVector);
            // RobotAnimationTree.Set("parameters/Run/blend_position", InputVector);
            // StateMachine.Travel("Run");

            Velocity = Velocity.MoveToward(InputVector * MaxSpeed, Acceleration * (float)delta);
        } 
        

        else {
            // StateMachine.Travel("Idle");
            Velocity = Velocity.MoveToward(Vector2.Zero, Friction * (float)delta);
        }
        MoveAndSlide();
    }
}