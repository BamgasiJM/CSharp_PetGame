// ======================================================
// File Tree
// PetGame/
// └ Pets/
//    └ Lizard.cs
// ======================================================

using PetGame.Core;

namespace PetGame.Pets;

public class Lizard : Pet
{
  public Lizard()
  {
    actionPreference = new()
        {
            { ActionType.Feed, 15 },
            { ActionType.Play, -5 },
            { ActionType.Hug, -15 },
            { ActionType.Talk, 2 },
            { ActionType.Observe, 15 },
            { ActionType.Rest, 10 }
        };
  }

  public override void React(ActionType action)
  {
    ApplyBasicAction(action);

    Affection += actionPreference[action];

    string message = action switch
    {
      ActionType.Feed => "도마뱀이 천천히 먹이를 먹습니다.",
      ActionType.Play => "도마뱀이 귀찮아하는 것 같습니다.",
      ActionType.Hug => "도마뱀이 긴장합니다.",
      ActionType.Talk => "도마뱀이 조용히 바라봅니다.",
      ActionType.Observe => "도마뱀이 안정감을 느낍니다.",
      ActionType.Rest => "도마뱀이 따뜻한 곳에서 쉽니다.",
      _ => ""
    };

    Console.WriteLine(message);

    ClampStats();
  }
}