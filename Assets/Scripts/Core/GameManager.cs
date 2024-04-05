using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    //상태 관련 -----------------------------------------------------------------------------------------------------

    /// <summary>
    /// 현재 게임 상태
    /// </summary>
    public enum GameState
    {
        Ready,      // 게임 시작 전
        Play,       // 첫 번째 셀이 열리거나 깃발이 설치된 후
        GameClear,  // 모든 지회를 찾았을 때
        GameOver    // 지뢰가 있는 셀을 열었을 때
    }

    GameState state = GameState.Ready;

    /// <summary>
    /// 상태 확인/변경용 프로퍼티
    /// </summary>
    GameState State
    {
        get => state;
        set
        {
            if (state != value)
            {
                state = value;
                switch (state)
                {
                    case GameState.Ready:
                        onGameReady?.Invoke();
                        break;
                    case GameState.Play:
                        onGamePlay?.Invoke();
                        break; 
                    case GameState.GameClear:
                        onGameClear?.Invoke();
                        break; 
                    case GameState.GameOver:
                        onGameOver?.Invoke();
                        break;
                }
            }
        }
    }

    //상태 변경 알림용 액션 - 프로퍼티
    public Action onGameReady;
    public Action onGamePlay;
    public Action onGameClear;
    public Action onGameOver;

    //깃발 관련 -----------------------------------------------------------------------------------------------------

    ///깃발 개수
    int flagCount = 0;

    public int FlagCount
    {
        get => flagCount; 
        private set
        {
            if(flagCount != value)
            {
                flagCount = value;
                onFlagCountChange?.Invoke(flagCount);   //델리게이트로 변경된 값 알리기
            }
        }
    }

    public Action<int> onFlagCountChange;

    //----------------------------------------------------------------------------------

#if UNITY_EDITOR
    public void TestFlagCounter(int a)
    {
        FlagCount = a;
    }

    public void Test_StateChange(GameState state)
    {
        State = state;
    }
#endif
}
