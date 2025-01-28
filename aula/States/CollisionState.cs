using Radiance;

public class CollisionState : State
{

    private Character otherCharacter;

    public CollisionState(Character otherCharacter)
    {
        this.otherCharacter = otherCharacter;
    }

    public override void Act()
    {
        if (character is null || otherCharacter is null)
            return;

        var dx = otherCharacter.X - character.X;
        var dy = otherCharacter.Y - character.Y;
        var distance = MathF.Sqrt(dx * dx + dy * dy);


        if (distance < 100)
        {
            character.SetState(new WaitingState());
            otherCharacter.SetState(new WaitingState());
        }
    }
}