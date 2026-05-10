// ======================================================
// File Tree
// PetGame/
// └ Core/
//    └ GameTime.cs
// ======================================================

namespace PetGame.Core;

public class GameTime
{
  public int Hour { get; private set; } = 9;

  public void AdvanceHour()
  {
    Hour++;
  }

  public bool IsNight()
  {
    return Hour >= 21;
  }

  public void PrintTime()
  {
    Console.WriteLine();
    Console.WriteLine($"===== 현재 시간 : {Hour}:00 =====");
  }
}