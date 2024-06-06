using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace FMPhotoXMLGenerator
{
    public static class Messages
    {
        #region fields
        public const string GenNewXmlSuccess = "生成新 xml 文件成功";
        public const string GenNewXmlFail = "生成新 xml 文件失败";
        public const string AppendIdSuccess = "追加 id 到 xml 文件成功";
        public const string AppendIdFail = "追加 id 到 xml 文件失败";
        public const string GenRemappingXmlSuccess = "生成重新映射的 xml 文件成功";
        public const string GenRemappingXmlFail = "生成重新映射的 xml 文件失败";
        public const string IdOverflow = "id 超过最大值";
        public const string DirectorNotExist = "文件夹不存在";
        public const string IdCountOverflow = "id 数超过上限";
        public const string IdCompareError = "起始 id 大于 终止 id，请修改";
        public const string CopyXmlFileSuccess = "复制 xml 文件成功";
        public const string CopyXmlFileFail = "复制 xml 文件失败";
        
        public const string CollectImagesFail = "收集图片失败";
        public const string GenMappingFail = "生成映射失败";
        public const string RemappingFail = "重新映射失败";
        public const string CreateXmlDocumentFail = "生成 xml 文档失败";
        public const string AppendXmlNodesFail = "添加 xml 节点失败";
        public const string WriteXmlFileFail = "写入 xml 文件失败";
        public const string ParseMappingFail = "解析映射失败，请检查 xml 文件内的 id 号的相关格式是否正确";
        public const string NoDiffIdWhenAppend = "要追加的 id 均已经存在于 xml 中";
        public const string GetListNodeFail = "没有找到正确的 xml node，请检查 xml 文件格式";
        public const string NoConfigInExeDirector = "在 exe 同级目录下没有找到 config.xml";
        
        public const string NoConfig = "在文件夹中没有找到没有找到 config.xml";
        public const string NoImage = "在文件夹中没有找到没有找到任何图片";
        public const string ParseXmlFail = "读取 xml 错误，请检查是否有格式错误";
        public const string RegexMatchFail = "正则表达式解析错误，请检查 xml 中球员 id 相关格式，建议从示例文档里复制";
        #endregion
    }
}