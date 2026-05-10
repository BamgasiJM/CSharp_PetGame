// ======================================================
// File Tree
// PetGame/
// └ Core/
//    └ GameManager.cs
// ======================================================

using PetGame.Pets;
using PetGame.Systems;
using PetGame.Utils;

namespace PetGame.Core;

public class GameManager
{
  private readonly GameTime gameTime = new();

  private Pet? currentPet;

  public void Run()
  {
    ShowTitle();

    CreatePet();

    GameLoop();

    if (currentPet != null)
    {
      EndingManager.ShowEnding(currentPet);
    }
  }

  private void ShowTitle()
  {
    Console.WriteLine("==================================");
    Console.WriteLine(" Console Pet Raising Game");
    Console.WriteLine("==================================");
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

    Console.Write("펫의 이름을 입력하세요 : ");

    string? name = Console.ReadLine();

    currentPet.Name = string.IsNullOrWhiteSpace(name)
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
      ConsoleHelper.Divider();

      gameTime.PrintTime();

      EventSystem.RandomEvent();

      currentPet.PrintStatus();

      ActionType action = InputSystem.GetAction();

      Console.WriteLine();

      currentPet.React(action);

      currentPet.PassTime();

      // 게임 종료 조건
      if (currentPet.IsSleeping())
      {
        Console.WriteLine();
        Console.WriteLine($"{currentPet.Name}가 잠들었습니다.");
        break;
      }

      if (gameTime.IsNight())
      {
        Console.WriteLine();
        Console.WriteLine("밤이 되었습니다.");
        break;
      }

      gameTime.AdvanceHour();
    }
  }
}