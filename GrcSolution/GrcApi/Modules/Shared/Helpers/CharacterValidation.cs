namespace GrcApi.Modules.Shared.Helpers
{
    public class CharacterValidation
    {
        public static bool IsInvalidCharacter(string text)
        {
            //var result = new List<string> { "!", "`", "~", "^", "@", "*", "{", "}", "[", "]", "|", "<", ">", "\\", "_" }.Contains(text);
            var disAllowedCharacters = new List<string> { "!", "`", "~", "^", "@", "*", "{", "}", "[", "]", "|", "<", ">", "\\", "_" };
            var result = disAllowedCharacters.Any(x => text.Contains(x));
            return result ? false : true;
        }

        public static bool IsInvalidUserName(string text)
        {
            //var result = new List<string> { "!", "`", "~", "^", "@", "*", "{", "}", "[", "]", "|", "<", ">", "\\", "_" }.Contains(text);
            var disAllowedCharacters = new List<string> { "!", "~", "^", "*", "{", "}", "[", "]", "|", "<", ">", "\\" };
            var result = disAllowedCharacters.Any(x => text.Contains(x));
            return result ? false : true;
        }
    }
}
