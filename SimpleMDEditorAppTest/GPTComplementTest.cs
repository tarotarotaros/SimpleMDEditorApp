using SimpleMDEditorApp;
using SimpleMDEditorApp.AI;
using System.Diagnostics;

namespace SimpleMDEditorAppTest
{
    public class GPTComplementTest
    {
        [Fact]
        public void TalkTest()
        {
            var gptComplement = new GPTComplement();

            var inputMessegeTextList = new List<string>()
            {
                "## はじめに",
                "SwiftUIは標準でいい感じにしてくれる一方、業務では厳格な余白（Padding）や間隔（Spacing）が求められることが多いです。",
                "本記事ではSwiftUIを使ったデザインの実装時に気をつけるべきことを紹介します。",
                "",
                "## 対象読者"
            };

            var inputMessegeText = string.Join("\n", inputMessegeTextList);

            var result = gptComplement.TalkAsync(inputMessegeText);
            Debug.WriteLine(result.Result);
        }
    }
}