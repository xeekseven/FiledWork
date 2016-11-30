using System;
using System.Linq;
using System.Text;
using System.Drawing;

namespace IOCore.Params
{
    /// <summary>
    /// LED参数
    /// </summary>
    public class LedArg
    {
        /// <summary>
        /// 动画方式
        /// </summary>
        public MoveAction MoveActionArg
        {
            get;
            set;
        }

        /// <summary>
        /// 停留方式
        /// </summary>
        public StopWay StopWayArg
        {
            get;
            set;
        }

        /// <summary>
        /// 移动速度和级别
        /// </summary>
        public MoveSpeed MoveSpeedArg
        {
            get;
            set;
        }

        /// <summary>
        /// 页面停留时间
        /// </summary>
        public StopTime StopTimeArg
        {
            get;
            set;
        }

        /// <summary>
        /// 字体
        /// </summary>
        public Font FontArg
        {
            get;
            set;
        }

        /// <summary>
        /// 字体颜色
        /// </summary>
        public FontColor FontColorArg
        {
            get;
            set;
        }

        /// <summary>
        /// 内容类型
        /// </summary>
        public ContentType ContentTypeArg
        {
            get;
            set;
        }

        /// <summary>
        /// 分区号
        /// </summary>
        public Partition PartitionArg
        {
            get;
            set;
        }

        /// <summary>
        /// 位图参数
        /// </summary>
        public BitmapArg BitmapArg
        {
            get;
            set;
        }
    }
}
