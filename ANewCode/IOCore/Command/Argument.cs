using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * byte[32]{
			0x01, 0x00, 0x0D, 0x00, 
			0x13, 0x03, 0x00, 0x00, 
			0x00, 0x00, 0x00, 0x00, 
			0x00, 0x00, 0x00, 0x00, 
			0x00, 0x00, 0x00, 0x00, 
			0x00, 0x00, 0x00, 0x00, 
			0x01, 0x01, 0x00, 0x00, 
			0x00, 0x00, 0x00, 0x00
		};
*/
namespace IOCore.Command
{
    /// <summary>
    /// 32字节指令参数
    /// </summary>
    internal class Argument
    {
        private byte[] argument = new byte[32]{
			0x00, 0x00, 0x00, 0x00, 
			0x00, 0x00, 0x00, 0x00, 
			0x00, 0x00, 0x00, 0x00, 
			0x00, 0x00, 0x00, 0x00, 
			0x00, 0x00, 0x00, 0x00, 
			0x00, 0x00, 0x00, 0x00, 
			0x00, 0x00, 0x00, 0x00, 
			0x00, 0x00, 0x00, 0x00
        };

        /// <summary>
        /// 设置屏幕显示顺序
        /// </summary>
        public int IPingIndex
        {
            set
            {
                argument[0] = Convert.ToByte(value & 0x00ff);
                argument[1] = Convert.ToByte(value >> 8 & 0x00ff);
            }
        }

        /// <summary>
        /// 设置动画方式
        /// </summary>
        public MoveAction EMoveAction
        {
            set
            {
                argument[2] = Convert.ToByte(value);
            }
        }

        /// <summary>
        /// 设置停留方式
        /// </summary>
        public StopWay EStopWay
        {
            set
            {
                argument[3] = Convert.ToByte(value);
            }
        }

        /// <summary>
        /// 设置移动速度和级别
        /// </summary>
        public MoveSpeed EMoveSpeed
        {
            set
            {
                argument[4] = Convert.ToByte(value);
            }
        }

        /// <summary>
        /// 设置页面停留时间
        /// </summary>
        public StopTime EStopTime
        {
            set
            {
                argument[5] = Convert.ToByte(value);
            }
        }

        /// <summary>
        /// 设置文字颜色
        /// </summary>
        public FontColor EFontColor
        {
            set
            {
                argument[24] = Convert.ToByte(value);
            }
        }

        /// <summary>
        /// 设置内容类型
        /// </summary>
        public ContentType EContentType
        {
            set
            {
                argument[25] = Convert.ToByte(value);
            }
        }

        /// <summary>
        /// 设置分区块
        /// </summary>
        public Partition EPartition
        {
            set
            {
                argument[30] = Convert.ToByte(value);
            }
        }

        /// <summary>
        /// 32字节指令参数编码
        /// </summary>
        public byte[] ArgumentBytes
        {
            get
            {
                return argument;
            }
        }

        /// <summary>
        /// 设置32字节指令参数编码
        /// </summary>
        /// <param name="iPingIndex">屏幕显示顺序</param>
        /// <param name="ledArg">LED参数</param>
        public void SetArgumentBytes(int iPingIndex, Params.LedArg ledArg)
        {
            argument[0] = Convert.ToByte(iPingIndex & 0x00ff);
            argument[1] = Convert.ToByte(iPingIndex >> 8 & 0x00ff);
            argument[2] = Convert.ToByte(ledArg.MoveActionArg);
            argument[3] = Convert.ToByte(ledArg.StopWayArg);
            argument[4] = Convert.ToByte(ledArg.MoveSpeedArg);
            argument[5] = Convert.ToByte(ledArg.StopTimeArg);
            argument[24] = Convert.ToByte(ledArg.FontColorArg);
            argument[25] = Convert.ToByte(ledArg.ContentTypeArg);
            argument[30] = Convert.ToByte(ledArg.PartitionArg);
        }
    }
}
