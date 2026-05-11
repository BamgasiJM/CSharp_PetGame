// ======================================================
// File Tree
// PetGame/
// └ Core/
//    └ GameEnums.cs
// ======================================================

namespace PetGame.Core;

// enum은 문자열보다 안전하고 유지보수가 쉽다.
// 게임 전체에서 공유되는 행동 타입 정의.
public enum ActionType
{
  Feed = 1,
  Play,
  Hug,
  Talk,
  Observe,
  Rest
}