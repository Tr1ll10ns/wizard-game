using Godot;
using System;

public class Player : Creature
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	bool onGround = false;
	float speed = 14000;
	float jumpStrength = 50000;
	float speedDeadband = 750;
	public void move(float delta)
	{
		if (Input.IsActionPressed("ui_left") && Math.Abs(this.LinearVelocity.x) <= speedDeadband && onGround)
		{
			this.ApplyCentralImpulse(Vector2.Left * speed * delta);
		}
		if (Input.IsActionPressed("ui_right") && Math.Abs(this.LinearVelocity.x) <= speedDeadband && onGround)
		{
			this.ApplyCentralImpulse(Vector2.Right * speed * delta);
		}
		if (Input.IsActionJustPressed("ui_select") && onGround)
		{
			this.ApplyCentralImpulse(Vector2.Up * jumpStrength * delta);
		}
	}
	public override void _Ready()
	{
		GD.Print("ready");

		var groundChecker = GetNode<Area2D>("Ground Checker");
		groundChecker.Connect("area_entered", this, nameof(land));
		groundChecker.Connect("body_entered", this, nameof(land));
		// groundChecker.Connect("body_shape_entered", this, nameof(land));
		groundChecker.Connect("area_exited", this, nameof(notLand));
		groundChecker.Connect("body_exited", this, nameof(notLand));
		// groundChecker.Connect("body_shape_exited", this, nameof(notLand));

	}

	//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		move(delta);
	}
	public void land(PhysicsBody2D body)
	{
		GD.Print("land");
		onGround = true;
	}
	public void notLand(PhysicsBody2D body)
	{
		GD.Print("not land");
		onGround = false;
	}
}
