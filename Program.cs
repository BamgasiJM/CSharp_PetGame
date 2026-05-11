// ======================================================
// File Tree
// PetGame/
// └ Program.cs
// ======================================================

using PetGame.Core;

namespace PetGame;

internal class Program
{
  static void Main(string[] args)
  {
    Console.OutputEncoding = System.Text.Encoding.UTF8;

    GameManager game = new();
    game.Run();
  }
}

/* 전체 프로젝트 구조
PetGame/
│
├ Program.cs
│
├ Core/
│   ├ GameManager.cs
│   └ GameEnums.cs
│
├ Pets/
│   ├ IPet.cs
│   ├ Pet.cs
│   ├ Cat.cs
│   ├ Lizard.cs
│   └ Parrot.cs
│
└ Systems/
    └ InputHandler.cs
*/