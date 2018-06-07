using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MusicBox.Models
{
    /// <summary>
    /// 专辑信息实体
    /// </summary>
    [DataContract]
    [Serializable]
    public class AlbumModel
    {
        /// <summary>
        /// 专辑名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 发行时间
        /// </summary>
        [DataMember]
        public string PublishDate { get; set; }

        /// <summary>
        /// 参与艺术家
        /// </summary>
        [DataMember]
        public string Artist { get; set; }

        [DataMember]
        public string CoverPath { get; set; }

        [DataMember]
        public int AlbumID { get; set; }

        [DataMember]
        public bool IsDelete { get; set; } = false;

        [DataMember]
        public bool IsAlter { get; set; } = false;
    }
}
