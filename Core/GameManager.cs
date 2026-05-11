// ======================================================
// File Tree
// PetGame/
// └ Core/
//    └ GameManager.cs
// ======================================================

using PetGame.Pets;
using PetGame.Systems;

namespace PetGame.Core;

public class GameManager
{
  private readonly Random random = new();

  private Pet? currentPet;

  // GameTime 클래스를 따로 만들지 않고
  // 간단하게 시간 변수로 관리
  private int currentHour = 9;

  public void Run()
  {
    ShowTitle();

    CreatePet();

    GameLoop();

    ShowEnding();
  }

  private void ShowTitle()
  {
    Console.WriteLine("=================================");
    Console.WriteLine(" Console Pet Raising Game");
    Console.WriteLine("=================================");
  }

  private void CreatePet()
  {
    Console.WriteLine();
    Console.WriteLine("펫을 선택하세요.");
    Console.WriteLine("1. 고양이");
    Console.WriteLine("2. 도마뱀");
    Console.WriteLine("3. 앵무새");

    while (true)
    {
      Console.Write("> ");

      string? input = Console.ReadLine();

      switch (input)
      {
        case "1":
          currentPet = new Cat();
          break;

        case "2":
          currentPet = new Lizard();
          break;

        case "3":
          currentPet = new Parrot();
          break;
      }

      if (currentPet != null)
      {
        break;
      }

      Console.WriteLine("잘못된 입력입니다.");
    }

    Console.Write("펫 이름을 입력하세요 : ");

    string? name = Console.ReadLine();

    currentPet.Name =
        string.IsNullOrWhiteSpace(name)
        ? "Buddy"
        : name;
  }

  private void GameLoop()
  {
    if (currentPet == null)
    {
      return;
    }

    while (true)
    {
      PrintDivider();

      Console.WriteLine($"현재 시간 : {currentHour}:00");

      RandomEvent();

      currentPet.PrintStatus();

      ActionType action = InputHandler.GetAction();

      Console.WriteLine();

      currentPet.React(action);

      // 시간 경과에 따른 자동 변화
      currentPet.PassTime();

      // 종료 조건
      if (currentPet.IsSleeping())
      {
        Console.WriteLine();
        Console.WriteLine($"{currentPet.Name}가 잠들었습니다.");
        break;
      }

      if (currentHour >= 21)
      {
        Console.WriteLine();
        Console.WriteLine("밤이 되었습니다.");
        break;
      }

      currentHour++;
    }
  }

  private void RandomEvent()
  {
    Console.WriteLine();

    int value = random.Next(0, 5);

    switch (value)
    {
      case 0:
        Console.WriteLine("창밖에서 새소리가 들립니다.");
        break;

      case 1:
        Console.WriteLine("펫이 하품을 합니다.");
        break;

      case 2:
        Console.WriteLine("오늘은 기분이 좋아 보입니다.");
        break;

      case 3:
        Console.WriteLine("잠시 주변을 둘러봅니다.");
        break;

      default:
        break;
    }
  }

  private void ShowEnding()
  {
    if (currentPet == null)
    {
      return;
    }

    PrintDivider();

    Console.WriteLine("게임 종료");
    Console.WriteLine();

    Console.WriteLine($"{currentPet.Name}의 최종 호감도 : {currentPet.Affection}");

    string ending = currentPet.Affection switch
    {
      >= 80 => "최고의 친구가 되었습니다.",
      >= 60 => "꽤 가까운 사이가 되었습니다.",
      >= 40 => "평범한 하루였습니다.",
      >= 20 => "아직 조금 어색합니다.",
      _ => "경계하는 상태로 끝났습니다."
    };

    Console.WriteLine(ending);
  }

  private void PrintDivider()
  {
    Console.WriteLine();
    Console.WriteLine("=================================");
  }
}