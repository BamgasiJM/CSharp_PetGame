using PetGame.Systems;

namespace PetGame.Pets;

public class Parrot : Pet
{
  public Parrot()
  {
    actionPreference = new()
        {
            { ActionType.Play, 10 },
            { ActionType.Feed, 5 },
            { ActionType.Hug, 3 },
            { ActionType.Talk, 18 },
            { ActionType.Observe, -3 },
            { ActionType.Rest, 2 }
        };
  }

  public override void React(ActionType action)
  {
    ApplyBasicAction(action);

    int preference = actionPreference[action];

    Affection += preference;

    string message = action switch
    {
      ActionType.Play => "앵무새가 신나게 움직입니다.",
      ActionType.Hug => "앵무새가 날개를 퍼덕입니다.",
      ActionType.Feed => "앵무새가 즐겁게 먹이를 먹습니다.",
      ActionType.Talk => "앵무새가 반응하며 소리를 냅니다.",
      ActionType.Observe => "앵무새가 심심해 보입니다.",
      ActionType.Rest => "앵무새가 횃대에서 쉽니다.",
      _ => ""
    };

    Console.WriteLine(message);

    ClampStats();
  }
}