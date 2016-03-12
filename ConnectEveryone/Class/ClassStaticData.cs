using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectEveryone
{
    class ClassStaticData
    {
        //当前版本分支
        private static string _visionBranch;
        //当前版本号
        private static string _visionNum;
        //配置文件存放文件夹
        private static string _pathConfigDir;
        //配置文件所在目录
        private static string _pathConfigXml;
        //历史主机列表文件夹
        private static string _pathHisListDir;
        //用户昵称
        private static string _userNickName;
        //用户IP地址
        private static string _userIP;
        //在线用户列表
        private static Dictionary<string, string> _onlineHost = new Dictionary<string, string>();
        //服务器地址
        private static string _hostUrl;
        //用户分享文件列表
        private static ArrayList _userShareList = new ArrayList();
        //分享文件配置文件地址
        private static string _userShareConfig;
        //全网文件列表
        private static Hashtable _allFileList = new Hashtable();
        //我的文件列表
        private static ArrayList _myFileList = new ArrayList();


        public static string PathConfigDir
        {
            get
            {
                return _pathConfigDir;
            }

            set
            {
                _pathConfigDir = value;
            }
        }

        public static string PathConfigXml
        {
            get
            {
                return _pathConfigXml;
            }

            set
            {
                _pathConfigXml = value;
            }
        }

        public static string PathHisListDir
        {
            get
            {
                return _pathHisListDir;
            }

            set
            {
                _pathHisListDir = value;
            }
        }

        public static string UserNickName
        {
            get
            {
                return _userNickName;
            }

            set
            {
                _userNickName = value;
            }
        }

        public static string UserIP
        {
            get
            {
                return _userIP;
            }

            set
            {
                _userIP = value;
            }
        }

        public static Dictionary<string, string> OnlineHost
        {
            get
            {
                return _onlineHost;
            }

            set
            {
                _onlineHost = value;
            }
        }

        public static string VisionBranch
        {
            get
            {
                return _visionBranch;
            }

            set
            {
                _visionBranch = value;
            }
        }

        public static string VisionNum
        {
            get
            {
                return _visionNum;
            }

            set
            {
                _visionNum = value;
            }
        }

        public static string HostUrl
        {
            get
            {
                return _hostUrl;
            }

            set
            {
                _hostUrl = value;
            }
        }

        public static ArrayList UserShareList
        {
            get
            {
                return _userShareList;
            }

            set
            {
                _userShareList = value;
            }
        }

        public static string UserShareConfig
        {
            get
            {
                return _userShareConfig;
            }

            set
            {
                _userShareConfig = value;
            }
        }


        public static ArrayList MyFileList
        {
            get
            {
                return _myFileList;
            }

            set
            {
                _myFileList = value;
            }
        }



        public static Hashtable AllFileList
        {
            get
            {
                return _allFileList;
            }

            set
            {
                _allFileList = value;
            }
        }
    }
}
