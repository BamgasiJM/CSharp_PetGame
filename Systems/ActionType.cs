// ======================================================
// File Tree
// PetGame/
// └ Systems/
//    └ ActionType.cs
// ======================================================

namespace PetGame.Systems;

// enum은 행동 종류를 안전하게 관리할 수 있다.
// 문자열 비교보다 훨씬 안정적이다.
public enum ActionType
{
  Feed = 1,
  Play,
  Hug,
  Talk,
  Observe,
  Rest
}