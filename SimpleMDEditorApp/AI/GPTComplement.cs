using OpenAI.Chat;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleMDEditorApp.AI
{

    public class GPTComplement
    {
        private readonly ChatClient _client;
        private List<ChatMessage> _messageHistory;

        public GPTResult Result { get; private set; }

        List<string> SYSTEM_MESSAGE_TEXT_LIST = new List<string>()
            {
                " -あなたは文章を予測する天才です。",
                " -これから入力されるマークダウン形式の文字列に続く文字列を予測して教えてください。",
                " -回答にあたってはその差分のみ回答してください。",
                "",
                "例えば",
                "",
                "# ハンバーグの作り方",
                "",
                "## 材料",
                "",
                "と入力された場合は",
                "",
                "- 合びき肉",
                " - 玉ねぎ",
                " - サラダ油",
                " - パン粉",
                " - 牛乳",
                " - おろしにんにく",
                " - 塩",
                " - 砂糖",
                " - こしょう",
                "",
                "",
                "と出力してください。",
                "",
                " -回答の際はすべてが英語であれば英語で回答してください。すくなくとも１単語以上日本語が存在している場合は日本語で回答してください。"
            };
        public GPTComplement()
        {
            _client = new ChatClient("gpt-4o", "APIKey");
            _messageHistory = new List<ChatMessage>();
            var systemMessageText = string.Join("\n", SYSTEM_MESSAGE_TEXT_LIST);
            _messageHistory.Add(new SystemChatMessage(systemMessageText));

            Result = new GPTResult(GptResultType.Empty, string.Empty);
        }

        public async Task<string> TalkAsync(string input)
        {
            // 入力を履歴に追加
            _messageHistory.Add(new UserChatMessage(input));

            // 非同期でチャットを完了
            var result = await _client.CompleteChatAsync(_messageHistory);

            // 結果メッセージを取得
            var resultMessage = result.Value.Content[0].Text;

            // 結果を履歴に追加
            _messageHistory.Add(resultMessage);

            // 結果を返す
            return resultMessage;
        }

        public async Task TalkAsyncForSingle(string input)
        {
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
