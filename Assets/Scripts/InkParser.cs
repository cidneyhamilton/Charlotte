using Ink.Runtime;

namespace Charlotte {

    // Parser utilty for Ink scripts
    public static class InkParser {
	
	const char SEPARATOR = ':';
	const string DEFAULT_SPEAKER = "Narrator";

	// Get the speaker from a line of content
	public static string Speaker(string content) {
	    int index = content.IndexOf(SEPARATOR);
	    if (index == -1) {
		return DEFAULT_SPEAKER;
	    } else {
		return content.Substring(0, index);
	    }
	}

	// Get the speech text from a line of content
	public static string Speech(string content) {
	    int index = content.IndexOf(':');
	    if (index == -1) {
		return content;
	    } else {
		return content.Substring(index + 1);
	    }
	}	
    }
}
    
