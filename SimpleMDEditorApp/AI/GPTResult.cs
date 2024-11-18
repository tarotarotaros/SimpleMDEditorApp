namespace SimpleMDEditorApp.AI
{
    public class GPTResult
    {
        public GptResultType GptResultType => _gptResultType;
        public string ResultText => _resultText;

        private readonly GptResultType _gptResultType;
        private readonly string _resultText;

        public GPTResult(GptResultType gptResultType, string resultText)
        {
            _gptResultType = gptResultType;
            _resultText = resultText;
        }
    }
}
