using System.Collections.Generic;

namespace SimpleMDEditorApp.Editor
{
    public class UndoRedoManager
    {
        private readonly Stack<string> undoStack = new Stack<string>(); // Undo用のスタック
        private readonly Stack<string> redoStack = new Stack<string>(); // Redo用のスタック
        private const int MaxHistoryCount = 5; // 最大履歴数
        private bool isOperationInProgress = false; // Undo/Redo操作中かを示すフラグ

        public bool CanUndo => undoStack.Count > 1; // Undo可能か
        public bool CanRedo => redoStack.Count > 0; // Redo可能か

        public UndoRedoManager()
        {
            undoStack.Push(""); // 初期状態をスタックに追加
        }

        // 履歴を追加する
        public void AddState(string state)
        {
            if (isOperationInProgress) return; // Undo/Redo中は履歴を追加しない

            if (undoStack.Count >= MaxHistoryCount)
            {
                RemoveOldestState(); // 最古の履歴を削除
            }

            undoStack.Push(state); // 最新の状態を追加
            redoStack.Clear(); // 新しい操作でRedo履歴をクリア
        }

        private void RemoveOldestState()
        {
            var tempStack = new Stack<string>();
            while (undoStack.Count > 1)
            {
                tempStack.Push(undoStack.Pop());
            }

            undoStack.Pop(); // 最古の要素を削除

            while (tempStack.Count > 0)
            {
                undoStack.Push(tempStack.Pop());
            }
        }

        // Undo操作
        public string Undo(string currentState)
        {
            if (!CanUndo) return undoStack.Peek(); // Undoができない場合は現在の状態を返す

            isOperationInProgress = true;
            redoStack.Push(currentState); // 現在の状態をRedoスタックに移動
            string previousState = undoStack.Pop(); // Undo履歴の現在の状態を削除
            isOperationInProgress = false;

            return previousState; // 次の状態を取得
        }

        // Redo操作
        public string Redo()
        {
            if (!CanRedo) return null; // Redoができない場合はnullを返す

            isOperationInProgress = true;
            string redoState = redoStack.Pop(); // Redoスタックから状態を取得
            undoStack.Push(redoState); // Redoした状態をUndo履歴に戻す
            isOperationInProgress = false;

            return redoState;
        }
    }

}
