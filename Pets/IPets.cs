// ======================================================
// File Tree
// PetGame/
// └ Pets/
//    └ IPet.cs
// ======================================================

using PetGame.Systems;

namespace PetGame.Pets;

public interface IPet
{
  void React(ActionType action);

  void PrintStatus();

  bool IsSleeping();
}