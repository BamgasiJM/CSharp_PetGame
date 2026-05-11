// ======================================================
// File Tree
// PetGame/
// └ Pets/
//    └ Cat.cs
// ======================================================

using PetGame.Core;

namespace PetGame.Pets;

public class Cat : Pet
{
  public Cat()
  {
    // collection initializer
    actionPreference = new()
        {
            { ActionType.Feed, 10 },
            { ActionType.Play, 15 },
            { ActionType.Hug, -10 },
            { ActionType.Talk, 5 },
            { ActionType.Observe, 10 },
            { ActionType.Rest, 5 }
        };
  }

  public override void React(ActionType action)
  {
    ApplyBasicAction(action);

    // 행동 선호도 적용
    Affection += actionPreference[action];

    // switch expression 사용
    string message = action switch
    {
      ActionType.Feed => "고양이가 기분 좋게 먹이를 먹습니다.",
      ActionType.Play => "고양이가 신나게 뛰어다닙니다.",
      ActionType.Hug => "고양이가 안기는 것을 싫어합니다.",
      ActionType.Talk => "고양이가 천천히 꼬리를 흔듭니다.",
      ActionType.Observe => "고양이가 편안해 보입니다.",
      ActionType.Rest => "고양이가 조용히 휴식합니다.",
      _ => ""
    };

    Console.WriteLine(message);

    ClampStats();
  }
}