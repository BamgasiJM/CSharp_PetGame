// ======================================================
// File Tree
// PetGame/
// └ Systems/
//    └ InputSystem.cs
// ======================================================

namespace PetGame.Systems;

public static class InputSystem
{
  public static ActionType GetAction()
  {
    while (true)
    {
      Console.WriteLine();
      Console.WriteLine("무엇을 할까요?");
      Console.WriteLine("1. 먹이주기");
      Console.WriteLine("2. 놀아주기");
      Console.WriteLine("3. 안아주기");
      Console.WriteLine("4. 말걸기");
      Console.WriteLine("5. 관찰하기");
      Console.WriteLine("6. 쉬게하기");

      Console.Write("> ");

      string? input = Console.ReadLine();

      // nullable 방어
      if (string.IsNullOrWhiteSpace(input))
      {
        continue;
      }

      bool success = int.TryParse(input, out int number);

      if (success && Enum.IsDefined(typeof(ActionType), number))
      {
        return (ActionType)number;
      }

      Console.WriteLine("잘못된 입력입니다.");
    }
  }
}