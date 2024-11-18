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
                "## �͂��߂�",
                "SwiftUI�͕W���ł��������ɂ��Ă�������A�Ɩ��ł͌��i�ȗ]���iPadding�j��Ԋu�iSpacing�j�����߂��邱�Ƃ������ł��B",
                "�{�L���ł�SwiftUI���g�����f�U�C���̎������ɋC������ׂ����Ƃ��Љ�܂��B",
                "",
                "## �Ώۓǎ�"
            };

            var inputMessegeText = string.Join("\n", inputMessegeTextList);

            var result = gptComplement.TalkAsync(inputMessegeText);
            Debug.WriteLine(result.Result);
        }
    }
}