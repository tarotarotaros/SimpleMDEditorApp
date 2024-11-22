using OpenAI.Chat;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleMDEditorApp.AI
{

    public class GPTComplement
    {
        private readonly ChatClient _client;
        private readonly bool _isNoAapi;
        private List<ChatMessage> _messageHistory;

        public GPTResult Result { get; private set; }

        public GPTComplement(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                _isNoAapi = true;
                return;
            }

            _client = new ChatClient("gpt-4o", apiKey);
            _messageHistory = new List<ChatMessage>();
            _messageHistory.Add(new SystemChatMessage(PromptDef.SYSTEM_MESSAGE_TEXT));

            Result = new GPTResult(GptResultType.Empty, string.Empty);
        }

        public async Task TalkAsyncForSingle(string input)
        {
            if (_isNoAapi) return;

            // 入力を履歴に追加
            _messageHistory.Add(new UserChatMessage(input));

            // 非同期でチャットを完了
            var result = await _client.CompleteChatAsync(_messageHistory);

            // 結果メッセージを取得
            var resultMessage = result.Value.Content[0].Text;

            Result = new GPTResult(GptResultType.Success, resultMessage);

            // 結果を返す
            //return resultMessage;
        }
    }
}
