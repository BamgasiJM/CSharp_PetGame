// ======================================================
// File Tree
// PetGame/
// └ Pets/
//    └ Pet.cs
// ======================================================

using PetGame.Core;

namespace PetGame.Pets;

// abstract class
// 공통 로직은 부모 클래스에서 처리한다.
public abstract class Pet : IPet
{
  public string Name { get; set; } = "Unknown";

  public int Affection { get; protected set; } = 50;

  public int Hunger { get; protected set; } = 20;

  public int Stress { get; protected set; } = 10;

  public int Energy { get; protected set; } = 80;

  public int Sleepiness { get; protected set; } = 0;

  // 행동 선호도 저장
  // Dictionary는 key-value 구조를 가진다.
  protected Dictionary<ActionType, int> actionPreference = new();

  // 다형성 핵심
  // 자식 클래스가 반드시 구현해야 한다.
  public abstract void React(ActionType action);

  public virtual void PrintStatus()
  {
    Console.WriteLine();
    Console.WriteLine($"[{Name} 상태]");
    Console.WriteLine($"호감도     : {Affection}");
    Console.WriteLine($"배고픔     : {Hunger}");
    Console.WriteLine($"스트레스   : {Stress}");
    Console.WriteLine($"에너지     : {Energy}");
    Console.WriteLine($"졸림       : {Sleepiness}");
  }

  // 시간 흐름에 따라 자동 변화
  public virtual void PassTime()
  {
    Hunger += 5;
    Stress += 2;
    Sleepiness += 8;

    ClampStats();
  }

  // 능력치 범위 제한
  // 방어적 프로그래밍의 좋은 예시
  protected void ClampStats()
  {
    Affection = Math.Clamp(Affection, 0, 100);
    Hunger = Math.Clamp(Hunger, 0, 100);
    Stress = Math.Clamp(Stress, 0, 100);
    Energy = Math.Clamp(Energy, 0, 100);
    Sleepiness = Math.Clamp(Sleepiness, 0, 100);
  }

  public bool IsSleeping()
  {
    return Sleepiness >= 100 || Energy <= 0;
  }

  // 모든 펫이 공유하는 기본 행동 처리
  protected void ApplyBasicAction(ActionType action)
  {
    switch (action)
    {
      case ActionType.Feed:
        Hunger -= 20;
        Affection += 5;
        break;

      case ActionType.Play:
        Energy -= 15;
        Sleepiness += 10;
        Affection += 5;
        break;

      case ActionType.Hug:
        Affection += 3;
        break;

      case ActionType.Talk:
        Affection += 4;
        break;

      case ActionType.Observe:
        Stress -= 5;
        break;

      case ActionType.Rest:
        Stress -= 10;
        Energy += 10;
        break;
    }

    ClampStats();
  }
}