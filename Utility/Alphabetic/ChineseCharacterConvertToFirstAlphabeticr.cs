using System.Text;

namespace RMS.Utility
{
    /// <summary>
    /// ����ת����ĸ������.
    /// </summary>
    public class ChineseCharacterConvertToFirstAlphabetic
    {
        /// <summary>
        /// ȡ���ֵ�����ĸ.
        /// </summary>
        /// <param name="chineseCharacters">���ִ�.</param>
        /// <returns>����ÿ����������ĸ.</returns>
        public string GetFirstLetter(string chineseCharacters)
        {
            chineseCharacters.NotNullOrEmptyOrSpaceWhite("chineseCharacters");
            string ls_second_eng = "CJWGNSPGCGNESYPBTYYZDXYKYGTDJNNJQMBSGZSCYJSYYQPGKBZGYCYWJKGKLJSWKPJQHYTWDDZLSGMRYPYWWCCKZNKYDGTTNGJEYKKZYTCJNMCYLQLYPYQFQRPZSLWBTGKJFYXJWZLTBNCXJJJJZXDTTSQZYCDXXHGCKBPHFFSSWYBGMXLPBYLLLHLXSPZMYJHSOJNGHDZQYKLGJHSGQZHXQGKEZZWYSCSCJXYEYXADZPMDSSMZJZQJYZCDJZWQJBDZBXGZNZCPWHKXHQKMWFBPBYDTJZZKQHYLYGXFPTYJYYZPSZLFCHMQSHGMXXSXJJSDCSBBQBEFSJYHWWGZKPYLQBGLDLCCTNMAYDDKSSNGYCSGXLYZAYBNPTSDKDYLHGYMYLCXPYCJNDQJWXQXFYYFJLEJBZRXCCQWQQSBNKYMGPLBMJRQCFLNYMYQMSQTRBCJTHZTQFRXQ" +
         "HXMJJCJLXQGJMSHZKBSWYEMYLTXFSYDSGLYCJQXSJNQBSCTYHBFTDCYZDJWYGHQFRXWCKQKXEBPTLPXJZSRMEBWHJLBJSLYYSMDXLCLQKXLHXJRZJMFQHXHWYWSBHTRXXGLHQHFNMNYKLDYXZPWLGGTMTCFPAJJZYLJTYANJGBJPLQGDZYQYAXBKYSECJSZNSLYZHZXLZCGHPXZHZNYTDSBCJKDLZAYFMYDLEBBGQYZKXGLDNDNYSKJSHDLYXBCGHXYPKDJMMZNGMMCLGWZSZXZJFZNMLZZTHCSYDBDLLSCDDNLKJYKJSYCJLKOHQASDKNHCSGANHDAASHTCPLCPQYBSDMPJLPCJOQLCDHJJYSPRCHNWJNLHLYYQYYWZPTCZGWWMZFFJQQQQYXACLBHKDJXDGMMYDJXZLLSYGXGKJRYWZWYCLZMSSJZLDBYDCFCXYHLXCHYZJQSFQAGMNYXPFRKSSB" +
         "JLYXYSYGLNSCMHCWWMNZJJLXXHCHSYDSTTXRYCYXBYHCSMXJSZNPWGPXXTAYBGAJCXLYSDCCWZOCWKCCSBNHCPDYZNFCYYTYCKXKYBSQKKYTQQXFCWCHCYKELZQBSQYJQCCLMTHSYWHMKTLKJLYCXWHEQQHTQHZPQSQSCFYMMDMGBWHWLGSSLYSDLMLXPTHMJHWLJZYHZJXHTXJLHXRSWLWZJCBXMHZQXSDZPMGFCSGLSXYMJSHXPJXWMYQKSMYPLRTHBXFTPMHYXLCHLHLZYLXGSSSSTCLSLDCLRPBHZHXYYFHBBGDMYCNQQWLQHJJZYWJZYEJJDHPBLQXTQKWHLCHQXAGTLXLJXMSLXHTZKZJECXJCJNMFBYCSFYWYBJZGNYSDZSQYRSLJPCLPWXSDWEJBJCBCNAYTWGMPAPCLYQPCLZXSBNMSGGFNZJJBZSFZYNDXHPLQKZCZWALSBCCJXJYZGWKYP" +
         "SGXFZFCDKHJGXDLQFSGDSLQWZKXTMHSBGZMJZRGLYJBPMLMSXLZJQQHZYJCZYDJWBMJKLDDPMJEGXYHYLXHLQYQHKYCWCJMYYXNATJHYCCXZPCQLBZWWYTWBQCMLPMYRJCCCXFPZNZZLJPLXXYZTZLGDLDCKLYRZZGQTGJHHHJLJAXFGFJZSLCFDQZLCLGJDJCSNCLLJPJQDCCLCJXMYZFTSXGCGSBRZXJQQCTZHGYQTJQQLZXJYLYLBCYAMCSTYLPDJBYREGKLZYZHLYSZQLZNWCZCLLWJQJJJKDGJZOLBBZPPGLGHTGZXYGHZMYCNQSYCYHBHGXKAMTXYXNBSKYZZGJZLQJDFCJXDYGJQJJPMGWGJJJPKQSBGBMMCJSSCLPQPDXCDYYKYFCJDDYYGYWRHJRTGZNYQLDKLJSZZGZQZJGDYKSHPZMTLCPWNJAFYZDJCNMWESCYGLBTZCGMSSLLYXQSXSBSJS" +
         "BBSGGHFJLWPMZJNLYYWDQSHZXTYYWHMCYHYWDBXBTLMSYYYFSXJCSDXXLHJHFSSXZQHFZMZCZTQCXZXRTTDJHNNYZQQMNQDMMGYYDXMJGDHCDYZBFFALLZTDLTFXMXQZDNGWQDBDCZJDXBZGSQQDDJCMBKZFFXMKDMDSYYSZCMLJDSYNSPRSKMKMPCKLGDBQTFZSWTFGGLYPLLJZHGJJGYPZLTCSMCNBTJBQFKTHBYZGKPBBYMTTSSXTBNPDKLEYCJNYCDYKZDDHQHSDZSCTARLLTKZLGECLLKJLQJAQNBDKKGHPJTZQKSECSHALQFMMGJNLYJBBTMLYZXDCJPLDLPCQDHZYCBZSCZBZMSLJFLKRZJSNFRGJHXPDHYJYBZGDLQCSEZGXLBLGYXTWMABCHECMWYJYZLLJJYHLGBDJLSLYGKDZPZXJYYZLWCXSZFGWYYDLYHCLJSCMBJHBLYZLYCBLYDPDQYSXQZB" +
         "YTDKYXJYYCNRJMDJGKLCLJBCTBJDDBBLBLCZQRPXJCGLZCSHLTOLJNMDDDLNGKAQHQHJGYKHEZNMSHRPHQQJCHGMFPRXHJGDYCHGHLYRZQLCYQJNZSQTKQJYMSZSWLCFQQQXYFGGYPTQWLMCRNFKKFSYYLQBMQAMMMYXCTPSHCPTXXZZSMPHPSHMCLMLDQFYQXSZYJDJJZZHQPDSZGLSTJBCKBXYQZJSGPSXQZQZRQTBDKYXZKHHGFLBCSMDLDGDZDBLZYYCXNNCSYBZBFGLZZXSWMSCCMQNJQSBDQSJTXXMBLTXZCLZSHZCXRQJGJYLXZFJPHYMZQQYDFQJJLZZNZJCDGZYGCTXMZYSCTLKPHTXHTLBJXJLXSCDQXCBBTJFQZFSLTJBTKQBXXJJLJCHCZDBZJDCZJDCPRNPQCJPFCZLCLZXZDMXMPHJSGZGSZZQJYLWTJPFSYASMCJBTZKYCWMYTCSJJLJCQLWZM" +
         "ALBXYFBPNLSFHTGJWEJJXXGLLJSTGSHJQLZFKCGNNDSZFDEQFHBSAQTGLLBXMMYGSZLDYDQMJJRGBJTKGDHGKBLQKBDMBYLXWCXYTTYBKMRTJZXQJBHLMHMJJZMQASLDCYXYQDLQCAFYWYXQHZ";

            string ls_second_ch = "ءآأؤإئابةتثجحخدذرزسشصضطظعغػؼؽ" +
         "ؾؿ������������������������������������������������������������������������������������������������������������������������������١٢٣٤٥٦٧٨٩٪٫٬٭ٮٯٰٱٲٳٴٵٶٷٸٹٺٻټٽپٿ������������������������������������������������������������������������������������������������������������������������������ڡڢڣڤڥڦڧڨکڪګڬڭڮگڰڱڲڳڴڵڶڷڸڹںڻڼڽھڿ����������������������������������������������������������������������������������" +
         "��������������������������������������������ۣۡۢۤۥۦۧۨ۩۪ۭ۫۬ۮۯ۰۱۲۳۴۵۶۷۸۹ۺۻۼ۽۾ۿ������������������������������������������������������������������������������������������������������������������������������ܡܢܣܤܥܦܧܨܩܪܫܬܭܮܯܱܴܷܸܹܻܼܾܰܲܳܵܶܺܽܿ������������������������������������������������������������������������������������������������������������������������������ݡݢݣݤݥݦݧݨݩݪݫݬݭݮݯݰݱݲݳݴݵݶ" +
         "ݷݸݹݺݻݼݽݾݿ������������������������������������������������������������������������������������������������������������������������������ޡޢޣޤޥަާިީުޫެޭޮޯްޱ޲޳޴޵޶޷޸޹޺޻޼޽޾޿������������������������������������������������������������������������������������������������������������������������������ߡߢߣߤߥߦߧߨߩߪ߲߫߬߭߮߯߰߱߳ߴߵ߶߷߸߹ߺ߻߼߽߾߿������������������������������������������������������������������������" +
         "�����������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������" +
         "����������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������" +
         "���������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������" +
         "������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������" +
         "�����������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������" +
         "��������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������" +
         "���������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������" +
         "������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������" +
         "��������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������" +
         "������������������������������������������������������������������������������������������������������������������������������������������������������������������������������";

            string firstAlphabetic = string.Empty;
            byte[] chineseCharacter = new byte[2];

            for (int i = 0; i < chineseCharacters.Length; i++)
            {
                chineseCharacter = Encoding.Default.GetBytes(chineseCharacters[i].ToString());

                // �Ǻ���
                if (chineseCharacter[0] < 176)
                {
                    firstAlphabetic += chineseCharacter[i];
                }
                // һ������
                else if (chineseCharacter[0] >= 176 && chineseCharacter[0] <= 215)
                {
                    if (chineseCharacters[i].ToString().CompareTo("��") >= 0)
                        firstAlphabetic += "z";
                    else if (chineseCharacters[i].ToString().CompareTo("ѹ") >= 0)
                        firstAlphabetic += "y";
                    else if (chineseCharacters[i].ToString().CompareTo("��") >= 0)
                        firstAlphabetic += "x";
                    else if (chineseCharacters[i].ToString().CompareTo("��") >= 0)
                        firstAlphabetic += "w";
                    else if (chineseCharacters[i].ToString().CompareTo("��") >= 0)
                        firstAlphabetic += "t";
                    else if (chineseCharacters[i].ToString().CompareTo("��") >= 0)
                        firstAlphabetic += "s";
                    else if (chineseCharacters[i].ToString().CompareTo("Ȼ") >= 0)
                        firstAlphabetic += "r";
                    else if (chineseCharacters[i].ToString().CompareTo("��") >= 0)
                        firstAlphabetic += "q";
                    else if (chineseCharacters[i].ToString().CompareTo("ž") >= 0)
                        firstAlphabetic += "p";
                    else if (chineseCharacters[i].ToString().CompareTo("Ŷ") >= 0)
                        firstAlphabetic += "o";
                    else if (chineseCharacters[i].ToString().CompareTo("��") >= 0)
                        firstAlphabetic += "n";
                    else if (chineseCharacters[i].ToString().CompareTo("��") >= 0)
                        firstAlphabetic += "m";
                    else if (chineseCharacters[i].ToString().CompareTo("��") >= 0)
                        firstAlphabetic += "l";
                    else if (chineseCharacters[i].ToString().CompareTo("��") >= 0)
                        firstAlphabetic += "k";
                    else if (chineseCharacters[i].ToString().CompareTo("��") >= 0)
                        firstAlphabetic += "j";
                    else if (chineseCharacters[i].ToString().CompareTo("��") >= 0)
                        firstAlphabetic += "h";
                    else if (chineseCharacters[i].ToString().CompareTo("��") >= 0)
                        firstAlphabetic += "g";
                    else if (chineseCharacters[i].ToString().CompareTo("��") >= 0)
                        firstAlphabetic += "f";
                    else if (chineseCharacters[i].ToString().CompareTo("��") >= 0)
                        firstAlphabetic += "e";
                    else if (chineseCharacters[i].ToString().CompareTo("��") >= 0)
                        firstAlphabetic += "d";
                    else if (chineseCharacters[i].ToString().CompareTo("��") >= 0)
                        firstAlphabetic += "c";
                    else if (chineseCharacters[i].ToString().CompareTo("��") >= 0)
                        firstAlphabetic += "b";
                    else if (chineseCharacters[i].ToString().CompareTo("��") >= 0)
                        firstAlphabetic += "a";
                }
                // ��������.
                else if (chineseCharacter[0] >= 215)
                {
                    firstAlphabetic += ls_second_eng.Substring(ls_second_ch.IndexOf(chineseCharacters[i].ToString(), 0), 1);
                }
            }
            return firstAlphabetic.ToUpper();
        }

        /// <summary>
        /// ȡ����ƴ��������ĸ.
        /// </summary>
        /// <param name="chineseCharacters">���ִ�.</param>
        /// <returns>����������ĸ.</returns>
        public static string GetFirstAlphabetic(string chineseCharacters)
        {
            chineseCharacters.NotNullOrEmptyOrSpaceWhite("chineseCharacters");
            int i = 0;
            ushort key = 0;
            string result = string.Empty;

            Encoding unicode = Encoding.Unicode;
            Encoding gbk = Encoding.GetEncoding(936);
            byte[] unicodeBytes = unicode.GetBytes(chineseCharacters);
            byte[] gbkBytes = Encoding.Convert(unicode, gbk, unicodeBytes);
            while (i < gbkBytes.Length)
            {
                if (gbkBytes[i] <= 127)
                { 
                    result = result + (char)gbkBytes[i];
                    i++;
                }
                #region ���ɺ���ƴ������,ȡƴ������ĸ
                else
                {
                    key = (ushort)(gbkBytes[i] * 256 + gbkBytes[i + 1]);
                    if (key >= '\uB0A1' && key <= '\uB0C4')
                    {
                        result = result + "A";
                    }
                    else if (key >= '\uB0C5' && key <= '\uB2C0')
                    {
                        result = result + "B";
                    }
                    else if (key >= '\uB2C1' && key <= '\uB4ED')
                    {
                        result = result + "C";
                    }
                    else if (key >= '\uB4EE' && key <= '\uB6E9')
                    {
                        result = result + "D";
                    }
                    else if (key >= '\uB6EA' && key <= '\uB7A1')
                    {
                        result = result + "E";
                    }
                    else if (key >= '\uB7A2' && key <= '\uB8C0')
                    {
                        result = result + "F";
                    }
                    else if (key >= '\uB8C1' && key <= '\uB9FD')
                    {
                        result = result + "G";
                    }
                    else if (key >= '\uB9FE' && key <= '\uBBF6')
                    {
                        result = result + "H";
                    }
                    else if (key >= '\uBBF7' && key <= '\uBFA5')
                    {
                        result = result + "J";
                    }
                    else if (key >= '\uBFA6' && key <= '\uC0AB')
                    {
                        result = result + "K";
                    }
                    else if (key >= '\uC0AC' && key <= '\uC2E7')
                    {
                        result = result + "L";
                    }
                    else if (key >= '\uC2E8' && key <= '\uC4C2')
                    {
                        result = result + "M";
                    }
                    else if (key >= '\uC4C3' && key <= '\uC5B5')
                    {
                        result = result + "N";
                    }
                    else if (key >= '\uC5B6' && key <= '\uC5BD')
                    {
                        result = result + "O";
                    }
                    else if (key >= '\uC5BE' && key <= '\uC6D9')
                    {
                        result = result + "P";
                    }
                    else if (key >= '\uC6DA' && key <= '\uC8BA')
                    {
                        result = result + "Q";
                    }
                    else if (key >= '\uC8BB' && key <= '\uC8F5')
                    {
                        result = result + "R";
                    }
                    else if (key >= '\uC8F6' && key <= '\uCBF9')
                    {
                        result = result + "S";
                    }
                    else if (key >= '\uCBFA' && key <= '\uCDD9')
                    {
                        result = result + "T";
                    }
                    else if (key >= '\uCDDA' && key <= '\uCEF3')
                    {
                        result = result + "W";
                    }
                    else if (key >= '\uCEF4' && key <= '\uD188')
                    {
                        result = result + "X";
                    }
                    else if (key >= '\uD1B9' && key <= '\uD4D0')
                    {
                        result = result + "Y";
                    }
                    else if (key >= '\uD4D1' && key <= '\uD7F9')
                    {
                        result = result + "Z";
                    }
                    else
                    {
                        result = result + "?";
                    }
                    i = i + 2;
                }
                #endregion
            }

            return result;
        }
    }
}