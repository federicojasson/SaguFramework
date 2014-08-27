using System.Text;

namespace SaguFramework.Managers {
	
	public static partial class UtilityManager {

		static UtilityManager() {
			encoding = new UTF8Encoding(false); // UTF-8 without BOM
		}

	}

}
