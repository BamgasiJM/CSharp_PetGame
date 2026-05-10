using PetGame.Systems;

namespace PetGame.Pets;

public class Lizard : Pet
{
  public Lizard()
  {
    actionPreference = new()
        {
            { ActionType.Play, -5 },
            { ActionType.Feed, 12 },
            { ActionType.Hug, -15 },
            { ActionType.Talk, 1 },
            { ActionType.Observe, 15 },
            { ActionType.Rest, 10 }
        };
  }

  public override void React(ActionType action)
  {
    ApplyBasicAction(action);

    int preference = actionPreference[action];

    Affection += preference;

    string message = action switch
    {
      ActionType.Play => "도마뱀이 귀찮아하는 듯 합니다.",
      ActionType.Hug => "도마뱀이 긴장합니다.",
      ActionType.Feed => "도마뱀이 천천히 먹이를 먹습니다.",
      ActionType.Talk => "도마뱀이 가만히 바라봅니다.",
      ActionType.Observe => "도마뱀이 안정감을 느낍니다.",
      ActionType.Rest => "도마뱀이 조용히 쉬고 있습니다.",
      _ => ""
    };

    Console.WriteLine(message);

    ClampStats();
  }
}