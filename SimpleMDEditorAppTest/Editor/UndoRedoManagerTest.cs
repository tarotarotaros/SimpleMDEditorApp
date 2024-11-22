
using SimpleMDEditorApp.Editor;

namespace SimpleMDEditorAppTest.Editor
{
    public class UndoRedoManagerTests
    {
        [Fact]
        public void AddState_ShouldAddStateToUndoQueue()
        {
            // Arrange
            var manager = new UndoRedoManager();

            // Act
            manager.AddState("State1");
            manager.AddState("State2");

            // Assert
            Assert.True(manager.CanUndo);
            Assert.False(manager.CanRedo);
        }

        [Fact]
        public void Undo_ShouldReturnPreviousState()
        {
            // Arrange
            var manager = new UndoRedoManager();
            manager.AddState("State1");
            manager.AddState("State2");
            manager.AddState("State3");

            // Act
            var result = manager.Undo("Current");

            // Assert
            Assert.Equal("State3", result); // "State3" が削除され、"State2" が最後の状態になる
            Assert.True(manager.CanRedo);
        }

        [Fact]
        public void Redo_ShouldReturnNextState()
        {
            // Arrange
            var manager = new UndoRedoManager();
            manager.AddState("State1");
            manager.AddState("State2");
            manager.AddState("State3");
            manager.Undo("Current"); // 1回Undo

            // Act
            var result = manager.Redo();

            // Assert
            Assert.False(manager.CanRedo); // Redoスタックは空になる
            Assert.Equal("Current", result); // "State3" がRedoされる
        }

        [Fact]
        public void Undo_ShouldNotExceedUndoQueue()
        {
            // Arrange
            var manager = new UndoRedoManager();
            manager.AddState("State1");
            manager.AddState("State2");

            // Act
            var result = manager.Undo("Current");
            var result2 = manager.Undo(result); // Undo を超えて呼び出す

            // Assert
            Assert.Equal("State2", result);  // 最初のUndoはState1に戻る
            Assert.Equal("State1", result2); // Undoがこれ以上戻れない
        }

        [Fact]
        public void AddState_ShouldLimitToMaxHistoryCount()
        {
            // Arrange
            var manager = new UndoRedoManager();

            // Act
            for (int i = 1; i <= 6; i++)
            {
                manager.AddState($"State{i}");
            }

            // Assert
            Assert.Equal("State6", manager.Undo("Current")); // State1は削除されている
            Assert.True(manager.CanUndo);
        }

        [Fact]
        public void UndoRedo_ShouldWorkTogether()
        {
            // Arrange
            var manager = new UndoRedoManager();
            manager.AddState("State1");
            manager.AddState("State2");
            manager.AddState("State3");

            // Act
            var undoResult1 = manager.Undo("Current"); // Undo to State2
            var undoResult2 = manager.Undo("State3");  // Undo to State1
            var redoResult = manager.Redo();          // Redo to State2

            // Assert
            Assert.Equal("State3", undoResult1);
            Assert.Equal("State2", undoResult2);
            Assert.Equal("State3", redoResult);
        }

        [Fact]
        public void CanUndo_ShouldReturnFalse_WhenNoStates()
        {
            // Arrange
            var manager = new UndoRedoManager();

            // Act & Assert
            Assert.False(manager.CanUndo);
        }

        [Fact]
        public void CanRedo_ShouldReturnFalse_WhenRedoStackIsEmpty()
        {
            // Arrange
            var manager = new UndoRedoManager();
            manager.AddState("State1");

            // Act & Assert
            Assert.False(manager.CanRedo);
        }
    }

}
