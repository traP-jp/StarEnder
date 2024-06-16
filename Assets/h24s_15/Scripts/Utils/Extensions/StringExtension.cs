namespace h24s_15.Utils.Extensions {
    public static class StringExtension {
        public static string ToFullNumber(this string value) {
            return value.Replace("1", "１")
                .Replace("2", "２")
                .Replace("3", "３")
                .Replace("4", "４")
                .Replace("5", "５")
                .Replace("6", "６")
                .Replace("7", "７")
                .Replace("8", "８")
                .Replace("9", "９")
                .Replace("0", "０");
        }
    }
}
