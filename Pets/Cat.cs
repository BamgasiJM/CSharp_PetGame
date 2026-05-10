// ======================================================
// File Tree
// PetGame/
// └ Pets/
//    └ Cat.cs
// ======================================================

using PetGame.Systems;

namespace PetGame.Pets;

public class Cat : Pet
{
  public Cat()
  {
    actionPreference = new()
        {
            { ActionType.Play, 15 },
            { ActionType.Feed, 10 },
            { ActionType.Hug, -10 },
            { ActionType.Talk, 3 },
            { ActionType.Observe, 8 },
            { ActionType.Rest, 5 }
        };
  }

  public override void React(ActionType action)
  {
    ApplyBasicAction(action);

    int preference = actionPreference[action];

    Affection += preference;

    string message = action switch
    {
      ActionType.Play => "고양이가 즐겁게 뛰어다닙니다.",
      ActionType.Hug => "고양이가 조금 부담스러워합니다.",
      ActionType.Feed => "고양이가 만족스럽게 먹습니다.",
      ActionType.Talk => "고양이가 귀를 움직입니다.",
      ActionType.Observe => "고양이가 편안해 보입니다.",
      ActionType.Rest => "고양이가 몸을 말고 쉽니다.",
      _ => ""
    };

    Console.WriteLine(message);

    ClampStats();
  }
}