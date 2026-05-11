// ======================================================
// File Tree
// PetGame/
// └ Pets/
//    └ IPet.cs
// ======================================================

using PetGame.Core;

namespace PetGame.Pets;

// 인터페이스는 "무엇을 할 수 있는가"를 정의한다.
// 모든 펫은 아래 기능들을 반드시 구현해야 한다.
public interface IPet
{
  void React(ActionType action);

  void PrintStatus();

  void PassTime();

  bool IsSleeping();
}