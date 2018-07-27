
using Ink.Runtime;

public static class InkParser {

	private static string[] SEPARATORS;

	public static string Speaker(string content) {
		int index = content.IndexOf(':');
		if (index == -1) {
			return "Narrator";
		} else {
			return content.Substring(0, index);
		}
	}

	public static string Speech(string content) {
		int index = content.IndexOf(':');
		if (index == -1) {
			return content;
		} else {
			return content.Substring(index + 1);
		}
	}
				
}
