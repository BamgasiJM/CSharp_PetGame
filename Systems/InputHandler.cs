// ======================================================
// File Tree
// PetGame/
// └ Systems/
//    └ InputHandler.cs
// ======================================================

using PetGame.Core;

namespace PetGame.Systems;

public static class InputHandler
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

      if (string.IsNullOrWhiteSpace(input))
      {
        continue;
      }

      bool success = int.TryParse(input, out int result);

      if (success && Enum.IsDefined(typeof(ActionType), result))
      {
        return (ActionType)result;
      }

      Console.WriteLine("잘못된 입력입니다.");
    }
  }
}