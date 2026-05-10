// ======================================================
// File Tree
// PetGame/
// └ Core/
//    └ EndingManager.cs
// ======================================================

using PetGame.Pets;

namespace PetGame.Core;

public static class EndingManager
{
  public static void ShowEnding(Pet pet)
  {
    Console.WriteLine();
    Console.WriteLine("===== 게임 종료 =====");

    Console.WriteLine($"{pet.Name}의 최종 호감도 : {pet.Affection}");

    string ending = pet.Affection switch
    {
      >= 80 => "최고의 친구가 되었습니다.",
      >= 60 => "꽤 가까운 사이가 되었습니다.",
      >= 40 => "무난한 하루였습니다.",
      >= 20 => "아직 조금 어색합니다.",
      _ => "경계하는 상태로 끝났습니다."
    };

    Console.WriteLine(ending);
  }
}