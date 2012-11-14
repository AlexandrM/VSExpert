using System;

namespace ASEExpertVS2005
{
	/// <summary>
	/// Summary description for Data.
	/// </summary>
	public class ListItemData
	{
		public string Name = "";
        public int Image = 0;
        public object[] Datas = new object[0];

        public ListItemData(string name, int image, params object[] datas)
        {
            Name = name;
            Datas = datas;
            Image = image;
        }
	}
}
