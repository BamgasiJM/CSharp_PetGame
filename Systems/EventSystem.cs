// ======================================================
// File Tree
// PetGame/
// └ Systems/
//    └ EventSystem.cs
// ======================================================

namespace PetGame.Systems;

public static class EventSystem
{
  private static readonly Random random = new();

  public static void RandomEvent()
  {
    int value = random.Next(0, 5);

    switch (value)
    {
      case 0:
        Console.WriteLine("창밖에서 새소리가 들립니다.");
        break;

      case 1:
        Console.WriteLine("펫이 졸린 듯 하품합니다.");
        break;

      case 2:
        Console.WriteLine("오늘은 유난히 기분이 좋아 보입니다.");
        break;

      case 3:
        Console.WriteLine("잠시 주변을 두리번거립니다.");
        break;

      default:
        break;
    }
  }
}