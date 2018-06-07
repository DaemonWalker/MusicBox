using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MusicBox.Models
{
    /// <summary>
    /// /Player/Play 页面歌曲信息展示Model
    /// </summary>
    [DataContract]
    public class SongModel
    {
        /// <summary>
        /// 序号
        /// </summary>
        [DataMember]
        public string Index { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// 艺术家
        /// </summary>
        [DataMember]
        public string Artist { get; set; }

        /// <summary>
        /// 专辑
        /// </summary>
        [DataMember]
        public string Album { get; set; }

        /// <summary>
        /// 歌曲时长
        /// </summary>
        [DataMember]
        public string Length { get; set; }

        /// <summary>
        /// 热度
        /// </summary>
        [DataMember]
        public int Hot { get; set; }

        [DataMember]
        public int SongID { get; set; }

        [DataMember]
        public int AlbumID { get; set; }

        [DataMember]
        public string FilePath { get; set; }
    }
}
