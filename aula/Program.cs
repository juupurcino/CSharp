using Radiance;
using static Radiance.Utils;

Character character = new Character(red);
Character character2 = new Character(blue);
character.SetState(new CollisionState(character));
character2.SetState(new CollisionState(character2));

Window.OnFrame += () =>
{
    character.Act();
    character2.Act();
};

Window.OnRender += () =>
{
    character.Draw();
    character2.Draw();
};

Window.CloseOn(Input.Escape);
Window.Open();