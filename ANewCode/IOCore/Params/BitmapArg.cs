using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOCore.Params
{
    /// <summary>
    /// 位图参数
    /// </summary>
    public class BitmapArg
    {
        private int backWidth = 80;
        private int backHeight = 16;
        private int fontWidth = 16;
        private int fontHeight = 16;

        /// <summary>
        /// 背景位图宽
        /// </summary>
        public int BackWidth
        {
            get
            {
                return backWidth;
            }
        }

        /// <summary>
        /// 背景位图高
        /// </summary>
        public int BackHeight
        {
            get
            {
                return backHeight;
            }
        }

        /// <summary>
        /// 字体位图宽
        /// </summary>
        public int FontWidth
        {
            get
            {
                return fontWidth;
            }
        }

        /// <summary>
        /// 字体位图高
        /// </summary>
        public int FontHeight
        {
            get
            {
                return fontHeight;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="backWidth">背景位图宽</param>
        /// <param name="backHeight">背景位图高</param>
        /// <param name="fontWidth">字体位图宽</param>
        /// <param name="fontHeight">字体位图高</param>
        public BitmapArg(int backWidth, int backHeight, int fontWidth, int fontHeight)
        {
            this.backWidth = backWidth;
            this.backHeight = backHeight;
            this.fontWidth = fontWidth;
            this.fontHeight = fontHeight;
        }
    }
}
